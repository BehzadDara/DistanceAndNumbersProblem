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
    private const int n = 7;

    private static List<int> EmptyList
    {
        get
        {
            var list = new List<int>();
            list.AddRange(Enumerable.Repeat(0, 2 * n));
            return list;
        }
    }

    public static void Solve()
    {
        #region Begin
        Console.WriteLine($"Combinations of elements satisfying given constraints for n = {n}:");
        #endregion

        #region Solve
        var result = FindAllCombinations();
        #endregion

        #region End
        PrintResult(result);
        #endregion
    }

    private static List<List<int>> FindAllCombinations()
    {
        var result = new List<List<int>>();
        for (var i = 0; i < n - 1; i++)
        {
            var list = FindCombinations(EmptyList, n, i);
            result.AddRange(list);
        }

        return result;
    }

    private static List<List<int>> FindCombinations(List<int> list, int currentN, int currentPosition)
    {
        var result = new List<List<int>>();

        if (currentPosition < list.Count - currentN - 1 && list[currentPosition] == 0 && list[currentPosition + currentN + 1] == 0)
        {
            var tmpList = new List<int>(list);
            tmpList[currentPosition] = currentN;
            tmpList[currentPosition + currentN + 1] = currentN;

            if(!tmpList.Any(x => x == 0))
            {
                result.Add(tmpList);
                return result;
            }

            for(var i = 0; i< tmpList.Count; i++)
            {
                foreach (var item in FindCombinations(tmpList, currentN - 1, i))
                {
                    if (!item.Any(x => x == 0))
                    {
                        var tmpItem = new List<int>(item);
                        result.Add(tmpItem);
                    }
                }
            }
        }
            
        return result;
    }

    private static void PrintResult(List<List<int>> result)
    {
        Console.WriteLine($"Total {result.Count} configurations possible.");

        foreach (var item in result)
        {
            Console.WriteLine("{" + string.Join(", ", item) + "}");
        }

        Console.WriteLine($"Total {result.Count} configurations possible.");
    }

}

