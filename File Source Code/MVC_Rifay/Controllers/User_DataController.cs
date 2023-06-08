using Microsoft.AspNetCore.Mvc;
using MVC_Rifay.Models;

namespace MVC_Rifay.Controllers
{
    public class User_DataController : Controller
    {
		private readonly AppDbContext _db;
		private readonly IWebHostEnvironment _environment;
		public User_DataController(AppDbContext db, IWebHostEnvironment environment)
		{

			_db = db;
			_environment = environment;
		}
		public IActionResult Signup()
        {
            return View();
        }
        public IActionResult sgnup(string confirm,[Bind("Name,Address,Email,DOB,Password,PhoneNumber")] Customer cust)
        {

            if(confirm == null||confirm!=cust.Password)
            {
                return RedirectToAction("Signup", "User_Data");
            }
            _db.Customers.Add(cust);
            _db.SaveChanges();
            return RedirectToAction("Login", "User_Data");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult sigin(string pass,string user)
        {
            List<Customer> cstmer = _db.Customers.ToList();
            List<Admin> add = _db.Admins.ToList();
			foreach (var ad in add)
			{
				if (user == ad.Email && pass == ad.Password)
				{
                    HttpContext.Session.SetInt32("admin_id", ad.id);
					return RedirectToAction("all_Room", "Admin");
				}
			}
			foreach (var cust in cstmer)
            {
				if (user==cust.Email&&pass==cust.Password)
                {
                    HttpContext.Session.SetInt32("ID", cust.Id);
                    HttpContext.Session.SetString("Name", cust.Name);
                   return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Login");
        }

    }
}
