using System;
using System.Collections.Generic;
using System.Linq;
using NetExercise.OPP;
using NUnit.Framework;
namespace NetExercise.Test.OPP
{
    public class Linq02Test
    {
        public List<int> initInt = new List<int> { 2, 4, 5, 7, 4, 6, 8, 9, 4, 5, 0, 12, 75, 56, 123, 231 };
        // public List<int> initInt = new List<int> { 0, 2, 4, 4, 4, 5, 5, 6, 7, 8, 9, 12, 56, 75, 123, 231 };

        [Test]
        public void Test_Get3Max_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.Get3Max();
            var resultText = String.Join(",", result.ToArray());

            // Assert
            Assert.AreEqual(resultText, "231,123,75");
        }

        [TestCase(4)]
        [TestCase(0)]
        public void Test_GetNRandom_Ok(int n)
        {
            var linq2 = new ExerciseLinq02(initInt);
            var list = linq2.IntegerList;

            // Act
            var result = linq2.GetNRandomItem(n);

            // Assert
            Assert.AreEqual(result.Count(), n);
            result.ForEach(i => Assert.AreEqual(list.Contains(i), true));
        }

        [Test]
        public void Test_SortByValueOfUnitPlace_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.SortByValueOfUnitPlace();
            var resultText = String.Join(",", result.ToArray());

            // Assert
            Assert.AreEqual(resultText, "0,231,2,12,123,4,4,4,5,5,75,6,56,7,8,9");
        }

        [Test]
        public void Test_FindMaxCountDuplicatedNumber_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.FindMaxCountDuplicatedNumber();

            // Assert
            Assert.AreEqual(result, 4);
        }

        [Test]
        public void Test_FindNonDuplicatedNumbers_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.FindNonDuplicatedNumbers();
            var resultText = String.Join(",", result.ToArray());

            // Assert
            Assert.AreEqual(resultText, "2,7,6,8,9,0,12,75,56,123,231");
        }

        [Test]
        public void Test_FindDuplicatedNumbers_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.FindDuplicatedNumbers();
            var resultText = String.Join(",", result.ToArray());

            // Assert
            Assert.AreEqual(resultText, "4,5");
        }
        
        [Test]
        public void Test_GetListByLengthOfNumber_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.GetListByLengthOfNumber();
            var resultText = String.Join(",", result.ToArray());

            // Assert
            Assert.AreEqual(resultText, "2,4,5,7,4,6,8,9,4,5,0,12,75,56,123,231");
        }

        [Test]
        public void Test_SumOfEvenNumber_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.SumOfEvenNumber();

            // Assert
            Assert.AreEqual(result, 96);
        }
        
        [Test]
        public void Test_FindMaxSquareNumber_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.FindMaxSquareNumber();

            // Assert
            Assert.AreEqual(result, 9);
        }
        
        [Test]
        public void Test_SumOfSquareNumbers_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.SumOfSquareNumbers();

            // Assert
            Assert.AreEqual(result, 21);
        }

        [Test]
        public void Test_CountPrimeNumber_Ok()
        {
            var linq2 = new ExerciseLinq02(initInt);

            // Act
            var result = linq2.CountPrimeNumber();

            // Assert
            Assert.AreEqual(result, 4);
        }
    }
}