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
            this.TestButton = new System.Windows.Forms.Button();
            this.GatesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SaveCircuit_button = new System.Windows.Forms.Button();
            this.CircuitName_TextBox = new System.Windows.Forms.TextBox();
            this.NumOfInputs_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumOfInputs_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(896, 659);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(75, 23);
            this.TestButton.TabIndex = 1;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // GatesPanel
            // 
            this.GatesPanel.Location = new System.Drawing.Point(977, 12);
            this.GatesPanel.Name = "GatesPanel";
            this.GatesPanel.Size = new System.Drawing.Size(161, 670);
            this.GatesPanel.TabIndex = 0;
            // 
            // SaveCircuit_button
            // 
            this.SaveCircuit_button.Location = new System.Drawing.Point(145, 659);
            this.SaveCircuit_button.Name = "SaveCircuit_button";
            this.SaveCircuit_button.Size = new System.Drawing.Size(74, 25);
            this.SaveCircuit_button.TabIndex = 2;
            this.SaveCircuit_button.Text = "Save";
            this.SaveCircuit_button.UseVisualStyleBackColor = true;
            this.SaveCircuit_button.Click += new System.EventHandler(this.SaveCircuit_button_Click);
            // 
            // CircuitName_TextBox
            // 
            this.CircuitName_TextBox.Location = new System.Drawing.Point(225, 661);
            this.CircuitName_TextBox.Name = "CircuitName_TextBox";
            this.CircuitName_TextBox.Size = new System.Drawing.Size(100, 20);
            this.CircuitName_TextBox.TabIndex = 3;
            // 
            // NumOfInputs_NumericUpDown
            // 
            this.NumOfInputs_NumericUpDown.Location = new System.Drawing.Point(3, 659);
            this.NumOfInputs_NumericUpDown.Name = "NumOfInputs_NumericUpDown";
            this.NumOfInputs_NumericUpDown.Size = new System.Drawing.Size(32, 20);
            this.NumOfInputs_NumericUpDown.TabIndex = 4;
            this.NumOfInputs_NumericUpDown.ValueChanged += new System.EventHandler(this.NumOfInputs_NumericUpDown_ValueChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1144, 681);
            this.Controls.Add(this.NumOfInputs_NumericUpDown);
            this.Controls.Add(this.CircuitName_TextBox);
            this.Controls.Add(this.SaveCircuit_button);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.GatesPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "MainWindow";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumOfInputs_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel GatesPanel;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button SaveCircuit_button;
        private System.Windows.Forms.TextBox CircuitName_TextBox;
        private System.Windows.Forms.NumericUpDown NumOfInputs_NumericUpDown;
    }
}

