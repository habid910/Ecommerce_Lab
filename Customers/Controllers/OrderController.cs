using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customers.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        Models.CustomersEntities1 db = new Models.CustomersEntities1();
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return View(db.Orders.Where(c=> c.customer_id==id));
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            Models.Order theOrder = db.Orders.SingleOrDefault(o => o.order_id == id);
            return View(theOrder);
        }

        // GET: Order/Create
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(int id,FormCollection collection)
        {
            
            try
            {
                // TODO: Add insert logic here
                Models.Order order = new Models.Order()
                {
                    customer_id = id,
                   order_item = collection["order_item"],
                    status = collection["status"]
                 
                };
                
                db.Orders.Add(order);
                db.SaveChanges();

                return RedirectToAction("Index",new {id=id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Order theOrder = db.Orders.SingleOrDefault(c => c.order_id == id);
            return View(theOrder);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Order theOrder = db.Orders.SingleOrDefault(o => o.order_id == id);
                theOrder.order_item = collection["order_item"];
                theOrder.status = collection["status"];
                
                db.SaveChanges();

                return RedirectToAction("Index",new {id=theOrder.customer_id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Order theOrder = db.Orders.SingleOrDefault(o=> o.order_id ==id);
            return View(theOrder);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Order theOrder = db.Orders.SingleOrDefault(o=> o.order_id==id);
                theOrder.order_item = collection["order_item"];
                theOrder.status = collection["status"];
                db.Orders.Remove(theOrder);
                db.SaveChanges();

                return RedirectToAction("Index",new {id=theOrder.customer_id });
            }
            catch
            {
                return View();
            }
        }
    }
}
