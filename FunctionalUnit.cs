using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIPS_ScoreBoard
{
    class FunctionalUnit
    {
        public uint Line;
        public bool Busy { get { return Op != ""; } }
        public bool Rj { get { return Data["Qj"] == ""; } }
        public bool Rk { get { return Data["Qk"] == ""; } }
        public factor Fi { get { return Line > 0 ? InstructionSet.GetInstruction(Line).Dest : new factor(); } }
        public factor Fj { get { return Line > 0 ? InstructionSet.GetInstruction(Line).S1 : new factor(); } }
        public factor Fk { get { return Line > 0 ? InstructionSet.GetInstruction(Line).S2 : new factor(); } }
        public string Op { get { return Line > 0 ? InstructionSet.GetInstruction(Line).OP : ""; } }
        uint Time = 0;
        uint Period;
        Dictionary<string, string> Data = new Dictionary<string, string>();
        public FunctionalUnit(string name, uint p)
        {
            Data.Add("Name", name);
            Data.Add("Qj", "");
            Data.Add("Qk", "");
            Period = p;
        }
        public string[] GetItem()
        {
            return new string[] { Data["Name"], (Time > 0 ? Time.ToString() : ""), Busy ? "Yes" : "No", Op, Fi.ToString(), Fj.ToString(), Fk.ToString(), Data["Qj"], Data["Qk"], Line > 0 ? (Rj ? "Yes" : "No") : "", Line > 0 ? (Rk ? "Yes" : "No") : "" };
        }
        public uint GetTime()
        {
            return Time;
        }
        public string GetData(string s)
        {
            switch(s)
            {
                case "Line":
                    return Line.ToString();
                case "Time":
                    return Time.ToString();
                default:
                    return Data[s];
            }
        }
            
        public void SetData(string colnum,string s)
        {
            switch (colnum)
            {
                case "Line":
                    Line = Convert.ToUInt32(s);
                    break;
                case "Time":
                    Time = Convert.ToUInt32(s);
                    break;
                default:
                    Data[colnum] = s;
                    break;
            }
        }
        internal bool NotCauseRAW(uint step)
        {
            foreach (FunctionalUnit f1 in AllFunction.Func)
            {
                if (f1.Line == 0 || this == f1) continue;
                Instruction ins = InstructionSet.GetInstruction(f1.Line);
                if (Line > f1.Line && (Fi.Equals(f1.Fj) || Fi.Equals(f1.Fk)) && (ins.GetStage("RO") == 0 || ins.GetStage("RO") == step))
                {
                    return false;
                }
            }
            return true;
        }

        internal void Execute(uint step)
        {
            DifftableList.SetValueFunc(step, Data["Name"], "Time", Period.ToString());
            Time = Period;
        }

        internal void Issue(Instruction ins,uint step)
        {
            DifftableList.SetValueFunc(step, Data["Name"], "Line", ins.line.ToString());
            Line = ins.line;
            string v = Fj.IsFReg() ? "temp" : "";
            DifftableList.SetValueFunc(step,Data["Name"], "Qj", v);
            Data["Qj"] = v;
            v = Fk.IsFReg() ? "temp" : "";
            DifftableList.SetValueFunc(step, Data["Name"], "Qk", v);
            Data["Qk"] = v;

        }
        internal void WriteResult(uint step)
        {
            Clear(step);
        }
        void Clear(uint step)
        {
            DifftableList.SetValueFunc(step, Data["Name"], "Line", "0");
            Line = 0;
            DifftableList.SetValueFunc(step, Data["Name"], "Qj", "");
            DifftableList.SetValueFunc(step, Data["Name"], "Qk", "");
            Data["Qj"] = "";
            Data["Ok"] = "";
        }

        internal void Tick(uint step)
        {
            if (Time > 0)
            {
                DifftableList.SetValueFunc(step, Data["Name"], "Time", (Time-1).ToString());
                Time--;
                if (Time == 0)
                {
                    Instruction ins = InstructionSet.GetInstruction(Line);
                    ins.ExecuteComp(step);
                }
            }
        }

        internal void ReadyCheck(uint step)
        {
            if (Fj.IsFReg() && !Rj)
            {
                string v = RegisterSet.Get(Fj);
                DifftableList.SetValueFunc(step, Data["Name"], "Qj", v);
                Data["Qj"] = v;
                if (Data["Qj"] == Data["Name"])
                {
                    DifftableList.SetValueFunc(step, Data["Name"], "Qj", "");
                    Data["Qj"] = "";
                }
            }
            if (Fk.IsFReg() && !Rk)
            {
                string v = RegisterSet.Get(Fk);
                DifftableList.SetValueFunc(step, Data["Name"], "Qk", v);
                Data["Qk"] = v;
                if (Data["Qk"] == Data["Name"])
                {
                    DifftableList.SetValueFunc(step, Data["Name"], "Qk", "");
                    Data["Qk"] = "";
                }
            }
        }
    }
}
