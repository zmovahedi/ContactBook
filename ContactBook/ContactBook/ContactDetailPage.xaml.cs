using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public Button SaveButton
        {
            get { return save; }
        }

        public ContactDetailPage(Contact contact)
        {
            InitializeComponent();

            BindingContext = new Contact
            {
                Id = contact.Id,
                Blocked = contact.Blocked,
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone
            };
        }
    }
}