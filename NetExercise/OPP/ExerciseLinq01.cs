using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NetExercise.OPP
{
    public class ExerciseLinq01
    {
        public List<Fraction> Fractions = new List<Fraction>();

        public ExerciseLinq01(List<Fraction> list)
        {
            Fractions.AddRange(list);
        }

        /* 1. get max fraction in list */
        public Fraction GetMax()
        {
            return Fractions.Max();
        }

        /* 2. get min fraction in list */
        public Fraction GetMin()
        {
            return Fractions.Min();
        }

        /* 3. get sum fraction in list */
        public Fraction GetSum()
        {
            return Fractions.Aggregate((acc, x) => acc + x);
        }

        /* 4. get multiply fraction in list */
        public Fraction GetAggregate()
        {
            return Fractions.Aggregate((acc, x) => acc * x);
        }

        /* 5. sx giam dan theo gia tri thuc cua Fraction */
        public List<Fraction> SortByValueDescending()
        {
            return Fractions.OrderByDescending(f => (float)f).ToList();
        }

        /* 6. sx giam dan theo gia tri cua A cua Fraction */
        public List<Fraction> SortByAValue()
        {
            return Fractions.OrderBy(f => f.A).ToList();
        }

        /* 7. sx giam dan theo gia tri cua B cua Fraction */
        public List<Fraction> SortByBValueDescending()
        {
            return Fractions.OrderByDescending(f => f.B).ToList();
        }

        /* 8. lay ra list cac Fraction bi duplicated do giong nhau */
        public List<Fraction> GetDuplicatedByEquals()
        {
            /* var unique = Fractions.Distinct().ToList();
            var duplicatedList = new List<Fraction>();
            unique.ForEach(u =>
            {
                if (Fractions.Count(fr => fr == u) > 1)
                {
                    duplicatedList.Add(u);
                }
            });
            return duplicatedList; */
            var grp = Fractions.GroupBy(f => f);
            var result = grp.Select(grp => new { f = grp.First(), count = grp.Count() }).ToList();

            return result.Where(a => a.count > 1).Select(a => a.f).ToList();
        }

        /* 9. lay ra list cac Fraction bi duplicated do bang nhau */
        public List<Fraction> GetDuplicatedBySameValue()
        {
            /* var duplicatedList = new List<Fraction>();
            Fractions.ForEach(f =>
            {
                if (Fractions.Count(fr =>
                {
                    fr.Minimal();
                    f.Minimal();
                    return fr == f;
                }) > 1)
                {
                    duplicatedList.Add(f);
                }
            });

            return duplicatedList; */

            // var grp = Fractions.GroupBy(f => { f.Minimal(); return f; });
            var grp = Fractions.Select(f =>
            {
                var temp = new Fraction(f.A, f.B);
                f.Minimal();
                return new { value = temp, cond = f };
            }).GroupBy(a => a.cond);
            var result = grp.Where(g => g.Count() > 1).Select(g => g.Select(a => a.value));
            return result.SelectMany(a => a).ToList();
        }

        /* 10. tim so luong cac fraction co cung gia tri A */
        public int CountByAValue(int a)
        {
            return Fractions.Count(f => f.A == a);
        }

        /* 11. tim so luong cac fraction co gia tri B lon hon so bat ki*/
        public int CountByBValueGreater(int b)
        {
            return Fractions.Count(f => f.B > b);
        }

        /* 12. tra ve list distinct theo gia tri bang nhau */
        public List<Fraction> GetDistinctByFractionValue()
        {
            var comparer = new FractionValueComparer();
            return Fractions.Distinct(comparer).ToList();
        }
    }

    public class FractionValueComparer : IEqualityComparer<Fraction>
    {
        public bool Equals([AllowNull] Fraction x, [AllowNull] Fraction y)
        {
            // check 2 object cung reference/ cung bi null
            if (ReferenceEquals(x, y))
                return true;

            // check 1 trong 2 object la null thi tra ve false
            if (x is null || y is null)
                return false;

            // minimal fraction
            x.Minimal();
            y.Minimal();
            // so sanh gia tri cua 2 doi tuong
            return x == y;
        }

        public int GetHashCode([DisallowNull] Fraction obj)
        {
            obj.Minimal();
            // xor de ket hop 2 prop
            return obj.A.GetHashCode() ^ obj.B.GetHashCode();
        }
    }
}