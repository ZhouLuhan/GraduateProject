using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLaw
{
    public static class ChessLawExe
    {
        public static List<List<Boolean>> PawnStep(ChessState state, int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> KnightStep(ChessState state, int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> BishopStep(ChessState state, int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> RookStep(ChessState state, int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> QueenStep(ChessState state, int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> KingStep(ChessState state, int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }
    }
}
