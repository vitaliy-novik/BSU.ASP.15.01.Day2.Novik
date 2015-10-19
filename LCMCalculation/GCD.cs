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
        public static int EuclideanAlgorithm(int a, int b, out long time)
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0 || b == 0)
                return Math.Max(a, b);
            int r=1;
            if (b > a) { r = a; a = b; b = r; }
            while(r != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return a;
        }

        public static int EuclideanAlgorithm(int a, int b, int c, out long time)
        {
            long rtime;
            int r = EuclideanAlgorithm(a, b, out time);
            r = EuclideanAlgorithm(r, c, out rtime);
            time += rtime;
            return r;
        }

        public static int EuclideanAlgorithm(out long time, params int[] numbers)
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long rtime;
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException();
            if (numbers.Length == 1)
                return numbers[0];
            int result = EuclideanAlgorithm(numbers[0], numbers[1], out rtime);
            for (int i = 2; i < numbers.Length; ++i)
            {
                result = EuclideanAlgorithm(numbers[i], result, out rtime);
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return result;
        }

        public static int BinaryAlgorithm(int a, int b, out long time)
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

        public static int BinaryAlgorithm(int a, int b, int c, out long time)
        {
            long rtime;
            int r = BinaryAlgorithm(a, b, out time);
            r = BinaryAlgorithm(r, c, out rtime);
            time += rtime;
            return r;
        }

        public static int BinaryAlgorithm(out long time, params int[] numbers)
        {
            time = 0;
            Stopwatch sw = new Stopwatch();
            long rtime;
            sw.Start();
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException();
            if (numbers.Length == 1)
                return numbers[0];
            int result = BinaryAlgorithm(numbers[0], numbers[1], out rtime);
            for (int i = 2; i < numbers.Length; ++i)
            {
                result = BinaryAlgorithm(numbers[i], result, out rtime);
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return result;
        }
    }
}
