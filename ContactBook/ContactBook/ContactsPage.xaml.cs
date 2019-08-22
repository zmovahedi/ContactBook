using ContactBook.Models;
using ContactBook.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        private ContactService _contactService;
        private Contact _detailPageContact;

        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactsPage()
        {
            _contactService = new ContactService();

            InitializeComponent();
            Contacts = new ObservableCollection<Contact>(_contactService.GetContacts());
            listView.ItemsSource = Contacts;
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var contact = e.SelectedItem as Contact;

            listView.SelectedItem = null;


            var detailPage = new ContactDetailPage(contact);
            _detailPageContact = detailPage.BindingContext as Contact;

            detailPage.SaveButton.Clicked += SaveButton_Clicked;
            Navigation.PushAsync(detailPage);


        }
        

        private void add_Clicked(object sender, EventArgs e)
        {
            var contactDetailPage = new ContactDetailPage(new Contact());

            _detailPageContact = contactDetailPage.BindingContext as Contact;

            contactDetailPage.SaveButton.Clicked += SaveButton_Clicked;
            var context = contactDetailPage.BindingContext;
            Navigation.PushAsync(contactDetailPage);
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            var detailPage = sender as ContactDetailPage;

            if (_detailPageContact.Id == 0)
            {
                _detailPageContact.Id = 1;
                _contactService.AddContact(_detailPageContact);
                Contacts.Add(_detailPageContact);
            }
            else
            {
                _contactService.EditContact(_detailPageContact);
            }
            Navigation.PopAsync();
        }

        private async void delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            var isConfirmed = await DisplayAlert("Alert", "Are you sure??", "Yes", "No");
            if (!isConfirmed) return;

            _contactService.DeleteContact(contact.Id);
            Contacts.Remove(contact);
        }
    }
}