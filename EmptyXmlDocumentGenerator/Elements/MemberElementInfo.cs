using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// member 要素の情報を格納します。
    /// </summary>
    public class MemberElementInfo : IXElementBuilder
    {
        private readonly string name;

        private readonly SummaryElementInfo summary;
        private readonly List<TypeparamElementInfo> typeparams;
        private readonly List<ParamElementInfo> parameters;
        private readonly ReturnsElementInfo? returns;

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="member"></param>
        public MemberElementInfo(MemberInfo member)
        {
            name = GetFullName(member);
            summary = new SummaryElementInfo();
            typeparams = new List<TypeparamElementInfo>();
            parameters = new List<ParamElementInfo>();
            returns = null;

            if (member is Type type && type.IsGenericType)
            {
                typeparams.AddRange(type.GetGenericArguments().Select(a => new TypeparamElementInfo(a)));
            }

            if (member is MethodInfo method)
            {
                typeparams.AddRange(method.GetGenericArguments().Select(a => new TypeparamElementInfo(a)));
                parameters.AddRange(method.GetParameters().Select(p => new ParamElementInfo(p)));
                if (method.ReturnType != typeof(void))
                {
                    returns = new ReturnsElementInfo();
                }
            }

            if (member is ConstructorInfo constructor)
            {
                parameters.AddRange(constructor.GetParameters().Select(p => new ParamElementInfo(p)));
            }
        }

        private string GetFullName(MemberInfo member)
        {
            return member switch
            {
                Type t => "T:" + t.FullName ?? "",
                EventInfo e => "E:" + GetTypeName(e) + e.Name,
                FieldInfo f => "F:" + GetTypeName(f) + f.Name,
                MethodInfo m => "M:" + GetTypeName(m) + GetName(m) + GetParameters(m),
                ConstructorInfo c => "M:" + GetTypeName(c) + GetName(c) + GetParameters(c),
                PropertyInfo p => "P:" + GetTypeName(p) + p.Name,
                _ => $"?:{member.Name}",
            };
        }

        private string GetTypeName(MemberInfo member)
        {
            if (member.DeclaringType == null) { return ""; }
            return member.DeclaringType.FullName + ".";
        }

        private string GetName(MethodBase method)
        {
            if (method.IsConstructor) { return method.Name.Replace('.', '#'); }
            if (method.IsGenericMethod) { return method.Name + "``" + method.GetGenericArguments().Length; }
            return method.Name;
        }

        private string GetParameters(MethodBase method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length <= 0) { return ""; }

            return "(" + string.Join(',', parameters.Select(p => ToParameterString(p))) + ")";
        }

        private string ToParameterString(ParameterInfo parameter)
        {
            Type parameterType = parameter.ParameterType;

            if (parameterType.IsGenericTypeParameter)
            {
                return "`" + parameterType.GenericParameterPosition;
            }
            if (parameterType.IsGenericMethodParameter)
            {
                return "``" + parameterType.GenericParameterPosition;
            }
            if (parameterType.IsGenericType)
            {
                // TODO: ジェネリック型の場合のパラメータ出力パターンを実装する。
            }

            return parameterType.FullName ?? "";
        }

        public XElement Build()
        {
            var elements = new List<IXElementBuilder> { summary };
            elements.AddRange(typeparams);
            elements.AddRange(parameters);
            if (returns != null)
            {
                elements.Add(returns);
            }

            return new XElement("member", 
                new XAttribute("name", name),
                elements.Select(e => e.Build()));
        }
    }
}
