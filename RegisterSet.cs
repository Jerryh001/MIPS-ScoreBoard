using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    static class RegisterSet
    {
        static public string[] reg;
        static RegisterSet()
        {
            Init();
        }
        static public void Init()
        {
            reg = new string[16];
            for(int i=0;i<16;i++)
            {
                reg[i] = "";
            }
        }
        static public string Get(factor i)
        {
            if(i.type==type.FReg)
            {
                return reg[Convert.ToUInt32(i.value)/2];
            }
            else
            {
                return "";
            }
        }
        static public void Set(factor i,string s)
        {
            if (i.type == type.FReg)
            {
                reg[Convert.ToUInt32(i.value)/2] = s;
            }
        }
        static public void SetRaw(string i, string s)
        {
            reg[Convert.ToUInt32(i.Substring(1)) / 2] = s;
        }
        static public void Clear(factor i)
        {
            Set(i, "");
        }
    }
}
