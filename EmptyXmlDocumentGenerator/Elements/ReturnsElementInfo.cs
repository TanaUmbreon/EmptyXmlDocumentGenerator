using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// returns 要素の情報を格納します。
    /// </summary>
    public class ReturnsElementInfo : IXElementConvertable
    {
        /// <summary>
        /// <see cref="ReturnsElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public ReturnsElementInfo() { }

        public XElement ToXElement() => new XElement("returns", "");
    }
}
