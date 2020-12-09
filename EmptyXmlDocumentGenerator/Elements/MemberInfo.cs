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
    public class MemberInfo : IXElementBuilder
    {
        private readonly string name;

        private readonly SummaryInfo summary;
        private readonly List<TypeparamInfo> typeparams;
        private readonly List<ParamInfo> parameters;
        private readonly ReturnsInfo? returns;

        /// <summary>
        /// <see cref="MemberInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="member"></param>
        public MemberInfo(System.Reflection.MemberInfo member)
        {
            name = GetFullName(member);
            summary = new SummaryInfo();
            typeparams = new List<TypeparamInfo>();
            parameters = new List<ParamInfo>();
            returns = null;

            if (member is Type type && type.IsGenericType)
            {
                typeparams.AddRange(type.GetGenericArguments().Select(a => new TypeparamInfo(a)));
            }

            if (member is MethodInfo method)
            {
                typeparams.AddRange(method.GetGenericArguments().Select(a => new TypeparamInfo(a)));
                parameters.AddRange(method.GetParameters().Select(p => new ParamInfo(p)));
                if (method.ReturnType != typeof(void))
                {
                    returns = new ReturnsInfo();
                }
            }

            if (member is ConstructorInfo constructor)
            {
                parameters.AddRange(constructor.GetParameters().Select(p => new ParamInfo(p)));
            }
        }

        private string GetFullName(System.Reflection.MemberInfo member)
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

        private string GetTypeName(System.Reflection.MemberInfo member)
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
