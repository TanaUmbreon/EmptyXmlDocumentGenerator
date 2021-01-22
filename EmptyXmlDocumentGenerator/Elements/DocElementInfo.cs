using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// doc 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>...</{ElementName,nq}>")]
    public class DocElementInfo : IXElementConvertable
    {
        public const string ElementName = "doc";

        public AssemblyElementInfo Assembly { get; private set; }
        public MembersElementInfo Members { get; private set; }

        /// <summary>
        /// <see cref="DocElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="excludeTypePatterns"></param>
        public DocElementInfo(Assembly assembly, IEnumerable<string> excludeTypePatterns)
        {
            Assembly = new AssemblyElementInfo(assembly);
            Members = new MembersElementInfo(assembly, excludeTypePatterns);
        }

        public DocElementInfo(XDocument document)
        {
            XElement element = document.Root;
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }

            Assembly = new AssemblyElementInfo(element.Element(AssemblyElementInfo.ElementName));
            Members = new MembersElementInfo(element.Element(MembersElementInfo.ElementName));
        }

        public void Merge(DocElementInfo mergeBase)
        {
            if (Assembly.Name.Content != mergeBase.Assembly.Name.Content)
            {
                throw new InvalidOperationException($"アセンブリ名が異なるためマージできません。(--Target: {Assembly.Name.Content}, --MergeBase: {mergeBase.Assembly.Name.Content}");
            }
            Members.Merge(mergeBase.Members);
        }

        public XElement ToXElement() => new XElement(ElementName,
            Assembly.ToXElement(),
            Members.ToXElement());
    }
}
