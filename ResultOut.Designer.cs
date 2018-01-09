﻿namespace Tanenbaum_CPU_Emulator
{
	partial class ResultOut
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
			this.components = new System.ComponentModel.Container();
			this.resultBox = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pauseButton = new System.Windows.Forms.Button();
			this.pcLabel = new System.Windows.Forms.Label();
			this.instructionCountLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.programCounter = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.acLabel = new System.Windows.Forms.Label();
			this.spLabel = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// resultBox
			// 
			this.resultBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.resultBox.FormattingEnabled = true;
			this.resultBox.Location = new System.Drawing.Point(0, 43);
			this.resultBox.Name = "resultBox";
			this.resultBox.Size = new System.Drawing.Size(547, 431);
			this.resultBox.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.spLabel);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.acLabel);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.pauseButton);
			this.panel1.Controls.Add(this.pcLabel);
			this.panel1.Controls.Add(this.instructionCountLabel);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(547, 43);
			this.panel1.TabIndex = 5;
			// 
			// pauseButton
			// 
			this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pauseButton.Location = new System.Drawing.Point(469, 3);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(75, 23);
			this.pauseButton.TabIndex = 4;
			this.pauseButton.Text = "Pause";
			this.pauseButton.UseVisualStyleBackColor = true;
			this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
			// 
			// pcLabel
			// 
			this.pcLabel.AutoSize = true;
			this.pcLabel.Location = new System.Drawing.Point(78, 22);
			this.pcLabel.Name = "pcLabel";
			this.pcLabel.Size = new System.Drawing.Size(13, 13);
			this.pcLabel.TabIndex = 3;
			this.pcLabel.Text = "0";
			// 
			// instructionCountLabel
			// 
			this.instructionCountLabel.AutoSize = true;
			this.instructionCountLabel.Location = new System.Drawing.Point(78, 9);
			this.instructionCountLabel.Name = "instructionCountLabel";
			this.instructionCountLabel.Size = new System.Drawing.Size(13, 13);
			this.instructionCountLabel.TabIndex = 2;
			this.instructionCountLabel.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(48, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(24, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "PC:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Instruction #:";
			// 
			// programCounter
			// 
			this.programCounter.Interval = 1;
			this.programCounter.Tick += new System.EventHandler(this.programCounter_Tick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(122, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "AC:";
			// 
			// acLabel
			// 
			this.acLabel.AutoSize = true;
			this.acLabel.Location = new System.Drawing.Point(152, 8);
			this.acLabel.Name = "acLabel";
			this.acLabel.Size = new System.Drawing.Size(13, 13);
			this.acLabel.TabIndex = 6;
			this.acLabel.Text = "0";
			// 
			// spLabel
			// 
			this.spLabel.AutoSize = true;
			this.spLabel.Location = new System.Drawing.Point(152, 21);
			this.spLabel.Name = "spLabel";
			this.spLabel.Size = new System.Drawing.Size(13, 13);
			this.spLabel.TabIndex = 8;
			this.spLabel.Text = "0";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(122, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "SP:";
			// 
			// ResultOut
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 474);
			this.Controls.Add(this.resultBox);
			this.Controls.Add(this.panel1);
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "ResultOut";
			this.Text = "Tanenbaum CPU Emulator - Result";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox resultBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button pauseButton;
		private System.Windows.Forms.Label pcLabel;
		private System.Windows.Forms.Label instructionCountLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer programCounter;
		private System.Windows.Forms.Label acLabel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label spLabel;
		private System.Windows.Forms.Label label5;
	}
}