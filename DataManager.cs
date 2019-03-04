using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace PhoneBook
{
	public class DataManager
	{
		const string STORAGE_PATH = @"Data/Contacts/";

		public DataManager()
		{
			
			if (!Directory.Exists(STORAGE_PATH)) {
				Directory.CreateDirectory(STORAGE_PATH);
			}
		}

		public void AddContact(Contact contact)
		{
			File.WriteAllLines(CreatePath(contact.Name), new string[] {
				contact.Number.ToString()
			});
		}

		public bool DellContact(string name)
		{
			if (File.Exists(CreatePath(name))) {
				File.Delete(CreatePath(name));
				return true;
			} else {
				return false;
			}
		}

		public int GetNumberFromName(string name)
		{
			if (File.Exists(CreatePath(name)))
			{
				return Convert.ToInt32(File.ReadAllText(CreatePath(name)));
			}
			else
			{
				return 0;
			}
		}

		public bool ContactExits(string name)
		{
			if (File.Exists(CreatePath(name)))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public List<Contact>  GetAllContacts()
		{
			List<Contact> cc = new List<Contact>();
			string[] files = Directory.GetFiles(STORAGE_PATH);

			foreach (string f in files)
			{
				int number = Convert.ToInt32(File.ReadAllText( f));

				cc.Add(new Contact(Path.GetFileNameWithoutExtension(f), number));
			}

			return cc;
		}

		private string CreatePath(string name)
		{
			return STORAGE_PATH + name + ".txt";
		}
	}
}
