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
using System.Windows.Shapes;

namespace ChessPresenter
{
    /// <summary>
    /// Interaction logic for NewAIWindow.xaml
    /// </summary>
    public partial class NewAIWindow : Window
    {
        private AI_Information info;

        public NewAIWindow()
        {
            InitializeComponent();
        }

        public NewAIWindow(AI_Information _info)
        {
            InitializeComponent();
            info = _info;
        }

        private void Ok_Btn_Click(object sender, RoutedEventArgs e)
        {
            info.ServerName = textBox1.Text;
            info.URL = textBox2.Text;
            info.Type = (AIType)(comboBox1.SelectedIndex);
            this.DialogResult = true;
        }

        private void Cancel_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
