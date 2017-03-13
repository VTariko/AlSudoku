using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlSudoku;

namespace TestConsole
{
	class Program
	{
		private static int[,] _northWest = new int[3, 3];
		private static int[,] _north = new int[3, 3];
		private static int[,] _northEast = new int[3, 3];
		private static List<int[,]> _rowNorth;
		private static int _size = 3;
		static void Main(string[] args)
		{

			int a = 1;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					_northWest[i, j] = ++a;
					_northEast[i, j] = a--;
					_north[i, j] = a++;
				}
			}

			Print();
			Console.WriteLine(new string('-', 20));
			_rowNorth = new List<int[,]>
			{
				_northWest,
				_north,
				_northEast
			};
			//CheckVertical(_rowNorth);
			Print();
			Console.WriteLine(new string('-', 20));
			CheckHorizontal(_rowNorth);
			Print();
			
			Console.ReadKey();
		}

		private static void Print()
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write("{0}\t", _north[i, j]);
				}
				Console.WriteLine();
			}

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write("{0}\t", _northWest[i, j]);
				}
				Console.WriteLine();
			}

			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Console.Write("{0}\t", _northEast[i, j]);
				}
				Console.WriteLine();
			}
		}

		private static void CheckVertical(List<int[,]> column)
		{
			for (int i = 0; i < _size; i++)
			{
				List<int> line = new List<int>();
				foreach (int[,] array in column)
				{
					for (int j = 0; j < _size; j++)
					{
						line.Add(array[j, i]);
					}
				}
				CheckLine(line, column, i, false);
			}
		}

		private static void CheckHorizontal(List<int[,]> row)
		{
			for (int i = 0; i < _size; i++)
			{
				List<int> line = new List<int>();
				foreach (int[,] array in row)
				{
					for (int j = 0; j < _size; j++)
					{
						line.Add(array[i, j]);
					}
				}
				CheckLine(line, row, i, true);
			}

		}

		private static void CheckLine(List<int> line, List<int[,]> row, int i, bool isRow)
		{
			List<int> query = line.GroupBy(x => x)
				.Where(g => g.Count() > 1)
				.Select(y => y.Key)
				.ToList();
			foreach (int n in query)
			{
				MarkNumber(n, row, i, isRow);
			}
		}

		private static void MarkNumber(int n, List<int[,]> row, int i, bool isRow)
		{
			foreach (int[,] ints in row)
			{
				for (int j = 0; j < _size; j++)
				{
					if (isRow)
					{
						if (ints[i, j] == n)
						{
							ints[i, j] = 0;
						}
					}
					else
					{
						if (ints[j, i] == n)
						{
							ints[j, i] = 0;
						}
					}
				}
			}
		}
	}
}