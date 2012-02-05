using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCMS.Models.Abstract;
using MyCMS.Models.Entities;

namespace MyCMS.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;
        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult Contact()
        {
            var contacts = _repository.GetContacts.ToList();
            return PartialView(contacts);
        }

        

    }
}
