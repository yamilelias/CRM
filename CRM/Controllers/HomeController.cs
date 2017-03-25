using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CRM.Models;

namespace CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Get count of database
            ViewBag.TotalAnnotations = _context.Annotations.Count();
            ViewBag.TotalContacts = _context.Contacts.Count();

            return View();
        }
    }
}