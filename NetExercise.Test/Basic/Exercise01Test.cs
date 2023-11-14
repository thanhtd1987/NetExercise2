using NetExercise.Basic;
using NUnit.Framework;
namespace NetExercise.Test.Basic
{
    public class Exercise01Test
    {
        [TestCase(12, 28, 4)]
        [TestCase(42, 28, 14)]
        [TestCase(10, 1, 1)]
        public void Test_Ucln_Ok(int a, int b, int result)
        {
            Assert.AreEqual(Exercise01.Ucln(a, b), result);
        }

        [TestCase(12, 28, 84)]
        [TestCase(42, 35, 210)]
        public void Test_Bcnn_Ok(int a, int b, int result)
        {
            Assert.AreEqual(Exercise01.Bcnn(a, b), result);
        }
    }
}
