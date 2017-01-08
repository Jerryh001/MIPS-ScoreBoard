using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    class Difftable
    {
        public Dictionary<Tuple<string, string>, Tuple<string, string>> InsTable = new Dictionary<Tuple<string, string>, Tuple<string, string>>();
        public Dictionary<Tuple<string, string>, Tuple<string, string>> FuncTable = new Dictionary<Tuple<string, string>, Tuple<string, string>>();
        public Dictionary<string, Tuple<string, string>> RegTable = new Dictionary<string, Tuple<string, string>>();
        public void SetValueIns(uint line,string colnum,uint value)
        {
            Instruction ins = InstructionSet.GetInstruction(line);
            InsTable.Add(new Tuple<string, string>(line.ToString(),colnum),new Tuple<string, string>(ins.GetStage(colnum).ToString(),value.ToString()));
        }

        internal void SetValueReg(factor dest, string v)
        {
            string key = dest.ToString();
            Tuple<string, string> val;
            if (RegTable.TryGetValue(key, out val))
            {
                RegTable[key] = new Tuple<string, string>(val.Item1, v);
            }
            else
            {
                RegTable.Add(key, new Tuple<string, string>(RegisterSet.Get(dest), v));
            }
        }

        public void SetValueFunc(string name, string colnum, string value)
        {
            FunctionalUnit f = AllFunction.GetFunctionUnitName(name);
            Tuple<string, string> key=new Tuple<string, string>(name, colnum);
            Tuple<string, string> val;
            if (FuncTable.TryGetValue(key,out val))
            {
                FuncTable[key] = new Tuple<string, string>(val.Item1, value);
            }
            else
            {
                FuncTable.Add(key, new Tuple<string, string>(f.GetData(colnum), value));
            }
        }
    }
}
