using System;
using System.Collections.Generic;
using System.Linq;

namespace NetExercise.OPP
{
    public class ExerciseLinq02
    {

        public static List<int> IntegerList = new List<int>();

        /* 1. 2. get 3 first max */
        public List<int> Get3Max()
        {
            return IntegerList.OrderByDescending(i => i).Take(3).ToList();
        }

        /* 3. get N random item */
        public List<int> GetNRandomItem(int n)
        {
            Random random = new Random();
            var result = new List<int>(n);
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    int index = random.Next(0, IntegerList.Count());
                    result.Add(IntegerList.ElementAt(index));
                }
            }

            return result;
        }

        /* 4. sap xep list theo gia tri hang don vi */
        public List<int> SortByValueOfUnitPlace()
        {
            return IntegerList.OrderBy(i => i % 10).ToList();
        }

        /* 5. tim gia tri bi duplicated nhieu nhat */
        public int FindMaxCountDuplicatedNumber()
        {
            var groups = IntegerList.GroupBy(i => i);
            var result = groups.Select(grp => new
            {
                value = grp.First(),
                count = grp.Count()
            }).OrderByDescending(t => t.count).First();

            return result.value;
        }

        /* 6. tim cac gia tri khong co gia tri bi duplicated */
        public List<int> FindNonDuplicatedNumbers()
        {
            var groups = IntegerList.GroupBy(i => i);
            var anonymousGrp = groups.Select(grp => new
            {
                value = grp.First(),
                count = grp.Count()
            });

            var result = anonymousGrp.Where(a => a.count == 1).Select(a => a.value).ToList();

            return result;
        }

        /* 7. tim cac gia tri co gia tri bi duplicated */
        public List<int> FindDuplicatedNumbers()
        {
            var groups = IntegerList.GroupBy(i => i);
            var anonymousGrp = groups.Select(grp => new
            {
                value = grp.First(),
                count = grp.Count()
            });

            var result = anonymousGrp.Where(a => a.count > 1).Select(a => a.value).ToList();

            return result;
        }

        /* 8. sap xep cac gia tri theo so luong chu so tang dan */
        public List<int> GetListByLengthOfNumber()
        {
            var groups = IntegerList.GroupBy(i => i.ToString().Length);
            var result = groups.SelectMany(a => a).ToList();

            return result;
        }

        /* 9. Tong cac so chan */
        public int SumOfEvenNumber()
        {
            return IntegerList.Where(i => i % 2 == 0).Sum();
        }

        /* 10. tim so chinh phuong lon nhat */
        public bool IsSquareNumber(int i)
        {
            if (i == 0)
                return false;
            int n = (int)Math.Sqrt(i);

            return (n * n) == i;
        }

        public int FindMaxSquareNumber()
        {
            var list = IntegerList.Where(i => IsSquareNumber(i)).ToList();
            if (list.Count != 0)
                return list.Max();
            return 0;
        }

        /* 11. Tong cac so chinh phuong */
        public int SumOfSquareNumbers()
        {
            return IntegerList.Where(i => IsSquareNumber(i)).Sum();
        }

        /* 12. tim va dem so nguyen to */
        public bool IsPrimeNumber(int i)
        {
            int sqrt = (int)Math.Sqrt(i);
            if (i == 0 || i == 1) return false;
            for (int a = 2; a <= sqrt; a++)
            {
                if (i % a == 0) return false;
            }
            return true;
        }

        public int CountPrimeNumber()
        {
            return IntegerList.Count(i => IsPrimeNumber(i));
        }
    }
}