using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// XML 要素を構築する機能を実装します。
    /// </summary>
    public interface IXElementBuilder
    {
        /// <summary>
        /// このインスタンスから、それと等価な <see cref="XElement"/> のインスタンスを構築します。
        /// </summary>
        /// <returns>このインスタンスと等価な <see cref="XElement"/> のインスタンス。</returns>
        XElement Build();
    }
}