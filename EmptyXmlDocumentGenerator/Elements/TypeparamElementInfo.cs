using System;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// typeparam 要素の情報を格納します。
    /// </summary>
    public class TypeparamElementInfo : IXElementConvertable
    {
        private readonly string name;

        /// <summary>
        /// <see cref="TypeparamElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public TypeparamElementInfo(Type type)
        {
            name = type.Name;
        }

        public XElement Build() => new XElement("typeparam", 
            new XAttribute("name", name),
            "");
    }
}