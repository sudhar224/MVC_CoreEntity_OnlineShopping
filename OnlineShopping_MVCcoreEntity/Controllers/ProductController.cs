using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProductController(ApplicationDbContext db) 
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Product> objProduct = _db.Products.ToList();
			if (objProduct == null)
			{
				return NotFound();
			}
			return View(objProduct);
		}
		public IActionResult Search(string query)
		{
			if(query == null)
			{
				List<Product> objProduct = _db.Products.ToList();
				return View("Index",objProduct);
			}
		 
		   var item = _db.Products.Where(u => u.ProductName.Contains(query) || u.ProductDescription.Contains (query)).ToList();
			return View("Index",item);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Product objProduct)
		{
			if(ModelState.IsValid)
			{
				_db.Products.Add(objProduct);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

		public IActionResult Edit(int id)
		{
			if(id == null || id == 0)
			{
				return BadRequest();
			}
			Product objProduct = _db.Products.FirstOrDefault(u => u.Id == id);
			if (objProduct == null)
			{
				return NotFound();
			}
			return View(objProduct);
		}
		[HttpPost]
		public IActionResult Edit(Product objProduct)
		{
			if(ModelState.IsValid)
			{
                _db.Products.Update(objProduct);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
			return View();
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			if(id == null || id ==0)
			{
				return BadRequest();
			}
			Product objProduct = _db.Products.FirstOrDefault(u => u.Id == id);
			if (objProduct == null)
			{
				return NotFound();
			}
			return View(objProduct);

		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(int id)
		{
			Product objProduct = _db.Products.FirstOrDefault(u => u.Id==id);
			if (objProduct == null)
			{
				return NotFound();
			}
			_db.Products.Remove(objProduct);
			_db.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult UserProduct()
		{
			List<Product> objproduct = _db.Products.ToList();
			return View(objproduct);
		}

		public IActionResult Details(int id)
		{
			Product objProduct = _db.Products.FirstOrDefault(u => u.Id==id);
			return View(objProduct);
		}
	}
}
