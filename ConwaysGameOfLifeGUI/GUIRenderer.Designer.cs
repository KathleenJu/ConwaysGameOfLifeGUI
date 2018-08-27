using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI
{
    partial class GUIRenderer
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
            this.GridBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GenerationNumber = new System.Windows.Forms.Label();
            this.NoOfLivingCells = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.GridBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridBox
            // 
            this.GridBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GridBox.Location = new System.Drawing.Point(3, 256);
            this.GridBox.Name = "GridBox";
            this.GridBox.Size = new System.Drawing.Size(1172, 879);
            this.GridBox.TabIndex = 1;
            this.GridBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generation: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. of Cells: ";
            // 
            // widthBox
            // 
            this.widthBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.widthBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthBox.Location = new System.Drawing.Point(308, 39);
            this.widthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(166, 38);
            this.widthBox.TabIndex = 6;
            this.widthBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // heightBox
            // 
            this.heightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.heightBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightBox.Location = new System.Drawing.Point(340, 39);
            this.heightBox.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(170, 38);
            this.heightBox.TabIndex = 7;
            this.heightBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(38, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Width for the grid: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(48, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Height for the grid: ";
            // 
            // GenerationNumber
            // 
            this.GenerationNumber.AutoSize = true;
            this.GenerationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GenerationNumber.Location = new System.Drawing.Point(207, 182);
            this.GenerationNumber.Name = "GenerationNumber";
            this.GenerationNumber.Size = new System.Drawing.Size(33, 37);
            this.GenerationNumber.TabIndex = 11;
            this.GenerationNumber.Text = "1";
            // 
            // NoOfLivingCells
            // 
            this.NoOfLivingCells.AutoSize = true;
            this.NoOfLivingCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NoOfLivingCells.Location = new System.Drawing.Point(236, 182);
            this.NoOfLivingCells.Name = "NoOfLivingCells";
            this.NoOfLivingCells.Size = new System.Drawing.Size(35, 37);
            this.NoOfLivingCells.TabIndex = 12;
            this.NoOfLivingCells.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splitContainer1.Location = new System.Drawing.Point(2, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.GenerationNumber);
            this.splitContainer1.Panel1.Controls.Add(this.widthBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.NoOfLivingCells);
            this.splitContainer1.Panel2.Controls.Add(this.heightBox);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1172, 240);
            this.splitContainer1.SplitterDistance = 556;
            this.splitContainer1.TabIndex = 13;
            // 
            // GUIRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1176, 1143);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.GridBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUIRenderer";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.GridBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox GridBox;
        private Label label1;
        private Label label2;
        private NumericUpDown widthBox;
        private NumericUpDown heightBox;
        private Label label3;
        private Label label4;
        private Label GenerationNumber;
        private Label NoOfLivingCells;
        private SplitContainer splitContainer1;
    }
}

