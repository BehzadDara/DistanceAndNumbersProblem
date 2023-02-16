using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DistanceAndNumbersProblem;

public class Problem
{
    #region Init

    private readonly int _n;

    public Problem(int n)
    {
        _n = n;
    }

    private List<int> EmptyList
    {
        get
        {
            var list = new List<int>();
            list.AddRange(Enumerable.Repeat(0, 2 * _n));
            return list;
        }
    }

    public List<List<int>> Solve()
    {
        #region Begin
        Console.WriteLine($"Combinations of elements satisfying given constraints for n = {_n}:");
        #endregion

        #region Solve
        var result = FindAllCombinations();
        #endregion

        #region End
        PrintResult(result);
        return result;
        #endregion
    }

    #endregion

    #region Solution
    private List<List<int>> FindAllCombinations()
    {
        var result = new List<List<int>>();
        for (var i = 0; i < _n - 1; i++)
        {
            var list = FindCombinations(EmptyList, _n, i);
            result.AddRange(list);
        }

        return result;
    }

    private static List<List<int>> FindCombinations(List<int> list, int currentN, int currentPosition)
    {
        var result = new List<List<int>>();

        if (currentPosition < list.Count - currentN - 1 && list[currentPosition] == 0 && list[currentPosition + currentN + 1] == 0)
        {
            var tmpList = new List<int>(list)
            {
                [currentPosition] = currentN,
                [currentPosition + currentN + 1] = currentN
            };

            if (!tmpList.Any(x => x == 0))
            {
                result.Add(tmpList);
                return result;
            }

            for (var i = 0; i < tmpList.Count; i++)
            {
                result.AddRange(FindCombinations(tmpList, currentN - 1, i));
            }
        }

        return result;
    }

    #endregion

    private static void PrintResult(List<List<int>> result)
    {
        Console.WriteLine($"Total {result.Count} configurations possible.");

        result.ForEach(item => Console.WriteLine("{" + string.Join(", ", item) + "}"));

        Console.WriteLine($"Total {result.Count} configurations possible.");
    }

}