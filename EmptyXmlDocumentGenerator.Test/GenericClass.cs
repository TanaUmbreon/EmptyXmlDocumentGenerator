#pragma warning disable CS0067
#pragma warning disable CS0169
#pragma warning disable CS0649
#pragma warning disable CS1072
#pragma warning disable CS8603
#pragma warning disable CS8618
#pragma warning disable IDE0044
#pragma warning disable IDE0051
#pragma warning disable IDE0060

using System;
using System.Collections.Generic;

namespace EmptyXmlDocumentGenerator.Test
{
    /// <summary>
    /// public class GenericClass&lt;T&gt;
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public class GenericClass<T>
    {
        /// <summary>private T privateField</summary>
        private T privateField;
        /// <summary>protected T protectedField</summary>
        protected T protectedField;
        /// <summary>internal T internalField</summary>
        internal T internalField;
        /// <summary>internal protected T internalProtectedField</summary>
        internal protected T internalProtectedField;
        /// <summary>public T publicField</summary>
        public T publicField;

        /// <summary>private static T staticField</summary>
        private static T staticField;
        /// <summary>private readonly T readonlyField</summary>
        private readonly T readonlyField;
        /// <summary>private int? nullableField</summary>
        private int? nullableField;
        /// <summary>private IList&lt;T&gt; genericField</summary>
        private IList<T> genericField;

        /// <summary>
        /// private T GetSetProperty { get; set; }
        /// </summary>
        public T GetSetProperty { get; set; }

        /// <summary>
        /// public T GetOnlyProperty { get; }
        /// </summary>
        public T GetOnlyProperty { get; }

        /// <summary>
        /// public T SetOnlyProperty { set { } }
        /// </summary>
        public T SetOnlyProperty { set { } }

        /// <summary>
        /// public T PrivateSetPublicGetProperty { get; private set; }
        /// </summary>
        public T PrivateSetPublicGetProperty { get; private set; }

        /// <summary>
        /// public virtual T VirtualProperty { get; set; }
        /// </summary>
        public virtual T VirtualProperty { get; set; }

        /// <summary>
        /// private IList&lt;T&gt; GenericTypeProperty { get; set; }
        /// </summary>
        private IList<T> GenericTypeProperty { get; set; }

        /// <summary>
        /// public event EventHandler NonGenericHandlerEvent
        /// </summary>
        public event EventHandler NonGenericHandlerEvent;

        /// <summary>
        /// public event EventHandler? NullableEvent
        /// </summary>
        public event EventHandler? NullableEvent;

        /// <summary>
        /// public event EventHandler&lt;AssemblyLoadEventArgs&gt; GenericHandlerEvent
        /// </summary>
        public event EventHandler<AssemblyLoadEventArgs> GenericHandlerEvent;

        /// <summary>
        /// public GenericClass()
        /// </summary>
        public GenericClass() { }

        /// <summary>
        /// public GenericClass(T arg1)
        /// </summary>
        /// <param name="arg1">T arg1</param>
        public GenericClass(T arg1) { }

        /// <summary>
        /// private GenericClass(string arg1)
        /// </summary>
        /// <param name="arg1">string arg1</param>
        private GenericClass(string arg1) { }

        /// <summary>
        /// public void VoidUnargumentableMethod()
        /// </summary>
        public void VoidUnargumentableMethod() { }

        /// <summary>
        /// public void VoidArgumentableMethod(DateTime arg1, object arg2, int arg3)
        /// </summary>
        /// <param name="arg1">DateTime arg1</param>
        /// <param name="arg2">object arg2</param>
        /// <param name="arg3">int arg3</param>
        public void VoidArgumentableMethod(DateTime arg1, object arg2, int arg3) { }

        /// <summary>
        /// public int ReturnsArgumentableMethod(DateTime arg1, object arg2, int arg3)
        /// </summary>
        /// <param name="arg1">DateTime arg1</param>
        /// <param name="arg2">object arg2</param>
        /// <param name="arg3">int arg3</param>
        /// <returns>returns int</returns>
        public int ReturnsArgumentableMethod(DateTime arg1, object arg2, int arg3) => 0;

        /// <summary>
        /// public void OptionalArgumentMethod(string arg1 = "")
        /// </summary>
        /// <param name="arg1">string arg1 = ""</param>
        public void OptionalArgumentMethod(string arg1 = "") { }

        /// <summary>
        /// public override string ToString()
        /// </summary>
        /// <returns>returns string</returns>
        public override string ToString() => base.ToString();

        /// <summary>
        /// public int? NullableReturnsArgumentableMethod(DateTime? arg1, object? arg2, int? arg3)
        /// </summary>
        /// <param name="arg1">DateTime? arg1</param>
        /// <param name="arg2">object? arg2</param>
        /// <param name="arg3">int? arg3</param>
        /// <returns>returns int?</returns>
        public int? NullableReturnsArgumentableMethod(DateTime? arg1, object? arg2, int? arg3) => 0;

        /// <summary>
        /// public DateTime? ArrayableArgumentMethod(params int[] args)
        /// </summary>
        /// <param name="args">params int[] args</param>
        /// <returns>returns DateTime?</returns>
        public DateTime? ArrayableArgumentMethod(params int[] args) => DateTime.MinValue;

        /// <summary>
        /// public virtual void VirtualMethod()
        /// </summary>
        public virtual void VirtualMethod() { }

        /// <summary>
        /// public int OverloadMethod()
        /// </summary>
        /// <returns>returns int</returns>
        public int OverloadMethod() => 0;

        /// <summary>
        /// public int OverloadMethod(int arg1)
        /// </summary>
        /// <param name="arg1">int arg1</param>
        /// <returns>returns int</returns>
        public int OverloadMethod(int arg1) => 0;

        /// <summary>
        /// public int OverloadMethod(int arg1, Exception arg2)
        /// </summary>
        /// <param name="arg1">int arg1</param>
        /// <param name="arg2">Exception arg2</param>
        /// <returns>returns int</returns>
        public int OverloadMethod(int arg1, Exception arg2) => 0;

        /// <summary>
        /// public int OverloadMethod(int arg1, Exception arg2, IEnumerable@lt;DateTime&gt; arg3)
        /// </summary>
        /// <param name="arg1">int arg1</param>
        /// <param name="arg2">Exception arg2</param>
        /// <param name="arg3">IEnumerable&lt;DateTime&gt; arg3</param>
        /// <returns>returns int</returns>
        public int OverloadMethod(int arg1, Exception arg2, IEnumerable<DateTime> arg3) => 0;

        /// <summary>
        /// public T GenericMethod1&lt;T1&gt;(T1 arg1, int arg2)
        /// </summary>
        /// <typeparam name="T1">T</typeparam>
        /// <param name="arg1">T1 arg1</param>
        /// <param name="arg2">int arg2</param>
        /// <returns>returns T</returns>
        public T GenericMethod1<T1>(T1 arg1, int arg2) => default;

        /// <summary>
        /// public TReturns GenericMethod2&lt;TParam, TReturns&gt;(TParam arg1)
        /// </summary>
        /// <typeparam name="TParam">TParam</typeparam>
        /// <typeparam name="TReturns">TReturns</typeparam>
        /// <param name="arg1">TParam arg1</param>
        /// <returns>returns TReturns</returns>
        public TReturns GenericMethod2<TParam, TReturns>(TParam arg1) => default;

        /// <summary>
        /// public void WheredGenericMethod&lt;T1&gt;(T1 arg1) where T1 : class
        /// </summary>
        /// <typeparam name="T1">where T1 : class</typeparam>
        /// <param name="arg1">T1 arg1</param>
        public void WheredGenericMethod<T1>(T1 arg1) where T1 : class { }
    }
}
