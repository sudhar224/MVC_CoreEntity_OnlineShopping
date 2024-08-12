using Microsoft.AspNetCore.Mvc;
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
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
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
                ModelState.AddModelError("Name","Name and display order cannot be same");
            }
            if(ModelState.IsValid)
            {
				_db.Categories.Add(objCategory);
				_db.SaveChanges();
				TempData["Success"] = ("Category Created Successfully");
				return RedirectToAction("Index");
                
			}
            return View();
         
		}

      
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //Category? catagoryFromDb = _db.Categories.Find (id);
            Category? catagoryFromDb1 = _db.Categories.FirstOrDefault( Categories => Categories.Id == id);
            //Category? catagoryFromDb2 = _db.Categories.Where(u => u.Id== id).FirstOrDefault();

			if (catagoryFromDb1 == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb1);
        }
        [HttpPost]
        public IActionResult Edit(Category objCategory)
        {
            if(ModelState.IsValid)
            {
				_db.Categories.Update(objCategory);
                _db.SaveChanges();
				TempData["Success"] = ("Category Updated Successfully");
			} 
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
             Category catagoryFromDb = _db.Categories.Find(id);

            if(catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
            
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Category catagoryFromDb =_db.Categories.Find(id);
            if(catagoryFromDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(catagoryFromDb);
            _db.SaveChanges();
			TempData["Success"] = ("Category Deleted Successfully");
			return RedirectToAction("Index");
			
		}

    }
}
