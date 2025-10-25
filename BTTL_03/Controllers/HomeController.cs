using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTTL_03.Models;
using System.Data.Entity;
namespace BTTL_03.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DsNhanVien()
        {
            Model1 data = new Model1();
            List<TBL_EMPLOYEE> list = data.TBL_EMPLOYEE.ToList();
            return View(list);
        }
        public ActionResult DetailStaff(int id)
        {
            Model1 data = new Model1();
            TBL_EMPLOYEE NV = data.TBL_EMPLOYEE.FirstOrDefault(s => s.Id== id);
            if (NV == null)
                return HttpNotFound();

            return View(NV);
        }
        // GET: Xác nhận xóa
        public ActionResult XoaStaff(int id)
        {
            Model1 data = new Model1();
            TBL_EMPLOYEE NV= data.TBL_EMPLOYEE.FirstOrDefault(s => s.Id == id);
            if (NV == null)
                return HttpNotFound();

            return View(NV);
        }

        // POST: Thực hiện xóa
        [HttpPost, ActionName("XoaStaff")]
        [ValidateAntiForgeryToken]
        public ActionResult XacNhanXoa(int id)
        {
            Model1 data = new Model1();
            TBL_EMPLOYEE NV= data.TBL_EMPLOYEE.FirstOrDefault(s => s.Id  == id);
            if (NV == null)
                return HttpNotFound();

            data.TBL_EMPLOYEE.Remove(NV);
            data.SaveChanges();
            return RedirectToAction("DsNhanVien");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TBL_EMPLOYEE NV, HttpPostedFileBase fileAnh)
        {
            Model1 db = new Model1();

            if (ModelState.IsValid)
            {
                // Nếu có upload ảnh
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(fileAnh.FileName);
                    string path = Server.MapPath("~/IMG/" + fileName);
                    fileAnh.SaveAs(path);
                    NV.ImgFace = "~/IMG/" + fileName;
                }

                // KHÔNG set NV.Id = ... nữa
                db.TBL_EMPLOYEE.Add(NV);
                db.SaveChanges();

                return RedirectToAction("DsNhanVien");
            }

            return View(NV);
        }

        // GET: Hiển thị form chỉnh sửa
        public ActionResult EditNV(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Model1 data = new Model1();
            TBL_EMPLOYEE nv = data.TBL_EMPLOYEE.FirstOrDefault(s => s.Id == id);
            if (nv == null)
                return HttpNotFound();

            return View(nv);
        }

        // POST: Lưu chỉnh sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNV(TBL_EMPLOYEE s, HttpPostedFileBase fileAnh)
        {
            Model1 data = new Model1();
            TBL_EMPLOYEE nv = data.TBL_EMPLOYEE.FirstOrDefault(x => x.Id == s.Id);
            if (nv == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                // Cập nhật thông tin nhân viên
                nv.Name = s.Name;
                nv.Gender = s.Gender;
                nv.City = s.City;
                nv.Deptld = s.Deptld;

                // Nếu có upload ảnh mới
                if (fileAnh != null && fileAnh.ContentLength > 0)
                {
                    string fileName = System.IO.Path.GetFileName(fileAnh.FileName);
                    string path = Server.MapPath("~/IMG/" + fileName);

                    // Lưu file ảnh vào thư mục IMG
                    fileAnh.SaveAs(path);

                    // Lưu đường dẫn ảnh vào DB
                    nv.ImgFace = "~/IMG/" + fileName;
                }

                data.SaveChanges();
                return RedirectToAction("DsNhanVien"); 
            }

            return View(s);
        }
        public ActionResult Slidebar(int? deptId)
        {
            Model1 db = new Model1();
            ViewBag.Departments = db.TBL_DEPARMENT.ToList();

            var employees = db.TBL_EMPLOYEE.Include(e => e.TBL_DEPARMENT).AsQueryable();

            if (deptId.HasValue)
                employees = employees.Where(e => e.Deptld == deptId.Value);

            return View(employees.ToList());
        }

        public ActionResult Index()
        {
            return View();
        }

   
    }
}