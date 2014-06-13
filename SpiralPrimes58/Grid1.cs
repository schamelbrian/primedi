using System;

namespace SpiralPrimes58
{
	public class intpair
	{
		public int x = 0;
		public int y = 0;

		public intpair(int X, int Y)
		{
			x = X;
			y = Y;
		}

		public intpair()
		{
		}
		public static intpair operator +(intpair p1, intpair p2)
		{
			return new intpair(p1.x + p2.x, p1.y + p2.y);
		}
		
		public static intpair operator -(intpair p1, intpair p2)
		{
			return new intpair(p1.x - p2.x, p1.y - p2.y);
		}

		public static intpair operator *(intpair p, int scalar)
		{
			return new intpair(p.x * scalar, p.y * scalar);
		}
	}
	class Grid<T>
	{
		private int size;
		public T[][] table;

		public T badval;
		public int Size { get { return size; } }

		public Grid(int thesize)
		{
			maketable(thesize);
			size = thesize;
		}
		public T this[intpair coords]
		{
			get { return this[coords.x, coords.y]; }
			set { this[coords.x, coords.y] = value; }
		}
		public T this[int x, int y]
		{
			get { return table[y][x]; }
			set { table[y][x] = value; }
		}
		public Grid(int thesize, T defval)
		{

			maketable(thesize);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					table[i][j] = defval;
				}
			}

			badval = defval;
		}

		public Grid(T[][] theparam)
		{
			size = theparam.Length;
			table = new T[theparam.Length][];
			for (int i = 0; i < size; i++)
			{
				table[i] = new T[theparam.Length];
				for (int j = 0; j < size; j++)
				{
					table[i][j] = theparam[i][j];
				}
			}


			ToString();
		}

		public void maketable(int thesize)
		{
			size = thesize;
			table = new T[thesize][];
			for (int i = 0; i < thesize; i++)
			{
				table[i] = new T[thesize];
			}
		}

		public void filltable(T val)
		{
			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					table[i][j] = val;
		}

		public string ToString(int minlength)
		{
			string ret = "";
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					string sval = " ";
					if (table[i][j].ToString() != badval.ToString())
						sval = table[i][j].ToString() + " ";
					else
						sval = "?";
					while (sval.Length < minlength)
						sval += " ";
					ret += sval;
				}

				ret += '\n';
			}
			return ret;
		}

		public override string ToString()
		{
			int maxlength = 0;

			for (int i = 0; i < size; i++)
				for (int j = 0; j < size; j++)
					if (table[i][j].ToString() != badval.ToString())
						maxlength = Math.Max(maxlength, table[i][j].ToString().Length + 1);

			return ToString(maxlength);
		}

		public static implicit operator string(Grid<T> g)
		{
			return g.ToString();
		}
	}
}
