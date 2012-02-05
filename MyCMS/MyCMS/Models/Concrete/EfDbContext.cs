using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MyCMS.Models.Entities;

namespace MyCMS.Models.Concrete
{
    public class EfDbContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}