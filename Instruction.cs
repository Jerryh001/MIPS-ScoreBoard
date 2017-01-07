using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    public enum type { Normal,FReg, RReg };
    public struct factor
    {
        public type type;
        public string value;
        public override string ToString()
        {
            string prefix="";
            switch (type)
            {
                case type.FReg:
                    prefix = "F";
                    break;
                case type.RReg:
                    prefix = "R";
                    break;
            }
            return prefix+value;
        }
        public bool IsFReg()
        {
            return type == type.FReg;
        }
    }
    class Instruction
    {
        public int line;
        public string OP;
        public factor Dest,S1,S2;
        public int IS =0, RO=0, EC=0, WR=0;

        internal bool CanWriteResult(int step)
        {
            return EC > 0 && EC < step && WR == 0;
        }

        public Instruction(string s,int l=0)
        {
            line = l;
            string[] s_sp = s.Split(new string[] { ","," ", "(",")" }, StringSplitOptions.RemoveEmptyEntries);
            OP = s_sp[0];
            switch(s_sp[1][0])
            {
                case 'F':
                    Dest.type = type.FReg;
                    Dest.value = s_sp[1].Substring(1);
                    break;
                case 'R':
                    Dest.type = type.RReg;
                    Dest.value = s_sp[1].Substring(1);
                    break;
                default:
                    Dest.type = type.Normal;
                    Dest.value = s_sp[1];
                    break;
            }
            switch (s_sp[2][0])
            {
                case 'F':
                    S1.type = type.FReg;
                    S1.value = s_sp[2].Substring(1);
                    break;
                case 'R':
                    S1.type = type.RReg;
                    S1.value = s_sp[2].Substring(1);
                    break;
                default:
                    S1.type = type.Normal;
                    S1.value = s_sp[2];
                    break;
            }
            switch (s_sp[3][0])
            {
                case 'F':
                    S2.type = type.FReg;
                    S2.value = s_sp[3].Substring(1);
                    break;
                case 'R':
                    S2.type = type.RReg;
                    S2.value = s_sp[3].Substring(1);
                    break;
                default:
                    S2.type = type.Normal;
                    S2.value = s_sp[3];
                    break;
            }
        }

        internal bool CanExcute(int step)
        {
            return RO > 0 && RO < step && EC == 0;
        }

        public string[] GetItem()
        {
            return new string[] { line.ToString(), OP, Dest.ToString(), S1.ToString(), S2.ToString(), IS.ToString(), RO.ToString(), EC.ToString(), WR.ToString() };
        }

        internal void ReadOperand(int step)
        {
            RO = step;
        }
    }
}
