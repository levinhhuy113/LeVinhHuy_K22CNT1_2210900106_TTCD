using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LEVINHHUY_K22CNT1_2210900106_PROJECT2.Models;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Controllers
{
    public class KHACH_HANGController : Controller
    {
        private LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities db = new LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities();

        // GET: KHACH_HANG
        public ActionResult Index()
        {
            var kHACH_HANG = db.KHACH_HANG.Include(k => k.USER);
            return View(kHACH_HANG.ToList());
        }

        // GET: KHACH_HANG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.USERS, "UserId", "UserName");
            return View();
        }

        // POST: KHACH_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoTen,DiaChi,SoDienThoai,Email,NgayDangKy,NgayTao,NgayCapNhat,UserId")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.USERS, "UserId", "UserName", kHACH_HANG.UserId);
            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.USERS, "UserId", "UserName", kHACH_HANG.UserId);
            return View(kHACH_HANG);
        }

        // POST: KHACH_HANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoTen,DiaChi,SoDienThoai,Email,NgayDangKy,NgayTao,NgayCapNhat,UserId")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.USERS, "UserId", "UserName", kHACH_HANG.UserId);
            return View(kHACH_HANG);
        }

        // GET: KHACH_HANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            if (kHACH_HANG == null)
            {
                return HttpNotFound();
            }
            return View(kHACH_HANG);
        }

        // POST: KHACH_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KHACH_HANG kHACH_HANG = db.KHACH_HANG.Find(id);
            db.KHACH_HANG.Remove(kHACH_HANG);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
