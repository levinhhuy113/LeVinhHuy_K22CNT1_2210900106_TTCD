using LEVINHHUY_K22CNT1_2210900106_PROJECT2.Bussiness;
using LEVINHHUY_K22CNT1_2210900106_PROJECT2.Models;
using LEVINHHUY_K22CNT1_2210900106_PROJECT2.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSessionKey = "ShoppingCart";

        LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1 db = new LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1();

        private ShoppingCart GetCart()
        {
            var cart = Session[CartSessionKey] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int Id, string name, string image, float price, int quantity)
        {
            var cart = GetCart();
            var item = new CartItem
            {
                Id = Id,
                Name = name,
                Image = image,
                Price = price,
                Quantity = quantity,
                Total = price * quantity

            };
            cart.AddToCart(item);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateToCart(int Id, int quantity)
        {
            var cart = GetCart();


            cart.UpdateToCart(Id, quantity);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult RemoveFromCart(int MaSP)
        {
            var cart = GetCart();
            cart.RemoveFromCart(MaSP);
            return RedirectToAction("Index");
        }

        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult ThanhToan(FormCollection form)
        {
            //Lấy thông tin khách hàng
            var ten_nguoi_nhan = form["Ten_Nguoi_Nhan"];
            var diachi_nguoi_nhan = form["Dia_Chi_Nhan"];
            var dienthoai_nguoi_nhan = form["Dien_Thoai_Nhan"];

            //Tạo đơn hàng (thêm mới 1 đơn hàng vào bảng đơn hàng)
            DON_HANG don_Hang = new DON_HANG();
            DateTime dt = DateTime.Now;
            don_Hang.MaDH = "DH" + dt.ToString("yyyyMMdd-hhmmss");
            don_Hang.MaKH = 1;
            don_Hang.Ten_Nguoi_Nhan = ten_nguoi_nhan;
            don_Hang.Dia_Chi_Nhan = diachi_nguoi_nhan;
            don_Hang.Dien_Thoai_Nhan = dienthoai_nguoi_nhan;
            don_Hang.Ngay_dat = dt;
            don_Hang.Trang_thai = 0;
            db.DON_HANG.Add(don_Hang);
            db.SaveChanges();

            //Lấy mã đơn hàng mới nhất -> thêm vào chi tiết đơn hàng
            int maxID_DH = db.DON_HANG.Max(x => x.ID);

            var cart = GetCart();
            foreach (CartItem item in cart.Items)
            {
                CHI_TIET_DON_HANG ct = new CHI_TIET_DON_HANG();
                ct.ID_DH = maxID_DH;
                ct.ID_SP = item.Id;
                ct.So_Luong = item.Quantity;
                ct.Don_gia = item.Price;
                ct.Thanh_Tien = item.Quantity * item.Price;
                db.CHI_TIET_DON_HANG.Add(ct);
                db.SaveChanges();
            }
            return RedirectToAction("CamOn");


        }
        public ActionResult CamOn()
        {
            return View();
        }
        // Cập nhật giỏ hàng
        public ActionResult UpdateFromCart(FormCollection form)
        {
            var cart = GetCart();
            var ids = form["Id"].Split(',');
            var qtys = form["Quantity"].Split(',');
            for (int i=0; i<ids.Length; i++)
            {
                int id = int.Parse(ids[i]);
                int quantity = int.Parse(qtys[i]);
                cart.UpdateFromCart(id, quantity);
            }
            return RedirectToAction("Index");
        }

        //Cập nhật item in cart
        public ActionResult UpdateItemCart(int id, int quantity)
        {
            var cart = GetCart();
            cart.UpdateFromCart(id, quantity);
            
            return RedirectToAction("Index");
        }

        public ActionResult DeleteItemCart(int id)
        {
            var cart = GetCart();
            cart.RemoveFromCart(id);

            return RedirectToAction("Index");
        }
    }
}