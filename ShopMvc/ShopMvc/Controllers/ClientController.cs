using System.Web.Security;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMvc.Models;

namespace ShopMvc.Controllers
{
    [Authorize(Roles = "Client")]
    public class ClientController : Controller
    {

        private ShopMvcDBContainer context = new ShopMvcDBContainer();
        //
        // GET: /Client/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditClient()
        {
            return View();

        }


        private Client CurrentClient()
        {
            return context.UserSet.First(x => x.UserName == User.Identity.Name).Client;
        }
        public JsonResult GetOrdersList(int pagesize = 10, int pagenum = 0, string sortdatafield = "", string sortorder = "")
        {
            var ordersInfo = from x in CurrentClient().Order
                             select new
                             {
                                 orderid = x.Id,
                                 //clientid = x.ClientId,
                                 managerid = x.ManagerId,
                                 itemid = x.ItemId,
                                 //clientName = x.Client.LastName + " " + x.Client.FirstName + " " + x.Client.MiddleName,
                                 managerName=x.Manager.LastName+" "+x.Manager.FirstName+" "+x.Manager.MiddleName,
                                 itemName = x.Item.Name,
                                 orderTime = x.OrderTime,
                                 itemCount = x.ItemCount,
                                 amount = x.Amount
                             };

            return Json(ordersInfo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditClient(EditClientModel model)
        {
            if (ModelState.IsValid)
            {
                Client editableClient = CurrentClient();//context.ClientSet.FirstOrDefault(x => x.Id == model.Id);
                if (editableClient != null)
                {
                    editableClient.FirstName = model.FirstName;
                    editableClient.LastName = model.LastName;
                    editableClient.MiddleName = model.MiddleName;
                    editableClient.Adress = model.Adress;
                    editableClient.BirthDay = model.BirthDay;
                    context.SaveChanges();
                    ViewBag.RegisterSucess = "Изменения внесены успешно";
                    return View();
                }
            }

            return HttpNotFound();
        }
    }
}