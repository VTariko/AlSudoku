using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace AlSudoku
{
	class Field
	{
		private static Canvas _canvas;
		private const int SIZE = 9;
		private const int SIZE_CUBE = 3;
		private static int _w;
		private static int _h;
		private static int _wCell;
		private static int _hCell;

		public static void FillField(Canvas cns)
		{
			_canvas = cns;
			_canvas.Children.Clear();
			_w = Convert.ToInt32(_canvas.Width);
			_h = Convert.ToInt32(_canvas.Height);
			_wCell = _w/SIZE;
			_hCell = _h/SIZE;

			for (int i = 0; i < SIZE; i++)
			{
				Line hLine = new Line
				{
					Stroke = System.Windows.Media.Brushes.LightSteelBlue,
					X1 = i*_wCell,
					Y1 = 0,
					X2 = i*_wCell,
					Y2 = _h,
					StrokeThickness = 1
				};
				_canvas.Children.Add(hLine);
				Line wLine = new Line
				{
					Stroke = System.Windows.Media.Brushes.LightSteelBlue,
					X1 = 0,
					Y1 = i*_hCell,
					X2 = _w,
					Y2 = i*_hCell,
					StrokeThickness = 1
				};
				_canvas.Children.Add(wLine);
			}

			_wCell = _w / SIZE_CUBE;
			_hCell = _h / SIZE_CUBE;

			for (int i = 1; i < SIZE_CUBE; i++)
			{
				Line hLine = new Line
				{
					Stroke = System.Windows.Media.Brushes.Black,
					X1 = i * _wCell,
					Y1 = 0,
					X2 = i * _wCell,
					Y2 = _h,
					StrokeThickness = 2
				};
				_canvas.Children.Add(hLine);
				Line wLine = new Line
				{
					Stroke = System.Windows.Media.Brushes.Black,
					X1 = 0,
					Y1 = i * _hCell,
					X2 = _w,
					Y2 = i * _hCell,
					StrokeThickness = 2
				};
				_canvas.Children.Add(wLine);
			}
		}
	}
}
