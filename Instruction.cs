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

        public factor(type t, string v) : this()
        {
            type = t;
            value = v;
        }

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
        public uint line;
        public string OP;
        factor[] Reg = new factor[3];
        public factor Dest { get { return Reg[0]; } set { Reg[0] = value; } }
        public factor S1 { get { return Reg[1]; } set { Reg[1] = value; } }
        public factor S2 { get { return Reg[2]; } set { Reg[2] = value; } }
        Dictionary<string, uint> Stage = new Dictionary<string, uint>();
        internal bool CanWriteResult(uint step)
        {
            return Stage["EC"] > 0 && Stage["EC"] < step && Stage["WR"] == 0;
        }



        public Instruction(string s,uint l=0)
        {
            line = l;
            string[] s_sp = s.Split(new string[] { ","," ", "(",")" }, StringSplitOptions.RemoveEmptyEntries);
            OP = s_sp[0];
            for(int i=0;i<3;i++)
            {
                type t;
                string v;
                switch (s_sp[i+1][0])
                {
                    case 'F':
                        t = type.FReg;
                        v = s_sp[i + 1].Substring(1);
                        break;
                    case 'R':
                        t = type.RReg;
                        v = s_sp[i + 1].Substring(1);
                        break;
                    default:
                        t = type.Normal;
                        v = s_sp[i + 1];
                        break;
                }
                Reg[i] = new factor(t,v);
            }
            Stage.Add("IS", 0);
            Stage.Add("RO", 0);
            Stage.Add("EC", 0);
            Stage.Add("WR", 0);
        }

        internal bool CanExcute(uint step)
        {
            return Stage["RO"] > 0 && Stage["RO"] < step && Stage["EC"] == 0;
        }

        public string[] GetItem()
        {
            return new string[] { line.ToString(), OP, Dest.ToString(), S1.ToString(), S2.ToString(), Stage["IS"].ToString(), Stage["RO"].ToString(), Stage["EC"].ToString(), Stage["WR"].ToString() };
        }
        public uint GetStage(string s)
        {
            return Stage[s];
        }
        public void SetStage(string stage,uint s)
        {
            Stage[stage] = s;
        }
        internal void WriteResult(uint step)
        {
            DifftableList.SetValueIns(step, line, "WR", step);
            Stage["WR"] = step;
        }
        internal void ExecuteComp(uint step)
        {
            DifftableList.SetValueIns(step, line, "EC", step);
            Stage["EC"] = step;
        }

        internal void ReadOperand(uint step)
        {
            DifftableList.SetValueIns(step, line, "RO", step);
            Stage["RO"] = step;
        }

        internal void Issue(uint step)
        {
            DifftableList.SetValueIns(step,line, "IS", step);
            Stage["IS"] = step;
        }
    }
}
