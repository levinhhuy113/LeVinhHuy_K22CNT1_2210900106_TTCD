using System;
using System.Linq;
using System.Web.Mvc;
using LEVINHHUY_K22CNT1_2210900106_PROJECT2.Models;
using LEVINHHUY_K22CNT1_2210900106_PROJECT2.ModelView;

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Controllers
{
    public class OrderHistoryController : Controller
    {
        private LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1 db = new LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1();

        // GET: OrderHistory
        public ActionResult Index()
        {
            // Kiểm tra nếu khách hàng đã đăng nhập
            if (Session["KhachHang"] == null)
            {
                return RedirectToAction("Login", "KHACH_HANG");
            }

            // Lấy mã khách hàng từ session
            var khachHang = (KHACH_HANG)Session["KhachHang"];
            int maKH = khachHang.MaKH;

            // Lấy tất cả đơn hàng của khách hàng từ cơ sở dữ liệu
            var donHangs = db.DON_HANG.Where(d => d.MaKH == maKH).ToList();

            return View(donHangs);
        }

        // GET: OrderHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            // Lấy đơn hàng theo id
            DON_HANG donHang = db.DON_HANG.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }

            // Lấy chi tiết đơn hàng
            var donHangChiTiet = (from ct in db.CHI_TIET_DON_HANG
                                  join sp in db.SAN_PHAM on ct.ID_SP equals sp.ID
                                  where ct.ID_DH == id
                                  select new DH_ChiTiet
                                  {
                                      Id = ct.ID,
                                      Name = sp.Name,
                                      Image = sp.Image,
                                      Price = ct.Don_gia,
                                      Quantity = ct.So_Luong,
                                      Total = ct.Thanh_Tien
                                  }).ToList();

            ViewBag.DonHangChiTiet = donHangChiTiet;
            return View(donHang);
        }
    }
}
