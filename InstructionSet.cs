using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIPS_ScoreBoard
{
    static class InstructionSet
    {
        static public List<Instruction> instruction;
        static InstructionSet()
        {

        }
        static public void ReadFile(string file)
        {
            instruction = new List<Instruction>();
            StreamReader fin=new StreamReader(file);
            int line = 1;
            while(!fin.EndOfStream)
            {
                string inp=fin.ReadLine().Trim();
                if(inp.Length>0)
                {
                    instruction.Add(new Instruction(inp,line));
                    line++;
                }
                
            }
        }

        internal static bool NotThingToDo()
        {
            foreach(Instruction ins in instruction)
            {
                if(ins.WR==0)
                {
                    return false;
                }
            }
            return true;
        }

        internal static Instruction GetInstruction(int line)
        {
            return instruction[line - 1];
        }
    }
}
