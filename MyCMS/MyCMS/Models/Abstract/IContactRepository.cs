using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCMS.Models.Entities;

namespace MyCMS.Models.Abstract
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetContacts { get; }

        void SaveContact(Contact contact);

        void DeleteContact(Contact contact);
    }
}