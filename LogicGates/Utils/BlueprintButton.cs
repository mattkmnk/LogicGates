using LogicGates.Gates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Utils
{
    class BlueprintButton : Button
    {
        CircuitBase Gate;

        public BlueprintButton(CircuitBase gate)
        {
            this.Gate = gate;
            this.Text = "Hello";
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        public CircuitBase GetGate()
        {
            return Gate.GetInstance(new Point(10, 10));
        }

    }
}
