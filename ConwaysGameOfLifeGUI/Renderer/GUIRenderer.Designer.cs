using System.Windows.Forms;

namespace ConwaysGameOfLifeGUI.Renderer
{
    partial class GuiRenderer
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
            this.WidthBox = new System.Windows.Forms.NumericUpDown();
            this.HeightBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GenerationNumber = new System.Windows.Forms.Label();
            this.NoOfLivingCells = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ClearGridButton = new System.Windows.Forms.Button();
            this.StartGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridBox
            // 
            this.GridBox.BackColor = System.Drawing.Color.Black;
            this.GridBox.Location = new System.Drawing.Point(0, 133);
            this.GridBox.Name = "GridBox";
            this.GridBox.Size = new System.Drawing.Size(1000, 800);
            this.GridBox.TabIndex = 1;
            this.GridBox.TabStop = false;
            this.GridBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generation: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "No. of Cells: ";
            // 
            // WidthBox
            // 
            this.WidthBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.WidthBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.WidthBox.Location = new System.Drawing.Point(244, 37);
            this.WidthBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(112, 38);
            this.WidthBox.TabIndex = 6;
            this.WidthBox.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthBox.ValueChanged += new System.EventHandler(this.WidthBox_ValueChanged);
            // 
            // HeightBox
            // 
            this.HeightBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.HeightBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.HeightBox.Location = new System.Drawing.Point(267, 35);
            this.HeightBox.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.HeightBox.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(114, 38);
            this.HeightBox.TabIndex = 7;
            this.HeightBox.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.HeightBox.ValueChanged += new System.EventHandler(this.HeightBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Width for the grid: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(17, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Height for the grid: ";
            // 
            // GenerationNumber
            // 
            this.GenerationNumber.AutoSize = true;
            this.GenerationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GenerationNumber.Location = new System.Drawing.Point(165, 91);
            this.GenerationNumber.Name = "GenerationNumber";
            this.GenerationNumber.Size = new System.Drawing.Size(33, 37);
            this.GenerationNumber.TabIndex = 11;
            this.GenerationNumber.Text = "1";
            // 
            // NoOfLivingCells
            // 
            this.NoOfLivingCells.AutoSize = true;
            this.NoOfLivingCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NoOfLivingCells.Location = new System.Drawing.Point(180, 91);
            this.NoOfLivingCells.Name = "NoOfLivingCells";
            this.NoOfLivingCells.Size = new System.Drawing.Size(35, 37);
            this.NoOfLivingCells.TabIndex = 12;
            this.NoOfLivingCells.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GenerationNumber);
            this.splitContainer1.Panel1.Controls.Add(this.WidthBox);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.CausesValidation = false;
            this.splitContainer1.Panel2.Controls.Add(this.ClearGridButton);
            this.splitContainer1.Panel2.Controls.Add(this.NoOfLivingCells);
            this.splitContainer1.Panel2.Controls.Add(this.HeightBox);
            this.splitContainer1.Panel2.Controls.Add(this.StartGameButton);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 135);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 13;
            // 
            // ClearGridButton
            // 
            this.ClearGridButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClearGridButton.Location = new System.Drawing.Point(424, 20);
            this.ClearGridButton.Name = "ClearGridButton";
            this.ClearGridButton.Size = new System.Drawing.Size(184, 38);
            this.ClearGridButton.TabIndex = 15;
            this.ClearGridButton.Text = "Clear Grid";
            this.ClearGridButton.UseVisualStyleBackColor = false;
            this.ClearGridButton.Click += new System.EventHandler(this.ClearGridButton_Click);
            // 
            // StartGameButton
            // 
            this.StartGameButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.StartGameButton.Location = new System.Drawing.Point(424, 74);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(184, 39);
            this.StartGameButton.TabIndex = 13;
            this.StartGameButton.Text = "Start Game";
            this.StartGameButton.UseVisualStyleBackColor = false;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // GuiRenderer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Load += new System.EventHandler(this.GuiRenderer_Load);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1004, 937);
            this.Controls.Add(this.GridBox);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GuiRenderer";
            this.Text = "Conway\'s Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.GridBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
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
        private NumericUpDown WidthBox;
        private NumericUpDown HeightBox;
        private Label label3;
        private Label label4;
        private Label GenerationNumber;
        private Label NoOfLivingCells;
        private SplitContainer splitContainer1;
        private Button StartGameButton;
        private Button ClearGridButton;
    }
}

