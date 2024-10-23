using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           List<Employee> objEmployee = _db.tbl_Employee.ToList();
            return View(objEmployee);
        }

        public IActionResult SearchEmployee(string query)
        {
            if(query == null)
            {
				List<Employee> objEmployee1 = _db.tbl_Employee.ToList();
                return View("Index",objEmployee1);

			}
            List<Employee> objEmployee = _db.tbl_Employee.Where(u => u.EmployeeName.Contains(query)).ToList();
            return View("Index",objEmployee);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee objEmployee)
        {
            if(ModelState.IsValid)
            {
				_db.tbl_Employee.Add(objEmployee);
				_db.SaveChanges();
                TempData["Success"] = "Employee Added Successfully";
				return RedirectToAction("Index");
                

			}
			return View();
		}
        public IActionResult Edit(int id)  
        {
            Employee objEmployee = _db.tbl_Employee.FirstOrDefault(u => u.Id == id);
            return View(objEmployee);
        }
        [HttpPost]
        public IActionResult Edit(Employee objEmployee)
        {
            _db.tbl_Employee.Update(objEmployee);
            _db.SaveChanges();
            return View();
        }
        public IActionResult Delete(int id)
        {
            Employee objEmployee = _db.tbl_Employee.FirstOrDefault(u => u.Id == id);
            return View(objEmployee);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Employee objEmployee = _db.tbl_Employee.Where(u => u.Id == id).FirstOrDefault();
            _db.tbl_Employee.Remove(objEmployee);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
