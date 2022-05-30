using LogicGates.Gates;
using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicGates
{
    public partial class MainWindow : Form
    {
        List<CircuitBase> Gates;
        CircuitEditor CircuitEdit;


        public MainWindow()
        {
            InitializeComponent();
            Gates = new List<CircuitBase>();

            Gates.Add(new AND());
            Gates.Add(new OR());
            Gates.Add(new NOT());

            this.Text = "Logic Gates Simulator";

            CircuitEdit = new CircuitEditor();

            GatesPanel.AutoScroll = false;
            GatesPanel.HorizontalScroll.Enabled = false;
            GatesPanel.HorizontalScroll.Visible = false;
            GatesPanel.HorizontalScroll.Maximum = 0;
            GatesPanel.AutoScroll = true;

            CircuitEdit.Location = new Point(12, 12);
            CircuitEdit.Size = new Size(960, 643);
            CircuitEdit.BackColor = Color.FromArgb(30, 30, 30);
            this.Controls.Add(CircuitEdit);
            LoadGates();

        }

        private void LoadGates()
        {
            GatesPanel.Controls.Clear();
            int x = 5;
            int y = 5;
            foreach (var gate in Gates)
            {
                var btn = new BlueprintButton(gate);
                btn.Name = gate.GetName();
                btn.Text = gate.GetName();
                btn.ForeColor = Color.White;
                btn.Location = new Point(x, y);
                btn.Size = new Size(GatesPanel.Size.Width - 10, 50);
                btn.MouseDown += GateMouseClick;
                GatesPanel.Controls.Add(btn);
                y += 10;
            }
        }

        private void GateMouseClick(object sender, EventArgs e)
        {
            var me = (MouseEventArgs)e;
            switch(me.Button)
            {
                case MouseButtons.Left:
                    CircuitEdit.Add_Gate(sender, e);
                break;
                case MouseButtons.Right:
                    ContextMenuStrip cm = new ContextMenuStrip();
                    ToolStripMenuItem precalc = new ToolStripMenuItem("Precalculate");
                    precalc.Click += (sender2, e2) => Calculate_Click(sender2, e2, sender as BlueprintButton);

                    cm.Items.Add(precalc);
                    ((BlueprintButton)sender).ContextMenuStrip = cm;
                break;
            }
            
        } 

        private void Calculate_Click(object sender, EventArgs e, BlueprintButton button)
        {
            Calculate(button.GetGate());
        }

        private void Calculate(CircuitBase gate)
        {
            var thread = new Thread(gate.PrecalculateValues);
            thread.Start();
        }

        private void SaveToDatabase_Click(object sender, EventArgs e, BlueprintButton button)
        {
            string res = "";
            var gate = (CustomCircuit)button.GetGate();
            string name = gate.GetName();
            if (!gate.IsPrecalculated(name))
                return;

            var tab = gate.GetResultTable(name);
            
            for(int i = 0; i < tab.Results.Count; ++i)
            {
                res += i + " " + tab.Results[i] + "\n";
            }
            MessageBox.Show($"{res}");
        }

        private void SaveCircuit_button_Click(object sender, EventArgs e)
        {
            var newCircuit = CircuitEdit.Save();
            if(CircuitName_TextBox.Text.Length == 0)
            {
                CircuitName_TextBox.BackColor = Color.Red;
                return;
            }
            CircuitName_TextBox.BackColor = Color.White;
            newCircuit.Name = CircuitName_TextBox.Text;
            CircuitName_TextBox.Clear();
            Gates.Add(newCircuit);
            CircuitEdit.Dispose();

            LoadGates();
            CircuitEdit = new CircuitEditor();
            CircuitEdit.Location = new Point(12, 12);
            CircuitEdit.Size = new Size(960, 640);
            CircuitEdit.BackColor = Color.FromArgb(30, 30, 30);
            this.Controls.Add(CircuitEdit);
            NumOfInputs_NumericUpDown.Value = 0;
        }

        private void NumOfInputs_NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CircuitEdit.CreateInputsOutputs((int)NumOfInputs_NumericUpDown.Value);
        }

        private void LGStore_Click(object sender, EventArgs e)
        {
            var store = new LGStore(Gates);
            store.GateAdded += LoadGateFromDB;
            store.Show();
        }

        private void LoadGateFromDB(CustomCircuit gate)
        {
            Gates.Add(gate);
            LoadGates();
        }
    }
}
