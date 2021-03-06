using System;
using FunctionalExtensions.Lambda;

namespace FunctionalExtensions.FluentOption
{
    public class Intermediate6<T1, T2, T3, T4, T5, T6> : IIntermediate6<T1, T2, T3, T4, T5, T6>
    {
        private readonly Func<Option<T1>> _f1;
        private readonly Func<Option<T2>> _f2;
        private readonly Func<Option<T3>> _f3;
        private readonly Func<Option<T4>> _f4;
        private readonly Func<Option<T5>> _f5;
        private readonly Func<Option<T6>> _f6;

        public Intermediate6(
            Func<Option<T1>> f1,
            Func<Option<T2>> f2,
            Func<Option<T3>> f3,
            Func<Option<T4>> f4,
            Func<Option<T5>> f5,
            Func<Option<T6>> f6)
        {
            _f1 = f1;
            _f2 = f2;
            _f3 = f3;
            _f4 = f4;
            _f5 = f5;
            _f6 = f6;
        }

        public Option<T6> Result()
        {
            return _f1()
                .Bind(x => _f2())
                .Bind(x => _f3())
                .Bind(x => _f4())
                .Bind(x => _f5())
                .Bind(x => _f6());
        }

        public IIntermediate1<TResult> Bind<TResult>(Func<T1, T2, T3, T4, T5, T6, Option<TResult>> selector)
        {
            var result = Fun.Create(() => _f1()
                .Bind(v1 => _f2()
                    .Bind(v2 => _f3()
                        .Bind(v3 => _f4()
                            .Bind(v4 => _f5()
                                .Bind(v5 => _f6()
                                    .Bind(v6 => selector(v1, v2, v3, v4, v5, v6))))))));

            return new Intermediate1<TResult>(result);
        }

        public IIntermediate1<TResult> Select<TResult>(Func<T1, T2, T3, T4, T5, T6, TResult> selector)
        {
            var result = Fun.Create(() => _f1()
                .Bind(v1 => _f2()
                    .Bind(v2 => _f3()
                        .Bind(v3 => _f4()
                            .Bind(v4 => _f5()
                                .Bind(v5 => _f6()
                                    .Select(v6 => selector(v1, v2, v3, v4, v5, v6))))))));

            return new Intermediate1<TResult>(result);
        }

        public IIntermediate7<T1, T2, T3, T4, T5, T6, TResult> From<TResult>(Func<Option<TResult>> f7)
        {
            return new Intermediate7<T1, T2, T3, T4, T5, T6, TResult>(_f1, _f2, _f3, _f4, _f5, _f6, f7);
        }
    }
}