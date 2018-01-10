﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Machine;

namespace Tanenbaum_CPU_Emulator
{


	public partial class EditorForm : Form
	{
		public EditorForm()
		{
			InitializeComponent();
		}

		private ResultOut resultOut;
		private void MakeLog()
		{
			if (resultOut == null || !resultOut.Visible)
				resultOut = new ResultOut();
			resultOut.Show();
			resultOut.Focus();
		}

		private void ClearLog()
		{
			MakeLog();
			resultOut.ClearLog();
		}

		private void Log(string line)
		{
			MakeLog();
			resultOut.Log(line);
		}

		private void LogFatal(string message)
		{
			MakeLog();
			resultOut.LogFatal(message);
		}


		private void runToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			ClearLog();

			Machine.Instruction[] p = null;
			try
			{
				p = Machine.Language.Parse(codeInputBox.Lines);
			}
			catch (Machine.CommandException ex)
			{
				LogFatal(ex.Message);
				if (ex.InnerException is Machine.CommandNotFoundException)
				{
					Log("Known commands: ");
					Log("  [label]:");
					foreach (var cmd in Machine.Language.Commands)
						if (cmd.RequiresParameter)
							Log("  " + cmd.Name + " [" + cmd.Parameter + "]");
						else
							Log("  " + cmd.Name);
				}
			}
			catch (Exception ex)
			{
				LogFatal(ex.Message);
			}

			if (p == null)
				return;
			MakeLog();
			resultOut.Run(p);
		}


		static Font commandFont = new Font("Consolas", 10, FontStyle.Bold);
		static Font defaultFont = new Font("Consolas", 10, FontStyle.Regular);
		static Font commentFont = new Font("Consolas", 10, FontStyle.Italic);
		static Font labelFont = new Font("Consolas", 10, FontStyle.Bold);
		static Font specialAddressFont = new Font("Consolas", 10, FontStyle.Bold|FontStyle.Italic);
		static Font errorFont = new Font("Consolas", 10, FontStyle.Bold | FontStyle.Underline);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

		private const int WM_SETREDRAW = 11;

		public static void SuspendDrawing(Control parent)
		{
			SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
		}

		public static void ResumeDrawing(Control parent)
		{
			SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
			parent.Refresh();
		}

		struct Selection
		{
			public int start, length;


			public Selection(int offset, Language.ParsedSegment seg)
			{
				start = offset + seg.Start;
				length = seg.Length;
			}

		}


