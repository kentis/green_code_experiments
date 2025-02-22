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

            var sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

            sum = 0L;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"{sum}");

        }
    }
}