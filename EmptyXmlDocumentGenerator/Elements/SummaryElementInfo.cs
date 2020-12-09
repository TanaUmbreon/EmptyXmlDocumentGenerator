using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// summary 要素の情報を格納します。
    /// </summary>
    public class SummaryElementInfo : IXElementConvertable
    {
        /// <summary>
        /// <see cref="SummaryElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public SummaryElementInfo() { }

        public XElement ToXElement() => new XElement("summary", "");
    }
}
