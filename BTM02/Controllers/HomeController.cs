using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTM02.Models;

namespace BTM02.Controllers
{
    public class HomeController : Controller
    {
 public ActionResult DsSach()
        {
            Model1 data = new Model1();
            List<Sach> list = data.Saches.ToList();
            return View(list);
        }
        public ActionResult ChiTietSach(int id)
        {
            Model1 data = new Model1();
            Sach sach = data.Saches.FirstOrDefault(s => s.MaSach == id);
            if (sach == null)
                return HttpNotFound();

            return View(sach);
        }
        // GET: Xác nhận xóa
        public ActionResult XoaSach(int id)
        {
            Model1 data = new Model1();
            Sach sach = data.Saches.FirstOrDefault(s => s.MaSach == id);
            if (sach == null)
                return HttpNotFound();

            return View(sach);
        }

        // POST: Thực hiện xóa
        [HttpPost, ActionName("XoaSach")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int id)
        {
            Model1 data = new Model1();
            Sach sach = data.Saches.FirstOrDefault(s => s.MaSach == id);
            if (sach == null)
                return HttpNotFound();

            data.Saches.Remove(sach);
            data.SaveChanges();
            return RedirectToAction("DsSach");
        }
      
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sach sach, HttpPostedFileBase fileAnh)
        {
            if (ModelState.IsValid)
            {
                Model1 db = new Model1();

             
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    // Lưu file ảnh vào thư mục 
                    var fileName = Path.GetFileName(fileAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/IMG"), fileName);

                    // Tạo thư mục nếu chưa có
                    if (!Directory.Exists(Server.MapPath("~/IMG")))
                        Directory.CreateDirectory(Server.MapPath("~/IMG"));

                    fileAnh.SaveAs(path);

                    // Lưu đường dẫn vào DB
                    sach.AnhBia = "~/IMG/" + fileName;
                }

                // Gán ngày cập nhật hiện tại
                sach.NgayCapNhat = DateTime.Now;

                db.Saches.Add(sach);
                db.SaveChanges();

                // Sau khi thêm xong, trở về danh sách
                return RedirectToAction("DsSach");
            }

            // Nếu dữ liệu không hợp lệ, trả lại view
            return View(sach);
        }
        // GET: Hiển thị form chỉnh sửa
        public ActionResult SuaSach(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Model1 data = new Model1();
            Sach sach = data.Saches.FirstOrDefault(s => s.MaSach == id);
            if (sach == null)
                return HttpNotFound();

            return View(sach);
        }


        // POST: Lưu chỉnh sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSach(Sach s, HttpPostedFileBase fileAnh)
        {
            Model1 data = new Model1();
            Sach sach = data.Saches.FirstOrDefault(x => x.MaSach == s.MaSach);
            if (sach == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                sach.TenSach = s.TenSach;
                sach.GiaBan = s.GiaBan;
                sach.MoTa = s.MoTa;
                sach.SoLuong = s.SoLuong;
                sach.MaChuDe = s.MaChuDe;
                sach.MaNXB = s.MaNXB;
                sach.NgayCapNhat = DateTime.Now;

                // Nếu có upload ảnh mới
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(fileAnh.FileName);
                    string path = Server.MapPath("~/IMG/" + fileName);
                    fileAnh.SaveAs(path);
                    sach.AnhBia = "~/IMG/" + fileName;
                }

                data.SaveChanges();
                return RedirectToAction("DsSach");
            }

            return View(s);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}