using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCMS.Models.Abstract;
using MyCMS.Models.Entities;

namespace MyCMS.Models.Concrete
{
    public class EfContactRepository:IContactRepository
    {
        private readonly EfDbContext _db=new EfDbContext();
        public IQueryable<Contact> GetContacts
        {
            get { return _db.Contacts; }
        } 

        public void SaveContact(Contact contact)
        {
            if (GetContacts.Where(x => x.ContactId == contact.ContactId).Count() == 0)
            {
                _db.Contacts.Add(contact);
            }
            _db.SaveChanges();
        }

        public void DeleteContact(Contact contact)
        {
            _db.Contacts.Remove(contact);
            _db.SaveChanges();
        }
    }
}