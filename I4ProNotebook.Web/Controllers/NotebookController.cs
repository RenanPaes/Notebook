using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4ProNotebook.Web.Models;
using I4PRONotebook.Entity.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace I4ProNotebook.Web.Controllers
{
    public class NotebookController : Controller
    {
        private readonly Models.AppContext _context;

        public NotebookController(Models.AppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetContacts()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var contacts = _context.Set<Contact>()
                .Include(e => e.Emails)
                .Include(e => e.PhoneNumbers)
                .ToList();

            return Json(contacts);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(NotepadModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            if (!string.IsNullOrEmpty(model.Name))
            {
                var newContact = new Contact() { Name = model.Name };
                _context.Set<Contact>().Add(newContact);

                foreach (PhoneNumber phoneNumber in model.PhoneNumbers)
                {
                    _context.Set<PhoneNumber>().Add(new PhoneNumber()
                    {
                        Number = phoneNumber.Number,
                        Contact = newContact
                    });
                }

                foreach (Email email in model.Emails)
                {
                    _context.Set<Email>().Add(new Email()
                    {
                        EmailName = email.EmailName,
                        Contact = newContact
                    });
                }

                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Change(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var model = _context.Set<Contact>()
                .Include(e => e.Emails)
                .Include(e => e.PhoneNumbers)
                .Where(e => e.ID == id)
                .SingleOrDefault();

            return View(model);
        }

        [HttpPost]
        public IActionResult Change(NotepadModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(e => e.Errors));

            var contact = new Contact(model.ID);
            contact.Name = model.Name;
            contact.PhoneNumbers = model.GetPhoneNumbers(contact, _context);
            contact.Emails = model.GetEmails(contact, _context);

            model.RemoveEmails(_context);
            model.RemovePhoneNumbers(_context);

            _context.Set<Contact>().Update(contact);
            _context.SaveChanges();
            

            return Ok();
        }
    }
}
