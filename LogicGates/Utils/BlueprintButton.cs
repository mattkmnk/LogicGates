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
        Gate gate;

        public BlueprintButton(Gate gate)
        {
            this.gate = gate;
            this.Text = "Hello";
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        public Gate GetGate(Panel panel)
        {
            return gate.GetInstance(new Point(10, 10), panel);
        }

    }
}
