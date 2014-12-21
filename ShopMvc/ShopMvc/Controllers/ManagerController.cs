using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DBLayer;
using ShopMvc.Models;

namespace ShopMvc.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/
        private ShopMvcDBContainer context = new ShopMvcDBContainer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderAdd()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderAdd(OrderModels model)
        {
            ViewBag.RegisterSucess = "";
            if (ModelState.IsValid)
            {
                try
                {
                    context.OrderSet.Add(new Order()
                    {
                        Manager = context.ManagerSet.First(x=>x.LastName==model.Manager),
                        Client = context.ClientSet.First(x=>x.LastName==model.Client),
                        ManagerId = context.ManagerSet.First(x=>x.LastName==model.Manager).Id,
                        ClientId = context.ClientSet.First(x => x.LastName == model.Client).Id,
                        Amount = model.Amount,
                        Item = context.ItemSet.First(x=>x.Name==model.Item),
                        ItemId = context.ItemSet.First(x=>x.Name==model.Item).Id,
                        ItemCount = model.Count,
                        OrderTime = DateTime.Now
                    });
                    context.SaveChanges();
                    ViewBag.RegisterSucess = "Заказ  оформлен";
                    return View();
                }
                catch (MembershipCreateUserException e)
                {
                    //ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }

        private Manager CurrentManager()
        {
            return context.UserSet.First(x => x.UserName == User.Identity.Name).Manager;
        }
        public JsonResult GetOrdersList(int pagesize = 10, int pagenum = 0, string sortdatafield = "", string sortorder = "")
        {
            var ordersInfo = from x in CurrentManager().Order
                             select new
                             {
                                 orderid = x.Id,
                                 clientid = x.ClientId,
                                 itemid = x.ItemId,
                                 clientName = x.Client.LastName + " " + x.Client.FirstName + " " + x.Client.MiddleName,
                                 itemName = x.Item.Name,
                                 orderTime = x.OrderTime,
                                 itemCount = x.ItemCount,
                                 amount = x.Amount
                             };

            return Json(ordersInfo, JsonRequestBehavior.AllowGet);
        }
    }
}