		private void ReColor()
		{


			SuspendDrawing(this);


			var start = codeInputBox.SelectionStart;
			var len = codeInputBox.SelectionLength;

			codeInputBox.SelectAll();
			codeInputBox.SelectionFont = defaultFont;
			codeInputBox.SelectionColor = Color.Black;
			int[] tabs = new int[32];
			for (int i = 0; i < tabs.Length; i++)
				tabs[i] = 28 * i;
			codeInputBox.SelectionTabs = tabs;

			int at = 0;
			foreach (var line in codeInputBox.Lines)
			{
				try
				{
					var l = new Language.PreParsedLine(line);
					var parameterType = Language.Command.ParameterType.None;
					if (l.Command.HasValue)
					{
						Select(at, l.Command);
						try
						{
							var cmd = Language.FindCommand(l.Command.Value, l.Parameter.HasValue);  //trigger exceptions (if any)
							parameterType = cmd.Parameter;

							codeInputBox.SelectionFont = commandFont;
							codeInputBox.SelectionColor = Color.Blue;
						}
						catch (Machine.CommandRequiresParameterException)
						{
							codeInputBox.SelectionFont = commandFont;
							codeInputBox.SelectionColor = Color.Maroon;
						}
						catch (Machine.CommandDoesNotSupportParameterException)
						{
							codeInputBox.SelectionFont = commandFont;
							codeInputBox.SelectionColor = Color.Blue;

							Select(at,l.Parameter);
							codeInputBox.SelectionFont = errorFont;
							codeInputBox.SelectionColor = Color.Maroon;
						}
						catch
						{
							codeInputBox.SelectionFont = errorFont;
							codeInputBox.SelectionColor = Color.Maroon;
						}
					}

					if (l.Label.HasValue)
					{
						Select(at,l.Label);
						codeInputBox.SelectionFont = labelFont;
						codeInputBox.SelectionColor = Color.Black;
					}

					if (l.Parameter.HasValue)
					{
						Select(at, l.Parameter);
						try
						{
							Language.ParsedType t;
							Language.ParseParameter(parameterType, l, out t);
							switch (t)
							{
								case Language.ParsedType.Constant:
									codeInputBox.SelectionColor = Color.FromArgb(0xb0, 0x60, 0);
									break;
								case Language.ParsedType.Address:
									codeInputBox.SelectionColor = Color.FromArgb(0,0xb0, 0x60);
									break;
								case Language.ParsedType.Label:
									codeInputBox.SelectionFont = labelFont;
									break;
								case Language.ParsedType.SpecialAddress:
									codeInputBox.SelectionFont = specialAddressFont;
									codeInputBox.SelectionColor = Color.FromArgb(0x90, 0, 0x50);
									break;
							}
						}
						catch
						{
							codeInputBox.SelectionFont = errorFont;
							codeInputBox.SelectionColor = Color.Maroon;
						}
					}

					if (l.Comment.HasValue)
					{
						Select(at,l.Comment);
						codeInputBox.SelectionFont = commentFont;
						codeInputBox.SelectionColor = Color.DarkGreen;
					}
				}
				catch
				{
					codeInputBox.Select(at, line.Length);
					codeInputBox.SelectionFont = errorFont;
					codeInputBox.SelectionColor = Color.Maroon;
				}



				at += line.Length + 1;
			}

			codeInputBox.Select(start, len);
			ResumeDrawing(this);
		}

		private void Select(int offset, Language.ParsedSegment seg)
		{
			Select(new Selection(offset, seg));
		}

		private void Select(Selection sel)
		{
			codeInputBox.Select(sel.start,sel.length);
		}

		private Selection GetSelected()
		{
			return new Selection() { start = codeInputBox.SelectionStart, length = codeInputBox.SelectionLength };
		}



		List<string> back = new List<string>();
		List<string> fore = new List<string>();
		bool ignoreChange = false;
		string lastText = null;

		private void codeInputBox_TextChanged(object sender, EventArgs e)
		{
			bool actualChange = codeInputBox.Text != lastText;
			if (!ignoreChange)
			{
				fore.Clear();
				if (lastText != null)
					back.Add(lastText);
				if (back.Count > 1024)
					back.RemoveRange(0, 64);//bulk
			}
			lastText = codeInputBox.Text;
			ReColor();
		}

		private void EditorForm_Shown(object sender, EventArgs e)
		{
			ReColor();
		}

		private void codeInputBox_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void codeInputBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				var sel = GetSelected();
				switch (e.KeyCode)
				{
					case Keys.C:
						Clipboard.SetText(codeInputBox.Text);
						e.Handled = true;
						break;
					case Keys.X:
						Clipboard.SetText(codeInputBox.Text);
						codeInputBox.Text = "";
						e.Handled = true;
						break;
					case Keys.V:
						codeInputBox.Text = Clipboard.GetText();
						e.Handled = true;
						break;
					case Keys.A:
						codeInputBox.SelectAll();
						e.Handled = true;
						break;
					case Keys.Z:
						{
							if (back.Count > 0)
							{
								ignoreChange = true;
								string text = back[back.Count - 1];
								back.RemoveAt(back.Count - 1);
								fore.Add(codeInputBox.Text);
								codeInputBox.Text = text;
								Select(sel);
								ignoreChange = false;
							}
							e.Handled = true;
						}
						break;
					case Keys.Y:
						{
							if (fore.Count > 0)
							{
								ignoreChange = true;
								string text = fore[fore.Count - 1];
								fore.RemoveAt(fore.Count - 1);
								back.Add(codeInputBox.Text);
								codeInputBox.Text = text;
								Select(sel);
								ignoreChange = false;
							}
							e.Handled = true;
						}
						break;
				}
			}
		}
	}




}
