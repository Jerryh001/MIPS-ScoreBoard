using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    static class DifftableList
    {
        static List<Difftable> Table = new List<Difftable>();
        public static List<string> tips = new List<string>();
        static public void SetValueIns(uint step,uint line, string colnum, uint value)
        {
            SizeCheck(step);
            Table[Convert.ToInt32(step-1)].SetValueIns(line, colnum, value);
        }
        static public void SetValueFunc(uint step,string name, string colnum, string value)
        {
            SizeCheck(step);
            Table[Convert.ToInt32(step - 1)].SetValueFunc(name,colnum,value);
        }
        internal static void SetValueReg(uint step, factor dest, string v)
        {
            SizeCheck(step);
            Table[Convert.ToInt32(step - 1)].SetValueReg(dest,v);
        }
        static public void SetTips(uint step,string m)
        {
            SizeCheck(step);
            tips[Convert.ToInt32(step)] += m+ "\r\n\r\n";
        }
        private static void SizeCheck(uint size)
        {
            while(Table.Count<size)
            {
                Table.Add(new Difftable());
            }
            while (tips.Count <= size)
            {
                tips.Add("");
            }
        }
        static public void Goto(uint start,uint end)
        {
            while (start<end)
            {
                Display.change = Color.Red;
                Difftable table = Table[Convert.ToInt32(start)];
                foreach(var t in table.InsTable)
                {
                    InstructionSet.GetInstruction(Convert.ToUInt32(t.Key.Item1)).SetStage(t.Key.Item2, Convert.ToUInt32(t.Value.Item2));
                }
                foreach (var t in table.FuncTable)
                {
                    AllFunction.GetFunctionUnitName(t.Key.Item1).SetData(t.Key.Item2, t.Value.Item2);
                }
                foreach (var t in table.RegTable)
                {
                    RegisterSet.SetRaw(t.Key,t.Value.Item2);
                }
                start++;
            }
            while (start > end)
            {
                Display.change = Color.Fuchsia;
                Difftable table = Table[Convert.ToInt32(start-1)];
                foreach (var t in table.InsTable)
                {
                    InstructionSet.GetInstruction(Convert.ToUInt32(t.Key.Item1)).SetStage(t.Key.Item2, Convert.ToUInt32(t.Value.Item1));
                }
                foreach (var t in table.FuncTable)
                {
                    AllFunction.GetFunctionUnitName(t.Key.Item1).SetData(t.Key.Item2, t.Value.Item1);
                }

                foreach (var t in table.RegTable)
                {
                    RegisterSet.SetRaw(t.Key, t.Value.Item1);
                }
                start--;
            }
        }

        internal static void Init()
        {
            Table = new List<Difftable>();
            tips = new List<string>();
            string s = "Latencies (clock cycles):\r\n";
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                s += f.GetData("Name") + ":" + f.Period.ToString() + "\r\n";
            }
            tips.Add(s);
        }
    }
}
