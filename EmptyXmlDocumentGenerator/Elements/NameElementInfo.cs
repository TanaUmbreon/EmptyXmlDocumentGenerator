using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// name 要素の情報を格納します。
    /// </summary>
    public class NameElementInfo : IXElementConvertable
    {
        private readonly string content;

        /// <summary>
        /// <see cref="NameElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="content">要素のコンテンツ。</param>
        public NameElementInfo(string content)
        {
            this.content = content;
        }

        public XElement ToXElement() => new XElement("name", content);
    }
}
