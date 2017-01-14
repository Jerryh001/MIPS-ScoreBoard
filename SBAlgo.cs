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
        static uint step;
        static public uint Slove(int s = -1)
        {
            step = 1;
            for (; !InstructionSet.NotThingToDo(); step++)
            {
                if (s >= 0 && step > s)
                {
                    return step;
                }
                TryIssue();
                TryReadOperand();
                TryExecute();
                TryWriteResult();
                EndOfStep();
            }
            DifftableList.SetTips(step-1, "DONE!!");
            return step - 1;
        }

        static void TryWriteResult()
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                if (f.Line != 0)
                {
                    Instruction ins = InstructionSet.GetInstruction(f.Line);
                    if (ins.CanWriteResult(step) && f.NotCauseRAW(step))
                    {
                        WriteResult(ins, f);
                    }
                }

            }
        }



        private static void WriteResult(Instruction ins, FunctionalUnit f)
        {
            DifftableList.SetTips(step, ins.OP + " #" + ins.line + " writes " + ins.Dest+".");
            ins.WriteResult(step);
            DifftableList.SetValueReg(step, f.Fi, "");
            RegisterSet.Clear(f.Fi);
            f.WriteResult(step);
        }
        static void TryExecute()
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
        static void TryReadOperand()
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                if (f.Line != 0)
                {
                    Instruction ins = InstructionSet.GetInstruction(f.Line);
                    if (CanRead(ins, f))
                    {
                        DifftableList.SetTips(step, ins.OP + " #" + ins.line + " reads operands");
                        ins.ReadOperand(step);
                    }
                }
            }
        }

        private static bool CanRead(Instruction ins, FunctionalUnit f)
        {
            if (ins.GetStage("IS") < step && ins.GetStage("RO") == 0)
            {
                if (f.Rj && f.Rk)
                {
                    return true;
                }
                else
                {
                    if (!f.Rj)
                    {
                        FunctionalUnit f1 = AllFunction.GetFunctionUnitName(f.GetData("Qj"));
                        DifftableList.SetTips(step, ins.OP + " #" + ins.line + " can\'t read its operands(" + f.Fj + ") because " + f1.Op + " #" + f1.Line + " hasn\'t finished.--> avoid RAW");
                    }
                    if (!f.Rk)
                    {
                        FunctionalUnit f1 = AllFunction.GetFunctionUnitName(f.GetData("Qk"));
                        DifftableList.SetTips(step, ins.OP + " #" + ins.line + " can\'t read its operands(" + f.Fk + ") because " + f1.Op + " #" + f1.Line + " hasn\'t finished.--> avoid RAW");
                    }
                }
            }
            return false;
        }
        static void EndOfStep()
        {
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                f.ReadyCheck(step);
                f.Tick(step);
            }
        }

        static void TryIssue()
        {
            foreach (Instruction ins in InstructionSet.instruction)
            {
                if (ins.GetStage("IS") == 0)
                {
                    FunctionalUnit f = AllFunction.GetFunctionUnit(ins);
                    if (CanIssue(ins, f))
                    {
                        DifftableList.SetTips(step, "Issue " + ins.OP + " #" + ins.line);
                        Issue(ins, f);

                    }
                    return;
                }
            }
        }

        static void Issue(Instruction ins, FunctionalUnit f)
        {
            f.Issue(ins, step);
            ins.Issue(step);
            DifftableList.SetValueReg(step, ins.Dest, f.GetData("Name"));
            RegisterSet.Set(ins.Dest, f.GetData("Name"));
        }

        static bool CanIssue(Instruction ins, FunctionalUnit f)
        {
            if (f.Busy == false)
            {
                string name = RegisterSet.Get(ins.Dest);
                if (name != "")
                {
                    DifftableList.SetTips(step, ins.OP + " #" + ins.line + "can\'t issue because destination(" + ins.Dest + ") hasn\'t freed.--> avoid WAW");

                    return false;
                }
                return true;
            }
            else
            {
                DifftableList.SetTips(step, ins.OP + " #" + ins.line + "can\'t issue since " + f.GetData("Name") + " unit is busy.");
                return false;
            }
        }
    }
}
