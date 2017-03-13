using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AlSudoku
{
	class LogicDigits
	{
		private static Canvas _canvas;
		private const int SIZE_CUBE = 3;
		private static int _w;
		private static int _h;
		private static int _wCell;
		private static int _hCell;

		public static void PaintCells(Canvas cns)
		{
			_canvas = cns;
			_canvas.Children.Clear();
			_canvas.Background = Brushes.BlanchedAlmond;
			_w = Convert.ToInt32(_canvas.Width);
			_h = Convert.ToInt32(_canvas.Height);
			_wCell = _w / SIZE_CUBE;
			_hCell = _h / SIZE_CUBE;
			for (int i = 1; i < SIZE_CUBE; i++)
			{
				Line hLine = new Line
				{
					Stroke = Brushes.Black,
					X1 = i * _wCell,
					Y1 = 0,
					X2 = i * _wCell,
					Y2 = _h,
					StrokeThickness = 1
				};
				_canvas.Children.Add(hLine);
				Line wLine = new Line
				{
					Stroke = Brushes.Black,
					X1 = 0,
					Y1 = i * _hCell,
					X2 = _w,
					Y2 = i * _hCell,
					StrokeThickness = 1
				};
				_canvas.Children.Add(wLine);
			}
			PaintDigits();
		}

		public static void PaintDigits()
		{
			for (int i = 0; i < SIZE_CUBE * SIZE_CUBE; i++)
			{
				int number = i + 1;
				TextBlock tbDigit = new TextBlock { Text = number.ToString(), FontSize = 18 };
				_canvas.Children.Add(tbDigit);
				Size size = MeasureString(number.ToString(), tbDigit);
				tbDigit.Margin = new Thickness(_wCell*(i%SIZE_CUBE) + (_wCell - size.Width)/2,
					_hCell*(i/SIZE_CUBE) + (_hCell - size.Height)/2, 0, 0);
			}
		}

		private static Size MeasureString(string candidate, TextBlock textBlock)
		{
			FormattedText formattedText = new FormattedText(
				candidate,
				CultureInfo.CurrentUICulture,
				FlowDirection.LeftToRight,
				new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch),
				textBlock.FontSize,
				Brushes.Black);

			return new Size(formattedText.Width, formattedText.Height);
		}
	}
}
