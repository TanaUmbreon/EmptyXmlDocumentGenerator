using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// member 要素の情報を格納します。
    /// </summary>
    public class MemberInfo : IXElementBuilder
    {
        private readonly string name;
        private readonly SummaryInfo summary;
        private readonly List<TypeparamInfo>? typeparams;
        //private readonly List<ParamInfo>? parameters;
        //private readonly ReturnsInfo? returns;

        /// <summary>
        /// <see cref="MemberInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="type"></param>
        public MemberInfo(Type type)
        {
            name = GetNamePrefix(type) + (type.FullName ?? "");
            summary = new SummaryInfo();
            if (type.IsGenericType)
            {
                typeparams = new List<TypeparamInfo>();
                foreach (Type genericArgument in type.GetGenericArguments())
                {
                    typeparams.Add(new TypeparamInfo(genericArgument));
                }
            }
        }

        private string GetNamePrefix(Type type)
        {
            if (type.IsClass || type.IsValueType || type.IsInterface) { return "T:"; }
            return "?:";
        }

        public XElement Build()
        {
            var elements = new List<IXElementBuilder>();
            elements.Add(summary);
            if (typeparams != null)
            {
                elements.AddRange(typeparams);
            }

            return new XElement("member", 
                new XAttribute("name", name),
                elements.Select(e => e.Build()));
        }
    }
}
