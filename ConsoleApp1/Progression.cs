using System;
using System.IO;
using Newtonsoft.Json;


namespace ConsoleApp1
{
    class Progression
    {
		public int[] array;
		public Progression(int[] numbers)
		{
			array = numbers;
		}

		public bool Is_in(int n)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == n)
				{
					return true;
				}
			}
			return false;
		}

		

		public int Max()
		{
			int max = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (max < array[i])
				{
					max = array[i];
				}
			}
			return max;
		}

		public int Min()
		{
			int min = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (min > array[i])
				{
					min = array[i];
				}
			}
			return min;
		}

		public void My_Type()
		{
			bool is_descending = true; // спадна послідовність
			bool is_ascending = true; // зростаюча послідовність
			
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (array[i] <= array[i + 1])
				{
					is_descending = false;
				}

				if (array[i] >= array[i + 1])
				{
					is_ascending = false;
				}

				
			}

			if (is_descending) { Console.WriteLine("Спадна послiдовнiсть"); }
			if (is_ascending) { Console.WriteLine("Зростаюча послiдовнiсть"); }
			

			bool is_arithmetic = true;
			bool is_geometric = true; 
			if (array.Length >= 2)
			{
				int d = array[1] - array[0];
				int q = array[1] / array[0];
				for (int i = 1; i < array.Length - 1; i++)
				{
					if (array[i + 1] - array[i] != d)
					{
						is_arithmetic = false;
					}

					if (array[i] != 0)
					{
						if (array[i + 1] / array[i] != q)
						{
							is_geometric = false;
						}
					}
					else { is_geometric = false; }
				}
			}
			if (is_arithmetic) { Console.WriteLine("Арифметична "); }
			if (is_geometric) { Console.WriteLine("Геометрична "); }
		}

		

		public int[] extremes()
		{
			string numbers = "";

			if (array.Length == 1) { numbers += array[0] + " "; }
			if (array.Length >= 2)
			{
				if (array[0] != array[1]) { numbers += array[0] + " "; }
				for (int i = 1; i < array.Length - 1; i++)
				{
					if ((array[i] < array[i - 1] & array[i] < array[i + 1]) || (array[i] > array[i - 1] & array[i] > array[i + 1]))
					{
						numbers += array[i] + " ";
					}
				}
				if (array[^1] != array[^2]) { numbers += array[^1] + " "; }
			}

			string[] s = numbers.Split(' ');
			int[] a = new int[s.Length - 1];
			for (int i = 0; i < s.Length - 1; i++) { a[i] = int.Parse(s[i]); }

			return a;
		}


		

		


		public void ToJson(string filePath)
		{
			string j = JsonConvert.SerializeObject(this);

			File.WriteAllText(filePath, j);
		}

		public static Progression FromJson(string filePath)
		{
			return JsonConvert.DeserializeObject<Progression>(File.ReadAllText(filePath));
		}


	}

}

