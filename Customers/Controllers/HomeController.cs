using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customers.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Models.CustomersEntities1 db = new Models.CustomersEntities1();
        public ActionResult Index()
        {
            return View(db.Customers);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            Models.Customer theCustomer = db.Customers.SingleOrDefault(c => c.customer_id == id);
            return View(theCustomer);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.Customer customer = new Models.Customer();
                customer.name = collection["name"];
                customer.number = collection["number"];
                customer.address = collection["address"];
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            Models.Customer theCustomer = db.Customers.SingleOrDefault(c => c.customer_id == id);
            return View(theCustomer);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                Models.Customer theCustomer = db.Customers.SingleOrDefault(c => c.customer_id == id);
                theCustomer.name = collection["name"];
                theCustomer.number = collection["number"];
                theCustomer.address = collection["address"];

               db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            Models.Customer theCustomer = db.Customers.SingleOrDefault(c => c.customer_id == id);
            return View(theCustomer);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Models.Customer theCustomer = db.Customers.SingleOrDefault(c => c.customer_id == id);
                theCustomer.name = collection["name"];
                theCustomer.number = collection["number"];
                theCustomer.address = collection["number"];
                db.Customers.Remove(theCustomer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
