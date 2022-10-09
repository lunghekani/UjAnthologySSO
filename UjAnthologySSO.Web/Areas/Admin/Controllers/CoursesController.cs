using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UjAnthologySSO.DataAccess;
using UjAnthologySSO.DataAccess.Repository.IRepository;
using UjAnthologySSO.Models;


namespace UjAnthologySSO.Web.Areas.Admin.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _context;

        public CoursesController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            IEnumerable<Course> objCourses = _context.Courses.GetAll();
            return View(objCourses);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var course = _context.Courses.GetFirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the name of the course");
            }

            if (ModelState.IsValid)
            {
                _context.Courses.Add(obj);
                _context.Save();
                TempData["success"] = "Course has been created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var course = _context.Courses.GetFirstOrDefault(u => u.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot match the name of the course");
            }

            if (ModelState.IsValid)
            {
                _context.Courses.Update(obj);
                _context.Save();
                TempData["success"] = "Course has been created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var course = _context.Courses.GetFirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var course = _context.Courses.GetFirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.Save();

            TempData["success"] = "Course has been deleted successfully";
            return RedirectToAction("Index");
        }



    }
}
