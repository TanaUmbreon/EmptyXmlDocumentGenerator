using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// members 要素の情報を格納します。
    /// </summary>
    public class MembersElementInfo : IXElementConvertable
    {
        private readonly List<MemberElementInfo> members;

        /// <summary>
        /// <see cref="MembersElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="excludeTypePatterns"></param>
        public MembersElementInfo(Assembly assembly, IEnumerable<string> excludeTypePatterns)
        {
            members = new List<MemberElementInfo>();

            var patterns = excludeTypePatterns.Select(p => new Regex(p));

            foreach (Type t in assembly.DefinedTypes.OrderBy(t => t.Namespace).OrderBy(t=> t.FullName))
            {
                if (IsExclude(t, patterns)) { continue; }
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
            if (method.IsSpecialName) { return true; }

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

        public XElement ToXElement() => new XElement("members", members.Select(m => m.ToXElement()));
    }
}
