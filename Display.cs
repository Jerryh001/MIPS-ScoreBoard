using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS_ScoreBoard
{
    static class Display
    {
        static public Color change = Color.Red;
        static public bool NothingChange = false;
        static public void ShowInstruction(ListView insview)
        {
            NothingChange = true;
            if (insview.Items.Count == 0)
            {
                foreach (Instruction ins in InstructionSet.instruction)
                {
                    ListViewGroup g;
                    if (ins.GetStage("IS") == 0)
                    {
                        g = insview.Groups["Group_Queue"];
                    }
                    else if (ins.GetStage("WR") > 0)
                    {
                        g = insview.Groups["Group_Complete"];
                    }
                    else
                    {
                        g = insview.Groups["Group_CPU"];
                    }
                    ListViewItem l = new ListViewItem(ins.GetItem(), g);
                    l.UseItemStyleForSubItems = false;
                    insview.Items.Add(l);
                }
            }
            else
            {
                int i = 0;
                foreach (Instruction ins in InstructionSet.instruction)
                {
                    insview.Items[i].Group = null;
                    string[] s = ins.GetItem();
                    for (int j = 0;j<4;j++)
                    {

                        if (s[j+5] != insview.Items[i].SubItems[j+5].Text)
                        {
                            insview.Items[i].SubItems[j+5].Text = s[j + 5];
                            insview.Items[i].SubItems[j+5].ForeColor = change;
                            NothingChange = false;
                        }
                        else
                        {
                            insview.Items[i].SubItems[j+5].ForeColor = Color.Black;
                        }
                    }
                    i++;
                }
                i = 0;
                foreach (Instruction ins in InstructionSet.instruction)//keep order
                {
                    ListViewGroup g;
                    if (ins.GetStage("IS") == 0)
                    {
                        g = insview.Groups["Group_Queue"];
                    }
                    else if (ins.GetStage("WR") > 0)
                    {
                        g = insview.Groups["Group_Complete"];
                    }
                    else
                    {
                        g = insview.Groups["Group_CPU"];
                    }
                    insview.Items[i].Group = g;
                    i++;
                }
            }

        }
        static public void Init(ListView insview, ListView funcview, ListView regview)
        {
            insview.Items.Clear();
            funcview.Items.Clear();
            if (funcview.Items.Count == 0)
            {
                string[] func = new string[] { "Integer", "Mult1", "Mult2", "Add", "Devide" };
                foreach (string s in func)
                {
                    ListViewItem l = new ListViewItem(s);
                    l.UseItemStyleForSubItems = false;
                    funcview.Items.Add(l);
                }
            }
            regview.Items.Clear();
            regview.Items.Add("");
            regview.Items[0].UseItemStyleForSubItems = false;
            for(int i=0;i<16;i++)
            {
                regview.Items[0].SubItems.Add("");
            }
        }
        static public void Update(ListView insview, ListView funcview, ListView regview)
        {
            ShowInstruction(insview);
            ShowFunction(funcview);
            for(int i=0;i<16;i++)
            {
                if (regview.Items[0].SubItems[i].Text != RegisterSet.reg[i])
                {
                    regview.Items[0].SubItems[i].Text = RegisterSet.reg[i];
                    regview.Items[0].SubItems[i].ForeColor = change;
                }
                else
                {
                    regview.Items[0].SubItems[i].ForeColor = Color.Black;
                }
            }
        }
        static void ShowFunction(ListView funcview)
        {
            int i = 0;
            foreach (FunctionalUnit f in AllFunction.Func)
            {
                
                string[] s = f.GetItem();
                if(funcview.Items[i].SubItems.Count<s.Count())
                {
                    funcview.Items[i] = new ListViewItem(s);
                    funcview.Items[i].UseItemStyleForSubItems = false;
                    for (int j = 1; j < funcview.Items[i].SubItems.Count; j++)
                    {
                        funcview.Items[i].SubItems[j].ForeColor = change;
                    }
                }
                else
                {
                    for (int j = 1; j < funcview.Items[i].SubItems.Count; j++)
                    {

                        if (funcview.Items[i].SubItems[j].Text != s[j])
                        {
                            funcview.Items[i].SubItems[j].Text = s[j];
                            funcview.Items[i].SubItems[j].ForeColor = change;
                        }
                        else
                        {
                            funcview.Items[i].SubItems[j].ForeColor = Color.Black;
                        }
                    }
                }
                i++;
            }
        }
    }
}
