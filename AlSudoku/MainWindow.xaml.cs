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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool isStart;
		public MainWindow()
		{
			InitializeComponent();
			spRules.Visibility = Visibility.Collapsed;
			spField.Visibility = Visibility.Collapsed;
			spDigits.Visibility = Visibility.Collapsed;
			btnStart.IsEnabled = false;
			btnReset.IsEnabled = false;
			isStart = false;
			tbRules.Text =
				"Игровое поле представляет собой квадрат размером 9×9, разделённый на меньшие квадраты со стороной в 3 клетки. " +
				"Таким образом, всё игровое поле состоит из 81 клетки. В них уже в начале игры стоят некоторые числа (от 1 до 9), " +
				"называемые подсказками. От игрока требуется заполнить свободные клетки цифрами от 1 до 9 так, чтобы в каждой строке, " +
				"в каждом столбце и в каждом малом квадрате 3×3 каждая цифра встречалась бы только один раз.";
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void btnRules_Click(object sender, RoutedEventArgs e)
		{
			spChoice.Visibility = Visibility.Collapsed;
			spField.Visibility = Visibility.Collapsed;
			spRules.Visibility = Visibility.Visible;
			btnStart.IsEnabled = true;
			if (isStart)
			{
				btnReset.IsEnabled = true;
				btnReset.Content = "Вернуться в игру";
			}
		}

		private void btnStart_Click(object sender, RoutedEventArgs e)
		{
			if (isStart)
			{
				MessageBoxResult result = MessageBox.Show("Вы действительно хотите начать новую игру?\nВаш текущий результат будет утерян.",
				"Внимание", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					cnsField.Children.Clear();
					spRules.Visibility = Visibility.Collapsed;
					spField.Visibility = Visibility.Collapsed;
					spChoice.Visibility = Visibility.Visible;
					isStart = false;
					btnReset.IsEnabled = false;
					btnReset.Content = "Начать сначала";
					btnStart.IsEnabled = false;
					return;
				}
			}
		}

		private void btn1_Click(object sender, RoutedEventArgs e)
		{
			AfterChoice(1);
		}

		private void btn2_Click(object sender, RoutedEventArgs e)
		{
			AfterChoice(2);
		}

		private void btn3_Click(object sender, RoutedEventArgs e)
		{
			AfterChoice(3);
		}

		private void btn4_Click(object sender, RoutedEventArgs e)
		{
			AfterChoice(4);
		}

		private void btn5_Click(object sender, RoutedEventArgs e)
		{
			AfterChoice(5);
		}

		private void AfterChoice(int difficult)
		{
			spChoice.Visibility = Visibility.Collapsed;
			spField.Visibility = Visibility.Visible;
			isStart = true;
			btnReset.IsEnabled = true;
			btnStart.IsEnabled = true;
			Field.FillField(cnsField);
		}

		private void spField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Point point = e.GetPosition(this);
			double xShift = SelectShift(point.X, true);
			double yShift = SelectShift(point.Y, false);
			spDigits.Visibility = Visibility.Visible;
			borderCanvas.Margin = new Thickness(xShift, yShift, 0, 0);
			LogicDigits.PaintCells(cnsDigits);
		}

		private double SelectShift(double coordinate, bool isWidth)
		{
			double shift = 0;
			double side = isWidth ? borderCanvas.Width : borderCanvas.Height;
			double fieldSide = isWidth ? cnsField.Width : cnsField.Height;
			if (coordinate - side / 2 >= 0 && coordinate + side / 2 <= fieldSide)
			{
				shift = coordinate - side / 2 + 1;
			}
			else
			{
				if (coordinate - side / 2 < 0)
				{
					shift = 1;
				}
				else
				{
					shift = fieldSide - side;
				}
			}
			return shift;
		}
	}


}
