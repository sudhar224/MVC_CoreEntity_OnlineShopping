using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
	public class RegisterController : Controller
	{
		private readonly ApplicationDbContext _db;
		public RegisterController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Register objRegister)
		{
			if(ModelState.IsValid)
			{
				_db.tbl_register.Add(objRegister);
				_db.SaveChanges();
				TempData["success"] = "Successfully Completed Your Registeration";
			}
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(Register objRegister)
		{			
			if(ModelState.IsValid)
			{
				_db.tbl_register.Where(u => u.Phone == objRegister.Phone && u.Password == objRegister.Password);
				return RedirectToAction("UserProduct", "Product");				
			}
			
			return View();
	
		}
	}
}

