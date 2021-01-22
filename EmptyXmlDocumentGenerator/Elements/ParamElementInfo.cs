using System.Xml.Linq;
using System.Reflection;
using System;
using System.Diagnostics;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// param 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq} {NameAttributeName,nq}={name}>{content,nq}</{ElementName,nq}>")]
    public class ParamElementInfo : IXElementConvertable
    {
        public const string ElementName = "param";
        private const string NameAttributeName = "name";
        private readonly string name;
        private readonly string content;

        /// <summary>
        /// <see cref="ParamElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="parameter"></param>
        public ParamElementInfo(ParameterInfo parameter)
        {
            name = parameter.Name ?? "";
            content = "";
        }

        public ParamElementInfo(XElement element)
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
