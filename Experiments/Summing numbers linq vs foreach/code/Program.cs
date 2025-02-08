namespace Program {
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Enumerable.Range(1, 1_000_000_000).Select(x=> (long)x).ToList<long>();

            // Warmpus
            Console.WriteLine($"---------------Warmup---------------");

            foreachSum(numbers);
            forSum(numbers);
            linqSum(numbers);
            linqParallelSum(numbers);
            
            // Real tests
            foreach (var i in Enumerable.Range(1, 10))
            {
                Console.WriteLine($"---------------Run {i}---------------");
                var foreachSumTime = foreachSum(numbers);
                var forSumTime = forSum(numbers);
                var linqSumTime = linqSum(numbers);
                var linqParallelSumTime = linqParallelSum(numbers);
                Console.WriteLine($"| {foreachSumTime} | {forSumTime} | {linqSumTime} |  {linqParallelSumTime} |");
            }
        }

        public static long foreachSum(List<long> numbers)
        {
            
            var sw = new Stopwatch();
            sw.Start();
            var sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            sw.Stop();
            //Console.WriteLine($"Foreach Sum: {sum}, Elapsed: {sw.ElapsedMilliseconds}ms");
            return sw.ElapsedMilliseconds;
        }

        public static long forSum(List<long> numbers)
        {
            var sw = new Stopwatch();
            sw.Start();
            var sum = 0L;
            for(int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            sw.Stop();
            //Console.WriteLine($"For Sum: {sum}, Elapsed: {sw.ElapsedMilliseconds}ms");
            return sw.ElapsedMilliseconds;
        }

        public static long linqSum(List<long> numbers)
        {
            var sw = new Stopwatch();
            sw.Start();
            var sum = numbers.Sum(x => x);
            sw.Stop();
            //Console.WriteLine($"Linq Sum: {sum}, Elapsed: {sw.ElapsedMilliseconds}ms");
            return sw.ElapsedMilliseconds;
        }

        public static long linqParallelSum(List<long> numbers)
        {
            var sw = new Stopwatch();
            sw.Start();
            var sum = numbers.AsParallel().Sum(x => x);
            sw.Stop();
            //Console.WriteLine($"Linq Parallel Sum: {sum}, Elapsed: {sw.ElapsedMilliseconds}ms");
            return sw.ElapsedMilliseconds;
        }
    }
}