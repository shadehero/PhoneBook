using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PhoneBook
{
	class MainClass
	{
		static DataManager DT = new DataManager();

		public static void Main(string[] args)
		{
			Console.Title = "PhoneBook By ShadeHero";
			Console.WriteLine(" @ PhoneBook NBy ShadeHero @");



			while (true)
			{
				Console.Write(" $> ");
				string[] cmd = Console.ReadLine().Split(' ');

				switch (cmd[0])
				{
					case "/help":
						Command_Help();
						break;
					case "/add":
						Command_Add(cmd);
						break;
					case "/update":
						Command_Update(cmd);
						break;
					case "/del":
						Command_Dell(cmd);
						break;
					case "/get":
						Command_Get(cmd);
						break;
					case "/getall":
						Command_GetAll();
						break;
				}
			}


		}

		static void Command_Help()
		{
			Console.WriteLine("\n ::Help::\n");
			Console.WriteLine(" /add [name] [number]");
			Console.WriteLine(" /update [name] [number]");
			Console.WriteLine(" /del [name]");
			Console.WriteLine(" /get [name]");
			Console.WriteLine(" /getall \n");
		}

		static void Command_Add(string[] cmd)
		{
			if (cmd.Length != 3)
			{
				Console.WriteLine(" Command Syntax");
			}
			else
			{
				if (DT.ContactExits(cmd[1]))
				{
					Console.WriteLine(" Contact Exits. user /update to change number");
				}
				else
				{
					DT.AddContact(new Contact(cmd[1], Convert.ToInt32(cmd[2])));
					Console.WriteLine(" Contact: {0},{1} Added!", cmd[1], cmd[2]);
				}
			}
		}

		static void Command_Update(string[] cmd)
		{
			if (cmd.Length != 3)
			{
				Console.WriteLine(" Command Syntax");
			}
			else
			{
				if (!DT.ContactExits(cmd[1]))
				{
					Console.WriteLine(" Contact Doesn't Exits use /add");
				}
				else
				{
					DT.DellContact(cmd[1]);
					DT.AddContact(new Contact(cmd[1], Convert.ToInt32(cmd[2])));
					Console.WriteLine(" Contact {0} Updated!", cmd[1]);
				}
			}
		}

		static void Command_Dell(string[] cmd)
		{
			if (cmd.Length != 2)
			{
				Console.WriteLine(" Command Syntax");
			}
			else
			{
				if (!DT.ContactExits(cmd[1]))
				{
					Console.WriteLine(" Contact Doesn't Exits");
				}
				else
				{
					DT.DellContact(cmd[1]);
					Console.WriteLine(" Contact {0} Deleted!", cmd[1]);
				}
			}
		}

		static void Command_Get(string[] cmd)
		{
			if (cmd.Length != 2)
			{
				Console.WriteLine(" Command Syntax");
			}
			else
			{
				if (!DT.ContactExits(cmd[1]))
				{
					Console.WriteLine(" Contact Doesn't Exits");
				}
				else
				{
					Console.WriteLine(" @ {0} : {1}",cmd[1], DT.GetNumberFromName(cmd[1]));
				}
			}
		}

		static void Command_GetAll()
		{
			Console.WriteLine("\n List of all contacts! \n");
			foreach (Contact c in DT.GetAllContacts())
			{
				Console.WriteLine(" @ {0} : {1}", c.Name, c.Number);
			}
			Console.WriteLine();
		}
	}
}
