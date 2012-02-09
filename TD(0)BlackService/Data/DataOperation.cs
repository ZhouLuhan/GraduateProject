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
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            if (!blackTD0.STATEs.Any(p => p.MSTATE == state))
            {
                STATE tmps = new STATE();
                if (blackTD0.STATEs.Count() > 0) tmps.SNO = blackTD0.STATEs.Max(p => p.SNO) + 1;
                else tmps.SNO = 0;
                tmps.MSTATE = state;
                blackTD0.STATEs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
            }
        }

        public static void InsertStrategy(string strategy)
        {
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            if (!blackTD0.ASTRATEGies.Any(p => p.STRATEGY == strategy))
            {
                ASTRATEGY tmps = new ASTRATEGY();
                if (blackTD0.ASTRATEGies.Count() > 0) tmps.ANO = blackTD0.ASTRATEGies.Max(p => p.ANO) + 1;
                else tmps.ANO = 0;
                tmps.STRATEGY = strategy;
                blackTD0.ASTRATEGies.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
            }
        }

        public static void InsertVState(string state, double value)
        {
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            int sno = blackTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;

            if (!blackTD0.VSTATEs.Any(p => p.SNO == sno))
            {
                VSTATE tmps = new VSTATE();
                tmps.SNO = sno;
                tmps.VALUE = value;
                blackTD0.VSTATEs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
            }
            else
            {
                blackTD0.VSTATEs.Where(p => p.SNO == sno).Single().VALUE = value;
                blackTD0.SubmitChanges();
            }
        }

        public static void InsertVReward(string state, string stra, bool win)
        {
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            int sno = blackTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = blackTD0.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
            int times;
            if (win) times = 1;
            else times = 0;
            double vs = blackTD0.VSTATEs.Where(p => p.SNO == sno).Single().VALUE;

            if (!blackTD0.VREWARDs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.TIMES = times;
                tmps.TOTAL = 1;
                tmps.REWARD = times;
                blackTD0.VREWARDs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
            }
            else
            {
                VREWARD tmps = blackTD0.VREWARDs.Where(p => p.SNO == sno && p.ANO == ano).Single();
                tmps.TIMES += times;
                tmps.TOTAL++;
                tmps.REWARD = vs * Convert.ToDouble(times) / tmps.TOTAL;
                blackTD0.SubmitChanges();
            }
        }

        public static void InsertProb(string state, string stra, string nstate)
        {
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            int sno = blackTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = blackTD0.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
            int nsno = blackTD0.STATEs.Where(p => p.MSTATE == nstate).Single().SNO;

            if (!blackTD0.PROBs.Any(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno))
            {
                PROB tmps = new PROB();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.NSNO = nsno;
                tmps.TIMES = 1;
                blackTD0.PROBs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
            }
            else
            {
                blackTD0.PROBs.Where(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno).Single().TIMES++;
                blackTD0.SubmitChanges();
            }
        }

        public static double SelectVState(string state)
        {
            double value;
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            var tmp = from c in blackTD0.STATEs
                      from o in blackTD0.VSTATEs
                      where c.SNO == o.SNO && c.MSTATE == state
                      select o.VALUE;
            if (tmp.Count() <= 0)
            {
                VSTATE tmps = new VSTATE();
                tmps.SNO = blackTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.VALUE = 1.0;
                blackTD0.VSTATEs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
                value = 1.0;
            }
            else value = tmp.Single();
            return value;
        }

        public static double SelectReward(string state, string strategy)
        {
            double reward;
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            var tmp = from c in blackTD0.STATEs
                      from o in blackTD0.ASTRATEGies
                      from e in blackTD0.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.REWARD;

            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = blackTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = blackTD0.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                tmps.REWARD = 1.0;
                blackTD0.VREWARDs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
                reward = 1.0;
            }
            else reward = tmp.Single();
            return reward;
        }

        int SelectWinTimes(string state, string strategy)
        {
            int times;
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            var tmp = from c in blackTD0.STATEs
                      from o in blackTD0.ASTRATEGies
                      from e in blackTD0.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.TIMES;
            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = blackTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = blackTD0.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                tmps.REWARD = 1.0;
                blackTD0.VREWARDs.InsertOnSubmit(tmps);
                blackTD0.SubmitChanges();
                times = 0;
            }
            else times = tmp.Single();
            return times;
        }

        public static VSTimes[] SelectProbTimes(string state, string strategy)
        {
            VSTimes[] tmps = new VSTimes[10000];
            BlackTD0DataContext blackTD0 = new BlackTD0DataContext();
            var tmp = from c in blackTD0.STATEs
                      from o in blackTD0.ASTRATEGies
                      from e in blackTD0.PROBs
                      from f in blackTD0.VSTATEs
                      where c.SNO == e.SNO && f.SNO == c.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select new
                      {
                          f.VALUE,
                          e.TIMES
                      };
            if (tmp.Count() > 0)
            {
                for (int i = 0; i < tmp.Count(); i++)
                    tmps[i] = new VSTimes(tmp.ElementAt(i).VALUE, tmp.ElementAt(i).TIMES);
            }
            return tmps;
        }
    }
}
