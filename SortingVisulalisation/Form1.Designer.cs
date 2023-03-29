namespace SortingVisulalisation
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.algorythmLabel = new System.Windows.Forms.Label();
            this.algorythmComboBox = new System.Windows.Forms.ComboBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.graphicsPanel = new System.Windows.Forms.Panel();
            this.sortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // algorythmLabel
            // 
            this.algorythmLabel.AutoSize = true;
            this.algorythmLabel.Location = new System.Drawing.Point(12, 40);
            this.algorythmLabel.Name = "algorythmLabel";
            this.algorythmLabel.Size = new System.Drawing.Size(64, 15);
            this.algorythmLabel.TabIndex = 0;
            this.algorythmLabel.Text = "Algorythm";
            // 
            // algorythmComboBox
            // 
            this.algorythmComboBox.FormattingEnabled = true;
            this.algorythmComboBox.Location = new System.Drawing.Point(82, 32);
            this.algorythmComboBox.Name = "algorythmComboBox";
            this.algorythmComboBox.Size = new System.Drawing.Size(161, 23);
            this.algorythmComboBox.TabIndex = 1;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(291, 32);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // graphicsPanel
            // 
            this.graphicsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphicsPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.graphicsPanel.Location = new System.Drawing.Point(12, 76);
            this.graphicsPanel.Name = "graphicsPanel";
            this.graphicsPanel.Size = new System.Drawing.Size(890, 427);
            this.graphicsPanel.TabIndex = 3;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(391, 32);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(75, 23);
            this.sortButton.TabIndex = 4;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 528);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.graphicsPanel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.algorythmComboBox);
            this.Controls.Add(this.algorythmLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label algorythmLabel;
        private System.Windows.Forms.ComboBox algorythmComboBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Panel graphicsPanel;
        private System.Windows.Forms.Button sortButton;
    }
}
