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

namespace ChessPresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private AI_Information AI_Construct(ComboBox comboBox)
        {
            AI_Information ret = new AI_Information();
            return ret;
        }

        private void NewAI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GameStart_Click(object sender, RoutedEventArgs e)
        {
            AI_Information ai_a = AI_Construct(comboBox1);
            AI_Information ai_b = AI_Construct(comboBox2);
            ChessGame chessGameWindow = new ChessGame(this, ai_a, ai_b);
            chessGameWindow.Show(); this.Hide();
        }


    }
}
