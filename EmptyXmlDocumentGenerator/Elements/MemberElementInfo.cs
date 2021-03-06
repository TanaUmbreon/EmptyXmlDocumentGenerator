﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace EmptyXmlDocumentGenerator.Elements
{
    /// <summary>
    /// member 要素の情報を格納します。
    /// </summary>
    [DebuggerDisplay("<{ElementName,nq} {NameAttributeName,nq}={Name}>...</{ElementName,nq}>")]
    public class MemberElementInfo : IXElementConvertable
    {
        public const string ElementName = "member";
        private const string NameAttributeName = "name";

        public string Name { get; private set; }

        private readonly SummaryElementInfo summary;
        private readonly IEnumerable<TypeparamElementInfo>? typeparams;
        private readonly IEnumerable<ParamElementInfo>? parameters;
        private readonly ReturnsElementInfo? returns;

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="type"></param>
        public MemberElementInfo(Type type)
        {
            Name = "T:" + type.FullName?.Replace("+", ".") ?? "";
            summary = new SummaryElementInfo();
            typeparams = type.GetGenericArguments().Select(a => new TypeparamElementInfo(a));
            parameters = null;
            returns = null;
        }

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="@event"></param>
        public MemberElementInfo(EventInfo @event)
        {
            Name = "E:" + GetDeclaringTypeName(@event) + @event.Name;
            summary = new SummaryElementInfo();
            typeparams = null;
            parameters = null;
            returns = null;
        }

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="field"></param>
        public MemberElementInfo(FieldInfo field)
        {
            Name = "F:" + GetDeclaringTypeName(field) + field.Name;
            summary = new SummaryElementInfo();
            typeparams = null;
            parameters = null;
            returns = null;
        }

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="constructor"></param>
        public MemberElementInfo(ConstructorInfo constructor)
        {
            Name = "M:" + GetDeclaringTypeName(constructor) + GetName(constructor) + GetArgumentFullString(constructor);
            summary = new SummaryElementInfo();
            typeparams = null;
            parameters = constructor.GetParameters().Select(p => new ParamElementInfo(p));
            returns = null;
        }

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="method"></param>
        public MemberElementInfo(MethodInfo method)
        {
            string name = method.Name;
            Name = "M:" + GetDeclaringTypeName(method) + GetName(method) + GetArgumentFullString(method);
            summary = new SummaryElementInfo();
            typeparams = method.GetGenericArguments().Select(a => new TypeparamElementInfo(a));
            parameters = method.GetParameters().Select(p => new ParamElementInfo(p));
            returns = method.ReturnType == typeof(void) ? null : new ReturnsElementInfo();
        }

        /// <summary>
        /// <see cref="MemberElementInfo"/> の新しいインスタンスを生成します。
        /// </summary>
        /// <param name="property"></param>
        public MemberElementInfo(PropertyInfo property)
        {
            Name = "P:" + GetDeclaringTypeName(property) + property.Name;
            summary = new SummaryElementInfo();
            typeparams = null;
            parameters = null;
            returns = null;
        }

        /// <summary>
        /// 指定したメンバーから、そのメンバーを宣言する型の完全修飾名を取得します。
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        private string GetDeclaringTypeName(MemberInfo member)
        {
            if (member.DeclaringType?.FullName == null) { return ""; }
            return member.DeclaringType.FullName.Replace("+", ".") + ".";
        }

        /// <summary>
        /// 指定したメソッドまたはコンストラクタの名前を取得します。
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private string GetName(MethodBase method)
        {
            if (method.IsConstructor) { return method.Name.Replace('.', '#'); }
            if (method.IsGenericMethod) { return method.Name + "``" + method.GetGenericArguments().Length; }
            return method.Name;
        }

        /// <summary>
        /// 指定したメソッドまたはコンストラクタの引数部全体を表す文字列を取得します。
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private string GetArgumentFullString(MethodBase method)
        {
            var parameters = method.GetParameters();
            if (parameters.Length <= 0) { return ""; }

            return "(" + GetArgumentsInnerString(parameters) + ")";
        }

        /// <summary>
        /// 指定したパラメータのコレクションから、
        /// メソッドまたはコンストラクタの引数部のかっこ内を表す文字列を取得します。
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string GetArgumentsInnerString(IEnumerable<ParameterInfo> parameters) =>
            string.Join(',', parameters.Select(p => GetArgumentString(p)));

        /// <summary>
        /// 指定したパラメータの型情報のコレクションから、
        /// メソッドまたはコンストラクタの引数部のかっこ内を表す文字列を取得します。
        /// </summary>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        private string GetArgumentsInnerString(IEnumerable<Type> parameterTypes) =>
            string.Join(',', parameterTypes.Select(t => GetArgumentString(t)));

        /// <summary>
        /// 指定したパラメータからメソッドまたはコンストラクタの引数部で使用する型情報を表す文字列を取得します。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private string GetArgumentString(ParameterInfo parameter) => 
            GetArgumentString(parameter.ParameterType);

        /// <summary>
        /// 指定したパラメータの型情報から
        /// メソッドまたはコンストラクタの引数部で使用する型情報を表す文字列を取得します。
        /// </summary>
        /// <param name="parameterType"></param>
        /// <returns></returns>
        private string GetArgumentString(Type parameterType)
        {
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
                return parameterType.Namespace + "." +
                    Regex.Replace(parameterType.Name, @"`\d+", "") +
                    "{" + GetArgumentsInnerString(parameterType.GetGenericArguments()) + "}";
            }

            // ジェネリクスな配列の場合
            if (parameterType.FullName is null)
            {
                // ToDo: "`0[]" や "``0[]" のように出力しないと XML ドキュメントとして認識しないが、その実装方法が未解決。 `parameterType.GenericParameterPosition` では例外がスローされる。

                //var info = parameterType.GetTypeInfo();
                //var member = info.DeclaredMembers.FirstOrDefault(m => m?.ReflectedType?.Name == parameterType.Name);
                return parameterType.Name;
            }

            // outパラメータは&→@に、ネストされた型へのアクセサは+→.に
            return parameterType.FullName?.Replace('&', '@')?.Replace('+', '.') ?? "";
        }

        public MemberElementInfo(XElement element)
        {
            if ((element == null) || (element.Name != ElementName)) { throw new InvalidCastException(); }
            var attribute = element.Attribute(NameAttributeName);
            if (attribute == null) { throw new InvalidCastException(); }
            summary = new SummaryElementInfo(element.Element(SummaryElementInfo.ElementName));
            typeparams = null;
            parameters = null;
            returns = null;
            Name = attribute.Value;

            if (element.Elements(TypeparamElementInfo.ElementName).Any())
            {
                typeparams = element.Elements(TypeparamElementInfo.ElementName).Select(e => new TypeparamElementInfo(e));
            }
            if (element.Elements(ParamElementInfo.ElementName).Any())
            {
                parameters = element.Elements(ParamElementInfo.ElementName).Select(e => new ParamElementInfo(e));
            }
            if (element.Element(ReturnsElementInfo.ElementName) != null)
            {
                returns = new ReturnsElementInfo(element.Element(ReturnsElementInfo.ElementName));
            }
        }

        public XElement ToXElement()
        {
            var elements = new List<IXElementConvertable> { summary };
            if (typeparams != null) { elements.AddRange(typeparams); }
            if (parameters != null) { elements.AddRange(parameters); }
            if (returns != null) { elements.Add(returns); }

            return new XElement(ElementName, 
                new XAttribute(NameAttributeName, Name),
                elements.Select(e => e.ToXElement()));
        }
    }
}
