using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessLaw;

namespace TD_0_BlackService
{
    public class ChessAIService : IChessAIService
    {
        public void GameStart()
        {
        }

        public string GetStrategy(ChessState state, Boolean isWhite)
        {
            return "abcde";
        }

        public void UpdateResult(Boolean isWin)
        {
        }

    }
}
