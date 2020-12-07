using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// doc 要素の情報を格納します。
    /// </summary>
    public class DocInfo : IXElementBuilder
    {
        private readonly AssemblyInfo assembly;
        private readonly MembersInfo members;

        /// <summary>
        /// <see cref="DocInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        public DocInfo(Assembly assembly)
        {
            this.assembly = new AssemblyInfo(assembly);
            members = new MembersInfo(assembly);
        }

        public XElement Build() => new XElement("doc",
            assembly.Build(),
            members.Build());
    }
}
