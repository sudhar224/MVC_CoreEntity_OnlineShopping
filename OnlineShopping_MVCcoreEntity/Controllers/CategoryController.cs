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
				return RedirectToAction("Index");
			}
            return View();
         
		}



	}
}
