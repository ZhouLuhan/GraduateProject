using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLaw
{
    public enum ChessType { None, WPawn, WKnight, WBishop, WRook, WQueen, WKing, BPawn, BKnight, BBishop, BRook, BQueen, BKing };
    public enum WinnerType { None, WhiteWin, BlackWin };

    public class ChessState
    {
        public ChessType[][] State { get; set; }
        public Boolean[][] InitState { get; set; }
        public static string ChessTypeStr = ".phbrqkPHBRQK";

        public ChessState()
        {
            State = new ChessType[8][];
            for (int i = 0; i < 8; ++i) State[i] = new ChessType[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) State[i][j] = ChessType.None;
            InitState = new Boolean[8][];
            for (int i = 0; i < 8; ++i) InitState[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) InitState[i][j] = true;
        }

        public void SetupNewGame()
        {
            State[0][0] = State[0][7] = ChessType.WRook;
            State[0][1] = State[0][6] = ChessType.WKnight;
            State[0][2] = State[0][5] = ChessType.WBishop;
            State[0][3] = ChessType.WQueen; State[0][4] = ChessType.WKing;
            for (int i = 0; i < 8; ++i) State[1][i] = ChessType.WPawn;
            State[7][0] = State[7][7] = ChessType.BRook;
            State[7][1] = State[7][6] = ChessType.BKnight;
            State[7][2] = State[7][5] = ChessType.BBishop;
            State[7][3] = ChessType.BQueen; State[7][4] = ChessType.BKing;
            for (int i = 0; i < 8; ++i) State[6][i] = ChessType.BPawn;
        }

        public bool IsWhiteChess(int row, int col)
        {
            if (State[row][col] >= ChessType.WPawn && State[row][col] <= ChessType.WKing) return true;
            return false;
        }

        public bool IsBlackChess(int row, int col)
        {
            if (State[row][col] >= ChessType.BPawn && State[row][col] <= ChessType.BKing) return true;
            return false;
        }

        public static string StateToStr(ChessState state)
        {
            string ret = string.Empty;
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j) ret = ret + ChessTypeStr[(int)state.State[i][j]];
            return ret;
        }

        public static ChessState StrToState(string state)
        {
            ChessState cState = new ChessState();
            for (int i = 0; i < 8; ++i)
                for (int j = 0; j < 8; ++j)
                {
                    int k;
                    for (k = 0; k < ChessTypeStr.Length; ++k)
                        if (ChessTypeStr[k] == state[i * 8 + j]) break;
                    cState.State[i][j] = (ChessType)k;
                }
            return cState;
        }
    }
}
