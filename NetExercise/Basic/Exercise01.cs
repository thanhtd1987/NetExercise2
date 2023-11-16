using System;
namespace NetExercise.Basic
{
    public class Exercise01
    {
        public static int Ucln(int a, int b)
        {
            if (a < 0) a = -a;
            if (b < 0) a = -b;
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }

        public static int Bcnn(int a, int b)
        {
            return a * b / Ucln(a, b);
        }
    }

}
