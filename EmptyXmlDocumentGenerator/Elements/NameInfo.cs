using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// name 要素の情報を格納します。
    /// </summary>
    public class NameInfo : IXElementBuilder
    {
        private readonly string content;

        /// <summary>
        /// <see cref="NameInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="content">要素のコンテンツ。</param>
        public NameInfo(string content)
        {
            this.content = content;
        }

        public XElement Build() => new XElement("name", content);
    }
}
