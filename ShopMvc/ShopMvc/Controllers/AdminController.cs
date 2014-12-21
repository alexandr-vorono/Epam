using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DBLayer;
using ShopMvc.Models;
using WebMatrix.WebData;

namespace ShopMvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private ShopMvcDBContainer context = new ShopMvcDBContainer();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Clients()
        {
            return View();
        }
        public ActionResult Items()
        {
            return View();
        }

        public JsonResult GetManagerAgePie()
        {

            //var ordersDates = (from x in context.OrderSet
            //                   orderby x.OrderTime ascending
            //                   select new { orderDate = x.OrderTime }
            //                  ).ToList();

            //var result = from x in ordersDates
            //             group x by x.orderDate.Month.ToString() + "/" + x.orderDate.Year.ToString()
            //                 into g
            //                 let count = g.Count()
            //                 select new { date = g.Key, count = count };

            var ordersManager = (from x in context.ManagerSet
                select new {orderAmount = (double?)x.Order.Sum(y=>y.Amount), manager = x.LastName}).ToList();
            ;
            return Json(ordersManager, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClientsList(int pagesize = 10, int pagenum = 0, string sortdatafield = "", string sortorder = "")
        {

            var clientsInfo = from x in context.ClientSet
                              select new
                              {
                                  id = x.Id,
                                  firstName = x.FirstName,
                                  lastName = x.LastName,
                                  middleName = x.MiddleName,
                                  birthDay = x.BirthDay,
                                  adress = x.Adress,
                                  ordersCount = x.Order.Count,
                                  amount = (double?)x.Order.Sum(y => y.Amount) ?? 0
                              };

            var queryString = HttpContext.Request.QueryString;
            var values = queryString.GetValues("filterscount");
            if (values != null && values.Length > 0)
            {
                var filtersCount = int.Parse(values[0]);
                for (var i = 0; i < filtersCount; i++)
                {
                    try
                    {
                        var filterValue = queryString.GetValues("filtervalue" + i)[0];
                        var filterDataField = queryString.GetValues("filterdatafield" + i)[0];
                        var filterCondition = queryString.GetValues("filtercondition" + i)[0];

                        switch (filterDataField)
                        {
                            case "lastName":
                                clientsInfo = clientsInfo.Where(x => x.lastName.Contains(filterValue));
                                break;
                            case "firstName":
                                clientsInfo = clientsInfo.Where(x => x.firstName.Contains(filterValue));
                                break;
                            case "middleName":
                                clientsInfo = clientsInfo.Where(x => x.middleName.Contains(filterValue));
                                break;
                            case "adress":
                                clientsInfo = clientsInfo.Where(x => x.adress.Contains(filterValue));
                                break;
                            case "birthDay":
                                DateTime date = DateTime.Parse(filterValue);
                                if (filterCondition == "GREATER_THAN_OR_EQUAL")
                                    clientsInfo = clientsInfo.Where(x => x.birthDay >= date);
                                else
                                    clientsInfo = clientsInfo.Where(x => x.birthDay <= date);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                    }

                }
            }

            switch (sortdatafield)
            {
                case "firstName":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.firstName)
                        : clientsInfo.OrderBy(x => x.firstName);
                    break;
                case "lastName":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.lastName)
                        : clientsInfo.OrderBy(x => x.lastName);
                    break;
                case "middleName":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.middleName)
                        : clientsInfo.OrderBy(x => x.middleName);
                    break;
                case "birthDay":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.birthDay)
                        : clientsInfo.OrderBy(x => x.birthDay);
                    break;
                case "adress":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.adress)
                        : clientsInfo.OrderBy(x => x.adress);
                    break;
                case "ordersCount":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.ordersCount)
                        : clientsInfo.OrderBy(x => x.ordersCount);
                    break;
                case "amount":
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.amount)
                        : clientsInfo.OrderBy(x => x.amount);
                    break;
                default:
                    clientsInfo = (sortorder == "desc")
                        ? clientsInfo.OrderByDescending(x => x.id)
                        : clientsInfo.OrderBy(x => x.id);
                    break;
            }

            var rowsCount = clientsInfo.Count();
            var clientsInfoList = clientsInfo.ToList().Skip(pagesize * pagenum).Take(pagesize);

            var res = new
            {
                TotalRows = rowsCount,
                Rows = clientsInfoList
            };

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(ItemModels model)
        {
            ViewBag.RegisterSucess = "";
            if (ModelState.IsValid)
            {
                try
                {
                    context.ItemSet.Add(new Item()
                    {
                        Name = model.Name,
                        Description = model.Description,
                    });
                    context.SaveChanges();
                    ViewBag.RegisterSucess = "Товар добавлен";
                    return View();
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }

        public JsonResult GetItemsList(int pagesize = 10, int pagenum = 0, string sortdatafield = "", string sortorder = "")
        {
            var itemsInfo = from x in context.ItemSet
                            select new
                            {
                                id = x.Id,
                                name = x.Name,
                                description = x.Description,
                                ordersCount = x.Order.Count,
                                amount = (double?)x.Order.Sum(y => y.Amount) ?? 0
                            };


            var queryString = HttpContext.Request.QueryString;
            var values = queryString.GetValues("filterscount");
            if (values != null && values.Length > 0)
            {
                var filtersCount = int.Parse(values[0]);
                for (var i = 0; i < filtersCount; i++)
                {
                    try
                    {
                        var filterValue = queryString.GetValues("filtervalue" + i)[0];
                        var filterDataField = queryString.GetValues("filterdatafield" + i)[0];
                        var filterCondition = queryString.GetValues("filtercondition" + i)[0];

                        switch (filterDataField)
                        {
                            case "name":
                                itemsInfo = itemsInfo.Where(x => x.name.Contains(filterValue));
                                break;
                            case "description":
                                itemsInfo = itemsInfo.Where(x => x.description.Contains(filterValue));
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                    }

                }
            }

            switch (sortdatafield)
            {
                case "name":
                    itemsInfo = (sortorder == "desc")
                        ? itemsInfo.OrderByDescending(x => x.name)
                        : itemsInfo.OrderBy(x => x.name);
                    break;
                case "description":
                    itemsInfo = (sortorder == "desc")
                        ? itemsInfo.OrderByDescending(x => x.description)
                        : itemsInfo.OrderBy(x => x.description);
                    break;
                case "ordersCount":
                    itemsInfo = (sortorder == "desc")
                        ? itemsInfo.OrderByDescending(x => x.ordersCount)
                        : itemsInfo.OrderBy(x => x.ordersCount);
                    break;
                case "amount":
                    itemsInfo = (sortorder == "desc")
                        ? itemsInfo.OrderByDescending(x => x.amount)
                        : itemsInfo.OrderBy(x => x.amount);
                    break;
                default:
                    itemsInfo = (sortorder == "desc")
                        ? itemsInfo.OrderByDescending(x => x.id)
                        : itemsInfo.OrderBy(x => x.id);
                    break;
            }

            var rowsCount = itemsInfo.Count();
            var itemsInfoList = itemsInfo.ToList().Skip(pagesize * pagenum).Take(pagesize);

            var res = new
            {
                TotalRows = rowsCount,
                Rows = itemsInfoList
            };

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddManager()
        {
            return View();
        }

        //
        // POST: /Admin/AddManager
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddManager(RegisterManagerModel model)
        {
            ViewBag.RegisterSucess = "";
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    Roles.AddUserToRole(model.UserName, "Manager");
                    context.ManagerSet.Add(new Manager()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        EmploymentDate = DateTime.Now,
                        User = context.UserSet.First(x => x.UserName == model.UserName)
                    });
                    context.SaveChanges();
                    ViewBag.RegisterSucess = "Менеджер зарегистрирован";
                    return View();
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }
        public ActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(RegisterClientModel model)
        {
            ViewBag.RegisterSucess = "";
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    Roles.AddUserToRole(model.UserName, "Client");
                    context.ClientSet.Add(new Client()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        Adress = model.Adress,
                        BirthDay = model.BirthDay,
                        User = context.UserSet.First(x => x.UserName == model.UserName)
                    });
                    context.SaveChanges();
                    ViewBag.RegisterSucess = "Клиент зарегистрирован";
                    return View();
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            return View(model);
        }
        public JsonResult GetManagersList(int pagesize = 10, int pagenum = 0, string sortdatafield = "", string sortorder = "")
        {
            var managersInfo = from x in context.ManagerSet
                               select new
                               {
                                   id = x.Id,
                                   firstName = x.FirstName,
                                   lastName = x.LastName,
                                   middleName = x.MiddleName,
                                   employmentDate = x.EmploymentDate,
                                   itemCount = x.Order.Count,
                                   amount = (double?)x.Order.Sum(y => y.Amount) ?? 0
                               };


            var queryString = HttpContext.Request.QueryString;
            var values = queryString.GetValues("filterscount");
            if (values != null && values.Length > 0)
            {
                var filtersCount = int.Parse(values[0]);
                for (var i = 0; i < filtersCount; i++)
                {
                    try
                    {
                        var filterValue = queryString.GetValues("filtervalue" + i)[0];
                        var filterDataField = queryString.GetValues("filterdatafield" + i)[0];
                        var filterCondition = queryString.GetValues("filtercondition" + i)[0];

                        switch (filterDataField)
                        {
                            case "firstName":
                                managersInfo = managersInfo.Where(x => x.firstName.Contains(filterValue));
                                break;
                            case "lastName":
                                managersInfo = managersInfo.Where(x => x.lastName.Contains(filterValue));
                                break;
                            case "middleName":
                                managersInfo = managersInfo.Where(x => x.middleName.Contains(filterValue));
                                break;
                            case "employmentDate":
                                DateTime date = DateTime.Parse(filterValue);
                                if (filterCondition == "GREATER_THAN_OR_EQUAL")
                                    managersInfo = managersInfo.Where(x => x.employmentDate >= date);
                                else
                                    managersInfo = managersInfo.Where(x => x.employmentDate <= date);
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                    }

                }
            }

            switch (sortdatafield)
            {
                case "firstName":
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.firstName)
                        : managersInfo.OrderBy(x => x.firstName);
                    break;
                case "lastName":
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.lastName)
                        : managersInfo.OrderBy(x => x.lastName);
                    break;
                case "middleName":
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.middleName)
                        : managersInfo.OrderBy(x => x.middleName);
                    break;
                case "employmentDat":
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.employmentDate)
                        : managersInfo.OrderBy(x => x.employmentDate);
                    break;
                case "itemCount":
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.itemCount)
                        : managersInfo.OrderBy(x => x.itemCount);
                    break;
                case "amount":
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.amount)
                        : managersInfo.OrderBy(x => x.amount);
                    break;
                default:
                    managersInfo = (sortorder == "desc")
                        ? managersInfo.OrderByDescending(x => x.id)
                        : managersInfo.OrderBy(x => x.id);
                    break;
            }

            var rowsCount = managersInfo.Count();
            var managersInfoList = managersInfo.ToList().Skip(pagesize * pagenum).Take(pagesize);

            var res = new
            {
                TotalRows = rowsCount,
                Rows = managersInfoList
            };

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Manager()
        {

            return View();
        }
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

    }
}
