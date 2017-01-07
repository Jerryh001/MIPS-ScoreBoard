using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS_ScoreBoard
{
    public partial class Form1 : Form
    {
        int maxstep = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitRegisterResult();
        }

        private void InitRegisterResult()
        {
            for(int i=0;i<16;i++)
            {
                ColumnHeader Header = new ColumnHeader();
                Header.Text = 'F' + (i*2).ToString();
                Header.Width = 50;
                RegisterResultStatus.Columns.Add(Header);
            }
            label2.Text = "/"+maxstep.ToString();
        }



        private void button_open_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                Display.Init(InstructionStatus,FunctionalUnitStatus,RegisterResultStatus);
                InstructionSet.ReadFile(openFileDialog.FileName);
                AllFunction.Init();
                RegisterSet.Init();
                Display.ShowInstruction(InstructionStatus);
                maxstep = SBAlgo.Slove(InstructionStatus, FunctionalUnitStatus, RegisterResultStatus);
                label2.Text = "/" + maxstep.ToString();
                numericUpDown1.Value = maxstep;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(numericUpDown1.Value);
            if(v>maxstep)
            {
                numericUpDown1.Value = maxstep;
                return;
            }
            if(v<0)
            {
                numericUpDown1.Value = 0;
                return;
            }
            InstructionSet.ReadFile(openFileDialog.FileName);
            AllFunction.Init();
            RegisterSet.Init();
            Display.ShowInstruction(InstructionStatus);
            SBAlgo.Slove(InstructionStatus, FunctionalUnitStatus, RegisterResultStatus, (v));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            numericUpDown1_ValueChanged(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value--;
            numericUpDown1_ValueChanged(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value++;
            numericUpDown1_ValueChanged(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = maxstep;
            numericUpDown1_ValueChanged(sender, e);
        }
    }
}
