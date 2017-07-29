using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 15;
            var expressionTree = new ExpressionTrees();
            var processor = new ExpressionProcessor();

            var factorial = expressionTree.Factorial;
            //long longResult = factorial.Compile()(number);
            long longResult = processor.Process(factorial, number);

            Console.Write("\n{0}! = [{1,0:N0}]\n", number, longResult);

            var lamda = expressionTree.ExpressionLamda;
            // bool boolResult = lamda.Compile()(number);
            bool boolResult = processor.Process(lamda, number);

            Console.Write("\nExpressionLamda({0}) = [{1}]\n", number, boolResult);

            Console.ReadKey();
        }
    }
}
