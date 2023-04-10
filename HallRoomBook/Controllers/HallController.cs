using HallRoomBook.Data;
using HallRoomBook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HallRoomBook.Controllers
{
    public class HallController : Controller
    {
        private HallRoomBookContext db = null;
        public HallController(HallRoomBookContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<MeetingHall> h = db.MeetingHall.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(MeetingHall hall)
        {
           if(ModelState.IsValid)
            {
                db.MeetingHall.Add(hall);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hall);
        }
        public IActionResult Index()
        {

            // List<Hall> model = db.Hall.ToList();
            //List<MeetingHall> model=(from h in db.MeetingHall select h).ToList();
            List<MeetingHall> model = db.MeetingHall.FromSqlRaw("select * from MeetingHall").ToList();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            MeetingHall HallDeatils = db.MeetingHall.Find(id);
            return View(HallDeatils);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MeetingHall HallEdit = db.MeetingHall.Find(id);
            return View(HallEdit);
        }
        [HttpPost]
        public IActionResult Edit(MeetingHall meetingHall)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.MeetingHall.Update(meetingHall);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return View(meetingHall);
                }
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            MeetingHall meetingHall = db.MeetingHall.Find(id);
            return View(meetingHall);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult confirmDelete(int id)
        {
            try
            {
                MeetingHall meetingHall = db.MeetingHall.Find(id);  
                db.MeetingHall.Remove(meetingHall);
                db.SaveChanges();
                TempData["msg"] = "Hall Deleted successfully";
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }


    }
}
