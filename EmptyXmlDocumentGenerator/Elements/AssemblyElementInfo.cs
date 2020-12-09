using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// assembly 要素の情報を格納します。
    /// </summary>
    public class AssemblyElementInfo : IXElementBuilder
    {
        private readonly NameElementInfo name;

        /// <summary>
        /// <see cref="AssemblyElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyElementInfo(Assembly assembly)
        {
            name = new NameElementInfo(Path.GetFileNameWithoutExtension(assembly.Location));
        }

        public XElement Build() => new XElement("assembly", name.Build());
    }
}
