using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    class FunctionalUnit
    {
        public int Line;
        public string Name, Op = "", Qj = "", Qk = "";
        public bool Busy
        {
            get { return Op != ""; }
        }
        public bool Rj
        {
            get { return Qj == ""; }
        }
        public bool Rk
        {
            get { return Qk == ""; }
        }
        public factor Fi, Fj, Fk;
        public int Time = 0;
        public int Period;
        public FunctionalUnit(string name, int p)
        {
            Name = name;
            Period = p;
        }
        public string[] GetItem()
        {
            return new string[] { Name, (Time > 0 ? Time.ToString() : ""), Busy.ToString(), Op, Fi.ToString(), Fj.ToString(), Fk.ToString(), Qj, Qk, Rj.ToString(), Rk.ToString() };
        }

        internal bool NotCauseRAW(int step)
        {
            foreach (FunctionalUnit f1 in AllFunction.Func)
            {
                if (f1.Line == 0|| this == f1) continue;
                Instruction ins = InstructionSet.GetInstruction(f1.Line);
                if (Line > f1.Line && (Fi.Equals(f1.Fj) || Fi.Equals(f1.Fk)) && (ins.RO == 0 || ins.RO == step))
                {
                    return false;
                }
            }
            return true;
        }

        internal void Issue(Instruction ins)
        {
            Op = ins.OP;
            Fi = ins.Dest;
            Fj = ins.S1;
            Fk = ins.S2;
            Qj = Fj.IsFReg() ? "a" : "";
            Qk = Fk.IsFReg() ? "a" : "";
            Line = ins.line;
        }
        internal void WriteResult()
        {
            Clear();
        }
        void Clear()
        {
            Op = "";
            Line = 0;
            Fi = new factor();
            Fj = new factor();
            Fk = new factor();
            Qj = "";
            Qk = "";
        }
    }
}
