using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace WPF_Picture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList states = new ArrayList();

        public MainWindow()
        {
            InitializeComponent();
            StackPanel[] stacks = new StackPanel[5];

            for (int i = 0; i < 5; i++)
            {
                stacks[i] = new StackPanel();
                stacks[i].Height = 143;
                stacks[i].Width = 143;
                gridpic.Children.Add(stacks[i]);
            }
            stacks[1].Orientation = stacks[3].Orientation = Orientation.Horizontal;
            Grid.SetRow(stacks[0], 0); Grid.SetColumn(stacks[0], 1);
            Grid.SetRow(stacks[1], 1); Grid.SetColumn(stacks[1], 0);
            Grid.SetRow(stacks[2], 1); Grid.SetColumn(stacks[2], 1);
            Grid.SetRow(stacks[3], 1); Grid.SetColumn(stacks[2], 2);
            Grid.SetRow(stacks[4], 2); Grid.SetColumn(stacks[2], 1);
        }

        void InsertPicture(string state1, string state2, string trans)
        {
            int i;
            int posState1 = -1, posState2 = -1;

            //画圆角矩形
            for (i = 0; i < states.Count; i++)
            {
                if (states[i] == state1) posState1 = i;
                if (states[i] == state2) posState2 = i;
            }
            if (posState1 < 0) { states.Add(state1); PictureTangle(state1, i / 2 * 2, i % 2 * 2); posState1 = i++; }
            if (posState2 < 0) { states.Add(state2); posState2 = i; PictureTangle(state2, i / 2 * 2, i % 2 * 2); }

            //画箭头和文字
            int row1 = posState1 / 2 * 2; int col1 = posState1 % 2 * 2;
            int row2 = posState2 / 2 * 2; int col2 = posState2 % 2 * 2;
            int row = (row1 + row2) / 2;
            int col = (col1 + col2) / 2;

            double angle = 0;
            if (row1 == row2 && col1 > col2) angle = 180;
            if (row1 == row2 && col1 < col2) angle = 0;
            if (col1 == col2 && row1 > row2) angle = 270;
            if (col1 == col2 && row1 < row2) angle = 90;
            if (row1 < row2 && col1 < col2) angle = 45;
            if (row1 > row2 && col1 > col2) angle = 225;
            if (row1 > row2 && col1 < col2) angle = 315;
            if (row1 < row2 && col1 > col2) angle = 135;

            int index = 0;
            if (row == 0) index = 0;
            if (row == 1) index = row + col;
            if (row == 2) index = 4;
            PictureArrowLabel((StackPanel)gridpic.Children[index], angle, trans, row, col);
        }

        private void PictureTangle(string state, int row, int colume)
        {
            
            Rectangle rectangle = new Rectangle();
            rectangle.StrokeThickness = 3;
            rectangle.Stroke = Brushes.Black;
            rectangle.RadiusX = 30;
            rectangle.RadiusY = 30;
            rectangle.Width = 100;
            rectangle.Height = 80;

            Label label = new Label();
            label.Margin = new Thickness(0);
            label.Width = 100;
            label.Height = 80;
            label.Content = state;
            label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            
            gridpic.Children.Add(rectangle);
            gridpic.Children.Add(label);

            Grid.SetRow(rectangle, row);
            Grid.SetColumn(rectangle, colume);

            Grid.SetRow(label, row);
            Grid.SetColumn(label, colume);
        }

        private void PictureArrowLabel(StackPanel stack, double angle, string trans, int row, int colume)
        {
            Polyline arrow = new Polyline();          
            arrow.Points.Add(new Point(0, 10));
            arrow.Points.Add(new Point(120, 10));
            arrow.Points.Add(new Point(100, 0));
            arrow.Points.Add(new Point(120, 10));
            arrow.Points.Add(new Point(100, 20));

            Polyline arrow1 = new Polyline();
            arrow1.Points.Add(new Point(10, 0));
            arrow1.Points.Add(new Point(10, 120));
            arrow1.Points.Add(new Point(20, 100));
            arrow1.Points.Add(new Point(10, 120));
            arrow1.Points.Add(new Point(0, 100));

            Label label = new Label();
            //label.Height = 30;
            //label.Width = 1;
            label.Content = trans;
            label.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            label.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            stack.Children.Add(label);

            if (angle == 90 || angle == 270)
            {
                arrow1.RenderTransform = new RotateTransform(angle-90, 10, 60);
                arrow1.Stroke = Brushes.Black;
                stack.Children.Add(arrow1);
            }
            else
            {
                arrow.RenderTransform = new RotateTransform(angle, 60, 10);
                arrow.Stroke = Brushes.Black;
                stack.Children.Add(arrow);
            }
         
            Grid.SetRow(stack, row);
            Grid.SetColumn(stack, colume);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            InsertPicture("A", "B", "yes");
            InsertPicture("B", "C", "no");
            InsertPicture("C", "B", "as");
            InsertPicture("B", "A", "yeah");
            InsertPicture("C", "D", "cd");
            InsertPicture("D", "C", "ds");
            InsertPicture("A", "C", "ac");           
            InsertPicture("C", "A", "ca");
            InsertPicture("B", "D", "bd");
            InsertPicture("D", "B", "db");
        }
    }
}
