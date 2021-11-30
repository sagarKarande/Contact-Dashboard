using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly IRepository _contactRepository;

        public ContactController(IRepository repoObject)
        {
            _contactRepository = repoObject;
        }
        //
        // GET: /Contact/

        public async Task<ActionResult> ListContact(int page=0)
        {
            const int PageSize = 3; 
            IEnumerable<ContactModel> contacts = new List<ContactModel>();
            contacts = await _contactRepository.GetContacts();
            var count = contacts.Count();

            var data = contacts.Skip(page * PageSize).Take(PageSize).ToList();

            this.ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            this.ViewBag.Page = page;

            return View(data);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateContact(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_contactRepository.SaveContact(contact))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UpdateContact(int id)
        {
            ContactModel contact = await _contactRepository.GetContact(id);
            return View(contact);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateContact(int id, ContactModel contact)
        {
            try
            {
                if (_contactRepository.UpdateContact(id, contact))
                {
                    return RedirectToAction("ListContact");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        [Authorize]
        public ActionResult DeleteContact(int id)
        {
            try
            {   
                if (_contactRepository.DeleteContact(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("ListContact");
            }
            catch
            {
                return View();
            }
        }
    }
}
