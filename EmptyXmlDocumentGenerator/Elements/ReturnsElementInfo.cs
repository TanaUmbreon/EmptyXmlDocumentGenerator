using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// returns 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq}>{content,nq}</{ElementName,nq}>")]
    public class ReturnsElementInfo : IXElementConvertable
    {
        public const string ElementName = "returns";
        private readonly IEnumerable<XNode> nodes;

        /// <summary>
        /// <see cref="ReturnsElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        public ReturnsElementInfo()
        {
            nodes = XNodeHelper.EmptyNodes;
        }

        public ReturnsElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }
            nodes = XNodeHelper.IsEmptyNodes(element.Nodes()) ? XNodeHelper.EmptyNodes : element.Nodes();
        }

        public XElement ToXElement() => new XElement(ElementName, nodes);
    }
}
