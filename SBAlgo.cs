using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS_ScoreBoard
{
    static class SBAlgo
    {
        static public int Slove(ListView insview, ListView funcview, ListView regview,int s=-1)
        {
            int step = 1;
            for (; !InstructionSet.NotThingToDo(); step++)
            {
                if (s >= 0 && step > s)
                {
                    return step;
                }
                TryIssue(step);
                TryReadOperand(step);
                TryExecute(step);
                TryWriteResult(step);
                EndOfStep(step);
                Display.Update(insview, funcview, regview);
                
            }
            return step;
        }

        static void TryWriteResult(int step)
        {
            foreach(FunctionalUnit f in AllFunction.Func)
            {
                if(f.Line!=0)
                {
                    Instruction ins = InstructionSet.GetInstruction(f.Line);
                    if (ins.CanWriteResult(step) && f.NotCauseRAW(step))
                    {
                        WriteResult(ins, f, step);
                    }
                }
                
            }
        }

        

        private static void WriteResult(Instruction ins,FunctionalUnit f,int step)
        {
            ins.WR = step;
            RegisterSet.Set(f.Fi, "");
            f.WriteResult();
        }
        static void TryExecute(int step)
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                if (f.Line != 0 && f.Time == 0)
                {
                    Instruction ins = InstructionSet.GetInstruction(f.Line);
                    if (ins.CanExcute(step))
                    {
                        Execute(f);
                    }
                }
            }
        }

        static void Execute(FunctionalUnit f)
        {
            f.Time = f.Period;
        }

        static void TryReadOperand(int step)
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                if (f.Line != 0)
                {
                    Instruction ins = InstructionSet.GetInstruction(f.Line);
                    if (CanRead(ins, f, step))
                    {
                        ins.ReadOperand(step);
                    }
                }
            }
        }

        private static bool CanRead(Instruction ins, FunctionalUnit f, int step)
        {
            return ins.IS < step && ins.RO == 0 && f.Rj && f.Rk;
        }
        static void EndOfStep(int step)
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                if (f.Fj.IsFReg() && !f.Rj)
                {
                    f.Qj = RegisterSet.Get(f.Fj);
                    if (f.Qj == f.Name)
                    {
                        f.Qj = "";
                    }
                }
                if (f.Fk.IsFReg() && !f.Rk)
                {
                    f.Qk = RegisterSet.Get(f.Fk);
                    if (f.Qk == f.Name)
                    {
                        f.Qk = "";
                    }
                }
                if (f.Time > 0)
                {
                    f.Time--;
                    if (f.Time == 0)
                    {
                        foreach (Instruction ins in InstructionSet.instruction)
                        {
                            if (f.Line == ins.line)
                            {
                                ins.EC = step;
                            }
                        }
                    }
                }
            }
        }

        static void TryIssue(int step)
        {
            foreach (Instruction ins in InstructionSet.instruction)
            {
                if (ins.IS == 0)
                {
                    FunctionalUnit f = AllFunction.GetFunctionUnit(ins);
                    if (CanIssue(ins, f))
                    {
                        Issue(ins, f, step);

                    }
                    return;
                }
            }
        }

        static void Issue(Instruction ins, FunctionalUnit f, int step)
        {
            f.Issue(ins);
            ins.IS = step;
            RegisterSet.Set(ins.Dest, f.Name);
        }

        static bool CanIssue(Instruction ins, FunctionalUnit f)
        {
            return f.Busy == false && RegisterSet.Get(ins.Dest) == "";
        }
    }
}
