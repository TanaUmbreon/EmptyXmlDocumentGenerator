using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// returns 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>{content,nq}</{ElementName,nq}>")]
    public class ReturnsElementInfo : IXElementConvertable
    {
        public const string ElementName = "returns";
        private readonly string content;

        /// <summary>
        /// <see cref="ReturnsElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public ReturnsElementInfo()
        {
            content = "";
        }

        public ReturnsElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }
            content = element.Value;
        }

        public XElement ToXElement() => new XElement(ElementName, content);
    }
}
