using System;
using System.Linq.Expressions;

namespace ExpressionTrees
{
    public class ExpressionTrees
    {
        public Expression<Func<long, long>> Factorial
        {
            get
            {
                ParameterExpression value = Expression.Parameter(typeof(long), "value");
                ParameterExpression result = Expression.Parameter(typeof(long), "result");

                LabelTarget label = Expression.Label(typeof(long));

                BlockExpression block = Expression.Block(
                    new[] { result },
                    Expression.Assign(result, Expression.Constant(1L)),
                    Expression.Loop(
                        Expression.IfThenElse(
                            Expression.GreaterThan(value, Expression.Constant(1L)),
                            Expression.MultiplyAssign(result, Expression.PostDecrementAssign(value)),
                            Expression.Break(label, result)
                        ),
                        label
                    )
                );

                return Expression.Lambda<Func<long, long>>(block, value);
            }
        }

        public Expression<Func<int, bool>> ExpressionLamda
        {
            get
            {
                Expression<Func<int, bool>> expressionTree = num => num < 5;

                return expressionTree;
            }
        }
    }
}
