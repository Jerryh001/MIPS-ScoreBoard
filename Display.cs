using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS_ScoreBoard
{
    static class Display
    {
        static public void ShowInstruction(ListView insview)
        {
            insview.Items.Clear();
            foreach (Instruction ins in InstructionSet.instruction)
            {
                ListViewGroup g;
                if(ins.IS==0)
                {
                    g = insview.Groups["Group_Queue"];
                }
                else if(ins.WR>0)
                {
                    g = insview.Groups["Group_Complete"];
                }
                else
                {
                    g = insview.Groups["Group_CPU"];
                }
                insview.Items.Add(new ListViewItem(ins.GetItem(), g));
            }
        }
        static public void Init(ListView insview, ListView funcview, ListView regview)
        {
            insview.Items.Clear();
            funcview.Items.Clear();
            string[] func = new string[] { "Integer","Mult1","Mult2", "Add", "Devide"};
            foreach(string s in func)
            {
                funcview.Items.Add(s);
            }
            regview.Items.Clear();
        }
        static public void Update(ListView insview, ListView funcview, ListView regview)
        {
            Init(insview, funcview, regview);
            ShowInstruction(insview);
            ShowFunction(funcview);
            regview.Items.Add(new ListViewItem(RegisterSet.reg));
        }
        static void ShowFunction(ListView funcview)
        {
            funcview.Items.Clear();
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                funcview.Items.Add(new ListViewItem(f.GetItem()));
            }
        }
    }
}
