using System;
using System.Collections.Generic;
using System.Linq;
using NetExercise.OPP;
using NUnit.Framework;
namespace NetExercise.Test.OPP
{
    public class Linq01Test
    {

        public readonly List<Fraction> InitList = new List<Fraction> {
            new Fraction(4,5),
            new Fraction(7,8),
            new Fraction(14,5),
            new Fraction(4,15),
            new Fraction(2,5),
            new Fraction(4,7),
            new Fraction(7,5)
        };

        public readonly List<Fraction> ShortList = new List<Fraction> {
            new Fraction(1,2),
            new Fraction(4,7),
            new Fraction(5,10),
            new Fraction(3,2)
        };

        [TestCase("14/5")]
        public void Test_GetMax_Ok(string textMax)
        {
            var linq1 = new ExerciseLinq01(InitList);

            var max = linq1.GetMax();

            Assert.AreEqual(max.ToString(), textMax);
        }

        [TestCase("4/15")]
        public void Test_GetMin_Ok(string textMin)
        {
            var linq1 = new ExerciseLinq01(InitList);

            var min = linq1.GetMin();

            Assert.AreEqual(min.ToString(), textMin);
        }

        [TestCase("5/2")]
        public void Test_GetSum_Ok(string textSum)
        {
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
            });

            var sum = linq1.GetSum();

            Assert.AreEqual(sum.ToString(), textSum);
        }

        [TestCase("3/8")]
        public void Test_GetMultiply_Ok(string textMultiply)
        {
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
            });

            var result = linq1.GetAggregate();

            Assert.AreEqual(result.ToString(), textMultiply);
        }

        [TestCase("3/2,4/7,1/2,5/10")]
        public void Test_SortByValue_Ok(string textSorted)
        {
            var linq1 = new ExerciseLinq01(ShortList);

            var result = linq1.SortByValueDescending().Select(f => f.ToString()).ToArray();
            string resText = String.Join(",", result);

            Assert.AreEqual(resText, textSorted);
        }

        [TestCase("1/2,3/2,4/7,5/10")]
        public void Test_SortByAValue_Ok(string textSorted)
        {
            var linq1 = new ExerciseLinq01(ShortList);

            var result = linq1.SortByAValue().Select(f => f.ToString()).ToArray();
            string resText = String.Join(",", result);

            Assert.AreEqual(resText, textSorted);
        }

        [TestCase("5/10,4/7,1/2,3/2")]
        public void Test_SortByBValueDescending_Ok(string textSorted)
        {
            var linq1 = new ExerciseLinq01(ShortList);

            var result = linq1.SortByBValueDescending().Select(f => f.ToString()).ToArray();
            string resText = String.Join(",", result);

            Assert.AreEqual(resText, textSorted);
        }

        [TestCase("1/2")]
        public void Test_GetDuplicatedByEqual_Ok(string textDuplicated)
        {
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
                new Fraction(1,2),
            });

            var result = linq1.GetDuplicatedByEquals().Select(f => f.ToString()).ToArray();
            string resText = String.Join(",", result);

            Assert.AreEqual(resText, textDuplicated);
        }

        [TestCase("1/2,4/8,1/2")]
        public void Test_GetDuplicatedBySameValue_Ok(string textDuplicated)
        {
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
                new Fraction(1,2),
            });

            var result = linq1.GetDuplicatedBySameValue().Select(f => f.ToString()).ToArray();
            string resText = String.Join(",", result);

            Assert.AreEqual(resText, textDuplicated);
        }

        [TestCase(2)]
        public void Test_CountByAValue_Ok(int count)
        {
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
                new Fraction(1,2),
            });

            var resText = linq1.CountByAValue(1);

            Assert.AreEqual(resText, count);
        }

        [Test]
        public void Test_CountByBValueGreater_Ok()
        {
            // Arrange
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
                new Fraction(1,2),
            });
            // Act
            var resText = linq1.CountByBValueGreater(2);
            // Assert
            Assert.AreEqual(resText, 1);
        }

        [TestCase("1/2,3/2")]
        public void Test_GetDistinctByFractionValue_Ok(string textDistinct)
        {
            var linq1 = new ExerciseLinq01(new List<Fraction> {
                new Fraction(1,2),
                new Fraction(4,8),
                new Fraction(3,2),
                new Fraction(1,2),
            });

            var result = linq1.GetDistinctByFractionValue().Select(f => f.ToString()).ToArray();
            string resText = String.Join(",", result);

            Assert.AreEqual(resText, textDistinct);
        }
    }
}