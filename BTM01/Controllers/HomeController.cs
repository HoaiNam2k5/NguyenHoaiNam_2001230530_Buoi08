using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTM01.Models;

namespace BTM01.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            Model1 data = new Model1();
            List<THELOAITIN> ds = data.THELOAITINs.ToList();
            return View(ds);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(THELOAITIN Ltin)
        {
            if (ModelState.IsValid)
            {
                using (Model1 data = new Model1())
                {
                    // Đảm bảo không gán khóa chính, hoặc gán = 0 để EF hiểu là mới
                    Ltin.IDLoai = 0;

                    data.THELOAITINs.Add(Ltin);
                    data.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(Ltin);
        }


        public ActionResult Edit(int ID)
        {
            Model1 data = new Model1();
            var EB_tin = data.THELOAITINs.First(m=>m.IDLoai==ID);
            return View(EB_tin);
        }
        [HttpPost]
        public ActionResult Edit(int ID,FormCollection collection)
        {
            Model1 data = new Model1();
            var Ltin = data.THELOAITINs.First(m => m.IDLoai == ID);
            var E_LoatTin = collection["TenTheLoai"];
            Ltin.IDLoai=ID;
            Ltin.Tentheloai=E_LoatTin;
            //thực hiện update
            UpdateModel(Ltin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }

        //xóa 1 thể loại
        public ActionResult Delete(int ID)
        {
            Model1 data = new Model1();
            var D_Tin=data.THELOAITINs.First(m=>m.IDLoai==ID);
            return View(D_Tin);
        }
        [HttpPost]
        public ActionResult Delete(int ID,FormCollection collection)
        {
            Model1 data = new Model1();
            var D_tin=data.THELOAITINs.Where(m=>m.IDLoai== ID).First();
            //xóa
            data.THELOAITINs.Remove(D_tin);
            data.SaveChanges();
            return RedirectToAction("Index");
        }
        //hiển thị chi tiết thể loại
        public ActionResult Details(int ID)
        {
            Model1 data = new Model1();
            var Details_tin=data.THELOAITINs.Where(m=>m.IDLoai==ID).First();
            return View(Details_tin);
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