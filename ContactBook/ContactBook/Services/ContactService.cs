using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Services
{
    public class ContactService
    {
        private List<Contact> _contacts = new List<Contact>()
        {
            new Contact
            {
                Id = 1, FirstName = "Zahra", LastName = "Movahedi", Email = "zahra@zahramovahedi.ir", Phone = "09354444444", Blocked = false
            },
            new Contact
            {
                Id = 2, FirstName = "Setayesh", LastName = "Shahab", Email = "setayesh@zahramovahedi.ir", Phone = "09355555555", Blocked = true
            }
        };

        public ContactService()
        {
            
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void EditContact(Contact contact)
        {
            var persisted = _contacts.First(c => c.Id == contact.Id);
            persisted.FirstName = contact.FirstName;
            persisted.LastName = contact.LastName;
            persisted.Email = contact.Email;
            persisted.Phone = contact.Phone;
            contact.Blocked = contact.Blocked;
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.First(c => c.Id == id);
            _contacts.Remove(contact);
        }
    }
}
