using System;
using System.Collections.Generic;

namespace SpiralPrimes58
{
	public class circArray<T> : List<T>
	{
		public T this[int index]
		{
			get
			{
				while (true)
					try
					{
						return base[index];
					}
					catch (ArgumentOutOfRangeException)
					{
						if (index < 0)
							index += Count;
						else
							index -= Count;
					}
			}

		}
	}

	class SpiralGrid : Grid<int>
	{
		intpair center;
		int currentradius = 0;
		intpair coords;
		int currentNum;

		int topy, bottomy, leftx, rightx;
		static circArray<intpair> directions = new circArray<intpair> { new intpair(0, -1), new intpair(-1, 0), new intpair(0, 1), new intpair(1, 0) };



		public SpiralGrid(int spiralRadius) : base(spiralRadius * 2 + 1)
		{
			currentNum = 1;
			center = new intpair(spiralRadius, spiralRadius);
			coords = new intpair(center.x, center.y);
			base[coords] = currentNum;
			coords.x++;
			currentNum++;
			base[coords] = currentNum;

			topy = bottomy = center.y;
			leftx = rightx = center.x;


		}
		public void addSpiral()
		{

			try
			{
				for (int i = 0; i < directions.Count; i++)
				{
					do
					{
						currentNum++;
						coords += directions[i];
						base[coords] = currentNum;
					} while (base[coords + directions[i + 1]] != 0);
				}
				base[coords] = currentNum;
			}

			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				//Console.WriteLine(ToString());
			}

			currentradius++;

			bottomy++;
			topy--;
			leftx--;
			rightx++;
			//currentNum++;
		}

		public List<intpair> getDiagonals()
		{
			List<intpair> r = new List<intpair>();

			for (int i = 0; i < Size; i++)
			{
				intpair t = new intpair();
				t.x = base[i, i];
				if (t.y != 1)
					t.y = base[i, Size - 1 - i];
				r.Add(t);
			}

			return r;
		}

		public int[] getCorners()
		{
			return new int[] { base[bottomy, leftx], base[topy, leftx], base[topy, rightx], /*base[bottomy, rightx]*/ };
		}

		public int radius
		{
			get { return currentradius; }
		}



	}
}
