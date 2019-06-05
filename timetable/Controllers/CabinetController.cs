using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Linq;

using timetable.Models;

namespace timetable.Controllers
{
    public class CabinetController : Controller
    {
        private readonly TimetableContext _context;

        public CabinetController(TimetableContext context)
        {
            _context = context;
        }
    
        // 
        // GET: /Cabinet/

        public IActionResult Index()
        {
            return View(_context.Cabinets.ToList());
        }

        // 
        // GET: /Cabinet/Create/ 

        public IActionResult Create()  
        {  
            return View();  
        }  
  
        // 
        // POST: /Cabinet/Create/ 

        [HttpPost]  
        public IActionResult Create(Cabinet model)  
        {  
            ModelState.Remove("CabinetId");  
            if (ModelState.IsValid)  
            {  
                _context.Cabinets.Add(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View();  
        }
        
        // 
        // GET: /Cabinet/Edit/ 

        public IActionResult Edit(int id)  
        {  
            Cabinet data = _context.Cabinets.Where(p => p.CabinetId == id).FirstOrDefault();  
            return View("Create", data);  
        }  
  
        // 
        // POST: /Cabinet/Edit/ 

        [HttpPost]  
        public IActionResult Edit(Cabinet model)  
        {  
            ModelState.Remove("CabinetId");  
            if (ModelState.IsValid)  
            {  
                _context.Cabinets.Update(model);  
                _context.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View("Create", model);  
        }
        
        public IActionResult Delete(int id)  
        {  
            Cabinet data = _context.Cabinets.Where(p => p.CabinetId == id).FirstOrDefault();  
            if (data != null)  
            {  
                _context.Cabinets.Remove(data);  
                _context.SaveChanges();  
            }  
            return RedirectToAction("Index");  
        } 
    }
}
