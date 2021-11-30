using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAPI.Models
{
    public interface IContact
    {
        IEnumerable<Contact> GetContactList();
        Contact GetContact(int contact_Id);

        void SaveContact(Contact contact);

        Contact UpdateContact(int Contact_Id, Contact contact);

        bool DeleteContact(int Contact_Id);
    }
}
