using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingDemo1
{
    public class ContactGenerator
    {
        private static List<string> FirstNames = new List<string> { "Ben", "Taylor", "Max", "Joe", "Brooke", "Liam" };
        private static List<string> LastNames = new List<string> { "Burgess", "McRofl", "Lol", "Omg", "Hai", "Wtf" };
        public static async Task<List<Contact>> CreateContacts()
        {
            var random = new Random();
            List<Contact> contacts = new List<Contact>();

            for (int i = 0; i < FirstNames.Count; i++)
            {
                string first = FirstNames[random.Next(FirstNames.Count - 1)];
                string last = LastNames[random.Next(LastNames.Count - 1)];

                first = InitCap(first);
                last = InitCap(last);
                Contact contact = new Contact();
                contact.FirstName = first;
                contact.LastName = last;
                contact.Email = first + "@ronoco.com";
                contacts.Add(contact);
            }
            return contacts;
        }

        private static string InitCap(string value)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(value[0]) + value.Substring(1);
        }
    }
}
