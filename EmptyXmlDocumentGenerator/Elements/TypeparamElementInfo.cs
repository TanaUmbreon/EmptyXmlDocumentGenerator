using System;
using System.Collections.Generic;
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
        private readonly IEnumerable<XNode> nodes;

        /// <summary>
        /// <see cref="TypeparamElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public TypeparamElementInfo(Type type)
        {
            name = type.Name;
            nodes = XNodeHelper.EmptyNodes;
        }

        public TypeparamElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }
            var attribute = element.Attribute(NameAttributeName);
            if (attribute == null) { throw new InvalidCastException(); }
            name = attribute.Value;
            nodes = XNodeHelper.IsEmptyNodes(element.Nodes()) ? XNodeHelper.EmptyNodes : element.Nodes();
        }

        public XElement ToXElement() => new XElement(ElementName, 
            new XAttribute(NameAttributeName, name),
            nodes);
    }
}