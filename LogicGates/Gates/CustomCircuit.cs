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
        public CustomCircuit(int inPins, string inName) : base(inPins, inName)
        {
        }

        public CustomCircuit(int inPins, string inName, Point pos) : base(inPins, inName)
        {
        }

        public override CircuitBase GetInstance(Point pos)
        {
            return new CustomCircuit(NumOfInputPins, Name, pos);
        }
    }
}
