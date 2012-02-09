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

        public StrategyState()
        {
            Conv = ChessType.None;
        }

        public StrategyState(int orgr, int orgc, int slcr, int slcc)
        {
            OrgR = orgr; OrgC = orgc; SlcR = slcr; SlcC = slcc; Conv = ChessType.None;
        }

        public static string StaToStr(StrategyState state)
        {
            string ret = string.Empty;
            ret = ret + (state.OrgR + '0');
            ret = ret + (state.OrgC + 'a');
            ret = ret + (state.SlcR + '0');
            ret = ret + (state.SlcC + 'a');
            ret = ret + ChessState.ChessTypeStr[(int)state.Conv];
            return ret;
        }

        public static StrategyState StrToSta(string state)
        {
            int i;
            StrategyState stra = new StrategyState();
            stra.OrgR = state[0] - '0'; stra.OrgC = state[1] - 'a';
            stra.SlcR = state[2] - '0'; stra.SlcC = state[3] - 'a';
            for (i = 0; i < ChessState.ChessTypeStr.Length; ++i)
                if (state[4] == ChessState.ChessTypeStr[i]) break;
            stra.Conv = (ChessType)i;
            return stra;
        }
    }
}
