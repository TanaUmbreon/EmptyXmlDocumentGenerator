using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// members 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>...</{ElementName,nq}>")]
    public class MembersElementInfo : IXElementConvertable
    {
        public const string ElementName = "members";
        private readonly List<MemberElementInfo> members;

        /// <summary>
        /// <see cref="MembersElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="excludeTypePatterns"></param>
        /// <param name="includeTypePatterns"></param>
        public MembersElementInfo(Assembly assembly, IEnumerable<string> excludeTypePatterns, IEnumerable<string> includeTypePatterns)
        {
            members = new List<MemberElementInfo>();

            var excludes = excludeTypePatterns.Any() ? excludeTypePatterns.Select(p => new Regex(p)) : null;
            var includes = includeTypePatterns.Any() ? includeTypePatterns.Select(p => new Regex(p)) : null;

            foreach (Type t in assembly.DefinedTypes.Where(t => t.IsPublic).OrderBy(t => t.Namespace).OrderBy(t=> t.FullName))
            {
                AddMember(t, excludes, includes);
            }
        }

        private void AddMember(Type t, IEnumerable<Regex>? excludes, IEnumerable<Regex>? includes)
        {
            if ((excludes != null) && IsExclude(t, excludes)) { return; }
            if ((includes != null) && !IsInclude(t, includes)) { return; }
            members.Add(new MemberElementInfo(t));

            foreach (var @event in t.GetRuntimeEvents().OrderBy(e => e.Name))
            {
                if (IsExclude(@event, t)) { continue; }
                members.Add(new MemberElementInfo(@event));
            }

            foreach (var field in t.GetRuntimeFields().OrderBy(f => f.Name))
            {
                if (IsExclude(field, t)) { continue; }
                members.Add(new MemberElementInfo(field));
            }

            foreach (var constructor in t.GetConstructors().OrderBy(c => c.Name))
            {
                if (IsExclude(constructor, t)) { continue; }
                members.Add(new MemberElementInfo(constructor));
            }

            foreach (var method in t.GetRuntimeMethods().OrderBy(m => m.Name))
            {
                if (IsExclude(method, t)) { continue; }
                members.Add(new MemberElementInfo(method));
            }

            foreach (var property in t.GetRuntimeProperties().OrderBy(p => p.Name))
            {
                if (IsExclude(property, t)) { continue; }
                members.Add(new MemberElementInfo(property));
            }

            foreach (Type nestedType in t.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (nestedType.IsNestedPrivate || nestedType.IsNestedFamANDAssem || nestedType.IsNestedAssembly) { continue; }
                AddMember(nestedType, excludes, includes);
            }
        }

        /// <summary>
        /// 指定した型が member 要素への追加から除外することを示します。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="excludePatterns"></param>
        /// <returns></returns>
        private bool IsExclude(Type type, IEnumerable<Regex> excludePatterns)
        {
            if (excludePatterns.Any(p => p.IsMatch(type.FullName?.Replace("+", ".")))) { return true; }

            if (type.IsNested)
            {
                if (type.IsNestedAssembly) { return true; }
                if (type.IsNestedPrivate) { return true; }
            }
            else
            {
                if (type.IsNotPublic) { return true; }
            }

            return false;
        }

        /// <summary>
        /// 指定した型が member 要素への追加に含めることを示します。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="includePatterns"></param>
        /// <returns></returns>
        private bool IsInclude(Type type, IEnumerable<Regex> includePatterns)
        {
            if (type.IsNested)
            {
                if (type.IsNestedAssembly) { return false; }
                if (type.IsNestedPrivate) { return false; }
            }
            else
            {
                if (type.IsNotPublic) { return false; }
            }

            return includePatterns.Any(p => p.IsMatch(type.FullName?.Replace("+", ".")));
        }

        private bool IsExclude(EventInfo @event, Type declaringType)
        {
            // アクセス修飾子がprivate, internalは除外する
            if (@event.AddMethod?.IsPrivate ?? true) { return true; }
            if (@event.AddMethod?.IsAssembly ?? true) { return true; }

            // 継承されたメンバーの場合は除外する
            if (@event.DeclaringType != declaringType) { return true; }

            return false;
        }

        private bool IsExclude(FieldInfo field, Type declaringType)
        {
            if (field.IsPrivate) { return true; }
            if (field.IsAssembly) { return true; }

            // 自動生成される特殊な名前のフィールドは除外する
            if (field.IsSpecialName) { return true; }

            if (field.DeclaringType != declaringType) { return true; }

            return false;
        }

        private bool IsExclude(MethodBase method, Type declaringType)
        {
            if (method.IsPrivate) { return true; }
            if (method.IsAssembly) { return true; }

            // コンストラクタ以外の特殊メソッド(イベントハンドラのadd/remove、プロパティのset/getメソッド等)を除外する
            if (method.IsSpecialName && !method.IsConstructor) { return true; }

            if (method.DeclaringType != declaringType) { return true; }

            return false;
        }

        private bool IsExclude(PropertyInfo property, Type declaringType)
        {
#pragma warning disable CS8602
            bool isInvisibleGet = (!property.CanRead) || (property.GetMethod.IsPrivate) || (property.GetMethod.IsAssembly);
            bool isInvisibleSet = (!property.CanWrite) || (property.SetMethod.IsPrivate) || (property.SetMethod.IsAssembly);
#pragma warning restore CS8602
            if (isInvisibleGet && isInvisibleSet) { return true; }

            if (property.DeclaringType != declaringType) { return true; }

            return false;
        }

        public MembersElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }

            members = new List<MemberElementInfo>();

            foreach (var child in element.Elements(MemberElementInfo.ElementName))
            {
                members.Add(new MemberElementInfo(child));
            }
        }

        public XElement ToXElement() => new XElement(ElementName, members.Select(m => m.ToXElement()));

        internal void Merge(MembersElementInfo mergeBase)
        {
            var baseMembers = new Dictionary<string, MemberElementInfo>();
            foreach (var baseMember in mergeBase.members)
            {
                baseMembers.TryAdd(baseMember.Name, baseMember);
            }
            foreach (var (member, index) in new List<MemberElementInfo>(members).Select((m, i) => (m,i)))
            {
                if (!baseMembers.ContainsKey(member.Name)) { continue; }
                
                MemberElementInfo baseMember = baseMembers[member.Name];
                baseMembers.Remove(member.Name);
                members[index] = baseMember;
            }
        }
    }
}
