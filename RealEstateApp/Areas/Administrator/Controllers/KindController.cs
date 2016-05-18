using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateApp.Models;
using System.Net;
using System.Text;

namespace RealEstateApp.Areas.Administrator.Controllers
{
    public class KindController : Controller
    {
        // GET: Administrator/Kind
        DBDataContext db = new DBDataContext();
        public ActionResult Index()
        {
            var kinds = db.Kinds;
            return View(kinds);
        }

        public ActionResult Create()
        {
            Kind kind = new Kind();
            return PartialView(kind);
        }

        [HttpPost]
        public ActionResult Create (Kind kind)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(kind);
            }
            try
            {
                db.Kinds.InsertOnSubmit(kind);
                db.SubmitChanges();
                var kinds = db.Kinds;
                return PartialView("Partial/KindList", kinds);
            }
            catch (Exception ex)
            {
                StringBuilder errorMessage = new StringBuilder(200);
                errorMessage.AppendFormat("<div class=\"validation-summay-errors\" title=\"Server Error\">{0}</div>", ex.GetBaseException().Message);
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Content(errorMessage.ToString());
            }
        }
    }
}