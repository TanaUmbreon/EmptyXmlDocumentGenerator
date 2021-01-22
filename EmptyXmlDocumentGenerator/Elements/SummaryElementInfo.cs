using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// summary 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>{content,nq}</{ElementName,nq}>")]
    public class SummaryElementInfo : IXElementConvertable
    {
        public const string ElementName = "summary";
        private readonly string content;

        /// <summary>
        /// <see cref="SummaryElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public SummaryElementInfo() 
        {
            content = "";
        }

        public SummaryElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }
            content = element.Value;
        }

        public XElement ToXElement() => new XElement(ElementName, content);
    }
}
