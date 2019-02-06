using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataBindingDemo1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Grouping<string, Contact>> ContactGroup;
        public MainPage()
        {
            InitContacts();
            BindingContext = ContactGroup;
            InitializeComponent();
        }

        private void InitContacts()
        {
            var listOfContacts = ContactGenerator.CreateContacts();

            var sorted =
                from c in listOfContacts.Result
                orderby c.FirstName
                group c by c.FirstName[0].ToString()
                into theGroup
                select new Grouping<string, Contact>(theGroup.Key, theGroup);

            ContactGroup = new ObservableCollection<Grouping<string, Contact>>(sorted);
        }

        public void OnItemTapped(Object o, ItemTappedEventArgs eventArgs)
        {
            var contact = eventArgs.Item as Contact;

            if (contact != null)
            {
                DisplayAlert("Contact", String.Format("You selected {0} {1} {2}", contact.FirstName, contact.LastName, contact.Email), "OK");
            }
        }
    }
}
