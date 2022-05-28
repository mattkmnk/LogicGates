using LogicGates.Gates;
using LogicGates.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<CircuitBase> DefaultGates;
        CircuitEditor CircuitEdit;


        public MainWindow()
        {
            InitializeComponent();
            DefaultGates = new List<CircuitBase>();

            DefaultGates.Add(new AND());
            DefaultGates.Add(new OR());
            DefaultGates.Add(new NOT());

            this.Text = "Logic Gates Simulator";

            CircuitEdit = new CircuitEditor();
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
            foreach (var gate in DefaultGates)
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
                    var thread = new Thread((sender as BlueprintButton).Precalculate);
                    thread.Start();
                break;
            }
            
        } 

        private void TestButton_Click(object sender, EventArgs e)
        {
            CircuitEdit.Testing();
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
            DefaultGates.Add(newCircuit);
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
    }
}
