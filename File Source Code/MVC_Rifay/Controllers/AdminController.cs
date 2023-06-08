using Microsoft.AspNetCore.Mvc;
using MVC_Rifay.Models;
using Microsoft.Extensions.Hosting;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace MVC_Rifay.Controllers
{

    public class AdminController : Controller
    {
		private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _environment;
       
		public AdminController(AppDbContext db, IWebHostEnvironment environment)
		{
            
			_db = db;
			_environment = environment;
			
		}
		
		public IActionResult add_Booking()
        {
            return View();
        }
        public IActionResult all_Booking()
        {
            return View();
        }
        public IActionResult edit_Booking()
        {
            return View();
        }



        public IActionResult all_Customer()
        {
            ViewBag.customers = _db.Customers.ToList();
            return View();
        }
        public IActionResult edit_Customer(int id)
        {
            Customer customer=_db.Customers.Find(id);
            return View(customer);
        }
        public IActionResult edit_cust(string cust_Address,string cust_Email,string cust_Phone,int cust_id)
        {
            int id = cust_id;
            Customer cust = _db.Customers.Find(id);
            cust.Address = cust_Address;
            cust.Email = cust_Email;
            cust.PhoneNumber = cust_Phone;
            
            _db.Customers.Update(cust);
            _db.SaveChanges();

            return RedirectToAction("edit_Room");

        }
		public IActionResult delete_Customer(int id)
		{
            Customer cust = _db.Customers.Find(id);
            _db.Customers.Remove(cust);
			_db.SaveChanges();
			return RedirectToAction("all_Customer");
		}

		public IActionResult add_Room()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> add_Room(IFormFile img, [Bind("Bed_Count,Category,active,Food,cancellation,RCFloor,RCPrice")]Room room)
        {
            string path = Path.Combine(_environment.WebRootPath, "image");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if(img!=null)
            {
                path = Path.Combine(path, img.FileName);
                using(var stream=new FileStream(path,FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                    room.imge = img.FileName;
                }
            }

			

			if (ModelState.IsValid)
			{
				_db.Rooms.Add(room);
				_db.SaveChanges();

			}
			else
			{
				ViewBag.ex = "NOt inserted";
				return RedirectToAction("edit_Room");
			}
			return RedirectToAction("add_Room");

		}



        public  IActionResult edit_r(Room room)
        {
					int roomId = room.RoomId;
            Room rm = _db.Rooms.Find(roomId);
					rm.Food = room.Food;
					rm.active = room.active;
					rm.Bed_Count = room.Bed_Count;
					rm.RCPrice = room.RCPrice;
					rm.Category = room.Category;
					rm.cancellation = room.cancellation;
					rm.RCFloor = room.RCFloor;
					_db.Rooms.Update(rm);
					_db.SaveChanges();

            return RedirectToAction("edit_Room", room);
		}


		public IActionResult all_Room()
        {
			
            List<Room> rooms = _db.Rooms.ToList();
			return View(rooms);
        }
        public IActionResult edit_Room(int id)
        {
			Room rm = _db.Rooms.Find(id);

			return View(rm);
        }
        public IActionResult delete_Room(int Room_Id)
        {
			
			Room rm = _db.Rooms.Find(Room_Id);
            _db.Rooms.Remove(rm);
            _db.SaveChanges();
            return RedirectToAction("all_Room");
		}
        public IActionResult Logout()
        {
            
            return RedirectToAction("Login", "User_Data");
		}
        public IActionResult profile()
        {
            var admin_id = HttpContext.Session.GetInt32("admin_id");
            Admin admin = _db.Admins.Find(admin_id);
            return View(admin);
        }
        public IActionResult change_pass(string oldPass,string newPass,string cNewPass)
        {
			var admin_id = HttpContext.Session.GetInt32("admin_id");
			Admin admin = _db.Admins.Find(admin_id);
            if (admin.Password == oldPass && newPass == cNewPass)
            {
                admin.Password = newPass;
                _db.Admins.Update(admin);
                _db.SaveChanges();
            }
            return RedirectToAction("all_Room", "Admin");
		}
        public IActionResult edit_profile(string name ,string email)
        {
			var admin_id = HttpContext.Session.GetInt32("admin_id");
			Admin admin = _db.Admins.Find(admin_id);
            admin.name = name;
            admin.Email = email;
            _db.Admins.Update(admin);
            _db.SaveChanges();
			return RedirectToAction("profile");
        }
	}
}
