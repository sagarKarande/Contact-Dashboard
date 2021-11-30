using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication2.Models
{
    public interface IRepository
    {
        Task<IEnumerable<ContactModel>> GetContacts();
        Task<ContactModel> GetContact(int contact_id);
        bool SaveContact(ContactModel contact);

        bool UpdateContact(int Contact_Id, ContactModel contact);

        bool DeleteContact(int Contact_Id);
    }
}
