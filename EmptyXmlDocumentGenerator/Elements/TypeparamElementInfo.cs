using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// typeparam 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq} {NameAttributeName,nq}={name}>{content,nq}</{ElementName,nq}>")]
    public class TypeparamElementInfo : IXElementConvertable
    {
        public const string ElementName = "typeparam";
        private const string NameAttributeName = "name";
        private readonly string name;
        private readonly string content;

        /// <summary>
        /// <see cref="TypeparamElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public TypeparamElementInfo(Type type)
        {
            name = type.Name;
            content = "";
        }

        public TypeparamElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }
            var attribute = element.Attribute(NameAttributeName);
            if (attribute == null) { throw new InvalidCastException(); }
            name = attribute.Value;
            content = element.Value;
        }

        public XElement ToXElement() => new XElement(ElementName, 
            new XAttribute(NameAttributeName, name),
            content);
    }
}