using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// doc 要素の情報を格納します。
    /// </summary>
    public class DocElementInfo : IXElementBuilder
    {
        private readonly AssemblyElementInfo assembly;
        private readonly MembersElementInfo members;

        /// <summary>
        /// <see cref="DocElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        public DocElementInfo(Assembly assembly)
        {
            this.assembly = new AssemblyElementInfo(assembly);
            members = new MembersElementInfo(assembly);
        }

        public XElement Build() => new XElement("doc",
            assembly.Build(),
            members.Build());
    }
}
