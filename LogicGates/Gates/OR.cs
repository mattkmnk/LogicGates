using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicGates.Utils;

namespace LogicGates.Gates
{
    public class OR : BinaryGate
    {
        public OR()
        {
            this.Name = "OR";
        }

        public OR(Point pos, Panel panel)
        {
            Name = "OR";
            Position = pos;
            input1 = new InputPin(new Point(0, 0), this);
            input1.Click += input1_Click;
            input2 = new InputPin(new Point(0, 20), this);
            input2.Click += input2_Click;

            Output = new OutputPin(new Point(60, 0));

            GateHitbox = new Label();
            GateHitbox.Location = pos;
            GateHitbox.BackColor = Color.White;
            GateHitbox.Text = this.Name;
            GateHitbox.TextAlign = ContentAlignment.MiddleCenter;
            GateHitbox.Size = new Size(80, 40);
            GateHitbox.Controls.Add(this.input1);
            GateHitbox.Controls.Add(this.input2);
            GateHitbox.Controls.Add(this.Output);

            Run();
        }

        private void input1_Click(object sender, EventArgs e)
        {
            input1.SwitchStatus();
        }

        private void input2_Click(object sender, EventArgs e)
        {
            input2.SwitchStatus();
        }

        public override void Run()
        {
            if (input1.GetStatus() || input2.GetStatus())
            {
                this.SetStatus(true);
            }
            else
            {
                this.SetStatus(false);
            }
        }

        public override Gate GetInstance(Point pos, Panel panel)
        {
            return new OR(pos, panel);
        }

        public override void Draw(Panel panel)
        {
            throw new NotImplementedException();
        }
    }
}
