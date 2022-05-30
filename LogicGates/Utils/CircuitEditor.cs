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
    public class CircuitEditor : Panel
    {
        List<Input> Inputs = new List<Input>();
        List<Output> Outputs = new List<Output>();
        List<CircuitBase> Map = new List<CircuitBase>();
        List<Wire> Wires = new List<Wire>();
        
        bool IsWiring = false;
        OutputPin WiringFrom = null;
        InputPin WiringTo = null;

        public CircuitEditor()
        {

            this.Paint += new PaintEventHandler(DrawWires);
            CreateInputsOutputs(0, 0);
        }

        public void CreateInputsOutputs(int inCount, int outCount)
        {
            this.Controls.Clear();
            Inputs.Clear();
            for (int i = 0; i < inCount; ++i)
            {
                Inputs.Add(new Input(new Point(0, 640/(inCount + 1)*(i+1))));
                this.Controls.Add(new CircuitGraphics(Inputs[i], Inputs[i].Position));
                Inputs[i].InputPins[0].MouseClick += new MouseEventHandler(Button_MouseClick);
                Inputs[i].OutputPins[0].MouseClick += new MouseEventHandler(BeginWiring);
            }

            Outputs.Clear();
            for (int i = 0; i < outCount; ++i)
            {
                Outputs.Add(new Output(new Point(920, 640/(outCount + 1)*(i + 1))));
                this.Controls.Add(new CircuitGraphics(Outputs[i], Outputs[i].Position));
                Outputs[i].InputPins[0].MouseClick += new MouseEventHandler(Button_MouseClick);
            }

            foreach (var gate in Map)
            {
                Draw_Gate(gate);
            }
        }

        public CustomCircuit Save()
        {
            var temp = new CustomCircuit("TEST", Inputs, Outputs, Map, Wires);
            return temp;
        }

        public void Add_Gate(object sender, EventArgs e)
        {
            BlueprintButton button = sender as BlueprintButton;
            var gate = button.GetGate();
            gate.Name = button.Name;
            gate.Position = new Point(50, 50);
            Map.Add(gate);
            Draw_Gate(gate);

            foreach (var pin in gate.InputPins)
            {
                pin.MouseClick += new MouseEventHandler(Button_MouseClick);
            }

            foreach (var pin in gate.OutputPins)
            {
                pin.MouseClick += new MouseEventHandler(BeginWiring);
            }

            gate.Run();
        }

        private void Draw_Gate(CircuitBase gate)
        {
            var graphics = new CircuitGraphics(gate, new Point(gate.Position.X, gate.Position.Y));
            graphics.MouseDown += new MouseEventHandler(GateHitbox_MouseDown);
            graphics.MouseUp += new MouseEventHandler(GateHitbox_MouseUp);
            graphics.MouseMove += new MouseEventHandler(GateHitbox_MouseMove);
            this.Controls.Add(graphics);
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsWiring)
            {
                WiringTo = sender as InputPin;
                var wire = new Wire(WiringFrom, WiringTo);
                WiringFrom.SetWire(wire);
                Wires.Add(wire);
                WiringFrom = null;
                WiringTo = null;
                IsWiring = false;
                wire.Propagate();
                wire.WireChangedStatus += Redraw;

                Redraw();
            }
            else
            {
                (sender as InputPin).SwitchStatus();
            }
        }

        private void Redraw()
        {
            this.Invalidate();
            this.Update();
        }

        private void DrawWires(object sender, PaintEventArgs e)
        {
            foreach (var wire in Wires)
            {
                var sscreen = this.PointToScreen(wire.From.Location);
                var start = wire.From.PointToScreen(wire.From.Location);
                start = new Point(start.X - sscreen.X + 10, start.Y - sscreen.Y + 10);

                var escreen = this.PointToScreen(wire.To.Location);
                var end = wire.To.PointToScreen(wire.To.Location);
                end = new Point(end.X - escreen.X + 10, end.Y - escreen.Y + 10);

                var color = wire.Status ? Color.Green : Color.Red;
                e.Graphics.DrawLine(new Pen(color, 2), start, end);

            }
        }

        private void BeginWiring(object sender, MouseEventArgs e)
        {
            WiringFrom = sender as OutputPin;
            IsWiring = true;
        }

        Point MouseDownLocation;
        bool selected = false;

        private void GateHitbox_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
        }

        private void GateHitbox_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownLocation = e.Location;
            selected = true;
        }

        private void GateHitbox_MouseMove(object sender, MouseEventArgs e)
        {
            CircuitGraphics p = sender as CircuitGraphics;
            if (p != null && selected)
            {
                p.SetPosition((e.X - MouseDownLocation.X), (e.Y - MouseDownLocation.Y));
                Redraw();
            }
        }

    }
}
