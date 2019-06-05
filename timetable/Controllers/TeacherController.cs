using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Linq;

using timetable.Models;

namespace timetable.Controllers
{
    public class TeacherController : Controller
    {
        private readonly TimetableContext _context;

        public TeacherController(TimetableContext context)
        {
            _context = context;
        }
    
        // 
        // GET: /Teacher/

        public IActionResult Index()
        {
            return View(_context.Teachers.ToList());
        }

        // 
        // GET: /Teacher/Create/ 

        public IActionResult Create()  
        {  
            return View();  
        }  
  
        // 
        // POST: /Teacher/Create/ 

        [HttpPost]  
        public IActionResult Create(Teacher model)  
        {  
            ModelState.Remove("TeacherId");  
            if (ModelState.IsValid)  
            {  
                _context.Teachers.Add(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View();  
        }
        
        // 
        // GET: /Teacher/Edit/ 

        public IActionResult Edit(int id)  
        {  
            Teacher data = _context.Teachers.Where(p => p.TeacherId == id).FirstOrDefault();  
            return View("Create", data);  
        }  
  
        // 
        // POST: /Teacher/Edit/ 

        [HttpPost]  
        public IActionResult Edit(Teacher model)  
        {  
            ModelState.Remove("TeacherId");  
            if (ModelState.IsValid)  
            {  
                _context.Teachers.Update(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View("Create", model);  
        }
        
        public IActionResult Delete(int id)  
        {  
            Teacher data = _context.Teachers.Where(p => p.TeacherId == id).FirstOrDefault();  
            if (data != null)  
            {  
                _context.Teachers.Remove(data);  
                _context.SaveChanges();  
            }  
            return RedirectToAction("Index");  
        } 
    }
}
