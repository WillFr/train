using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Median
{
    class Program
    {

        private static Random rand = new Random();
        static void Main(string[] args)
        {
            Test1A();
            Test1B();
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
            Test7();
            Test8();
            Test9();
            Test10();
            Test11();
            Test12();
            Test13();
            Test14();
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i);
                Fuzz();
            }

            Console.WriteLine("all test successfull");
        }

        private static void Test1A()
        {
            var a = new[] { 1, 5 };
            var b = new[] { 1,2, 3, 4, 5 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 3, " c = " + c);
        }

        private static void Test1B()
        {
            var a = new[] { 1,2,3,4, 5 };
            var b = new[] { 1, 5 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 3, " c = " + c);
        }

        private static void Test2()
        {
            var a = new[] { 1, 2 };
            var b = new[] { 3, 4, 5 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 3, " c = " + c);
        }

        private static void Test3()
        {
            var a = new[] { 1, 2 ,3};
            var b = new[] {4, 5 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 3, " c = " + c);
        }
        private static void Test4()
        {
            var a = new[]{1, 2};
            var b = new[] { 0,1,3,4,5 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 2, " c = " + c);
        }

        private static void Test5()
        {
            var a = new[] { 1,3,5,7,9 };
            var b = new[] { 2,4,6,8,10 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 5.5, " c = " + c);
        }

        private static void Test6()
        {
            var a = new[] { 2, 4, 6, 8, 10 };
            var b = new[] { 1, 3, 5, 7, 9 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 5.5, " c = " + c);
        }

        private static void Test7()
        {
            var a = new[] { 2, 4, 6, 8 };
            var b = new[] { 1, 3, 5, 7, 9,10,11};

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 6, " c = " + c);
        }

        private static void Test8()
        {
            var a = new[] { 2, 4, 6 };
            var b = new[] { 1, 3, 5, 7, 9, 10, 11 };

            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == 5.5, " c = " + c);
        }

        private static void Test9()
        {
            var a = new[] { 24, 32, 41, 41, 46, 52, 56, 61, 63, 72 };
            var b = new[] { 21, 26, 35, 44, 51, 51 };
            var cc = GetMedianTest(a, b);
            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == cc, " c = " + c);
        }

        private static void Test10()
        {
            var a = new[] { 13, 19, 25, 34 };
            var b = new[] { 23, 32, 32, 41, 50, 59 };
            var cc = GetMedianTest(a, b);
            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == cc, " c = " + c);
        }

        private static void Test11()
        {
            var a = new[] { -3,3};
            var b = new[] { -23, -20, -13, -9, -3, -2, 1, 3, 11 };
            var cc = GetMedianTest(a, b);
            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == cc, " c = " + c);
        }

        private static void Test12()
        {
            var a = new[] { -17, -9, -5, -2, 3, 10 };
            var b = new[] { -9,-3};
            var cc = GetMedianTest(a, b);
            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == cc, " c = " + c);
        }


        private static void Test13()
        {
            var a = new[] { 48, 49, 55, 63 };
            var b = new[] { 34, 39, 48, 56, 59 };
            var cc = GetMedianTest(a, b);
            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == cc, " c = " + c);
        }

        private static void Test14()
        {
            var a = new[] { -38, -31, -29, -21, -20, -12 };
            var b = new[] { -40, -33, -25, -17, -10, -6 };
            var cc = GetMedianTest(a, b);
            var c = Solution.GetMedian(a, b);

            Debug.Assert(c == cc, " c = " + c);
        }
        private static void Fuzz()
        {
            var a = GenerateRandomSortedArray();
            var b = GenerateRandomSortedArray();

            Console.WriteLine(string.Join(",",a));
            Console.WriteLine(string.Join(",",b));

            var t = Solution.GetMedian(a, b);
            var s = GetMedianTest(a, b);
            Debug.Assert( t == s , " Fuzz : the median should be : "+s + " and not "+t);
        }

        private static float GetMedianTest(int[] a, int[] b)
        {
            var tt = a.ToList();
            tt.AddRange(b);
            var t = tt.OrderBy(x => x).ToArray();
            if (t.Length%2 == 0)
            {
                return t[t.Length/2 - 1] + (float)(t[t.Length/2] - t[t.Length/2 - 1])/2;
            }
            else
            {
                return t[t.Length/2];
            }
        }

        private static int[] GenerateRandomSortedArray()
        {
            var l = rand.Next(1,11);
            var r = new int[l];
            r[0] = rand.Next(-50, 50);

            for (int i = 1; i < l; i++)
            {
                r[i] = r[i-1]+ rand.Next(0, 10);
            }

            return r;
        }
    }
}
