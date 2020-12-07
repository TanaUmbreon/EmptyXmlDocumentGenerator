#pragma warning disable CS0067
#pragma warning disable CS0169
#pragma warning disable CS0649
#pragma warning disable CA1822
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
    /// public class PublicClass
    /// </summary>
    public class PublicClass
    {
        /// <summary>private int privateField</summary>
        private int privateField;
        /// <summary>protected int protectedField</summary>
        protected int protectedField;
        /// <summary>internal int internalField</summary>
        internal int internalField;
        /// <summary>internal protected int internalProtectedField</summary>
        internal protected int internalProtectedField;
        /// <summary>public int publicField</summary>
        public int publicField;

        /// <summary>private static int staticField</summary>
        private static int staticField;
        /// <summary>private readonly int readonlyField</summary>
        private readonly int readonlyField;
        /// <summary>private int? nullableField</summary>
        private int? nullableField;
        /// <summary>private IList&lt;int&gt; genericField</summary>
        private IList<int> genericField;

        /// <summary>
        /// private float GetSetProperty { get; set; }
        /// </summary>
        public float GetSetProperty { get; set; }

        /// <summary>
        /// public float GetOnlyProperty { get; }
        /// </summary>
        public float GetOnlyProperty { get; }

        /// <summary>
        /// public float SetOnlyProperty { set { } }
        /// </summary>
        public float SetOnlyProperty { set { } }

        /// <summary>
        /// public float PrivateSetPublicGetProperty { get; private set; }
        /// </summary>
        public float PrivateSetPublicGetProperty { get; private set; }

        /// <summary>
        /// public virtual float VirtualProperty { get; set; }
        /// </summary>
        public virtual float VirtualProperty { get; set; }

        /// <summary>
        /// private IList&lt;int&gt; GenericTypeProperty { get; set; }
        /// </summary>
        private IList<int> GenericTypeProperty { get; set; }

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
        /// public PublicClass()
        /// </summary>
        public PublicClass() { }

        /// <summary>
        /// public PublicClass(int arg1)
        /// </summary>
        /// <param name="arg1">int arg1</param>
        public PublicClass(int arg1) { }

        /// <summary>
        /// private PublicClass(string arg1)
        /// </summary>
        /// <param name="arg1">string arg1</param>
        private PublicClass(string arg1) { }

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
        /// public int OverloadMethod(int arg1, Exception arg2, IEnumerable&lt;DateTime&gt; arg3)
        /// </summary>
        /// <param name="arg1">int arg1</param>
        /// <param name="arg2">Exception arg2</param>
        /// <param name="arg3">IEnumerable&lt;DateTime&gt; arg3</param>
        /// <returns>returns int</returns>
        public int OverloadMethod(int arg1, Exception arg2, IEnumerable<DateTime> arg3) => 0;

        /// <summary>
        /// public T GenericMethod1&lt;T&gt;(T arg1, int arg2)
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="arg1">T arg1</param>
        /// <param name="arg2">int arg2</param>
        /// <returns>returns T</returns>
        public T GenericMethod1<T>(T arg1, int arg2) => default;

        /// <summary>
        /// public TReturns GenericMethod2&lt;TParam, TReturns&gt;(TParam arg1)
        /// </summary>
        /// <typeparam name="TParam">TParam</typeparam>
        /// <typeparam name="TReturns">TReturns</typeparam>
        /// <param name="arg1">TParam arg1</param>
        /// <returns>returns TReturns</returns>
        public TReturns GenericMethod2<TParam, TReturns>(TParam arg1) => default;

        /// <summary>
        /// public void WheredGenericMethod&lt;T&gt;(T arg1) where T : class
        /// </summary>
        /// <typeparam name="T">where T : class</typeparam>
        /// <param name="arg1">T arg1</param>
        public void WheredGenericMethod<T>(T arg1) where T : class { }
    }
}
