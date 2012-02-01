using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLaw
{
    public delegate Boolean[][] StepJudge(ChessState state, int col, int row);

    public static class ChessLawExe
    {
        public static Boolean[][] PawnStep(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            //白棋小兵的第一步
            if (row == 1 && state.State[row][col] == ChessType.WPawn)
            {
                if (state.State[row + 1][col] == ChessType.None) ret[row + 1][col] = true;
                if (ret[row + 1][col] && state.State[row + 2][col] == ChessType.None) ret[row + 2][col] = true;
            }
            //黑棋小兵的第一步
            if (row == 6 && state.State[row][col] == ChessType.BPawn)
            {
                if (state.State[row - 1][col] == ChessType.None) ret[row - 1][col] = true;
                if (ret[row - 1][col] && state.State[row - 2][col] == ChessType.None) ret[row - 2][col] = true;
            }
            //白棋小兵的中间步
            if (row < 7 && state.State[row][col] == ChessType.WPawn)
            {
                if (state.State[row + 1][col] == ChessType.None) ret[row + 1][col] = true;
                if (col > 0 && state.State[row + 1][col - 1] >= ChessType.BPawn && state.State[row + 1][col - 1] <= ChessType.BKing) ret[row + 1][col - 1] = true;
                if (col < 7 && state.State[row + 1][col + 1] >= ChessType.BPawn && state.State[row + 1][col + 1] <= ChessType.BKing) ret[row + 1][col + 1] = true;
            }
            //黑棋小兵的中间步
            if (row > 0 && state.State[row][col] == ChessType.BPawn)
            {
                if (state.State[row - 1][col] == ChessType.None) ret[row - 1][col] = true;
                if (col > 0 && state.State[row - 1][col - 1] >= ChessType.WPawn && state.State[row - 1][col - 1] <= ChessType.WKing) ret[row - 1][col - 1] = true;
                if (col < 7 && state.State[row - 1][col + 1] >= ChessType.WPawn && state.State[row - 1][col + 1] <= ChessType.WKing) ret[row - 1][col + 1] = true;
            }
            return ret;
        }

        public static Boolean[][] KnightStep(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            int[] dc = { 1, -1, -2, -2, -1, 1, 2, 2 };
            int[] dr = { -2, -2, -1, 1, 2, 2, 1, -1 };
            int tcol, trow;

            for (int i = 0; i < 8; i++)
            {
                tcol = col + dc[i]; trow = row + dr[i];
                if (tcol >= 0 && tcol < 8 && trow >= 0 && trow < 8)
                {
                    //白马
                    if (state.State[row][col] == ChessType.WKnight)
                    {
                        if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.BPawn && state.State[trow][tcol] <= ChessType.BKing)
                            ret[trow][tcol] = true;
                    }
                    //黑马
                    if (state.State[row][col] == ChessType.BKnight)
                    {
                        if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.WPawn && state.State[trow][tcol] <= ChessType.WKing)
                            ret[trow][tcol] = true;
                    }
                }
            }

            return ret;
        }

        public static Boolean[][] BishopStep(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            int[] dc = { 1, -1, -1, 1 };
            int[] dr = { -1, -1, 1, 1 };

            int tcol, trow;
  
            for (int i = 0; i < 4; i++)
            {
                tcol = col; trow = row;
                for (int j = 1; j < 8; j++)
                {
                    tcol += dc[i]; trow += dr[i];
                    if (tcol >= 0 && tcol <= 7 && trow >= 0 && trow <= 7)
                    {
                        //白主教
                        if (state.State[row][col] == ChessType.WBishop)
                        {
                            if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.BPawn && state.State[trow][tcol] <= ChessType.BKing)
                                ret[trow][tcol] = true;
                            if (state.State[trow][tcol] != ChessType.None) break;
                        }
                        //黑主教
                        if (state.State[row][col] == ChessType.BBishop)
                        {
                            if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.WPawn && state.State[trow][tcol] <= ChessType.WKing)
                                ret[trow][tcol] = true;
                            if (state.State[trow][tcol] != ChessType.None) break;
                        }
                    }
                    else break;
                }
            }
            return ret;
        }

        public static Boolean[][] RookStep(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            int[] dc = { 1, 0, -1, 0 };
            int[] dr = { 0, -1, 0, 1 };

            int tcol, trow;

            for (int i = 0; i < 4; i++)
            {
                tcol = col; trow = row;
                for (int j = 1; j < 8; j++)
                {
                    tcol += dc[i]; trow += dr[i];
                    if (tcol >= 0 && tcol <= 7 && trow >= 0 && trow <= 7)
                    {
                        //白车
                        if (state.State[row][col] == ChessType.WRook)
                        {
                            if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.BPawn && state.State[trow][tcol] <= ChessType.BKing)
                                ret[trow][tcol] = true;
                            if (state.State[trow][tcol] != ChessType.None) break;
                        }
                        //黑车
                        if (state.State[row][col] == ChessType.BRook)
                        {
                            if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.WPawn && state.State[trow][tcol] <= ChessType.WKing)
                                ret[trow][tcol] = true;
                            if (state.State[trow][tcol] != ChessType.None) break;
                        }
                    }
                    else break;
                }
            }
            return ret;
        }

        public static Boolean[][] QueenStep(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            int[] dc = { 1, -1, -1, 1, 1, 0, -1, 0 };
            int[] dr = { -1, -1, 1, 1, 0, -1, 0, 1 };

            int tcol, trow;

            for (int i = 0; i < 8; i++)
            {
                tcol = col; trow = row;
                for (int j = 1; j < 8; j++)
                {
                    tcol += dc[i]; trow += dr[i];
                    if (tcol >= 0 && tcol <= 7 && trow >= 0 && trow <= 7)
                    {
                        //白皇后
                        if (state.State[row][col] == ChessType.WQueen)
                        {
                            if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.BPawn && state.State[trow][tcol] <= ChessType.BKing)
                                ret[trow][tcol] = true;
                            if (state.State[trow][tcol] != ChessType.None) break;
                        }
                        //黑皇后
                        if (state.State[row][col] == ChessType.BQueen)
                        {
                            if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.WPawn && state.State[trow][tcol] <= ChessType.WKing)
                                ret[trow][tcol] = true;
                            if (state.State[trow][tcol] != ChessType.None) break;
                        }
                    }
                    else break;
                }
            }
            return ret;
        }

        public static Boolean[][] KingStep(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            int[] dc = { 1, -1, -1, 1, 1, 0, -1, 0 };
            int[] dr = { -1, -1, 1, 1, 0, -1, 0, 1 };

            int tcol, trow;

            for (int i = 0; i < 8; i++)
            {
                tcol = col + dc[i]; trow = row + dr[i];
                if (tcol >= 0 && tcol <= 7 && trow >= 0 && trow <= 7)
                {
                    //白王
                    if (state.State[row][col] == ChessType.WKing)
                    {
                        if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.BPawn && state.State[trow][tcol] <= ChessType.BKing)
                            ret[trow][tcol] = true;
                        
                    }
                    //黑王
                    if (state.State[row][col] == ChessType.BKing)
                    {
                        if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.WPawn && state.State[trow][tcol] <= ChessType.WKing)
                            ret[trow][tcol] = true;
                    }
                }
            }

            if (KingRookSwap(state, row, col, row, 0)) ret[row][col - 2] = true;
            else if (KingRookSwap(state, row, col, row, 7)) ret[row][col + 2] = true;

            return ret;
        }

        public static Boolean[][] KingStep1(ChessState state, int col, int row)
        {
            Boolean[][] ret = new Boolean[8][];
            for (int i = 0; i < 8; ++i) ret[i] = new Boolean[8];
            for (int i = 0; i < 8; ++i) for (int j = 0; j < 8; ++j) ret[i][j] = false;

            int[] dc = { 1, -1, -1, 1, 1, 0, -1, 0 };
            int[] dr = { -1, -1, 1, 1, 0, -1, 0, 1 };

            int tcol, trow;

            for (int i = 0; i < 8; i++)
            {
                tcol = col + dc[i]; trow = row + dr[i];
                if (tcol >= 0 && tcol <= 7 && trow >= 0 && trow <= 7)
                {
                    //白王
                    if (state.State[row][col] == ChessType.WKing)
                    {
                        if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.BPawn && state.State[trow][tcol] <= ChessType.BKing)
                            ret[trow][tcol] = true;

                    }
                    //黑王
                    if (state.State[row][col] == ChessType.BKing)
                    {
                        if (state.State[trow][tcol] == ChessType.None || state.State[trow][tcol] >= ChessType.WPawn && state.State[trow][tcol] <= ChessType.WKing)
                            ret[trow][tcol] = true;
                    }
                }
            }

            return ret;
        }

        public static bool CheckMate(ChessState state, int kr, int kc)
        {
            bool ret = false;
            ChessType Pawn, King;
            if (state.State[kr][kc] == ChessType.BKing) { Pawn = ChessType.WPawn; King = ChessType.WKing; }
            else { Pawn = ChessType.BPawn; King = ChessType.BKing; }

            Boolean[][] Step;

            for (int i = 6; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (state.State[i][j] >= Pawn && state.State[i][j] <= King)
                    {
                        switch (state.State[i][j])
                        {
                            case ChessType.WPawn:
                            case ChessType.BPawn:
                                Step = PawnStep(state, i, j);
                                if (Step[kr][kc]) return ret = true;
                                break;
                            case ChessType.WKnight:
                            case ChessType.BKnight:
                                Step = KnightStep(state, i, j);
                                if (Step[kr][kc]) return ret = true;
                                break;
                            case ChessType.WBishop:
                            case ChessType.BBishop:
                                Step = BishopStep(state, i, j);
                                if (Step[kr][kc]) return ret = true;
                                break;
                            case ChessType.WRook:
                            case ChessType.BRook:
                                Step = RookStep(state, i, j);
                                if (Step[kr][kc]) return ret = true;
                                break;
                            case ChessType.WQueen:
                            case ChessType.BQueen:
                                Step = QueenStep(state, i, j);
                                if (Step[kr][kc]) return ret = true;
                                break;
                            case ChessType.WKing:
                            case ChessType.BKing:
                                Step = KingStep1(state, i, j);
                                if (Step[kr][kc]) return ret = true;
                                break;
                        }
                    }
                }
            }
            return ret;
        }

        public static Boolean KingRookSwap(ChessState state, int kr, int kc, int rr, int rc)
        {
            Boolean ret = true;

            //条件1 是否动过
            bool move = true;
            if (state.InitState[kr][kc] && state.InitState[rr][rc]) move = false;
            if (move) return ret = false;
            
            //条件2 之间位置是否是空
            int cs, ct;
            bool empty = true;
            if (kc > rc) { cs = rc; ct = kc; }
            else { cs = kc; ct = rc; }
            for (int i = cs + 1; i < ct; i++)
                if (state.State[kr][i] != ChessType.None) empty = false;
            if (!empty) return ret = false;

            //条件3是否被将军
            if (CheckMate(state, kr, kc)) return ret = false;

            return ret;
        }

        public static WinnerType GetGameResult(ChessState state)
        {
            WinnerType ret = WinnerType.None;
            bool ew = false,eb = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (state.State[i][j] == ChessType.WKing) ew = true;
                    if (state.State[i][j] == ChessType.BKing) eb = true;
                }
            }
            if (ew && eb) ret = WinnerType.None;
            if (ew && !eb) ret = WinnerType.WhiteWin;
            if (!ew && eb) ret = WinnerType.BlackWin;

            return ret;
        }
    }
}
