using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicGates.Gates
{
    public abstract class BinaryGate : Gate
    {
        protected InputPin input1;
        protected InputPin input2;

        public override List<InputPin> GetInputs()
        {
            return new List<InputPin> { input1, input2 };
        }
    }
}
