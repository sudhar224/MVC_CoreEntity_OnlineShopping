using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
       public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategory = _db.Categories.ToList();
            return View(objCategory);
        }

       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category objCategory)
        {
            if(objCategory.Name == objCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", ("Name and Display order cannot be same"));
            }

            if(ModelState.IsValid)
            {
                _db.Categories.Add(objCategory);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");

			}
            return View();
        }

        public IActionResult Edit(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category objCategory = _db.Categories.Find(id);
			Category objCategory1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            if(objCategory1 == null)
            {
                return NotFound();
            }
            return View(objCategory1);
        }
        [HttpPost]
        public IActionResult Edit(Category objCategory)
        {
            if(ModelState.IsValid)
            {
				_db.Categories.Update(objCategory);
				_db.SaveChanges();
				TempData["Success"] = "Category Created Successfully";
				return RedirectToAction("Index");
			}
            return View();
          
        }

       public IActionResult Delete(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category objCategory = _db.Categories.Find(id);
            _db.Categories.FirstOrDefault(u => u.Id == id);
            if(objCategory == null)
            {
                return NotFound();
            }

            return View(objCategory);
		}

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
			Category objCategory = _db.Categories.Find(id);
			if (objCategory == null)
			{
				return NotFound();
			}
            _db.Categories.Remove(objCategory);
            _db.SaveChanges();

			TempData["Success"] = "Category Deleted Successfully";
			return RedirectToAction("Index");
        }

    }
}
