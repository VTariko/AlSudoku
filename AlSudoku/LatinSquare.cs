using System.Collections.Generic;
using System.Linq;

namespace AlSudoku
{
	class LatinSquare
	{
		private List<int[,]> _allSquares;
		private List<List<int[,]>> _allRows;
		private List<List<int[,]>> _allColumns;
		private List<int[,]> _rowNorth;
		private List<int[,]> _rowCenter;
		private List<int[,]> _rowSouth;
		private List<int[,]> _columnWest;
		private List<int[,]> _columnCenter;
		private List<int[,]> _columnEast;
		private int[,] _northWest;
		private int[,] _north;
		private int[,] _northEast;
		private int[,] _west;
		private int[,] _center;
		private int[,] _east;
		private int[,] _southWest;
		private int[,] _south;
		private int[,] _southEast;
		private int _size;

		public LatinSquare(int size)
		{
			_size = size;
			_northWest = new int[_size, _size];
			_north = new int[_size, _size];
			_northEast = new int[_size, _size];
			_west = new int[_size, _size];
			_center = new int[_size, _size];
			_east = new int[_size, _size];
			_southWest = new int[_size, _size];
			_south = new int[_size, _size];
			_southEast = new int[_size, _size];

			_rowNorth = new List<int[,]>
			{
				_northWest,
				_north,
				_northEast
			};
			_rowCenter = new List<int[,]>
			{
				_west,
				_center,
				_east
			};
			_rowSouth = new List<int[,]>
			{
				_southWest,
				_south,
				_southEast
			};

			_columnWest = new List<int[,]>
			{
				_northWest,
				_west,
				_southWest
			};
			_columnCenter = new List<int[,]>
			{
				_north,
				_center,
				_east
			};
			_columnEast = new List<int[,]>
			{
				_northEast,
				_east,
				_southEast
			};

			_allSquares = new List<int[,]>
			{
				_northWest,
				_north,
				_northEast,
				_west,
				_center,
				_east,
				_southWest,
				_south,
				_southEast
			};
			_allRows = new List<List<int[,]>>
			{
				_rowNorth,
				_rowCenter,
				_rowSouth
			};
			_allColumns = new List<List<int[,]>>
			{
				_columnWest,
				_columnCenter,
				_columnEast
			};
		}

		public void CheckAll()
		{
			foreach (int[,] square in _allSquares)
			{
				CheckSquare(square);
			}
			foreach (List<int[,]> row in _allRows)
			{
				CheckVertical(row);
			}
			foreach (List<int[,]> column in _allColumns)
			{
				CheckHorizontal(column);
			}
		}

		private void CheckSquare(int[,] square)
		{

		}

		private void CheckVertical(List<int[,]> column)
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

		private void CheckHorizontal(List<int[,]> row)
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

		private void CheckLine(List<int> line, List<int[,]> row, int i, bool isRow)
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

		private void MarkNumber(int n, List<int[,]> row, int i, bool isRow)
		{
			foreach (int[,] ints in row)
			{
				//TODO: Заменить на метод окраски. Но как?
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
