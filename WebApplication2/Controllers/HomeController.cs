using DBShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;


namespace WebApplication2.Controllers
{
    
    public class HomeController : Controller
    {
        CustomerContext db = new CustomerContext();
        public ActionResult Index()
        {
            
            return View(db.Customers);
        }

        public ActionResult DeleteCustomer(int customerid)
        {
            
            db.Customers.Remove(db.Customers.Find(customerid));
            db.SaveChanges();
            return Redirect("/home/index");
        }

        public ActionResult DataGrid()
        {
            return View(new DataGrid(db.Orders,db.Customers));
        }



        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
            return Redirect("/home/index");
        }

        public ActionResult UpdateCustomer(int customerid)
        {
            CustomerModel c = db.Customers.Find(customerid);
            ViewBag.Debug = c.Id;
            return View(c);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(CustomerModel n)
        {
            CustomerModel update = db.Customers.Find(n.Id);
            update.FirstName = n.FirstName;
            update.SecondName = n.SecondName;
            update.Age = n.Age;
            db.SaveChanges();
            return Redirect("/home/index");
        }


        public ActionResult Orders(int customerid)

        {
            ViewBag.IdForOrder = customerid;
            return View( new OrderView(customerid,db.Orders));
        }

        
        public ActionResult DeleteOrder(int orderid,int customerid)
        {
            db.Orders.Remove(db.Orders.Find(orderid));
            db.SaveChanges();
            return Redirect("/home/orders?customerid="+customerid);
        }

        public ActionResult CreateOrder(int customerid)
        {
            OrderModel m=new OrderModel();
            m.CustomerId = customerid;
            return View(m);
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderModel m)
        {
            db.Orders.Add(m);
            m.CustomerModel = db.Customers.Find(m.CustomerId);
            db.SaveChanges();
            return Redirect("/home/orders?customerid=" + m.CustomerId);
        }

        public ActionResult UpdateOrder(int orderid)
        {
            OrderModel o = db.Orders.Find(orderid);
            return View(o);
        }


        [HttpPost]
        public ActionResult UpdateOrder(OrderModel m)
        {
            OrderModel u = db.Orders.Find(m.Id);
            u.Product = m.Product;
            u.Cost = m.Cost;
            db.SaveChanges();
            return Redirect("/home/orders?customerid=" + u.CustomerId);
        }


        [HttpPost]
        public ActionResult PartialCalc(string num1, string select, string num2)
        {
            ViewBag.Result = new DataTable().Compute(num1 + select + num2, null).ToString(); ;
            return PartialView("PartialCalc");
        }
































    }
}