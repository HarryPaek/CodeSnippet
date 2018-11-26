
namespace BackToAlgorithms
{

    public class Frog
    {
        public static int NumberOfWays(int n)
        {
            int maxStep = n;
            int minStep = n/2 + n%2;
            int totalCase = maxStep - minStep;
            int totalWay = 0;
          
        
            for(int i = 0; i<= totalCase; i++) {
                totalWay += fac(minStep + i) / (fac(minStep - i) * fac(i));
            }

            return totalWay;
        }

        private static int fac(int num)
        {
            if (num < 2)
                return 1;

            return num * fac(num - 1);
        }
    }
}
