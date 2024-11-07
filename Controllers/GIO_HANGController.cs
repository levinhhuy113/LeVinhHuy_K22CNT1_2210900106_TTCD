using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using LEVINHHUY_K22CNT1_2210900106_PROJECT2.Models;


namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Controllers
{
    public class GIO_HANGController : Controller
    {
        private LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities db = new LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities();

        // GET: GIO_HANG
        public ActionResult Index()
        {
            var userIdString = User.Identity.GetUserId(); // Lấy ID người dùng hiện tại
            int userId;

            // Kiểm tra nếu userIdString là null hoặc empty
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out userId))
            {
                // Nếu không có ID người dùng hợp lệ, trả về giỏ hàng trống
                return View(new List<GIO_HANG>()); // Trả về giỏ hàng trống
            }

            var gIO_HANG = db.GIO_HANG.Include(g => g.SAN_PHAM).Include(g => g.USER).Where(g => g.UserId == userId);
            return View(gIO_HANG.ToList());
        }



        public ActionResult AddToCart(int MaSP)
        {
            var userIdString = User.Identity.GetUserId(); // Lấy ID người dùng hiện tại

            // Kiểm tra nếu userIdString là null
            if (string.IsNullOrEmpty(userIdString))
            {
                // Nếu không có ID người dùng hợp lệ, có thể trả về trang đăng nhập hoặc thông báo lỗi
                return RedirectToAction("Login", "Account"); // Hoặc xử lý khác tùy ý
            }

            int userId;
            if (!int.TryParse(userIdString, out userId))
            {
                // Xử lý nếu không thể chuyển đổi ID người dùng (nên hiếm khi xảy ra)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cartItem = db.GIO_HANG.FirstOrDefault(g => g.MaSP == MaSP && g.UserId == userId);

            if (cartItem == null)
            {
                // Tạo mới giỏ hàng nếu chưa có sản phẩm này trong giỏ
                var newCartItem = new GIO_HANG
                {
                    UserId = userId,
                    MaSP = MaSP,
                    SoLuong = 1, // Mặc định là 1
                    NgayThem = DateTime.Now
                };
                db.GIO_HANG.Add(newCartItem);
            }
            else
            {
                // Nếu sản phẩm đã có trong giỏ, tăng số lượng
                cartItem.SoLuong++;
            }

            db.SaveChanges();
            return RedirectToAction("Index", "GIO_HANG"); // Quay lại trang giỏ hàng
        }





        // GET: GIO_HANG/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP");
            ViewBag.UserId = new SelectList(db.USERS, "UserId", "UserName");
            return View();
        }

        // POST: GIO_HANG/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,MaSP,SoLuong,NgayThem")] GIO_HANG gIO_HANG)
        {
            if (ModelState.IsValid)
            {
                var existingCartItem = db.GIO_HANG.FirstOrDefault(g => g.MaSP == gIO_HANG.MaSP && g.UserId == gIO_HANG.UserId);

                if (existingCartItem == null)
                {
                    db.GIO_HANG.Add(gIO_HANG);
                }
                else
                {
                    existingCartItem.SoLuong += gIO_HANG.SoLuong; // Cập nhật số lượng
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", gIO_HANG.MaSP);
            ViewBag.UserId = new SelectList(db.USERS, "UserId", "UserName", gIO_HANG.UserId);
            return View(gIO_HANG);
        }

        // GET: GIO_HANG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            if (gIO_HANG == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SAN_PHAM, "MaSP", "TenSP", gIO_HANG.MaSP);
            return View(gIO_HANG);
        }

        // POST: GIO_HANG/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGioHang,SoLuong")] GIO_HANG gIO_HANG)
        {
            if (ModelState.IsValid)
            {
                var cartItem = db.GIO_HANG.Find(gIO_HANG.MaGioHang);
                if (cartItem != null)
                {
                    cartItem.SoLuong = gIO_HANG.SoLuong; // Cập nhật số lượng
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(gIO_HANG);
        }

        // GET: GIO_HANG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            if (gIO_HANG == null)
            {
                return HttpNotFound();
            }
            return View(gIO_HANG);
        }

        // POST: GIO_HANG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIO_HANG gIO_HANG = db.GIO_HANG.Find(id);
            db.GIO_HANG.Remove(gIO_HANG);
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
