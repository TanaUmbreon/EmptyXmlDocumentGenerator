using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// returns 要素の情報を格納します。
    /// </summary>
    public class ReturnsInfo : IXElementBuilder
    {
        /// <summary>
        /// <see cref="ReturnsInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public ReturnsInfo() { }

        public XElement Build() => new XElement("returns", "");
    }
}
