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
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            if (!whiteQlearning.STATEs.Any(p => p.MSTATE == state))
            {
                STATE tmps = new STATE();
                if (whiteQlearning.STATEs.Count() > 0) tmps.SNO = whiteQlearning.STATEs.Max(p => p.SNO) + 1;
                else tmps.SNO = 0;
                tmps.MSTATE = state;
                whiteQlearning.STATEs.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
            }
        }

        public static void InsertStrategy(string strategy)
        {
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            if (!whiteQlearning.ASTRATEGies.Any(p => p.STRATEGY == strategy))
            {
                ASTRATEGY tmps = new ASTRATEGY();
                if (whiteQlearning.ASTRATEGies.Count() > 0) tmps.ANO = whiteQlearning.ASTRATEGies.Max(p => p.ANO) + 1;
                else tmps.ANO = 0;
                tmps.STRATEGY = strategy;
                whiteQlearning.ASTRATEGies.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
            }
        }

        public static void InsertQState(string state, string stra, double value)
        {
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            int sno = whiteQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
            int ano = whiteQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;

            if (!whiteQlearning.QSTATEs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                QSTATE tmps = new QSTATE();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.VALUE = value;
                whiteQlearning.QSTATEs.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
            }
            else
            {
                whiteQlearning.QSTATEs.Where(p => p.SNO == sno && p.ANO == ano).Single().VALUE = value;
                whiteQlearning.SubmitChanges();
            }
        }

        public static void InsertVReward(string state, string stra, bool win)
        {
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            int sno = whiteQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;           
            int ano = whiteQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
           
            int times;
            if (win) times = 1;
            else times = 0;
            double vs = whiteQlearning.QSTATEs.Where(p => p.SNO == sno && p.ANO == ano).Single().VALUE;

            if (!whiteQlearning.VREWARDs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.TIMES = times;
                tmps.TOTAL = 1;
                tmps.REWARD = times;
                whiteQlearning.VREWARDs.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
            }
            else
            {
                VREWARD tmps = whiteQlearning.VREWARDs.Where(p => p.SNO == sno && p.ANO == ano).Single();
                tmps.TIMES += times;
                tmps.TOTAL++;
                tmps.REWARD = vs * Convert.ToDouble(times) / tmps.TOTAL;
                whiteQlearning.SubmitChanges();
            }
        }

        //public static void InsertProb(string state, string stra, string nstate)
        //{
        //    WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
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
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            var tmp = from c in whiteQlearning.STATEs
                      from e in whiteQlearning.ASTRATEGies
                      from o in whiteQlearning.QSTATEs
                      where c.SNO == o.SNO && e.ANO == o.ANO && c.MSTATE == state && e.STRATEGY == stra
                      select o.VALUE;
            if (tmp.Count() <= 0)
            {
                QSTATE tmps = new QSTATE();
                tmps.SNO = whiteQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = whiteQlearning.ASTRATEGies.Where(p => p.STRATEGY == stra).Single().ANO;
                tmps.VALUE = 1.0;
                whiteQlearning.QSTATEs.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
                value = 1.0;
            }
            else value = tmp.Single();
            return value;
        }

        public static double SelectVState(string state)
        {
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            var tmp = from c in whiteQlearning.STATEs
                      from e in whiteQlearning.QSTATEs
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
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            var tmp = from c in whiteQlearning.STATEs
                      from o in whiteQlearning.ASTRATEGies
                      from e in whiteQlearning.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.REWARD;

            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = whiteQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = whiteQlearning.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                if (isKing) tmps.REWARD = 100.0;
                else tmps.REWARD = 1.0;
                whiteQlearning.VREWARDs.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
                reward = tmps.REWARD;
            }
            else reward = tmp.Single();
            return reward;
        }

        int SelectWinTimes(string state, string strategy)
        {
            int times;
            WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
            var tmp = from c in whiteQlearning.STATEs
                      from o in whiteQlearning.ASTRATEGies
                      from e in whiteQlearning.VREWARDs
                      where c.SNO == e.SNO && o.ANO == e.ANO && c.MSTATE == state && o.STRATEGY == strategy
                      select e.TIMES;
            if (tmp.Count() <= 0)
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = whiteQlearning.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.ANO = whiteQlearning.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                tmps.REWARD = 1.0;
                whiteQlearning.VREWARDs.InsertOnSubmit(tmps);
                whiteQlearning.SubmitChanges();
                times = 0;
            }
            else times = tmp.Single();
            return times;
        }

        //public static VSTimes[] SelectProbTimes(string state, string strategy)
        //{
        //    int i = 0;
        //    VSTimes[] tmps = new VSTimes[10000];
        //    WhiteQlearningDataContext whiteQlearning = new WhiteQlearningDataContext();
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
