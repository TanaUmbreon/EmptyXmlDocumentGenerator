using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// members 要素の情報を格納します。
    /// </summary>
    public class MembersInfo : IXElementBuilder
    {
        private readonly List<MemberInfo> members;

        /// <summary>
        /// <see cref="MembersInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        public MembersInfo(Assembly assembly)
        {
            members = new List<MemberInfo>();

            foreach (Type t in assembly.GetTypes().Where(t => t.IsPublic))
            {
                members.Add(new MemberInfo(t));
            }
        }

        public XElement Build() => new XElement("members", members.Select(m => m.Build()));
    }
}
