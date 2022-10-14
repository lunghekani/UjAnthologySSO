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
using UjAnthologySSO.Models.ViewModels;


namespace UjAnthologySSO.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;

        public ProductController(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = _context.Product.GetAll();
            return View(products);
        }
      

      
        // GET: Product/Edit/5
        public async Task<IActionResult> Upsert(int? id)
        {
            ProductVM productVm = new()
            {
                product = new Product(),
                CourseList = _context.Courses.GetAll().Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),
                CoverList = _context.CoverType.GetAll().Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    })
            };

            if (id == null || id == 0)
            {
                //create a product
              
                return View(productVm);
            }
            else
            {
                // update a product
            }

            return View(productVm);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ProductVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //_context.CoverType.Update(obj);
                _context.Save();
                TempData["success"] = "Cover Type has been created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

       



    }
}
