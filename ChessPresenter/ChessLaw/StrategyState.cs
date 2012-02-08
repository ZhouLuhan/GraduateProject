using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLaw
{
    public class StrategyState
    {
        public int OrgR { get; set; }
        public int OrgC { get; set; }
        public int SlcR { get; set; }
        public int SlcC { get; set; }
        public ChessType Conv { get; set; }

        public static string StaToStr(StrategyState state)
        {
            return "abcde";
        }

        public static StrategyState StrToSta(string state)
        {
            StrategyState stra = new StrategyState();
            return stra;
        }
    }
}
