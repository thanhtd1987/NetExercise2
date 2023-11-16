using System;
using System.Collections;
using NetExercise.Basic;
namespace NetExercise.OPP
{
    /* 1. Implement Fraction class */
    public class Fraction : IComparable
    {
        public int A { get; private set; }
        public int B { get; private set; }

        public Fraction(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentException("B can not be zero");
            }
            A = a;
            B = b;
        }

        /* 2. Override == != Equals ToString GetHashCode */
        // override ==
        public static bool operator ==(Fraction obj1, Fraction obj2)
        {
            // check 2 object cung reference/ cung bi null
            if (ReferenceEquals(obj1, obj2))
                return true;

            // check 1 trong 2 object la null thi tra ve false
            if (obj1 is null || obj2 is null)
                return false;

            // so sanh gia tri cua 2 doi tuong
            return obj1.A == obj2.A && obj1.B == obj2.B;
        }

        // override !=
        public static bool operator !=(Fraction obj1, Fraction obj2)
        {
            return !(obj1 == obj2);
        }

        // override Equals
        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
            {
                return this.A == other.A && this.B == other.B;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // xor de ket hop 2 prop
            return A.GetHashCode() ^ B.GetHashCode();
        }

        public override string ToString()
        {
            return $"{A}/{B}";
        }

        /* 3. Don gian phan so */
        public void Minimal()
        {
            int ucln = Exercise01.Ucln(A, B);
            A /= ucln;
            B /= ucln;
        }

        public int CompareTo(object obj)
        {
            if (obj != null && obj is Fraction other)
            {
                return this < other ? -1 : this > other ? 1 : 0;
            }
            return 1;
        }

        /* 4. Implement toan tu + - * / */
        public static Fraction operator +(Fraction obj1, Fraction obj2)
        {
            int Bcnn = Exercise01.Bcnn(obj1.B, obj2.B);
            int a1 = obj1.A * (Bcnn / obj1.B);
            int a2 = obj2.A * (Bcnn / obj2.B);

            var result = new Fraction(a1 + a2, Bcnn);
            result.Minimal();

            return result;
        }

        public static Fraction operator -(Fraction obj1, Fraction obj2)
        {
            return obj1 + (new Fraction(-obj2.A, obj2.B));
        }

        public static Fraction operator *(Fraction obj1, Fraction obj2)
        {
            int multiA = obj1.A * obj2.A;
            int multiB = obj1.B * obj2.B;

            var result = new Fraction(multiA, multiB);
            result.Minimal();

            return result;
        }

        /* 6. implement toan tu ! , dao nguoc phan so */
        public static Fraction operator !(Fraction obj)
        {
            var fraction = new Fraction(obj.B, obj.A);
            fraction.Minimal();
            return fraction;
        }

        public static Fraction operator /(Fraction obj1, Fraction obj2)
        {
            var switchFraction = !obj2;

            return obj1 * switchFraction;
        }

        /* 5. implement toan tu so sanh <= >= < > */
        public static bool operator <=(Fraction obj1, Fraction obj2)
        {
            var compare = obj1 - obj2;
            return compare.A <= 0;
        }

        public static bool operator >=(Fraction obj1, Fraction obj2)
        {
            var compare = obj1 - obj2;
            return compare.A >= 0;
        }

        public static bool operator <(Fraction obj1, Fraction obj2)
        {
            var compare = obj1 - obj2;
            return compare.A < 0;
        }

        public static bool operator >(Fraction obj1, Fraction obj2)
        {
            var compare = obj1 - obj2;
            return compare.A > 0;
        }

        /* 7. Implement cast int sang Fraction */
        public static explicit operator Fraction(int i)
        {
            return new Fraction(i, 1);
        }

        /* 8. implement cast: Fraction sang float */
        public static explicit operator float(Fraction obj)
        {
            return (float)obj.A / obj.B;
        }

        /* 9. implement toan tu + - * / giua phan so va so nguyen
            => dua so nguyen ve dang phan so va tra ve kqua toan tu giua phan so va phan so
         */
        public static Fraction operator +(Fraction obj, int i)
        {
            return obj + (Fraction)i;
        }

        public static Fraction operator -(Fraction obj, int i)
        {
            return obj - (Fraction)i;
        }

        public static Fraction operator *(Fraction obj, int i)
        {
            return obj * (Fraction)i;
        }

        public static Fraction operator /(Fraction obj, int i)
        {
            return obj / (Fraction)i;
        }
    }
}