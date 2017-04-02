using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tibox.UnitOfWork;
using Tibox.Models;
using Tibox.Mvc.Models;

namespace Tibox.Mvc.Controllers
{
    public class OrderController : BaseController
    {
        public OrderController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Order
        public ActionResult Index()
        {
            return View(_unit.Orders.GetAll());
        }


        public ActionResult Create()
        {
            var model = new OrderViewModel
            {
                Order = new Order { OrderDate=DateTime.Now }
                ,Customer= _unit.Customers.GetAll()  };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (!ModelState.IsValid) return  View (order);
            var id = _unit.Orders.Insert(order);
            return RedirectToAction("Index");
        }
    }
}