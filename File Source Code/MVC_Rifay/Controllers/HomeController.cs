using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Rifay.Models;
using System.Diagnostics;
using System.Security.AccessControl;

namespace MVC_Rifay.Controllers
{
	
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _db;
		public HomeController(ILogger<HomeController> logger ,AppDbContext db) { 
		
			_db=db;
			_logger = logger;
		}

		
		public IActionResult Index()
		{
			List<Room> li = _db.Rooms.ToList();
			ViewBag.list = li;
			var name = HttpContext.Session.GetString("Name");
			ViewBag.username = name;
			return View();
		}

		public IActionResult about()
		{
			return View();
		}
        public IActionResult accomodation()
        {
            List<Room> li = _db.Rooms.ToList();
			ViewBag.list = li;
            return View();
        }
        public IActionResult blog()
        {
            return View();
        }
        public IActionResult contact()
        {

            return View();
        }
		public IActionResult Booking(int id)
		{
			HttpContext.Session.SetInt32("Room_Id", id);
			Room rr = _db.Rooms.Find(id);
			var cust_id = HttpContext.Session.GetInt32("ID");
			Customer cust=_db.Customers.Find(cust_id);
			ViewBag.cust = cust;
			return View(rr);
		}
	public IActionResult book(DateTime checkin,DateTime checkout ,string user_email,string pass)
		{
			var room_id = HttpContext.Session.GetInt32("Room_Id");
				var cust_id = HttpContext.Session.GetInt32("ID");
				Customer cust = _db.Customers.Find(cust_id);
			if(cust.Password==pass&& cust.Email==user_email)
			{
                Booking booking = new Booking();
                booking.customer_id = cust.Id;
                booking.CheckIn = checkin;
                booking.CheckOut = checkout;

                if (ModelState.IsValid)
                {
                    _db.Bookings.Add(booking);
                    _db.SaveChanges();
                }

                return RedirectToAction("Booking_Details", "Home");
            }
			else
			{
				ViewBag.massage = "the password or email is not corect";
				return View("/Views/Home/Booking.cshtml");
			
			}
			
			
		}
		public IActionResult Booking_Details()
		{
			var lastInsertedId = _db.Bookings.Max(e => e.booking_id);  
			Booking booking = _db.Bookings.Find(lastInsertedId);
			var room_id=HttpContext.Session.GetInt32("Room_Id");
			Room rr = _db.Rooms.Find(room_id);
			TimeSpan timeSpan = (booking.CheckOut -booking.CheckIn);
			int totalDays = (int)timeSpan.TotalDays;
			Booking_Details details = new Booking_Details();
			details.BookingAmount = (decimal)( totalDays * rr.RCPrice);
			details.RoomId = rr.RoomId;
			details.TotalDays = totalDays;
			
			details.BookingId = lastInsertedId;
			if (ModelState.IsValid)
			{
				_db.BookingDetails.Add(details);
				_db.SaveChanges();
			}
			return RedirectToAction("Payment","Home");
		}
		public IActionResult Payment()
		{
			List<Booking_Details> details = _db.BookingDetails.ToList();
			return View(details);
		}
		public IActionResult card(string CVV,string CardHoldername,string CardNumber,DateTime ExpiratonDate)
		{
			Credit_Card card = new Credit_Card();
			card.CardNumber = CardNumber;
			card.CardHolderName = CardHoldername;
			card.CVV = CVV;
			card.ExpirationDate = ExpiratonDate;
			_db.CreditCards.Add(card);
			_db.SaveChanges();

			return RedirectToAction("Index","Home");
		}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}