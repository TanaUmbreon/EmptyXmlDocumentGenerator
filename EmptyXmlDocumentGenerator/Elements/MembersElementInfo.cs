using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

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
        public MembersElementInfo(Assembly assembly)
        {
            members = new List<MemberElementInfo>();

            foreach (Type t in assembly.GetTypes().Where(t => t.IsPublic))
            {
                members.Add(new MemberElementInfo(t));

                foreach (var @event in t.GetRuntimeEvents().OrderBy(e => e.Name))
                {
                    // アクセス修飾子がprivate, internalは除外する
                    if (@event.AddMethod?.IsPrivate ?? true) { continue; }
                    if (@event.AddMethod?.IsAssembly ?? true) { continue; }

                    members.Add(new MemberElementInfo(@event));
                }

                foreach (var field in t.GetRuntimeFields().OrderBy(f => f.Name))
                {
                    if (field.IsPrivate) { continue; }
                    if (field.IsAssembly) { continue; }

                    members.Add(new MemberElementInfo(field));
                }

                foreach (var constructor in t.GetConstructors().OrderBy(c => c.Name))
                {
                    if (constructor.IsPrivate) { continue; }
                    if (constructor.IsAssembly) { continue; }

                    members.Add(new MemberElementInfo(constructor));
                }

                foreach (var method in t.GetRuntimeMethods().OrderBy(m => m.Name))
                {
                    if (method.IsPrivate) { continue; }
                    if (method.IsAssembly) { continue; }

                    // コンストラクタ以外の特殊メソッド(イベントハンドラのadd/remove、プロパティのset/getメソッド等)を除外する
                    if (method.IsSpecialName) { continue; }

                    // 継承されたメンバーの場合は除外する
                    if (!method.DeclaringType?.Equals(t) ?? false) { continue; }

                    members.Add(new MemberElementInfo(method));
                }

                foreach (var property in t.GetProperties().OrderBy(p => p.Name))
                {
                    // TODO: get/setメソッドを考慮したアクセス修飾子による無視を実装する。
                    //if (property.IsPrivate) { continue; }
                    //if (property.IsAssembly) { continue; }

                    members.Add(new MemberElementInfo(property));
                }
            }
        }

        public XElement Build() => new XElement("members", members.Select(m => m.Build()));
    }
}
