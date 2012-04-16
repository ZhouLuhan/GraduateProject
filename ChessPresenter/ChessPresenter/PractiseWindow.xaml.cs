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
using System.Windows.Threading;
using System.IO;
using ChessLaw;

namespace ChessPresenter
{
    /// <summary>
    /// Interaction logic for PractiseWindow.xaml
    /// </summary>
    public partial class PractiseWindow : Window
    {
        private AI_Information[] aiInfo;
        private GameState gameState;
        private ChessState chessState;
        private WinnerType resultState;
        private MainWindow root;
        private int practiseTime, turnNumber, totNumber;
        private string practiseFile, logStr = string.Empty;

        public PractiseWindow()
        {
            InitializeComponent();
        }

        public PractiseWindow(MainWindow _father, AI_Information _whiteAI, AI_Information _blackAI)
        {
            InitializeComponent();
            aiInfo = new AI_Information[2];
            aiInfo[0] = _whiteAI; aiInfo[1] = _blackAI; root = _father;
            this.Closed += Window_Closed;
        }

        private void textBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.Text, @"[0-9]+");
            base.OnPreviewTextInput(e);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            root.Show();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please indicate the number of practise times");
                return;
            }
            totNumber = practiseTime = int.Parse(textBox1.Text);
            practiseFile = "Prc" + DateTime.Now.Year.ToString() + "_" + 
                           DateTime.Now.Month.ToString() + "_" +
                           DateTime.Now.Day.ToString() + "_" + 
                           DateTime.Now.Hour.ToString() + "_" + 
                           DateTime.Now.Minute.ToString() + "_" +
                           DateTime.Now.Second.ToString() + ".txt";
            textBox2.Text = "The pracise is running and you cannot operate the application.\r\nPlease wait for the end of the practise.\r\n";
            textBox2.Text += "Log file name: " + practiseFile + "\r\n";
            textBox2.Text += "Time: " + DateTime.Now.ToString() + "\r\n";
            textBox2.Text += "\r\n----------------------------------------------\r\n\r\n";
            logStr = textBox2.Text;
            SetupTheTimer();
        }

        private void SetupTheTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Tick += TimerTick;
            timer.Start();
        }

        void TimerTick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer).Stop();
            if (practiseTime <= 0) { PractiseEnd(); return; }
            practiseTime--; StartGame();
        }

        void PractiseEnd()
        {
            string fileName = System.Environment.CurrentDirectory;
            fileName += "\\PractiseLog\\" + practiseFile;
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Flush(); sw.BaseStream.Seek(0, SeekOrigin.Begin);
            sw.Write(logStr); sw.Flush(); sw.Close();
            fs.Close();
            MessageBox.Show(@"Practise end, the log will be saved at '~\PractiseLog\" + practiseFile + @"'." + "\n");
            this.Close();
        }

        void StartGame()
        {
            aiInfo[0].proxy.GameStart();
            aiInfo[1].proxy.GameStart();
            SetupNewGame(); turnNumber = 0;
            while ((resultState = ChessLawExe.GetGameResult(chessState)) == WinnerType.None)
            {
                gameState = 1 - gameState; turnNumber++;
                string str = aiInfo[(int)gameState].proxy.GetStrategy(chessState, Convert.ToBoolean(1 - gameState));
                MakeDecision(StrategyState.StrToSta(str));
            }
            textBox2.Text = "Round: " + (totNumber - practiseTime).ToString() + "\r\n";
            textBox2.Text += "Winner: ";
            if (resultState == WinnerType.WhiteWin) textBox2.Text += "White\r\n"; else textBox2.Text += "Black\r\n";
            textBox2.Text += "Total Turns: " + turnNumber.ToString() + "\r\n";
            textBox2.Text += "Time: " + DateTime.Now.ToString() + "\r\n";
            textBox2.Text += "\r\n----------------------------------------------\r\n\r\n";
            logStr += textBox2.Text;
            aiInfo[0].proxy.UpdateResult(resultState == WinnerType.WhiteWin);
            aiInfo[1].proxy.UpdateResult(resultState == WinnerType.BlackWin);
            SetupTheTimer();
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
    }
}
