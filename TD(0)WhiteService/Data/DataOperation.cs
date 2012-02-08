using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    class DataOperation
    {
        void InsertState(string state)
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

        void InsertStrategy(string strategy)
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

        void InsertVState(int sno, double value)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
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

        void InsertVReward(int sno, int ano, int times, double reward)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            if (!whiteTD0.VREWARDs.Any(p => p.SNO == sno && p.ANO == ano))
            {
                VREWARD tmps = new VREWARD();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.TIMES = times;
                tmps.REWARD = reward;
                whiteTD0.VREWARDs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
            else
            {
                VREWARD tmps = whiteTD0.VREWARDs.Where(p=>p.SNO == sno && p.ANO == ano).Single();
                tmps.TIMES = times;
                tmps.REWARD = reward;
                whiteTD0.SubmitChanges();
            }
        }

        void InsertProb(int sno, int ano, int nsno, int times)
        {
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            if (!whiteTD0.PROBs.Any(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno))
            {
                PROB tmps = new PROB();
                tmps.SNO = sno;
                tmps.ANO = ano;
                tmps.NSNO = nsno;
                tmps.TIMES = times;
                whiteTD0.PROBs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
            }
            else
            {
                whiteTD0.PROBs.Where(p => p.SNO == sno && p.ANO == ano && p.NSNO == nsno).Single().TIMES = times;
                whiteTD0.SubmitChanges();
            }
        }

        double SelectVState(string state)
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

        double SelectReward(string state, string strategy)
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
                tmps.REWARD = 1.0;
                whiteTD0.VREWARDs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
                reward = 1.0;
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

        int SelectProbTimes(string state, string strategy, string nstate)
        {
            int times;
            WhiteTD0DataContext whiteTD0 = new WhiteTD0DataContext();
            var tmp = from c in whiteTD0.STATEs
                      from f in whiteTD0.STATEs
                      from o in whiteTD0.ASTRATEGies
                      from e in whiteTD0.PROBs
                      where c.SNO == e.SNO && f.SNO == e.NSNO && o.ANO == e.ANO && c.MSTATE == state && f.MSTATE == nstate && o.STRATEGY == strategy
                      select e.TIMES;
            if (tmp.Count() <= 0)
            {
                PROB tmps = new PROB();
                tmps.SNO = whiteTD0.STATEs.Where(p => p.MSTATE == state).Single().SNO;
                tmps.NSNO = whiteTD0.STATEs.Where(p => p.MSTATE == nstate).Single().SNO;
                tmps.ANO = whiteTD0.ASTRATEGies.Where(p => p.STRATEGY == strategy).Single().ANO;
                tmps.TIMES = 0;
                whiteTD0.PROBs.InsertOnSubmit(tmps);
                whiteTD0.SubmitChanges();
                times = 0;
            }
            else times = tmp.Single();
            return times;
        }
    }
}
