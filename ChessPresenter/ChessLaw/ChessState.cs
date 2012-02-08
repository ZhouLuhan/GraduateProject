﻿using System;
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

        public ChessState()
        {
            State = new ChessType[8][];
            for (int i = 0; i < 8; ++i) State[i] = new ChessType[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) State[i][j] = ChessType.None;
            InitState = new Boolean[8][];
            for (int i = 0; i < 8; ++i) InitState[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) InitState[i][j] = true;
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
            return "abcde";
        }

        public static ChessState StrToState(string state)
        {
            ChessState cState = new ChessState();
            return cState;
        }
    }
}
