using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excite.Utilities.Extensions;
using Excite.Web.Models;

namespace Excite.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Error = "Invalid Input!";
                return View(model);
            }

            var result = model.Text.IndicesOf(model.SubText);

            model.Result = string.Join(",", result);
            if (String.IsNullOrEmpty(model.Result))
                model.Result = "<no match>";

            return View(model);
        }
    }
}