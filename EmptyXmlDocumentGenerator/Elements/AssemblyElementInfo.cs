using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// assembly 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>...</{ElementName,nq}>")]
    public class AssemblyElementInfo : IXElementConvertable
    {
        public const string ElementName = "assembly";

        public NameElementInfo Name { get; private set; }

        /// <summary>
        /// <see cref="AssemblyElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="assembly"></param>
        public AssemblyElementInfo(Assembly assembly)
        {
            Name = new NameElementInfo(Path.GetFileNameWithoutExtension(assembly.Location));
        }

        public AssemblyElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }

            Name = new NameElementInfo(element.Element(NameElementInfo.ElementName));
        }

        public XElement ToXElement() => new XElement(ElementName, Name.ToXElement());
    }
}
