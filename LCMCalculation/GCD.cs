using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDCalculation
{
    public static class GCD
    {
        delegate int Algorithm(out long time, int a, int b);

        public static int EuclideanAlgorithm(out long time, int a, int b, int c)
        {
            return GCDThreeNumbers(new Algorithm(EuclideanAlgorithm), out time, a, b, c);
        }

        public static int BinaryAlgorithm(out long time, int a, int b, int c)
        {
            return GCDThreeNumbers(new Algorithm(BinaryAlgorithm), out time, a, b, c);
        }

        public static int EuclideanAlgorithm(out long time, params int[] numbers)
        {
            return GCDParamsAlgorithm(new Algorithm(EuclideanAlgorithm), out time, numbers);
        }

        public static int BinaryAlgorithm(out long time, params int[] numbers)
        {
            return GCDParamsAlgorithm(new Algorithm(BinaryAlgorithm), out time, numbers);
        }

        public static int EuclideanAlgorithm(out long time, int a, int b)
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0 || b == 0)
                return Math.Max(a, b);
            int r = 1;
            if (b > a) { r = a; a = b; b = r; }
            while (r != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return a;
        }

        public static int BinaryAlgorithm(out long time, int a, int b)
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int result = 1;
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (true)
            {
                if (a == 0) { result *= b; break; };
                if (b == 0) { result *= a; break; };
                if (a == b) { result *= a; break; };
                if (a == 1 || b == 1) break;
                if ((a % 2 == 0) && (b % 2 == 0))
                { 
                    result <<= 1; a >>= 1; b >>= 1; 
                    continue; 
                }
                if ((a % 2 == 0) && (b % 2 != 0))
                { 
                    a >>= 1; continue; 
                }
                if ((a % 2 != 0) && (b % 2 == 0))
                { 
                    b >>= 1; continue; 
                }
                int t = a; a = b; 
                b = Math.Abs(t - b);
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return result;
        }

        private static int GCDThreeNumbers(Algorithm algorithm, out long time, int a, int b, int c)
        {
            long rtime;
            int r = algorithm(out time, a, b);
            r = algorithm(out rtime, r, c);
            time += rtime;
            return r;
        }

        private static int GCDParamsAlgorithm(Algorithm algorithm, out long time, params int[] numbers)
        {
            time = 0;
            long rtime;
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException();
            int result = algorithm(out rtime, numbers[0], numbers[1]);
            time += rtime;
            for (int i = 2; i < numbers.Length; ++i)
            {
                result = algorithm(out rtime, numbers[i], result);
                time += rtime;
            }
            return result;
        }
        
    }
}
