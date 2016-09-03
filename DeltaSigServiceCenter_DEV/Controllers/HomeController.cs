using DeltaSigServiceCenter_DEV.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeltaSigServiceCenter_DEV.Controllers
{
    public class HomeController : Controller
    {
        BrothersInfo_BLL broInfoObj;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Show contacts per ID";
            return View();
        }

        [HttpGet]
        public ActionResult ShowBrothersStandings()
        {
            broInfoObj = new Models.BrothersInfo_BLL();

            var brothersStandings = broInfoObj.requestAllBrothersHours();
            return Json(brothersStandings, JsonRequestBehavior.AllowGet);
        }
    }
}