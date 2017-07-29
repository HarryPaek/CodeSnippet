using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public class ExpressionProcessor
    {
        public TResult Process<T, TResult>(Expression<Func<T, TResult>> expression, T value)
        {
            var complied = expression.Compile();

            return complied(value);
        }
    }
}
