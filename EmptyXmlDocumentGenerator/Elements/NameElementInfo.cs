using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// name 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>{Content,nq}</{ElementName,nq}>")]
    public class NameElementInfo : IXElementConvertable
    {
        public const string ElementName = "name";

        public string Content { get; private set; }

        /// <summary>
        /// <see cref="NameElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="content">要素のコンテンツ。</param>
        public NameElementInfo(string content)
        {
            Content = content;
        }

        public NameElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }

            Content = element.Value;
        }

        public XElement ToXElement() => new XElement(ElementName, Content);
    }
}
