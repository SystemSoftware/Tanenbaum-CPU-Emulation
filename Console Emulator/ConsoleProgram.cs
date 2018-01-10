﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Emulator
{
	class ConsoleProgram
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.Error.WriteLine("Usage: trun filename");
				return;
			}
			Machine.Emulator exec = null;
			try
			{
				exec = new Machine.Emulator(Machine.Language.Parse(File.ReadAllLines(args[0])), x => Console.WriteLine(x));
				exec.Execute(int.MaxValue);
			}
			catch (Machine.CommandException ex)
			{
				Console.Error.WriteLine(ex.Message);
				if (ex.InnerException is Machine.CommandNotFoundException)
				{
					Console.WriteLine("Known commands: ");
					Console.WriteLine("  [label]:");
					foreach (var cmd in Machine.Language.Commands)
						if (cmd.RequiresParameter)
							Console.WriteLine("  " + cmd.Name + " [" + cmd.Parameter + "]");
						else
							Console.WriteLine("  " + cmd.Name);
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			if (exec != null)
				Console.WriteLine("Program ended after " + exec.InstructionCounter + " instruction(s)");

		}
	}
}
