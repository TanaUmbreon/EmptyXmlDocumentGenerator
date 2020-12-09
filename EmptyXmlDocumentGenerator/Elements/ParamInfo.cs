using System.Xml.Linq;
using System.Reflection;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// param 要素の情報を格納します。
    /// </summary>
    public class ParamInfo : IXElementBuilder
    {
        private readonly string name;

        /// <summary>
        /// <see cref="ParamInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="parameter"></param>
        public ParamInfo(ParameterInfo parameter)
        {
            name = parameter.Name ?? "";
        }

        public XElement Build() => new XElement("param",
            new XAttribute("name", name),
            "");
    }
}
