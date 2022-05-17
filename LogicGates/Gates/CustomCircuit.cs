using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGates.Gates
{
    public class CustomCircuit : CircuitBase
    {
        List<CircuitBase> Circuits;
        List<Wire> Wires;
        List<Input> Inputs;
        Output Output;

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

        public override void Run()
        {
            for (int i = 0; i < Inputs.Count; ++i)
            {
                Inputs[i].InputPins[0].SetStatus(InputPins[i].GetStatus());
                OutputPin.SetStatus(Output.OutputPin.GetStatus());
            }
        }
    }
}
