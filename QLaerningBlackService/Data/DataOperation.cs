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
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            if (!blackQlearning.STATEs.Any(p => p.MSTATE == state))
            {
                STATE tmps = new STATE();
                if (blackQlearning.STATEs.Count() > 0) tmps.SNO = blackQlearning.STATEs.Max(p => p.SNO) + 1;
                else tmps.SNO = 0;
                tmps.MSTATE = state;
                blackQlearning.STATEs.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
            }
        }

        public static void InsertStrategy(string strategy)
        {
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            if (!blackQlearning.ASTRATEGies.Any(p => p.STRATEGY == strategy))
            {
                ASTRATEGY tmps = new ASTRATEGY();
                if (blackQlearning.ASTRATEGies.Count() > 0) tmps.ANO = blackQlearning.ASTRATEGies.Max(p => p.ANO) + 1;
                else tmps.ANO = 0;
                tmps.STRATEGY = strategy;
                blackQlearning.ASTRATEGies.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
            }
        }

        public static void InsertQState(string state, string stra, double value)
        {
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            int sno = blackQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = blackQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;

            if (!blackQlearning.QSTATEs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                QSTATE tmps = new QSTATE();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.VALUE = value;
                blackQlearning.QSTATEs.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
            }
            else
            {
                blackQlearning.QSTATEs.Where(p => p.SNO == sno && p.ANO == ano).Single().VALUE = value;
                blackQlearning.SubmitChanges();
            }
        }

        public static void InsertVReward(string state, string stra, bool win)
        {
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            int sno = blackQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = blackQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;

            int times;
            if (win) times = 1;
            else times = 0;
            double vs = blackQlearning.QSTATEs.Where(p => p.SNO == sno && p.ANO == ano).Single().VALUE;

            if (!blackQlearning.VREWARDs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.TIMES = times;
                tmps.TOTAL = 1;
                tmps.REWARD = times;
                blackQlearning.VREWARDs.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
            }
            else
            {
                VREWARD tmps = blackQlearning.VREWARDs.Where(p => p.SNO == sno && p.ANO == ano).Single();
                tmps.TIMES += times;
                tmps.TOTAL++;
                tmps.REWARD = vs * Convert.ToDouble(times) / tmps.TOTAL;
                blackQlearning.SubmitChanges();
            }
        }

        //public static void InsertProb(string state, string stra, string nstate)
        //{
        //    BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
        //    int sno = whiteQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
        //    int ano = whiteQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
        //    int nsno = whiteQlearning.STATEs.Where(p => p.MSTATE == nstate).Single().SNO;

        //    if (!whiteQlearning.PROBs.Any(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno))
        //    {
        //        PROB tmps = new PROB();
        //        tmps.SNO = sno;
        //        tmps.ANO = ano;
        //        tmps.NSNO = nsno;
        //        tmps.TIMES = 1;
        //        whiteQlearning.PROBs.InsertOnSubmit(tmps);
        //        whiteQlearning.SubmitChanges();
        //    }
        //    else
        //    {
        //        whiteQlearning.PROBs.Where(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno).Single().TIMES++;
        //        whiteQlearning.SubmitChanges();
        //    }
        // }

        public static double SelectQState(string state, string stra)
        {
            double value;
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            int sno = blackQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = blackQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;

            var tmp = from c in blackQlearning.QSTATEs
                      where c.SNO == sno && c.ANO == ano
                      select c.VALUE;

            if (tmp.Count() <= 0)
            {
                QSTATE tmps = new QSTATE();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.VALUE = 1.0;
                blackQlearning.QSTATEs.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
                value = 1.0;
            }
            else value = tmp.Single();
            return value;
        }

        public static double SelectVState(string state)
        {
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            var tmp = from c in blackQlearning.STATEs
                      from e in blackQlearning.QSTATEs
                      where c.MSTATE == state && c.SNO == e.SNO
                      select e.VALUE;
            double maxQ = 0.0;
            foreach (var c in tmp)
                if (c > maxQ) maxQ = c;
            return maxQ;
        }

        public static double SelectReward(string state, string strategy, bool isKing)
        {
            double reward;
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            var tmp = from c in blackQlearning.STATEs
                      from o in blackQlearning.ASTRATEGies
                      from e in blackQlearning.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.REWARD;

            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = blackQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = blackQlearning.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                if (isKing) tmps.REWARD = 100.0;
                else tmps.REWARD = 1.0;
                blackQlearning.VREWARDs.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
                reward = tmps.REWARD;
            }
            else reward = tmp.Single();
            return reward;
        }

        int SelectWinTimes(string state, string strategy)
        {
            int times;
            BlackQlearningDataContext blackQlearning = new BlackQlearningDataContext();
            var tmp = from c in blackQlearning.STATEs
                      from o in blackQlearning.ASTRATEGies
                      from e in blackQlearning.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.TIMES;
            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = blackQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = blackQlearning.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                tmps.REWARD = 1.0;
                blackQlearning.VREWARDs.InsertOnSubmit(tmps);
                blackQlearning.SubmitChanges();
                times = 0;
            }
            else times = tmp.Single();
            return times;
        }

        //public static VSTimes[] SelectProbTimes(string state, string strategy)
        //{
        //    int i = 0;
        //    VSTimes[] tmps = new VSTimes[10000];
        //    BlackQlearningDataContext whiteQlearning = new BlackQlearningDataContext();
        //    var tmp = from c in whiteQlearning.STATEs
        //              from o in whiteQlearning.ASTRATEGies
        //              from e in whiteQlearning.PROBs
        //              from f in whiteQlearning.QSTATEs
        //              where c.SNO == e.SNO && f.SNO == c.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
        //              select new
        //              {
        //                  f.VALUE,
        //                  e.TIMES
        //              };
        //    if (tmp.Count() > 0)
        //    {
        //        foreach (var c in tmp)
        //            tmps[i++] = new VSTimes(c.VALUE, c.TIMES);
        //    }
        //    return tmps;
        //}
    }
}
