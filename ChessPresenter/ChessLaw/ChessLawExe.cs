using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLaw
{
    public static class ChessLawExe
    {
        public static List<List<Boolean>> PawnStep(int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> KnightStep(int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> BishopStep(int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> RookStep(int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> QueenStep(int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }

        public static List<List<Boolean>> KingStep(int px, int py)
        {
            List<List<Boolean>> ret = new List<List<bool>>(8);
            for (int i = 0; i < 8; ++i) ret[i] = new List<bool>(8);
            return ret;
        }
    }
}
