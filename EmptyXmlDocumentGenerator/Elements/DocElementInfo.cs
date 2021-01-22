using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// doc 要素の情報を格納します。
    /// </summary>
    public class DocElementInfo : IXElementConvertable
    {
        private readonly AssemblyElementInfo assembly;
        private readonly MembersElementInfo members;

        /// <summary>
        /// <see cref="DocElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="excludeTypePatterns"></param>
        public DocElementInfo(Assembly assembly, IEnumerable<string> excludeTypePatterns)
        {
            this.assembly = new AssemblyElementInfo(assembly);
            members = new MembersElementInfo(assembly, excludeTypePatterns);
        }

        public DocElementInfo(XDocument document)
        {
            throw new NotImplementedException();
        }

        public void Merge(DocElementInfo mergeBase)
        {
            throw new NotImplementedException();
        }

        public XElement ToXElement() => new XElement("doc",
            assembly.ToXElement(),
            members.ToXElement());
    }
}
