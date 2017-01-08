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
        static public uint Slove(int s=-1)
        {
            uint step = 1;
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
            }
            return step-1;
        }

        static void TryWriteResult(uint step)
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

        

        private static void WriteResult(Instruction ins,FunctionalUnit f,uint step)
        {
            ins.WriteResult(step);
            DifftableList.SetValueReg(step, f.Fi, "");
            RegisterSet.Clear(f.Fi);
            f.WriteResult(step);
        }
        static void TryExecute(uint step)
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                if (f.Line != 0 && f.GetTime() == 0)
                {
                    Instruction ins = InstructionSet.GetInstruction(f.Line);
                    if (ins.CanExcute(step))
                    {
                        f.Execute(step);
                    }
                }
            }
        }
        static void TryReadOperand(uint step)
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

        private static bool CanRead(Instruction ins, FunctionalUnit f, uint step)
        {
            return ins.GetStage("IS") < step && ins.GetStage("RO") == 0 && f.Rj && f.Rk;
        }
        static void EndOfStep(uint step)
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                f.ReadyCheck(step);
                f.Tick(step);
            }
        }

        static void TryIssue(uint step)
        {
            foreach (Instruction ins in InstructionSet.instruction)
            {
                if (ins.GetStage("IS") == 0)
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

        static void Issue(Instruction ins, FunctionalUnit f, uint step)
        {
            f.Issue(ins,step);
            ins.Issue(step);
            DifftableList.SetValueReg(step, ins.Dest, f.GetData("Name"));
            RegisterSet.Set(ins.Dest, f.GetData("Name"));
        }

        static bool CanIssue(Instruction ins, FunctionalUnit f)
        {
            return f.Busy == false && RegisterSet.Get(ins.Dest) == "";
        }
    }
}
