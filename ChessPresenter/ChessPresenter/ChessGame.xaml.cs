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
using System.Timers;
using System.Windows.Threading;
using ChessLaw;

namespace ChessPresenter
{
    /// <summary>
    /// Interaction logic for ChessGame.xaml
    /// </summary>
    /// 
    public class SelectedType { public ChessType type; }
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
        private AI_Information[] aiInfo;
        private int slcRow, slcCol;
        private StepJudge[] stepJudge;

        public ChessGame()
        {
            InitializeComponent();
        }

        public ChessGame(MainWindow _father, AI_Information _whiteAI, AI_Information _blackAI)
        {
            InitializeComponent();
            aiInfo = new AI_Information[2];
            root = _father; aiInfo[0] = _whiteAI; aiInfo[1] = _blackAI;
            for (int i = 0; i < 2; ++i) if (aiInfo[i] != null) aiInfo[i].proxy.GameStart();
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
            Loaded += GameLoaded;
        }

        void GameLoaded(object sender, RoutedEventArgs e)
        {
            RenderChessBoard();
            ChangeTurn();
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
        }

        void RenderChessBoard()
        {
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) borders[i][j].Visibility = System.Windows.Visibility.Hidden;
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j)
                {
                    switch (chessState.State[i][j])
                    {
                        case ChessType.BBishop:
                            SetButtonImage("picture/black_bishop.png", buttons[i][j]); break;
                        case ChessType.WBishop:
                            SetButtonImage("picture/white_bishop.png", buttons[i][j]); break;
                        case ChessType.BPawn:
                            SetButtonImage("picture/black_pawn.png", buttons[i][j]); break;
                        case ChessType.WPawn:
                            SetButtonImage("picture/white_pawn.png", buttons[i][j]); break;
                        case ChessType.BRook:
                            SetButtonImage("picture/black_rook.png", buttons[i][j]); break;
                        case ChessType.WRook:
                            SetButtonImage("picture/white_rook.png", buttons[i][j]); break;
                        case ChessType.BKnight:
                            SetButtonImage("picture/black_knight.png", buttons[i][j]); break;
                        case ChessType.WKnight:
                            SetButtonImage("picture/white_knignt.png", buttons[i][j]); break;
                        case ChessType.BQueen:
                            SetButtonImage("picture/black_queen.png", buttons[i][j]); break;
                        case ChessType.WQueen:
                            SetButtonImage("picture/white_queen.png", buttons[i][j]); break;
                        case ChessType.BKing:
                            SetButtonImage("picture/black_king.png", buttons[i][j]); break;
                        case ChessType.WKing:
                            SetButtonImage("picture/white_king.png", buttons[i][j]); break;
                        default: buttons[i][j].Content = ""; break;
                    } if (chessState.IsWhiteChess(i, j)) buttons[i][j].Foreground = new SolidColorBrush(Colors.Aqua);
                    else buttons[i][j].Foreground = new SolidColorBrush(Colors.Black);
                }
        }

        void SetButtonImage(string add, Button btn)
        {
            Uri uri = new Uri(add, UriKind.Relative);
            Image image = new Image();
            image.Source = new BitmapImage(uri);
            btn.Content = image;
        }

        void ChangeTurn()
        {
            gameState = 1 - gameState;
            resultState = ChessLawExe.GetGameResult(chessState);
            if (resultState != WinnerType.None)
            {
                if (resultState == WinnerType.WhiteWin) MessageBox.Show("The White Win!");
                else MessageBox.Show("The Black Win!");
                if (aiInfo[0] != null) aiInfo[0].proxy.UpdateResult(resultState == WinnerType.WhiteWin);
                if (aiInfo[1] != null) aiInfo[1].proxy.UpdateResult(resultState == WinnerType.BlackWin);
                this.Close(); return;
            }
            if (aiInfo[(int)gameState] != null)
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                timer.Tick += TimerTick;
                timer.Start();
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            string str = aiInfo[(int)gameState].proxy.GetStrategy(chessState, Convert.ToBoolean(1 - gameState));
            MakeDecision(StrategyState.StrToSta(str));
            RenderChessBoard();
            ChangeTurn();
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
                if (aiInfo[(int)gameState] != null) return;
                if (Convert.ToBoolean(Convert.ToInt16((gameState == GameState.WhiteTurn)) ^ Convert.ToInt16(chessState.IsBlackChess(cr, cc))))
                {
                    Boolean[][] reachable = stepJudge[Convert.ToInt32(chessState.State[cr][cc])](chessState, cc, cr);
                    for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j)
                            if (reachable[i][j]) borders[i][j].Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                StrategyState str = new StrategyState();
                str.SlcC = cc; str.SlcR = cr; str.OrgC = slcCol; str.OrgR = slcRow;
                if (chessState.State[slcRow][slcCol] == ChessType.WPawn && cr == 7)
                {
                    SelectedType slcType = new SelectedType();
                    PawnPromotion pawnPromotion = new PawnPromotion(slcType, true);
                    pawnPromotion.ShowDialog(); str.Conv = slcType.type;
                }
                else if (chessState.State[slcRow][slcCol] == ChessType.BPawn && cr == 0)
                {
                    SelectedType slcType = new SelectedType();
                    PawnPromotion pawnPromotion = new PawnPromotion(slcType, false);
                    pawnPromotion.ShowDialog(); str.Conv = slcType.type;
                }
                else str.Conv = ChessType.None;
                MakeDecision(str);
                RenderChessBoard();
                ChangeTurn();
            }
        }

        void MakeDecision(StrategyState str)
        {
            if ((chessState.State[str.OrgR][str.OrgC] == ChessType.BKing || chessState.State[str.OrgR][str.OrgC] == ChessType.WKing) &&
            System.Math.Abs(str.OrgC - str.SlcC) == 2)
            {
                if (str.OrgC > str.SlcC)
                {
                    chessState.State[str.SlcR][str.SlcC + 1] = chessState.State[str.SlcR][0]; chessState.InitState[str.SlcR][str.SlcC + 1] = false;
                    chessState.State[str.SlcR][0] = ChessType.None; chessState.InitState[str.SlcR][0] = false;
                }
                else
                {
                    chessState.State[str.SlcR][str.SlcC - 1] = chessState.State[str.SlcR][7]; chessState.InitState[str.SlcR][str.SlcC - 1] = false;
                    chessState.State[str.SlcR][7] = ChessType.None; chessState.InitState[str.SlcR][7] = false;
                }
            }
            chessState.State[str.SlcR][str.SlcC] = chessState.State[str.OrgR][str.OrgC]; chessState.InitState[str.SlcR][str.SlcC] = false;
            chessState.State[str.OrgR][str.OrgC] = ChessType.None; chessState.InitState[str.OrgR][str.OrgC] = false;
            if (str.Conv != ChessType.None) chessState.State[str.SlcR][str.SlcC] = str.Conv;
        }

        void ChessGame_Closed(object sender, EventArgs e)
        {
            root.Show();
        }
    }
}
