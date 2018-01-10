﻿namespace Tanenbaum_CPU_Emulator
{
	partial class EditorForm
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.codeInputBox = new System.Windows.Forms.RichTextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(801, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem1});
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.runToolStripMenuItem.Text = "Run";
			// 
			// runToolStripMenuItem1
			// 
			this.runToolStripMenuItem1.Name = "runToolStripMenuItem1";
			this.runToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.runToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
			this.runToolStripMenuItem1.Text = "Run";
			this.runToolStripMenuItem1.Click += new System.EventHandler(this.runToolStripMenuItem1_Click);
			// 
			// codeInputBox
			// 
			this.codeInputBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codeInputBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.codeInputBox.Location = new System.Drawing.Point(0, 24);
			this.codeInputBox.Name = "codeInputBox";
			this.codeInputBox.Size = new System.Drawing.Size(801, 589);
			this.codeInputBox.TabIndex = 6;
			this.codeInputBox.Text = "//loop 10 times:\nloco 10\n\nloop:\nsubd one\njnze loop\n\nhalt\n";
			this.codeInputBox.TextChanged += new System.EventHandler(this.codeInputBox_TextChanged);
			// 
			// EditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(801, 613);
			this.Controls.Add(this.codeInputBox);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "EditorForm";
			this.Text = "Tanenbaum CPU Emulator - Code";
			this.Shown += new System.EventHandler(this.EditorForm_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem1;
		private System.Windows.Forms.RichTextBox codeInputBox;
	}
}

