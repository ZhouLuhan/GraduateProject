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
    /// Interaction logic for ChessGame.xaml
    /// </summary>
    /// 
    public class BoardButtonPos { public int Row, Col; }
    public enum GameState { WhiteTurn, BlackTurn, GameOver }

    public partial class ChessGame : Window
    {
        private Button[][] buttons;
        private Border[][] borders;
        private GameState gameState;
        private ChessState chessState;
        private WinnerType resultState;
        private MainWindow root;
        private AI_Information whiteAI, blackAI;
        private int slcRow, slcCol;
        private StepJudge[] stepJudge;

        public ChessGame()
        {
            InitializeComponent();
        }

        public ChessGame(MainWindow _father, AI_Information _whiteAI, AI_Information _blackAI)
        {
            InitializeComponent();
            root = _father; whiteAI = _whiteAI; blackAI = _blackAI;
            this.Closed +=new EventHandler(ChessGame_Closed);
            buttons = new Button[8][]; borders = new Border[8][];
            for (int i = 0; i < 8; ++i)
            {
                buttons[i] = new Button[8];
                borders[i] = new Border[8];
            }
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j)
            {
                    BoardButtonPos buttonInfo = new BoardButtonPos();
                    buttonInfo.Row = i; buttonInfo.Col = j;
                    buttons[i][j] = new Button();
                    buttons[i][j].Background = (Convert.ToBoolean((i + j) % 2) ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.Gray));
                    buttons[i][j].DataContext = buttonInfo;
                    buttons[i][j].Click += new RoutedEventHandler(ChessBoardGrid_Click);
                    Grid.SetColumn(buttons[i][j], j); Grid.SetRow(buttons[i][j], 7-i);
                    Chessboard.Children.Add(buttons[i][j]);
                    borders[i][j] = new Border();
                    borders[i][j].BorderBrush = new SolidColorBrush(Colors.Black);
                    borders[i][j].BorderThickness = new Thickness(2.0);
                    borders[i][j].Visibility = System.Windows.Visibility.Hidden;
                    Grid.SetColumn(borders[i][j], j); Grid.SetRow(borders[i][j], 7 - i);
                    Chessboard.Children.Add(borders[i][j]);
            }
            SetupReflect();
            SetupNewGame();
        }

        void SetupReflect()
        {
            stepJudge = new StepJudge[13];
            stepJudge[1] = stepJudge[7] = ChessLawExe.PawnStep;
            stepJudge[2] = stepJudge[8] = ChessLawExe.KnightStep;
            stepJudge[3] = stepJudge[9] = ChessLawExe.BishopStep;
            stepJudge[4] = stepJudge[10] = ChessLawExe.RookStep;
            stepJudge[5] = stepJudge[11] = ChessLawExe.QueenStep;
            stepJudge[6] = stepJudge[12] = ChessLawExe.KingStep;
        }

        void SetupNewGame() 
        {
            gameState = GameState.BlackTurn;
            chessState = new ChessState();
            chessState.State[0][0] = chessState.State[0][7] = ChessType.WRook;
            chessState.State[0][1] = chessState.State[0][6] = ChessType.WKnight;
            chessState.State[0][2] = chessState.State[0][5] = ChessType.WBishop;
            chessState.State[0][3] = ChessType.WQueen; chessState.State[0][4] = ChessType.WKing;
            for (int i = 0; i < 8; ++i) chessState.State[1][i] = ChessType.WPawn;
            chessState.State[7][0] = chessState.State[7][7] = ChessType.BRook;
            chessState.State[7][1] = chessState.State[7][6] = ChessType.BKnight;
            chessState.State[7][2] = chessState.State[7][5] = ChessType.BBishop;
            chessState.State[7][3] = ChessType.BQueen; chessState.State[7][4] = ChessType.BKing;
            for (int i = 0; i < 8; ++i) chessState.State[6][i] = ChessType.BPawn;
            RenderChessBoard();
            ChangeTurn();
        }

        void RenderChessBoard()
        {
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j)
                {
                    switch (chessState.State[i][j])
                    {
                        case ChessType.BBishop:
                        case ChessType.WBishop:
                            buttons[i][j].Content = "Bishop"; break;
                        case ChessType.BPawn:
                        case ChessType.WPawn:
                            buttons[i][j].Content = "Pawn"; break;
                        case ChessType.BRook:
                        case ChessType.WRook:
                            buttons[i][j].Content = "Rook"; break;
                        case ChessType.BKnight:
                        case ChessType.WKnight:
                            buttons[i][j].Content = "Knight"; break;
                        case ChessType.BQueen:
                        case ChessType.WQueen:
                            buttons[i][j].Content = "Queen"; break;
                        case ChessType.BKing:
                        case ChessType.WKing:
                            buttons[i][j].Content = "King"; break;
                        default: buttons[i][j].Content = ""; break;
                    } if (chessState.IsWhiteChess(i, j)) buttons[i][j].Foreground = new SolidColorBrush(Colors.Aqua);
                    else buttons[i][j].Foreground = new SolidColorBrush(Colors.Black);
                }
        }

        void ChangeTurn()
        {
            gameState = 1 - gameState;
            resultState = ChessLawExe.GetGameResult(chessState);
            if (resultState != WinnerType.None)
            {
                if (resultState == WinnerType.WhiteWin) MessageBox.Show("The White Win!");
                else MessageBox.Show("The Black Win!");
                this.Close();
            }
        }

        void ChessBoardGrid_Click(object sender, RoutedEventArgs e)
        {
            BoardButtonPos buttonInfo = (sender as Button).DataContext as BoardButtonPos;
            int cr = buttonInfo.Row, cc = buttonInfo.Col;
            if (borders[cr][cc].Visibility == System.Windows.Visibility.Hidden || (slcCol == cc && slcRow == cr))
            {
                slcCol = cc; slcRow = cr;
                for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) borders[i][j].Visibility = System.Windows.Visibility.Hidden;
                borders[cr][cc].Visibility = System.Windows.Visibility.Visible;
                if (chessState.State[cr][cc] == ChessType.None) return;
                if (Convert.ToBoolean(Convert.ToInt16((gameState == GameState.WhiteTurn)) ^ Convert.ToInt16(chessState.IsBlackChess(cr, cc))))
                {
                    Boolean[][] reachable = stepJudge[Convert.ToInt32(chessState.State[cr][cc])](chessState, cc, cr);
                    for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j)
                            if (reachable[i][j]) borders[i][j].Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) borders[i][j].Visibility = System.Windows.Visibility.Hidden;
                chessState.State[cr][cc] = chessState.State[slcRow][slcCol]; chessState.InitState[cr][cc] = false;
                chessState.State[slcRow][slcCol] = ChessType.None; chessState.InitState[slcRow][slcCol] = false;
                RenderChessBoard();
                ChangeTurn();
            }
        }

        void ChessGame_Closed(object sender, EventArgs e)
        {
            root.Show();
        }
    }
}
