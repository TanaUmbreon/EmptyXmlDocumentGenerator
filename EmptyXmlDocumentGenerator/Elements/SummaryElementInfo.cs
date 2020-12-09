using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// summary 要素の情報を格納します。
    /// </summary>
    public class SummaryElementInfo : IXElementBuilder
    {
        /// <summary>
        /// <see cref="SummaryElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public SummaryElementInfo() { }

        public XElement Build() => new XElement("summary", "");
    }
}
