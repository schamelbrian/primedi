using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralPrimes58
{
	class Program
	{
		static bool isPrime(int num)
		{
			int sqrt = (int)Math.Ceiling(Math.Sqrt(num));
			for (int i = 3; i < sqrt; i+=2)
			{
				if (num % i == 0)
					return false;
			}

			return true;
		}
		static void Main(string[] args)
		{
			SpiralGrid s = new SpiralGrid(100);
			Console.WriteLine("GridMade");
			List<int> diagonals = new List<int>();
			diagonals.Add(1);

			int numprime = 0;
			bool done = false;
			do
			{
				s.addSpiral();
				foreach (int num in s.getCorners())
				{
					diagonals.Add(num);
					if (isPrime(num))
						numprime++;
				}

				double ratio = numprime / (double)(diagonals.Count + s.radius);
				if (ratio < .64 && ratio > .60)
					done = true;
			} while (!done);

			//Console.Write(s);
			Console.WriteLine(s.radius * 2 + 1);

			Console.ReadKey();
		}
	}
}
