using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] input = Console.ReadLine().Split(' ');
            int[] array = new int[input.Length];
            for (int i = 0; i < input.Length; i++) { array[i] = int.Parse(input[i]); }
            Progression s = new Progression(array);

            int[] list = new int[] { 1, 2, 3, 4, 5 };
            Console.Write("Max:");
            Console.WriteLine(s.Max());
            Console.Write("Min:");
            Console.WriteLine(s.Min());
            Console.WriteLine();
            s.My_Type();
            Console.WriteLine("==============");

            Console.Write("Екстремуми: ");
            for (int i = 0; i < s.extremes().Length; i++) { Console.Write(s.extremes()[i] + ";"); }

            Console.WriteLine();
            Console.WriteLine();

            

            s.ToJson("new.json");
            var json_array = Progression.FromJson("data.json");
            Console.WriteLine("json: ");
            for (int i = 0; i < json_array.array.Length; i++) { Console.Write(json_array.array[i] + " "); }

        }

    }
}
    

