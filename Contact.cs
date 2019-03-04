using System;
namespace PhoneBook
{
	public class Contact
	{
		public string Name;
		public int Number;

		public Contact() { }

		public Contact(string name,int number)
		{
			Name = name;
			Number = number;
		}
	}
}
