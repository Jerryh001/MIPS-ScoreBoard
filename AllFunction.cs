using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    static class AllFunction
    {
        static public List<FunctionalUnit> Func;
        static Dictionary<string, string> table;
        static AllFunction()
        {
            Init();
        }
        static public void Init()
        {
            table = new Dictionary<string, string>();
            table.Add("L.D", "Integer");
            table.Add("SUB.D", "Add");
            table.Add("ADD.D", "Add");
            table.Add("MUL.D", "Mult");
            table.Add("DIV.D", "Devide");
            Func = new List<FunctionalUnit>(new FunctionalUnit[] { new FunctionalUnit("Integer", 1), new FunctionalUnit("Mult1", 10), new FunctionalUnit("Mult2", 10), new FunctionalUnit("Add", 2), new FunctionalUnit("Devide", 40) });
        }
        static public FunctionalUnit GetFunctionUnit(Instruction ins)
        {
            List<FunctionalUnit> possible = new List<FunctionalUnit>();
            foreach(FunctionalUnit f in Func)
            {
                if(f.GetData("Name").Contains(table[ins.OP]))
                {
                    possible.Add(f);
                }
            }
            foreach (FunctionalUnit f in possible)
            {
                if(f.Line==ins.line||!f.Busy)
                {
                    return f;
                }
            }
            return possible.First();
        }

        internal static FunctionalUnit GetFunctionUnitName(string name)
        {
            foreach (FunctionalUnit f in Func)
            {
                if (f.GetData("Name").Equals(name))
                {
                    return f;
                }
            }
            return null;
        }
    }
}
