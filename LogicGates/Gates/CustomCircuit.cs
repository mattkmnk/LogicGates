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
        Output Output;

        static Dictionary<string, ResultTable> PrecalcTable = new Dictionary<string, ResultTable>();

        public CustomCircuit(int numOfPins) : base(numOfPins, "TEST")
        {
        }

        public CustomCircuit(string inName, List<Input> inputs, Output output, List<CircuitBase> circuits,
            List<Wire> wires)
            : base(inputs.Count, inName)
        {
            Output = output;
            Inputs = inputs;
            Circuits = circuits;
            Wires = wires;
        }

        public override CircuitBase GetInstance(Point pos)
        {
            var res = new CustomCircuit(this.Inputs.Count);
            res.Wires = this.Wires;
            res.Inputs = this.Inputs;
            res.Circuits = this.Circuits;
            res.Output = this.Output;

            return res;
        }

        public override void PrecalculateValues()
        {
            if (PrecalcTable.ContainsKey(this.Name)) return;
            var Res = new ResultTable();
            
            for(int i = 0; i < this.Inputs.Count*this.Inputs.Count; ++i)
            {
                for (int j = 0; j < this.Inputs.Count; ++j)
                {
                    var bin = Convert.ToString(i, 2).PadLeft(this.Inputs.Count, '0');
                    InputPins[j].SetStatus(bin[j] == '1' ? true : false);
                }
                Res.Results.Add(i, this.Run());
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
                OutputPin.SetStatus(PrecalcTable[this.Name].Results[inSum] == 1 ? true : false);
                return -1;
            }
            else
            {
                for (int i = 0; i < Inputs.Count; ++i)
                {
                    Inputs[i].InputPins[0].SetStatus(InputPins[i].GetStatus());
                    OutputPin.SetStatus(Output.OutputPin.GetStatus());
                }

                return OutputPin.GetStatus() ? 1 : 0;
            }
        }
    }
}
