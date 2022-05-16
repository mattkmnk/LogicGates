using LogicGates.Gates;
using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates
{
    public partial class MainWindow : Form
    {
        List<CircuitBase> DefaultGates;
        List<CircuitBase> Map;

        public MainWindow()
        {
            DefaultGates = new List<CircuitBase>();
            Map = new List<CircuitBase>();
            DefaultGates.Add(new AND());
            DefaultGates.Add(new OR());
            DefaultGates.Add(new CustomCircuit(4, "TEST"));
            InitializeComponent();
            this.Text = "Logic Gates Simulator";
            LoadGates();
        }

        private void LoadGates()
        {
            int x = 5;
            int y = 5;
            foreach(var gate in DefaultGates)
            {
                var btn = new BlueprintButton(gate);
                btn.Name = gate.GetName();
                btn.Text = gate.GetName();
                btn.ForeColor = Color.White;
                btn.Location = new Point(x, y);
                btn.Size = new Size(GatesPanel.Size.Width - 10, 50);
                btn.Click += Add_Gate;
                GatesPanel.Controls.Add(btn);
                y += 10;
            }
        }

        private void MainboardPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_Gate(object sender, EventArgs e)
        {
            BlueprintButton button = sender as BlueprintButton;
            var gate = button.GetGate();
            Map.Add(gate);
            var graphics = new CircuitGraphics(gate, new Point(50, 50));
            graphics.MouseDown += new MouseEventHandler(GateHitbox_MouseDown);
            graphics.MouseUp += new MouseEventHandler(GateHitbox_MouseUp);
            graphics.MouseMove += new MouseEventHandler(GateHitbox_MouseMove);
            MainboardPanel.Controls.Add(graphics);
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
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            string res = "";
            foreach(var val in Map)
            {
                res += $"{val} at ({val.GetPosition().X}; {val.GetPosition().Y})\n";
            }
            MessageBox.Show(res);
        }
    }
}
