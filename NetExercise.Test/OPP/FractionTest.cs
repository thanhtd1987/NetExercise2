using System;
using NetExercise.OPP;
using NUnit.Framework;
namespace NetExercise.Test.OPP
{
    public class FractionTest
    {
        [TestCase(3, 4, "3/4")]
        [TestCase(12, 5, "12/5")]
        public void Test_New_Fraction_Ok(int a, int b, string text)
        {
            var fraction = new Fraction(a, b);

            Assert.AreEqual(fraction.ToString(), text);
        }

        [TestCase(3, 0, "B can not be zero")]
        public void Test_New_Fraction_Throw_Exception(int a, int b, string text)
        {
            var e = Assert.Throws<ArgumentException>(() => new Fraction(a, b));
            Assert.That(e.Message, Is.EqualTo(text));
        }

        [TestCase(4, 5, 4, 5)]
        public void Test_Equal_Fraction_Ok(int a1, int b1, int a2, int b2)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            Assert.AreEqual(fraction1 == fraction2, true);
        }

        [TestCase(14, 5, 4, 15)]
        public void Test_Not_Equal_Fraction_Ok(int a1, int b1, int a2, int b2)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            Assert.AreEqual(fraction1 == fraction2, false);
        }

        [TestCase(14, 8, 14, 8)]
        public void Test_Equals_Fraction_Ok(int a1, int b1, int a2, int b2)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            Assert.AreEqual(fraction1.Equals(fraction2), true);
        }

        [TestCase(14, 8)]
        public void Test_GetHashCode_Fraction_Ok(int a1, int b1)
        {
            var fraction = new Fraction(a1, b1);

            Assert.AreEqual(fraction.GetHashCode(), a1.GetHashCode() ^ b1.GetHashCode());
        }

        [TestCase(14, 8, "7/4")]
        [TestCase(72, 12, "6/1")]
        public void Test_Minimal_Fraction_Ok(int a, int b, string text)
        {
            var fraction = new Fraction(a, b);

            fraction.Minimal();

            Assert.AreEqual(fraction.ToString(), text);
        }

        [TestCase(14, 8, 2, 8, "2/1")]
        [TestCase(72, 12, 3, 4, "27/4")]
        [TestCase(1, 4, -3, 4, "-1/2")]
        public void Test_Plus_Fraction_Ok(int a1, int b1, int a2, int b2, string text)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var sum = fraction1 + fraction2;

            Assert.AreEqual(sum.ToString(), text);
        }
        [TestCase(14, 8, 2, 8, "3/2")]
        [TestCase(72, 12, 3, 4, "21/4")]
        [TestCase(2, 8, 14, 8, "-3/2")]
        public void Test_Minus_Fraction_Ok(int a1, int b1, int a2, int b2, string text)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var result = fraction1 - fraction2;

            Assert.AreEqual(result.ToString(), text);
        }
        [TestCase(14, 8, 2, 8, "7/16")]
        [TestCase(72, 12, 3, 4, "9/2")]
        public void Test_Multiply_Fraction_Ok(int a1, int b1, int a2, int b2, string text)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var result = fraction1 * fraction2;

            Assert.AreEqual(result.ToString(), text);
        }
        [TestCase(14, 8, 2, 8, "7/1")]
        [TestCase(72, 12, 3, 4, "8/1")]
        public void Test_Devide_Fraction_Ok(int a1, int b1, int a2, int b2, string text)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var result = fraction1 / fraction2;

            Assert.AreEqual(result.ToString(), text);
        }

        [TestCase(14, 8, "4/7")]
        [TestCase(72, 12, "1/6")]
        public void Test_Reverse_Fraction_Ok(int a, int b, string text)
        {
            var fraction = new Fraction(a, b);

            var result = !fraction;

            Assert.AreEqual(result.ToString(), text);
        }

        [TestCase(14, 8, 2, 8, true)]
        [TestCase(72, 12, 3, 4, true)]
        [TestCase(2, 12, 3, 4, false)]
        [TestCase(8, 12, 3, 4, false)]
        public void Test_Fraction_Greater_Ok(int a1, int b1, int a2, int b2, bool result)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var compare = fraction1 > fraction2;

            Assert.AreEqual(compare, result);
        }

        [TestCase(14, 8, 2, 8, false)]
        [TestCase(72, 12, 3, 4, false)]
        [TestCase(2, 12, 3, 4, true)]
        [TestCase(8, 12, 3, 4, true)]
        public void Test_Fraction_Less_Ok(int a1, int b1, int a2, int b2, bool result)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var compare = fraction1 < fraction2;

            Assert.AreEqual(compare, result);
        }

        [TestCase(14, 8, 2, 8, true)]
        [TestCase(72, 12, 24, 4, true)]
        [TestCase(2, 12, 3, 4, false)]
        [TestCase(8, 12, 2, 3, true)]
        public void Test_Fraction_Greater_Equal_Ok(int a1, int b1, int a2, int b2, bool result)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var compare = fraction1 >= fraction2;

            Assert.AreEqual(compare, result);
        }

        [TestCase(14, 8, 2, 8, false)]
        [TestCase(72, 12, 3, 4, false)]
        [TestCase(2, 12, 3, 4, true)]
        [TestCase(12, 16, 3, 4, true)]
        public void Test_Fraction_Less_Equal_Ok(int a1, int b1, int a2, int b2, bool result)
        {
            var fraction1 = new Fraction(a1, b1);
            var fraction2 = new Fraction(a2, b2);

            var compare = fraction1 <= fraction2;

            Assert.AreEqual(compare, result);
        }

        [TestCase(5, "5/1")]
        public void Test_Int_To_Fraction_Ok(int a, string text)
        {
            var fraction = (Fraction)a;

            Assert.AreEqual(fraction.ToString(), text);
        }

        [TestCase(2, 3, (float)2 / 3)]
        public void Test_Cast_Fraction_To_Float_Ok(int a, int b, float test)
        {
            var fraction = new Fraction(a, b);

            Assert.AreEqual((float)fraction, test);
        }

        [TestCase(2, 3, 3, "11/3")]
        public void Test_Fraction_Plus_Int_Ok(int a, int b, int i, string text)
        {
            var fraction = new Fraction(a, b);
            var result = fraction + i;

            Assert.AreEqual(result.ToString(), text);
        }

        [TestCase(2, 3, 3, "-7/3")]
        public void Test_Fraction_Minus_Int_Ok(int a, int b, int i, string text)
        {
            var fraction = new Fraction(a, b);
            var result = fraction - i;

            Assert.AreEqual(result.ToString(), text);
        }

        [TestCase(2, 3, 3, "2/1")]
        public void Test_Fraction_Multiply_Int_Ok(int a, int b, int i, string text)
        {
            var fraction = new Fraction(a, b);
            var result = fraction * i;

            Assert.AreEqual(result.ToString(), text);
        }

        [TestCase(2, 3, 3, "2/9")]
        public void Test_Fraction_Devide_Int_Ok(int a, int b, int i, string text)
        {
            var fraction = new Fraction(a, b);
            var result = fraction / i;

            Assert.AreEqual(result.ToString(), text);
        }
    }
}