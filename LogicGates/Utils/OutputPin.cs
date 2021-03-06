using LogicGates.Gates;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates.Utils
{
    public class OutputPin : Pin
    {
        bool Status;
        List<Wire> Wires = new List<Wire>();

        public OutputPin(Point pos, CircuitBase gate)
        {
            SetStatus(false);
            this.ParentGate = gate;

            this.Size = new Size(20, 20);
            this.Location = pos;
            this.Text = "O";
            this.TabStop = false;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
        }

        public override void SetStatus(bool status)
        {
            Status = status;
            this.BackColor = Status ? Color.Green : Color.Red;

            foreach(var wire in Wires)
            {
                wire.Propagate();
            }
        }

        public void SetWire(Wire wire)
        {
            Wires.Add(wire);
        }

        public override bool GetStatus()
        {
            return Status;
        }

        public void SwitchStatus()
        {
            Status = !Status;
            this.BackColor = Status ? Color.Green : Color.Red;
        }
    }
}
