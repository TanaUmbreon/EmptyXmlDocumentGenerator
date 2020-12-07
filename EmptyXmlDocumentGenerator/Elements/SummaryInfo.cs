using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// summary 要素の情報を格納します。
    /// </summary>
    public class SummaryInfo : IXElementBuilder
    {
        /// <summary>
        /// <see cref="SummaryInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public SummaryInfo() { }

        public XElement Build() => new XElement("summary", "");
    }
}
