using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessLaw;
using Data;

namespace TD_0_BlackService
{
    public class ChessAIService : IChessAIService
    {
        string[] State; string[] Strategy;
        double a = 0.2;//学习速率
        double u = 0.2;//折扣率
        int tcount;

        public void GameStart()
        {
            State = new string[10000];
            Strategy = new string[10000];
            tcount = 0;
        }

        double VPaiNextState(ChessState state, StrategyState strategy)
        {
            int Tot = 0;
            string mstate = ChessState.StateToStr(state);
            string astrategy = StrategyState.StaToStr(strategy);

            //插入决策
            DataOperation.InsertStrategy(astrategy);

            VSTimes[] NsT = new VSTimes[10000];
            NsT = DataOperation.SelectProbTimes(mstate, astrategy);

            //计算V(s+1)
            double NS = 0.0;
            for (int i = 0; i < NsT.Count(); i++)
            {
                NS += NsT[i].Vs * NsT[i].times;
                Tot += NsT[i].times;
            }
            if (Tot > 0) NS /= Tot;

            //从数据库里读出v(s)
            double vs = DataOperation.SelectVState(mstate);

            //从数据库读出瞬时回报值
            double r = DataOperation.SelectReward(mstate, astrategy);

            //计算现在的v(s)
            vs = vs + a * (r + u * NS - vs);

            return vs;
        }

        void CommonGetStra(Boolean[][] whtmp, int i, int j, ref double max, ref double[] VSmax, ref string[] Stra, ref int count, ChessState state)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (whtmp[row][col])
                    {
                        StrategyState ss = new StrategyState(i, j, row, col);
                        double Ns = VPaiNextState(state, ss);
                        if (Ns > max) { max = Ns; count = 1; VSmax[0] = Ns; Stra[0] = StrategyState.StaToStr(ss); }
                        else if (Ns == max) { VSmax[count] = Ns; Stra[count++] = StrategyState.StaToStr(ss); }
                    }
                }
            }
        }

        public string GetStrategy(ChessState state, Boolean isWhite)
        {
            int i, j, count = 0;
            double max = 0.0;
            double[] VSmax = new double[10000];
            string[] Stra = new string[10000];
            Boolean[][] whtmp;

            //插入状态
            DataOperation.InsertState(ChessState.StateToStr(state));

            for (i = 0; i < 8; i++)
            {
                for (j = 0; j < 8; j++)
                {
                    if (state.State[i][j] >= ChessType.BPawn && state.State[i][j] <= ChessType.BKing)
                    {
                        switch (state.State[i][j])
                        {
                            case ChessType.BPawn:
                                whtmp = ChessLawExe.PawnStep(state, j, i);
                                for (int row = 0; row < 8; row++)
                                {
                                    for (int col = 0; col < 8; col++)
                                    {
                                        if (whtmp[row][col])
                                        {
                                            StrategyState ss = new StrategyState(i, j, row, col);
                                            if (row == 7) ss.Conv = ChessType.BQueen;
                                            double Ns = VPaiNextState(state, ss);
                                            if (Ns > max) { max = Ns; count = 1; VSmax[0] = Ns; Stra[0] = StrategyState.StaToStr(ss); }
                                            else if (Ns == max) { VSmax[count] = Ns; Stra[count++] = StrategyState.StaToStr(ss); }

                                            if (row == 7) ss.Conv = ChessType.BKnight;
                                            Ns = VPaiNextState(state, ss);
                                            if (Ns > max) { max = Ns; count = 1; VSmax[0] = Ns; Stra[0] = StrategyState.StaToStr(ss); }
                                            else if (Ns == max) { VSmax[count] = Ns; Stra[count++] = StrategyState.StaToStr(ss); }
                                        }
                                    }
                                }
                                break;

                            case ChessType.BKnight:
                                whtmp = ChessLawExe.KnightStep(state, j, i);
                                CommonGetStra(whtmp, i, j, ref max, ref VSmax, ref Stra, ref count, state);
                                break;

                            case ChessType.BBishop:
                                whtmp = ChessLawExe.BishopStep(state, j, i);
                                CommonGetStra(whtmp, i, j, ref max, ref VSmax, ref Stra, ref count, state);
                                break;

                            case ChessType.BRook:
                                whtmp = ChessLawExe.RookStep(state, j, i);
                                CommonGetStra(whtmp, i, j, ref max, ref VSmax, ref Stra, ref count, state);
                                break;

                            case ChessType.BQueen:
                                whtmp = ChessLawExe.QueenStep(state, j, i);
                                CommonGetStra(whtmp, i, j, ref max, ref VSmax, ref Stra, ref count, state);
                                break;

                            case ChessType.BKing:
                                whtmp = ChessLawExe.KingStep(state, j, i);
                                CommonGetStra(whtmp, i, j, ref max, ref VSmax, ref Stra, ref count, state);
                                break;
                        }
                    }
                }
            }

            Random rand = new Random();
            int key = rand.Next(0, count);

            double CurrVs = VSmax[key];
            string CurrStr = Stra[key];

            //把得到的vs存入数据库
            DataOperation.InsertVState(ChessState.StateToStr(state), CurrVs);

            //把状态和决策存入数组
            State[tcount] = ChessState.StateToStr(state);
            Strategy[tcount++] = CurrStr;

            return CurrStr;
        }

        public void UpdateResult(Boolean isWin)
        {
            //更新PROB
            for (int i = 0; i < tcount - 1; i++)
                DataOperation.InsertProb(State[i], Strategy[i], State[i + 1]);

            //更新VREWARD
            for (int i = 0; i < tcount; i++)
                DataOperation.InsertVReward(State[i], Strategy[i], isWin);
        }
    }
}
