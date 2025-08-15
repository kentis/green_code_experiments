namespace dotNetNewtonSoft
{
using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    class Program
    {
        static void Main(string[] args)
        {

            var json = File.ReadAllText("../data/data_1k.json");

            // warmup
            JsonSerializer.Deserialize<dynamic>(json);

            // Deserialize the json string 10_000 times while timing it

            var sw = new Stopwatch();
            sw.Start();
            for (int i =0; i < 10; i++)
            {
                var obj = JsonSerializer.Deserialize<dynamic>(json);
            }
            sw.Stop();
            Console.WriteLine($"System.Text.Json: {sw.ElapsedMilliseconds}ms");
        }
    }
}
