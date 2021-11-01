using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPerf
{
    public class Benchmarks
    {
        private readonly int[] data = new int[1000];

        public Benchmarks()
        {
            data.Fill(100);
            data[^1] = 101;
        }

        [Benchmark]
        public int UsingLinqFirstElement() => UsingLinqFirstElement(data);
        static int UsingLinqFirstElement(IEnumerable<int> array)
        {
             return array.First(x => x == 100);
        }

        [Benchmark]
        public int UsingLinqLastElement() => UsingLinqLastElement(data);
        static int UsingLinqLastElement(IEnumerable<int> array)
        {
            return array.First(x => x > 100);
        }

        [Benchmark]
        public int UsingArrayFirstElement() => UsingArrayFirstElement(data);
        static int UsingArrayFirstElement(int[] array)
        {
            return array.First(x => x == 100);
        }

        [Benchmark]
        public int UsingArrayLastElement() => UsingArrayLastElement(data);
        static int UsingArrayLastElement(int[] array)
        {
            return array.First(x => x > 100);
        }

        [Benchmark]
        public int UsingLoopFirstElement() => UsingLoopFirstElement(data, 100);
        static int UsingLoopFirstElement(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return array[i];
                }
            }
            throw new InvalidOperationException("Element not found");
        }

        [Benchmark]
        public int UsingLoopLastElement() => UsingLoopLastElement(data, 100);
        static int UsingLoopLastElement(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > value)
                {
                    return array[i];
                }
            }
            throw new InvalidOperationException("Element not found");
        }
    }

    class Program
    {
        static void Main()
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }

    public static class Extensions
    {
        public static T[] Fill<T>(this T[] array, T value)
        {
            for (int x = 0; x < array.Length; x++)
            {
                array[x] = value;
            }
            return array;
        }

        public static T First<T>(this T[] array, Func<T, bool> predicate)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    return array[i];
                }
            }

            throw new InvalidOperationException("Element not found");
        }
    }
}
