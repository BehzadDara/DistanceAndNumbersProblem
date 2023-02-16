using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceAndNumbersProblem.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        [DataRow(2, 0)]
        [DataRow(3, 2)]
        [DataRow(4, 2)]
        [DataRow(5, 0)]
        [DataRow(6, 0)]
        [DataRow(7, 52)]
        [DataRow(8, 300)]
        [DataRow(9, 0)]
        public void TestCountLevel1(int n, int count)
        {
            var result = new Problem(n).Solve();

            Assert.IsTrue(result.Count == count);
        }

        [TestMethod]
        [DataRow(10, 0)]
        [DataRow(11, 35584)]
        [DataRow(12, 216288)]
        [DataRow(13, 0)]
        [Ignore]
        public void TestCountLeve2(int n, int count)
        {
            var result = new Problem(n).Solve();

            Assert.IsTrue(result.Count == count);
        }

        [TestMethod]
        public void TestResult3()
        {
            var trueResult = new List<List<int>>{
                        new List<int>
                        {
                            3, 1, 2, 1, 3, 2
                        },
                        new List<int>
                        {
                            2, 3, 1, 2, 1, 3
                        }
            };

            var result = new Problem(3).Solve();

            Assert.IsTrue(IsEqual(trueResult, result));
        }

        [TestMethod]
        public void TestResult4()
        {
            var trueResult = new List<List<int>>{
                        new List<int>
                        {
                            4, 1, 3, 1, 2, 4, 3, 2
                        },
                        new List<int>
                        {
                            2, 3, 4, 2, 1, 3, 1, 4
                        }
            };

            var result = new Problem(4).Solve();

            Assert.IsTrue(IsEqual(trueResult, result));
        }

        private static bool IsEqual(List<List<int>> first, List<List<int>> second)
        {
            if(first.Count != second.Count)
                return false;

            for(var i = 0; i < first.Count; i++)
            {
                if (!first[i].SequenceEqual(second[i]))
                    return false;
            }

            return true;
        }

    }
}
