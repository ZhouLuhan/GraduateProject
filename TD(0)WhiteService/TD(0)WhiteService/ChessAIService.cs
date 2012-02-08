using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChessLaw;

namespace TD_0_WhiteService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AIService" in both code and config file together.
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
