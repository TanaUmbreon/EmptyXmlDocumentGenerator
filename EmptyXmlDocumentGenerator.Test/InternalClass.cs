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
    internal class InternalClass
    {
        private int privateField;
        protected int protectedField;
        internal int internalField;
        internal protected int internalProtectedField;
        public int publicField;

        private static int staticField;
        private readonly int readonlyField;
        private int? nullableField;
        private IList<int> genericField;

        public float GetSetProperty { get; set; }
        public float GetOnlyProperty { get; }
        public float SetOnlyProperty { set { } }
        public float PrivateSetPublicGetProperty { get; private set; }
        public virtual float VirtualProperty { get; set; }
        private IList<int> GenericTypeProperty { get; set; }

        public event EventHandler NonGenericHandlerEvent;
        public event EventHandler? NullableEvent;
        public event EventHandler<AssemblyLoadEventArgs> GenericHandlerEvent;

        public InternalClass() { }
        public InternalClass(int arg1) { }
        private InternalClass(string arg1) { }

        public void VoidUnargumentableMethod() { }
        public void VoidArgumentableMethod(DateTime arg1, object arg2, int arg3) { }
        public int ReturnsArgumentableMethod(DateTime arg1, object arg2, int arg3) => 0;
        public void OptionalArgumentMethod(string arg1 = "") { }
        public override string ToString() => base.ToString();
        public int? NullableReturnsArgumentableMethod(DateTime? arg1, object? arg2, int? arg3) => 0;
        public DateTime? ArrayableArgumentMethod(params int[] args) => DateTime.MinValue;
        public virtual void VirtualMethod() { }
        public int OverloadMethod() => 0;
        public int OverloadMethod(int arg1) => 0;
        public int OverloadMethod(int arg1, Exception arg2) => 0;
        public int OverloadMethod(int arg1, Exception arg2, IEnumerable<DateTime> arg3) => 0;
        public T GenericMethod1<T>(T arg1, int arg2) => default;
        public TReturns GenericMethod2<TParam, TReturns>(TParam arg1) => default;
        public void WheredGenericMethod<T>(T arg1) where T : class { }
    }
}
