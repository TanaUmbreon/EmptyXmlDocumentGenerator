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
    /// <summary></summary>
    public class PublicClass
    {
        #region E:イベント

        /// <summary></summary>
        public event EventHandler<AssemblyLoadEventArgs> GenericHandlerEvent;

        internal event EventHandler InternalEvent;

        /// <summary></summary>
        public event EventHandler NonGenericHandlerEvent;

        /// <summary></summary>
        public event EventHandler? NullableEvent;

        private event EventHandler PrivateEvent;

        /// <summary></summary>
        protected event EventHandler ProtectedEvent;

        /// <summary></summary>
        protected internal event EventHandler ProtectedInternalEvent;

        #endregion

        #region F:フィールド

        /// <summary></summary>
        public IList<int> genericField;

        internal int internalField;

        /// <summary></summary>
        internal protected int internalProtectedField;

        /// <summary></summary>
        public int? nullableField;

        private int privateField;
 
        /// <summary></summary>
        protected int protectedField;
       
        /// <summary></summary>
        public int publicField;
       
        /// <summary></summary>
        public readonly int readonlyField;

        /// <summary></summary>
        public static int staticField;

        #endregion

        #region M:メソッド・コンストラクタ

        private PublicClass(string arg1) { }

        /// <summary></summary>
        public PublicClass() { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        public PublicClass(int arg1) { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        public PublicClass(float arg1) { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public PublicClass(int arg1, float arg2, Func<int, string> arg3) { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void ArgumentMethod(DateTime arg1, object arg2, int arg3) { }

        /// <summary></summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DateTime? ArrayableArgumentMethod(params int[] args) => DateTime.MinValue;

        /// <summary></summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public T GenericMethod1<T>(T arg1, int arg2) => default;

        /// <summary></summary>
        /// <typeparam name="TParam"></typeparam>
        /// <typeparam name="TReturns"></typeparam>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public TReturns GenericMethod2<TParam, TReturns>(TParam arg1) => default;

        /// <summary></summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <returns></returns>
        public T1 GenericMethod3<T1, T3>(T1 arg1, IEnumerable<IEnumerable<int>> arg2, T3 arg3, T1 arg4) => default;

        internal void InternalMethod() { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public int? NullableReturnsArgumentableMethod(DateTime? arg1, object? arg2, int? arg3) => 0;

        /// <summary></summary>
        /// <param name="arg1"></param>
        public void OptionalArgumentMethod(string arg1 = "") { }

        /// <summary></summary>
        /// <returns></returns>
        public int OverloadMethod() => 0;

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public int OverloadMethod(int arg1) => 0;

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public int OverloadMethod(int arg1, Exception arg2) => 0;

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public int OverloadMethod(int arg1, Exception arg2, IEnumerable<DateTime> arg3) => 0;

        /// <summary></summary>
        protected internal void ProtectedInternalMethod() { }

        /// <summary></summary>
        protected void ProtectedMethod() { }

        private void PrivateMethod() { }

        /// <summary></summary>
        public void PublicMethod() { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public int ReturnsAndArgumentMethod(DateTime arg1, object arg2, int arg3) => 0;

        /// <summary></summary>
        /// <returns></returns>
        public override string ToString() => base.ToString();

        /// <summary></summary>
        public virtual void VirtualMethod() { }

        /// <summary></summary>
        public void VoidMethod() { }

        /// <summary></summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="arg1"></param>
        public void WheredGenericMethod<T1>(T1 arg1) where T1 : class { }

        #endregion

        #region P:プロパティ

        /// <summary></summary>
        public IList<int> GenericTypeProperty { get; set; }

        /// <summary></summary>
        public float GetOnlyProperty { get; }

        /// <summary></summary>
        public float GetSetProperty { get; set; }

        private float PrivateProperty { get; set; }

        /// <summary></summary>
        public float PrivateSetPublicGetProperty { get; private set; }

        /// <summary></summary>
        public int PublicSetPrivateGetProperty { private get; set; }

        /// <summary></summary>
        public float SetOnlyProperty { set { } }

        /// <summary></summary>
        public virtual float VirtualProperty { get; set; }

        #endregion
    }
}
