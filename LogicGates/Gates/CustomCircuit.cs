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

        public CustomCircuit() : base(4, "TEST")
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
            var res = new CustomCircuit();
            res.Wires = new List<Wire>();
            res.Wires.Add(new Wire(InputPins[0], OutputPin));

            return res;
        }

        public override void Run()
        {
            OutputPin.SetStatus(this.InputPins[0].GetStatus());
        }
    }
}
