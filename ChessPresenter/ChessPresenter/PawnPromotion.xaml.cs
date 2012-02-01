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
using ChessLaw;

namespace ChessPresenter
{
    /// <summary>
    /// Interaction logic for PawnPromotion.xaml
    /// </summary>
    public partial class PawnPromotion : Window
    {
        private SelectedType slcType;

        public PawnPromotion()
        {
            InitializeComponent();
        }

        public PawnPromotion(SelectedType _slcType, bool _isWhite)
        {
            InitializeComponent();
            slcType = _slcType;
            if (_isWhite)
            {
                SlcRook.DataContext = ChessType.WPawn;
                SlcKnight.DataContext = ChessType.WKnight;
                SlcBishop.DataContext = ChessType.WBishop;
                SlcQueen.DataContext = ChessType.WQueen;
            }
            else
            {
                SlcRook.DataContext = ChessType.BPawn;
                SlcKnight.DataContext = ChessType.BKnight;
                SlcBishop.DataContext = ChessType.BBishop;
                SlcQueen.DataContext = ChessType.BQueen;
            }
        }

        private void SlcRook_Click(object sender, RoutedEventArgs e)
        {
            slcType.type = (ChessType)SlcRook.DataContext;
            this.Close();
        }

        private void SlcKnight_Click(object sender, RoutedEventArgs e)
        {
            slcType.type = (ChessType)SlcKnight.DataContext;
            this.Close();
        }

        private void SlcBishop_Click(object sender, RoutedEventArgs e)
        {
            slcType.type = (ChessType)SlcBishop.DataContext;
            this.Close();
        }

        private void SlcQueen_Click(object sender, RoutedEventArgs e)
        {
            slcType.type = (ChessType)SlcQueen.DataContext;
            this.Close();
        }
    }
}
