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
        uint maxstep = 0;
        uint now;
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
            totalstep.Text = "/"+maxstep.ToString();
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                Display.Init(InstructionStatus,FunctionalUnitStatus,RegisterResultStatus);
                InstructionSet.ReadFile(openFileDialog.FileName);
                AllFunction.Init();
                RegisterSet.Init();
                DifftableList.Init();
                Display.ShowInstruction(InstructionStatus);
                maxstep = SBAlgo.Slove();
                Display.Update(InstructionStatus, FunctionalUnitStatus, RegisterResultStatus);
                tiptext.Text = DifftableList.tips[Convert.ToInt32(maxstep)];
                totalstep.Text = "/" + maxstep.ToString();
                stepnow.Maximum = maxstep;
                stepnow.Value = now = maxstep;
            }
        }

        private void stepnow_ValueChanged(object sender, EventArgs e)
        {
            DifftableList.Goto(now, Convert.ToUInt32(stepnow.Value));
            Display.Update(InstructionStatus, FunctionalUnitStatus, RegisterResultStatus);
            tiptext.Text = DifftableList.tips[Convert.ToInt32(stepnow.Value)];
            while (skipbox.Checked&&Display.NothingChange)
            {
                if(now > Convert.ToUInt32(stepnow.Value))
                {
                    try
                    {
                        stepnow.Value--;
                    }
                    catch
                    {
                        break;
                    }
                }
                else if (now < Convert.ToUInt32(stepnow.Value))
                {
                    try
                    {
                        stepnow.Value++;
                    }
                    catch
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            now = Convert.ToUInt32(stepnow.Value);
        }
        private void button_first_Click(object sender, EventArgs e)
        {
            stepnow.Value = 0;
        }
        private void button_last_Click(object sender, EventArgs e)
        {
            stepnow.Value = maxstep;
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            try
            {
                stepnow.Value++;
            }
            catch
            {

            }
        }
        private void button_back_Click(object sender, EventArgs e)
        {
            try
            {
                stepnow.Value--;
            }
            catch
            {

            }
        }
    }
}
