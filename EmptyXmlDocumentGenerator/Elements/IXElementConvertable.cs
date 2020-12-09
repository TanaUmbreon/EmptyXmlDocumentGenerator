using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// <see cref="XElement"/> に変換する機能を実装します。
    /// </summary>
    public interface IXElementConvertable
    {
        /// <summary>
        /// このインスタンスから、それと等価な <see cref="XElement"/> のインスタンスに変換します。
        /// </summary>
        /// <returns>このインスタンスと等価な <see cref="XElement"/> のインスタンス。</returns>
        XElement ToXElement();
    }
}