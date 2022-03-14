using System;
using System.Collections.Generic;
using Unit = System.ValueTuple;

namespace LaYumba.Functional
{
    using static F;

    public static partial class F
    {
        public static Validation<T> Valid<T>(T value) => new Validation<T>(value);

        // create a Validation in the Invalid state
        public static Validation.Invalid Invalid(params Error[] errors) => new Validation.Invalid(errors);
        public static Validation<R> Invalid<R>(params Error[] errors) => new Validation.Invalid(errors);
        public static Validation.Invalid Invalid(IEnumerable<Error> errors) => new Validation.Invalid(errors);
        public static Validation<R> Invalid<R>(IEnumerable<Error> errors) => new Validation.Invalid(errors);
    }


    public struct Validation<T>
    {
        internal IEnumerable<Error> Errors { get; }
        internal T Value { get; }

        public bool IsValid { get; }

        // the Return function for Validation
        public static Func<T, Validation<T>> Return = t => Valid(t);

        public static Validation<T> Fail(IEnumerable<Error> errors)
            => new Validation<T>(errors);

        public static Validation<T> Fail(params Error[] errors)
            => new Validation<T>(errors.AsEnumerable());

        private Validation(IEnumerable<Error> errors)
        {
            IsValid = false;
            Errors = errors;
            Value = default(T);
        }

        internal Validation(T right)
        {
            IsValid = true;
            Value = right;
            Errors = Enumerable.Empty<Error>();
        }

        public static implicit operator Validation<T>(Error error) 
            => new Validation<T>(new [] { error });
        public static implicit operator Validation<T>(Validation.Invalid left) 
            => new Validation<T>(left.Errors);
        public static implicit operator Validation<T>(T right) => Valid(right);

    }

    public static class Validation
    {
        public struct Invalid
        {
            internal IEnumerable<Error> Errors;

            public Invalid(IEnumerable<Error> errors)
            {
                Errors = errors;
            }
        }

        public static Validation<RR> Map<R, RR>(this Validation<R> @this, Func<R, RR> f)
            => @this.IsValid
                ? Valid(f(@this.Value))
                : Invalid(@this.Errors);
    }
}