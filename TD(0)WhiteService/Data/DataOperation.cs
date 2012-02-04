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
    }
}
