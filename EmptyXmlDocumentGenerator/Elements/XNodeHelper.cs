using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    public static class XNodeHelper
    {
        public static readonly IEnumerable<XNode> EmptyNodes = new[] { new XText("") };

        public static bool IsEmptyNodes(IEnumerable<XNode> nodes) => !nodes.Any();
    }
}
