using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactAPI.Models
{
    public class ContactService : IContact,IDisposable
    {
        private ContactsDBEntities dbContact = new ContactsDBEntities();
        public IEnumerable<Contact> GetContactList()
        {
            return dbContact.Contacts.ToList();
        }

        public Contact GetContact(int contact_Id)
        {
            return dbContact.Contacts.Find(contact_Id);
        }

        public void SaveContact(Contact contact)
        {
            if (contact != null)
            {
                dbContact.Contacts.Add(contact);
                dbContact.SaveChanges();
            }
        }

        public Contact UpdateContact(int Contact_Id, Contact contact)
        {

            var entity = dbContact.Contacts.FirstOrDefault(x => x.Contact_Id == Contact_Id);
            if (entity != null)
            {
                entity.FirstName = contact.FirstName;
                entity.LastName = contact.LastName;
                entity.Email = contact.Email;
                entity.PhoneNumber = contact.PhoneNumber;
                dbContact.SaveChanges();
            }
            return entity;
        }

        public bool DeleteContact(int Contact_Id)
        {
            var entity = dbContact.Contacts.FirstOrDefault(x => x.Contact_Id == Contact_Id);
            if (entity != null)
            {
                dbContact.Contacts.Remove(entity);
                dbContact.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContact != null)
                {
                    dbContact.Dispose();
                    dbContact = null;
                }
            }
        }

        public void  Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}