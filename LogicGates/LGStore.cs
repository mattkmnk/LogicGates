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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LogicGates
{

    public delegate void GateAddedHandler(CustomCircuit gate);

    public partial class LGStore : Form
    {
        StorageManager manager;
        List<CircuitBase> gates;
        List<CircuitBase> dbGates;

        public event GateAddedHandler GateAdded;

        public LGStore(List<CircuitBase> gates)
        {
            InitializeComponent();
            this.gates = gates;

            manager = new StorageManager();
            dbGates = new List<CircuitBase>();

            dbGates = manager.LoadGatesFromDB();

            LoadPanels();
        }

        private void LoadPanels()
        {
            ImportGates.Controls.Clear();
            LoadGates(dbGates, ImportGates);
            LoadedGates.Controls.Clear();
            LoadGates(gates, LoadedGates);
        }

        private void LoadGates(List<CircuitBase> gates, Panel panel)
        {
            panel.Controls.Clear();
            int x = 5;
            int y = 5;
            foreach (var gate in gates)
            {
                var btn = new BlueprintButton(gate);
                btn.Name = gate.GetName();
                btn.Text = gate.GetName();
                btn.ForeColor = Color.White;
                btn.Location = new Point(x, y);
                btn.Size = new Size(panel.Size.Width - 10, 50);
                if(panel.Name == "LoadedGates")
                {
                    btn.MouseDown += Btn_MouseDownSaveToDB;
                }
                else
                {
                    btn.MouseDown += Btn_MouseDownFromDB;
                }
                
                panel.Controls.Add(btn);
                y += 50;
            }
        }

        private void Btn_MouseDownFromDB(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                ToolStripMenuItem SaveToDB = new ToolStripMenuItem("Load From DB");
                SaveToDB.Click += (sender2, e2) => LoadFromDB(sender2, e2, sender as BlueprintButton);
                ToolStripMenuItem DeleteFromDB = new ToolStripMenuItem("Delete");
                DeleteFromDB.Click += (sender2, e2) => Delete(sender2, e2, sender as BlueprintButton);
                cm.Items.Add(SaveToDB);
                cm.Items.Add(DeleteFromDB);
                ((BlueprintButton)sender).ContextMenuStrip = cm;
            }
        }

        private void Delete(object sender2, EventArgs e2, BlueprintButton blueprintButton)
        {
            var gate = blueprintButton.GetGate() as CustomCircuit;
            var name = gate.GetName();

            manager.Delete(name);
            dbGates = manager.LoadGatesFromDB();
            LoadPanels();
        }

        private void LoadFromDB(object sender2, EventArgs e2, BlueprintButton blueprintButton)
        {
            GateAddedHandler handler = GateAdded;
            var gate = blueprintButton.GetGate() as CustomCircuit;
            var res = manager.GetPrecalcTable(gate.GetName());
            if (gate.IsPrecalculated(gate.GetName()))
            {
                return;
            }
            gate.SetPrecalculatedTable(gate.GetName(), res);
            handler?.Invoke(gate);
            LoadPanels();
        }

        private void Btn_MouseDownSaveToDB(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip cm = new ContextMenuStrip();
                ToolStripMenuItem SaveToDB = new ToolStripMenuItem("Save to DB");
                SaveToDB.Click += (sender2, e2) => ToDB(sender2, e2, sender as BlueprintButton);

                cm.Items.Add(SaveToDB);
                ((BlueprintButton)sender).ContextMenuStrip = cm;
            }
        }

        private void ToDB(object sender2, EventArgs e2, BlueprintButton blueprintButton)
        {
            var gate = blueprintButton.GetGate() as CustomCircuit;
            string name = gate.GetName();
            if (!gate.IsPrecalculated(name))
            {
                gate.PrecalculateValues();
            }
            

            XmlDocument doc = new XmlDocument();
            doc.LoadXml($"<Circuit></Circuit>");
            XmlElement InputCount = doc.CreateElement("InputCount");
            InputCount.InnerText = gate.NumOfInputPins.ToString();
            doc.DocumentElement.AppendChild(InputCount);
            for(int i = 0; i < gate.GetResultTable(name).Results.Count; ++i)
            {
                XmlElement newElem = doc.CreateElement("Case");
                XmlElement input = doc.CreateElement("Input");
                input.InnerText = i.ToString();
                XmlElement output = doc.CreateElement("Output");
                output.InnerText = gate.GetResultTable(name).Results[i].ToString();
                newElem.AppendChild(input);
                newElem.AppendChild(output);
                doc.DocumentElement.AppendChild(newElem);
            }

            doc.PreserveWhitespace = true;
            doc.Save($"{name}.xml");
            manager.Save(name, doc);
            dbGates = manager.LoadGatesFromDB();
            LoadPanels();
        }
    }
}
