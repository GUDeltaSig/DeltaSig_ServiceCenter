using DeltaSigServiceCenter_DEV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeltaSigServiceCenter_DEV.Controllers
{
    public class BrotherManagerController : Controller
    {
        private BrothersInfo_BLL bI_BLL;

        // GET: BrotherManager
        public ActionResult BrotherManager()
        {
            return View();

        }

        public ActionResult BrotherAdditionSuccess()
        {
            return View("BrotherAdditionSuccess");
        }

        public ActionResult BrotherAdditionFailed()
        {
            return View("BrotherAdditionFailed");
        }

        public ActionResult BrotherAlreadyExists()
        {
            return View("BrotherAlreadyExists");
        }

        //Add New Brother from the Form
        [HttpPost]
        public ActionResult AddNewBrother(Brother bro)
        {
            bI_BLL = new BrothersInfo_BLL();

            if (ModelState.IsValid)
            {
                if (bI_BLL.requestBrotherAddition(bro) == true) {
                    return View("BrotherAdditionSuccess");
                }
                else
                {
                    //The brother must already exist.
                    return View("Nope");
                }               
            }
            //Model state is not valid, so return the BrotherAdditionFaield
            else
            {
                return View("BrotherAdditionFailed");
            }
        }      
    }
}