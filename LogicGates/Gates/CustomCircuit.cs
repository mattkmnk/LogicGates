using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Gates
{
    public class CustomCircuit : CircuitBase
    {
        List<CircuitBase> Circuits;
        List<Wire> Wires;
        List<Input> Inputs;
        List<Output> Outputs;

        static Dictionary<string, ResultTable> PrecalcTable = new Dictionary<string, ResultTable>();

        public CustomCircuit(int numOfInPins, int numOfOutPins) : base(numOfInPins, numOfOutPins, "TEST")
        {
            Inputs = new List<Input>();
            for(int i = 0; i < numOfInPins; ++i)
            {
                Inputs.Add(new Input());
            }
            Outputs = new List<Output>(numOfOutPins);
            for (int i = 0; i < numOfOutPins; ++i)
            {
                Outputs.Add(new Output());
            }
        }

        public CustomCircuit(string inName, List<Input> inputs, List<Output> outputs, List<CircuitBase> circuits,
            List<Wire> wires)
            : base(inputs.Count, outputs.Count, inName)
        {
            Outputs = outputs;
            Inputs = inputs;
            Circuits = circuits;
            Wires = wires;
        }

        public override CircuitBase GetInstance(Point pos)
        {
            var res = new CustomCircuit(this.Inputs.Count, this.Outputs.Count);
            res.Name = this.Name;
            res.Wires = this.Wires;
            res.Inputs = this.Inputs;
            res.Circuits = this.Circuits;
            res.Outputs = this.Outputs;

            return res;
        }

        public bool IsPrecalculated(string name)
        {
            return PrecalcTable.ContainsKey(name);
        }

        public ResultTable GetResultTable(string name)
        {
            return PrecalcTable[name];
        }

        public override void PrecalculateValues()
        {
            if (PrecalcTable.ContainsKey(this.Name)) return;
            var Res = new ResultTable();
            
            for(int i = 0; i < Math.Pow(2, InputPins.Count); ++i)
            {
                var bin = Convert.ToString(i, 2).PadLeft(this.Inputs.Count, '0');
                for (int j = 0; j < this.Inputs.Count; ++j)
                {
                    InputPins[j].SetStatus(bin[bin.Length - j - 1] == '1' ? true : false);
                }
                var runres = this.Run();
                Res.Results.Add(i, runres);
            }

            PrecalcTable.Add(this.Name, Res);
        }

        public override int Run()
        {
            if (PrecalcTable.ContainsKey(this.Name))
            {
                int inSum = 0;
                for(int i = 0; i < Inputs.Count; ++i)
                {
                    inSum += InputPins[i].GetStatus() ? (int)Math.Pow(2, i) : 0;
                }
                for (int i = 0; i < Outputs.Count; ++i)
                {
                    var result = Convert.ToString(PrecalcTable[this.Name].Results[inSum], 2).PadLeft(Outputs.Count, '0');
                    OutputPins[i].SetStatus(result[result.Length - i - 1] == '1' ? true : false);
                }
                
                return -1;
            }
            else
            {
                for (int i = 0; i < Inputs.Count; ++i)
                {
                    Inputs[i].InputPins[0].SetStatus(InputPins[i].GetStatus());
                }
                var res = 0;
                for (int i = 0; i < Outputs.Count; ++i)
                {
                    OutputPins[i].SetStatus(Outputs[i].OutputPins[0].GetStatus());
                    res += OutputPins[i].GetStatus() ? (int)Math.Pow(2, i) : 0;
                }
                return res;
            }
        }

        public void SetPrecalculatedTable(string name, ResultTable res)
        {
            PrecalcTable.Add(name, res);
        }
    }
}
