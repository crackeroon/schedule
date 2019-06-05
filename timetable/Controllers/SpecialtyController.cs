using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Linq;

using timetable.Models;

namespace timetable.Controllers
{
    public class SpecialtyController : Controller
    {
        private readonly TimetableContext _context;

        public SpecialtyController(TimetableContext context)
        {
            _context = context;
        }
    
        // 
        // GET: /Specialty/

        public IActionResult Index()
        {
            return View(_context.Specialties.ToList());
        }

        // 
        // GET: /Specialty/Create/ 

        public IActionResult Create()  
        {  
            return View();  
        }  
  
        // 
        // POST: /Specialty/Create/ 

        [HttpPost]  
        public IActionResult Create(Specialty model)  
        {  
            ModelState.Remove("SpecialtyId");  
            if (ModelState.IsValid)  
            {  
                _context.Specialties.Add(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View();  
        }
        
        // 
        // GET: /Specialty/Edit/ 

        public IActionResult Edit(int id)  
        {  
            Specialty data = _context.Specialties.Where(p => p.SpecialtyId == id).FirstOrDefault();  
            return View("Create", data);  
        }  
  
        // 
        // POST: /Specialty/Edit/ 

        [HttpPost]  
        public IActionResult Edit(Specialty model)  
        {  
            ModelState.Remove("SpecialtyId");  
            if (ModelState.IsValid)  
            {  
                _context.Specialties.Update(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View("Create", model);  
        }
        
        public IActionResult Delete(int id)  
        {  
            Specialty data = _context.Specialties.Where(p => p.SpecialtyId == id).FirstOrDefault();  
            if (data != null)  
            {  
                _context.Specialties.Remove(data);  
                _context.SaveChanges();  
            }  
            return RedirectToAction("Index");  
        } 
    }
}
