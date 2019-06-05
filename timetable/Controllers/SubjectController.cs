using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Linq;

using timetable.Models;

namespace timetable.Controllers
{
    public class SubjectController : Controller
    {
        private readonly TimetableContext _context;

        public SubjectController(TimetableContext context)
        {
            _context = context;
        }
    
        // 
        // GET: /Subject/

        public IActionResult Index()
        {
            return View(_context.Subjects.ToList());
        }

        // 
        // GET: /Subject/Create/ 

        public IActionResult Create()  
        {  
            return View();  
        }  
  
        // 
        // POST: /Subject/Create/ 

        [HttpPost]  
        public IActionResult Create(Subject model)  
        {  
            ModelState.Remove("SubjectId");  
            if (ModelState.IsValid)  
            {  
                _context.Subjects.Add(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View();  
        }
        
        // 
        // GET: /Subject/Edit/ 

        public IActionResult Edit(int id)  
        {  
            Subject data = _context.Subjects.Where(p => p.SubjectId == id).FirstOrDefault();  
            return View("Create", data);  
        }  
  
        // 
        // POST: /Subject/Edit/ 

        [HttpPost]  
        public IActionResult Edit(Subject model)  
        {  
            ModelState.Remove("SubjectId");  
            if (ModelState.IsValid)  
            {  
                _context.Subjects.Update(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View("Create", model);  
        }
        
        public IActionResult Delete(int id)  
        {  
            Subject data = _context.Subjects.Where(p => p.SubjectId == id).FirstOrDefault();  
            if (data != null)  
            {  
                _context.Subjects.Remove(data);  
                _context.SaveChanges();  
            }  
            return RedirectToAction("Index");  
        } 
    }
}
