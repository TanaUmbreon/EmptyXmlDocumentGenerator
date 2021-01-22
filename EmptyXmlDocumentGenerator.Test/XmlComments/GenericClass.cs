#pragma warning disable CS0067
#pragma warning disable CS0169
#pragma warning disable CS0649
#pragma warning disable CS8603
#pragma warning disable CS8618
#pragma warning disable IDE0044
#pragma warning disable IDE0051
#pragma warning disable IDE0060

using System;
using System.Collections.Generic;

namespace EmptyXmlDocumentGenerator.Test.XmlComments
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class GenericClass<T, T2>
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
        public IList<T> genericField;
    
        internal T internalField;
        
        /// <summary></summary>
        internal protected T internalProtectedField;

        /// <summary></summary>
        public int? nullableField;

        private T privateField;

        /// <summary></summary>
        protected T protectedField;
        
        /// <summary></summary>
        public T publicField;

        /// <summary></summary>
        public readonly T readonlyField;

        /// <summary></summary>
        public static T staticField;

        #endregion

        #region M:メソッド・コンストラクタ

        private GenericClass(string arg1) { }

        /// <summary></summary>
        public GenericClass() { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        public GenericClass(T arg1) { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        public GenericClass(int arg1) { }

        /// <summary></summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public GenericClass(T2 arg1, T arg2) { }

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
        /// <typeparam name="T1"></typeparam>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public T GenericMethod1<T1>(T1 arg1, int arg2) => default;

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
        public T GenericMethod3<T1, T3>(T1 arg1, T2 arg2, T3 arg3, T1 arg4) => default;

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
        public IList<T> GenericTypeProperty { get; set; }

        /// <summary></summary>
        public T GetOnlyProperty { get; }

        /// <summary></summary>
        public T GetSetProperty { get; set; }

        private T PrivateProperty { get; set; }

        /// <summary></summary>
        public T PrivateSetPublicGetProperty { get; private set; }

        /// <summary></summary>
        public T PublicSetPrivateGetProperty { private get; set; }

        /// <summary></summary>
        public T SetOnlyProperty { set { } }

        /// <summary></summary>
        public virtual T VirtualProperty { get; set; }

        #endregion
    }
}
