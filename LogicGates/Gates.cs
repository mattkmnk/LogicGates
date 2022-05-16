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
        List<Gate> DefaultGates;
        List<Gate> Map;

        public MainWindow()
        {
            DefaultGates = new List<Gate>();
            Map = new List<Gate>();
            DefaultGates.Add(new AND());
            DefaultGates.Add(new OR());
            InitializeComponent();
            this.Text = "Logic Gates Simulator";
            LoadGates();
        }

        private void LoadGates()
        {
            int x = GatesPanel.Location.X + 5;
            int y = GatesPanel.Location.Y + 5;
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
            BlueprintButton button = (BlueprintButton)sender;
            Gate gate = button.GetGate(MainboardPanel);
            gate.SetPosition(new Point(10, 10));
            Map.Add(gate);

            MainboardPanel.AllowDrop = true;
            MainboardPanel.Controls.Add(gate.GetBody());
            gate.GetBody().MouseDown += new MouseEventHandler(GateHitbox_MouseDown);
            MainboardPanel.DragOver += new DragEventHandler(Circuit_DragOver);
            MainboardPanel.DragDrop += new DragEventHandler(Circuit_DragDrop);
        }

        private void Circuit_DragDrop(object sender, DragEventArgs e)
        {
            Control c = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            if (c != null)
            {
                c.Location = MainboardPanel.PointToClient(new Point(e.X, e.Y));
                MainboardPanel.Controls.Add(c);
            }
        }

        private void Circuit_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void GateHitbox_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            c.DoDragDrop(c, DragDropEffects.Move);
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
