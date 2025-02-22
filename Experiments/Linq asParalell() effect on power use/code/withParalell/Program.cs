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

            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
            Console.WriteLine($"{numbers.AsParallel().Sum()}");
        }
    }
}