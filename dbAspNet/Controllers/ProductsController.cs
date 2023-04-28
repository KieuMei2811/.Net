using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.Framework;

namespace dbAspNet.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
             var iplPro = new productsModel();
             var model = iplPro.ListAll();
             return  View(model);
        }


        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(tbl_products collection)
        {
             try
             {
                 // TODO: Add insert logic here
                 if (ModelState.IsValid)
                {
                    var model = new productsModel();
                    int res = model.create(collection.ID, collection.Name, collection.Price, collection.Detail, collection.Images);
                    if (res < 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Thêm mới không thành công");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //Post dữ liệu
        [HttpPost]
        public ActionResult Edit(tbl_products collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    var model = new productsModel();
                    int res = model.update(collection.ID, collection.Name, collection.Price, collection.Detail,collection.Images);
                    if (res < 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Cập nhật không thành công");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }


        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var iplPro = new productsModel();
            var model = iplPro.selectID(id);
            return View(model);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(tbl_products collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (true)
                {
                    var model = new productsModel();
                    int res = model.delete(collection.ID);
                    if (res < 0)
                        return RedirectToAction("Index");
                    else
                    {
                        ModelState.AddModelError("", "Xóa không thành công");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

    }
}
