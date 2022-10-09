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
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _context;

        public CoverTypeController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            IEnumerable<CoverType> coverTypes = _context.CoverType.GetAll();
            return View(coverTypes);
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverType = _context.CoverType.GetFirstOrDefault(x => x.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
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
        public async Task<IActionResult> Create(CoverType obj)
        {
            

            if (ModelState.IsValid)
            {
                _context.CoverType.Add(obj);
                _context.Save();
                TempData["success"] = "Cover Type has been created successfully";
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

            var coverType = _context.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoverType obj)
        {
            

            if (ModelState.IsValid)
            {
                _context.CoverType.Update(obj);
                _context.Save();
                TempData["success"] = "Cover Type has been created successfully";
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

            var coverType = _context.CoverType.GetFirstOrDefault(x => x.Id == id);

            if (coverType == null)
            {
                return NotFound();
            }

            return View(coverType);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var coverType = _context.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }

            _context.CoverType.Remove(coverType);
            _context.Save();

            TempData["success"] = "Cover Type has been deleted successfully";
            return RedirectToAction("Index");
        }



    }
}
