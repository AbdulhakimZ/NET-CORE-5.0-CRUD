using abdulhamid.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace abdulhamid.Controllers
{
    public class ChildController : Controller
    {
        private readonly ILogger<ChildController> _logger;
        private readonly ToDoListContext _context;

        public ChildController(ILogger<ChildController> logger)
        {
            this._context = new ToDoListContext();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var childs = _context.ChildLists.Where(i => i.Id != null).ToList();
            return View(childs);
        }
        [HttpPost]
        public IActionResult Create(string title, string body)
        {
            var newChild = new ChildList();
            newChild.Title = title;
            newChild.Body = body;
            _context.Add(newChild);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var isExist = _context.ChildLists.Where(i => i.Id == Id).FirstOrDefault();
            if(isExist != null)
            {
                _context.Remove(isExist);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
