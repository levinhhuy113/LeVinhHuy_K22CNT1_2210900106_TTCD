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
        private LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1 db = new LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1();

        // GET: KHACH_HANG
        public ActionResult Index()
        {
            if (Session["KhachHang"] == null)
            {
                return RedirectToAction("Login"); // Nếu chưa đăng nhập, chuyển hướng tới trang đăng nhập
            }

            return View(db.KHACH_HANG.ToList());
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
            return View();
        }

        // POST: KHACH_HANG/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,Ho_ten,Tai_khoan,Mat_khau,Dia_chi,Dien_thoai,Email,Ngay_sinh,Ngay_cap_nhat,Gioi_tinh,Trang_thai")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.KHACH_HANG.Add(kHACH_HANG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(kHACH_HANG);
        }

        // POST: KHACH_HANG/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,Ho_ten,Tai_khoan,Mat_khau,Dia_chi,Dien_thoai,Email,Ngay_sinh,Ngay_cap_nhat,Gioi_tinh,Trang_thai")] KHACH_HANG kHACH_HANG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kHACH_HANG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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


        // GET: KHACH_HANG/Login
        public ActionResult Login()
        {

            return View();
        }

        // POST: KHACH_HANG/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Tai_khoan, string Mat_khau)
        {
            // Giả sử mật khẩu đã được mã hóa
            var khachHang = db.KHACH_HANG.SingleOrDefault(k => k.Tai_khoan == Tai_khoan && k.Mat_khau == Mat_khau);

            if (khachHang != null)
            {
                // Đăng nhập thành công, lưu thông tin người dùng vào session
                Session["KhachHang"] = khachHang;
                return RedirectToAction("Index"); // Hoặc chuyển hướng tới trang khác
            }
            else
            {
                ViewBag.ErrorMessage = "Tài khoản hoặc mật khẩu không đúng!";
                return View();
            }
        }



        // GET: KHACH_HANG/Logout
        // GET: KHACH_HANG/Logout
        public ActionResult Logout()
        {
            // Xóa session
            Session["KhachHang"] = null;

            // Chuyển hướng đến trang đăng nhập
            return RedirectToAction("Login");
        }



    }
}
