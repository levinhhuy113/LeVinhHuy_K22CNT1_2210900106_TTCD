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
    public class QUAN_TRIController : Controller
    {
        private LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities db = new LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities();

        // GET: QUAN_TRI
        public ActionResult Index()
        {
            return View(db.QUAN_TRI.ToList());
        }

        // GET: QUAN_TRI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QUAN_TRI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaQT,TenDangNhap,MatKhau,HoTen,Email")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.QUAN_TRI.Add(qUAN_TRI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaQT,TenDangNhap,MatKhau,HoTen,Email")] QUAN_TRI qUAN_TRI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qUAN_TRI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qUAN_TRI);
        }

        // GET: QUAN_TRI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            if (qUAN_TRI == null)
            {
                return HttpNotFound();
            }
            return View(qUAN_TRI);
        }

        // POST: QUAN_TRI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QUAN_TRI qUAN_TRI = db.QUAN_TRI.Find(id);
            db.QUAN_TRI.Remove(qUAN_TRI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm kiếm người dùng trong cơ sở dữ liệu dựa trên tên đăng nhập và mật khẩu
                var user = db.QUAN_TRI.FirstOrDefault(u => u.TenDangNhap == model.Username && u.MatKhau == model.Password);

                if (user != null)
                {
                    // Nếu người dùng tồn tại, lưu thông tin vào session
                    Session["TaiKhoan"] = user.TenDangNhap;

                    // Chuyển hướng đến trang chỉ định (trang quản trị)
                    return RedirectToAction("Index", "QUAN_TRI");
                }
                else
                {
                    // Nếu không tìm thấy người dùng, thêm thông báo lỗi vào ModelState
                    ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không hợp lệ.");
                }
            }

            // Nếu ModelState không hợp lệ hoặc người dùng không tìm thấy, quay lại trang đăng nhập với thông báo lỗi
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
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
