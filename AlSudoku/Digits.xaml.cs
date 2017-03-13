using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlSudoku
{
	/// <summary>
	/// Interaction logic for Digits.xaml
	/// </summary>
	public partial class Digits : Page
	{
		private const int SIZE_CUBE = 3;
		private static int _w;
		private static int _h;
		private static int _wCell;
		private static int _hCell;

		public Digits()
		{
			InitializeComponent();
		}

		public void PaintDigits()
		{
			gridDigits.Children.Clear();
			_w = Convert.ToInt32(Width);
			_h = Convert.ToInt32(Height);
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
				gridDigits.Children.Add(hLine);
				Line wLine = new Line
				{
					Stroke = Brushes.Black,
					X1 = 0,
					Y1 = i * _hCell,
					X2 = _w,
					Y2 = i * _hCell,
					StrokeThickness = 1
				};
				gridDigits.Children.Add(wLine);
			}
		}
	}
}
