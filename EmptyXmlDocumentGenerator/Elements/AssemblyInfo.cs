using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// assembly 要素の情報を格納します。
    /// </summary>
    public class AssemblyInfo : IXElementBuilder
    {
        private readonly NameInfo name;

        /// <summary>
        /// <see cref="AssemblyInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyInfo(Assembly assembly)
        {
            name = new NameInfo(Path.GetFileNameWithoutExtension(assembly.Location));
        }

        public XElement Build() => new XElement("assembly", name.Build());
    }
}
