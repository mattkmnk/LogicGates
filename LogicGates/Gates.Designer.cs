using System.Drawing;
using System.Windows.Forms;

namespace LogicGates
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GatesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveCircuit_button = new System.Windows.Forms.Button();
            this.CircuitName_TextBox = new System.Windows.Forms.TextBox();
            this.NumOfInputs_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.NumOfOutputs_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfInputs_NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfOutputs_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // GatesPanel
            // 
            this.GatesPanel.Location = new System.Drawing.Point(986, 45);
            this.GatesPanel.Name = "GatesPanel";
            this.GatesPanel.Size = new System.Drawing.Size(140, 624);
            this.GatesPanel.TabIndex = 0;
            // 
            // SaveCircuit_button
            // 
            this.SaveCircuit_button.Location = new System.Drawing.Point(790, 660);
            this.SaveCircuit_button.Name = "SaveCircuit_button";
            this.SaveCircuit_button.Size = new System.Drawing.Size(74, 21);
            this.SaveCircuit_button.TabIndex = 2;
            this.SaveCircuit_button.Text = "Save as";
            this.SaveCircuit_button.UseVisualStyleBackColor = true;
            this.SaveCircuit_button.Click += new System.EventHandler(this.SaveCircuit_button_Click);
            // 
            // CircuitName_TextBox
            // 
            this.CircuitName_TextBox.BackColor = System.Drawing.Color.DarkGray;
            this.CircuitName_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CircuitName_TextBox.Location = new System.Drawing.Point(870, 660);
            this.CircuitName_TextBox.Name = "CircuitName_TextBox";
            this.CircuitName_TextBox.Size = new System.Drawing.Size(100, 20);
            this.CircuitName_TextBox.TabIndex = 3;
            // 
            // NumOfInputs_NumericUpDown
            // 
            this.NumOfInputs_NumericUpDown.Location = new System.Drawing.Point(68, 660);
            this.NumOfInputs_NumericUpDown.Name = "NumOfInputs_NumericUpDown";
            this.NumOfInputs_NumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.NumOfInputs_NumericUpDown.TabIndex = 4;
            this.NumOfInputs_NumericUpDown.ValueChanged += new System.EventHandler(this.NumOfInputs_NumericUpDown_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.CausesValidation = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(989, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 27);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Text = "LGStore";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.LGStore_Click);
            // 
            // NumOfOutputs_NumericUpDown
            // 
            this.NumOfOutputs_NumericUpDown.Location = new System.Drawing.Point(173, 660);
            this.NumOfOutputs_NumericUpDown.Name = "NumOfOutputs_NumericUpDown";
            this.NumOfOutputs_NumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.NumOfOutputs_NumericUpDown.TabIndex = 6;
            this.NumOfOutputs_NumericUpDown.ValueChanged += new System.EventHandler(this.NumOfOutputs_NumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(21, 662);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Inputs:";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(119, 662);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Outputs:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1144, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumOfOutputs_NumericUpDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NumOfInputs_NumericUpDown);
            this.Controls.Add(this.CircuitName_TextBox);
            this.Controls.Add(this.SaveCircuit_button);
            this.Controls.Add(this.GatesPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumOfInputs_NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfOutputs_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel GatesPanel;
        private System.Windows.Forms.Button SaveCircuit_button;
        private System.Windows.Forms.TextBox CircuitName_TextBox;
        private System.Windows.Forms.NumericUpDown NumOfInputs_NumericUpDown;
        private Button button1;
        private NumericUpDown NumOfOutputs_NumericUpDown;
        private Label label1;
        private Label label2;
    }
}

