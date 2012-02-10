using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public struct VSTimes
    {
        public double Vs;
        public int times;
        public VSTimes(double vs, int prob)
        {
            Vs = vs;
            times = prob;
        }
    };

    public class DataOperation
    {

        public static void InsertState(string state)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            if (!whiteTD0.STATEs.Any(p => p.MSTATE == state))
            {
                STATE tmps = new STATE();
                if (whiteTD0.STATEs.Count() > 0) tmps.SNO = whiteTD0.STATEs.Max(p => p.SNO) + 1;
                else tmps.SNO = 0;
                tmps.MSTATE = state;
                whiteTD0.STATEs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
        }

        public static void InsertStrategy(string strategy)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            if (!whiteTD0.ASTRATEGies.Any(p => p.STRATEGY == strategy))
            {
                ASTRATEGY tmps = new ASTRATEGY();
                if (whiteTD0.ASTRATEGies.Count() > 0) tmps.ANO = whiteTD0.ASTRATEGies.Max(p => p.ANO) + 1;
                else tmps.ANO = 0;
                tmps.STRATEGY = strategy;
                whiteTD0.ASTRATEGies.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
        }

        public static void InsertVState(string state, double value)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            int sno = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;

            if (!whiteTD0.VSTATEs.Any(p => p.SNO == sno))
            {
                VSTATE tmps = new VSTATE();
                tmps.SNO = sno;
                tmps.VALUE = value;
                whiteTD0.VSTATEs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
            else
            {
                whiteTD0.VSTATEs.Where(p => p.SNO == sno).Single().VALUE = value;
                whiteTD0.SubmitChanges();
            }
        }

        public static void InsertVReward(string state, string stra, bool win)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            int sno = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = whiteTD0.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
            int times;
            if (win) times = 1;
            else times = 0;
            double vs = whiteTD0.VSTATEs.Where(p => p.SNO == sno).Single().VALUE;

            if (!whiteTD0.VREWARDs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.TIMES = times;
                tmps.TOTAL = 1;
                tmps.REWARD = times;
                whiteTD0.VREWARDs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
            else
            {
                VREWARD tmps = whiteTD0.VREWARDs.Where(p=>p.SNO == sno && p.ANO == ano).Single();
                tmps.TIMES += times;              
                tmps.TOTAL++;
                tmps.REWARD = vs * Convert.ToDouble(times) / tmps.TOTAL;
                whiteTD0.SubmitChanges();
            }
        }

        public static void InsertProb(string state, string stra, string nstate)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            int sno = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = whiteTD0.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
            int nsno = whiteTD0.STATEs.Where(p => p.MSTATE == nstate).Single().SNO;

            if (!whiteTD0.PROBs.Any(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno))
            {
                PROB tmps = new PROB();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.NSNO = nsno;
                tmps.TIMES = 1;
                whiteTD0.PROBs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
            else
            {
                whiteTD0.PROBs.Where(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno).Single().TIMES++;
                whiteTD0.SubmitChanges();
            }
        }

        public static double SelectVState(string state)
        {
            double value;
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            var tmp = from c in whiteTD0.STATEs
                      from o in whiteTD0.VSTATEs
                      where c.SNO == o.SNO && c.MSTATE == state
                      select o.VALUE;
            if (tmp.Count() <= 0)
            {
                VSTATE tmps = new VSTATE();
                tmps.SNO = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.VALUE = 1.0;
                whiteTD0.VSTATEs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
                value = 1.0;
            }
            else value = tmp.Single();
            return value;
        }

        public static double SelectReward(string state, string strategy, bool isKing)
        {
            double reward;
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            var tmp = from c in whiteTD0.STATEs
                      from o in whiteTD0.ASTRATEGies
                      from e in whiteTD0.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.REWARD;

            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = whiteTD0.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                if (isKing) tmps.REWARD = 100.0;
                else tmps.REWARD = 1.0;
                whiteTD0.VREWARDs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
                reward = tmps.REWARD;
            }
            else reward = tmp.Single();
            return reward;
        }

        int SelectWinTimes(string state, string strategy)
        {
            int times;
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            var tmp = from c in whiteTD0.STATEs
                      from o in whiteTD0.ASTRATEGies
                      from e in whiteTD0.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.TIMES;
            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = whiteTD0.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                tmps.REWARD = 1.0;
                whiteTD0.VREWARDs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
                times = 0;
            }
            else times = tmp.Single();
            return times;
        }

        public static VSTimes[] SelectProbTimes(string state, string strategy)
        {
            int i = 0;
            VSTimes[] tmps = new VSTimes[10000];
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            var tmp = from c in whiteTD0.STATEs
                      from o in whiteTD0.ASTRATEGies
                      from e in whiteTD0.PROBs
                      from f in whiteTD0.VSTATEs
                      where c.SNO == e.SNO && f.SNO == c.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select new
                      {
                          f.VALUE,
                          e.TIMES
                      };
            if (tmp.Count() > 0)
            {
                foreach(var c in tmp)
                    tmps[i++] = new VSTimes(c.VALUE, c.TIMES);
            }
            return tmps;
        }
    }
}
