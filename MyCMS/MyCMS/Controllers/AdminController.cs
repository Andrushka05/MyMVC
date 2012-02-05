using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCMS.Models.Abstract;
using MyCMS.Models.Entities;

namespace MyCMS.Controllers
{
    //[Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        private readonly IContactRepository _repository;
        public AdminController(IContactRepository repository)
        {
            _repository = repository;
        }

        public ViewResult ListContacts()
        {
            return View(_repository.GetContacts);
        }

        public ViewResult EditContact(int contactId)
        {
            return View(_repository.GetContacts.FirstOrDefault(x => x.ContactId == contactId));
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = string.Format("Контакт {0} сохранён", contact.ContactId);
                _repository.SaveContact(contact);
                return RedirectToAction("ListContacts");
            }else
            {
                return View();
            }
        }

        public ActionResult CreateContact()
        {
            return RedirectToAction("EditContact", new Contact());
        }

        [HttpPost]
        public ActionResult DeleteContact(int contactId)
        {
            if (contactId > 0)
            {
                var contact = _repository.GetContacts.FirstOrDefault(x => x.ContactId == contactId);
                TempData["message"] = string.Format("Контакт {0} удалён", contact.ContactId);
                _repository.DeleteContact(contact);
            }
            return RedirectToAction("ListContacts");
        }
    }
}
