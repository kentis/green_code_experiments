namespace dotNetNewtonSoft
{
using System;
    using System.Diagnostics;
    using System.IO;
    using Newtonsoft.Json;
    class Program
    {
        static void Main(string[] args)
        {

            var json = File.ReadAllText("../data/data_1k.json");

            // Deserialize the json string 10_000 times while timing it
            JsonConvert.DeserializeObject<dynamic>(json);
            var sw = new Stopwatch();
            sw.Start();
            for (int i =0; i < 10; i++)
            {
                var obj = JsonConvert.DeserializeObject<dynamic>(json);
            }
            sw.Stop();
            Console.WriteLine($"NewtonSoft: {sw.ElapsedMilliseconds}ms");
        }
    }
}
