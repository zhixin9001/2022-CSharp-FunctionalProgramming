using System;
using Unit = System.ValueTuple;

namespace LaYumba.Functional
{
    public static partial class F
    {
        public static Exceptional<T> Exceptional<T>(T value) => new Exceptional<T>(value);
    }

    public struct Exceptional<T>
    {
        internal Exception Ex { get; }
        internal T Value { get; }

        public bool Success => Ex == null;
        public bool Exception => Ex != null;

        internal Exceptional(Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex));
            Ex = ex;
            Value = default(T);
        }

        internal Exceptional(T right)
        {
            Value = right;
            Ex = null;
        }

        public static implicit operator Exceptional<T>(Exception left) => new Exceptional<T>(left);
        public static implicit operator Exceptional<T>(T right) => new Exceptional<T>(right);
    }
}