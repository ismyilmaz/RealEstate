using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealEstateApp.Models;
using RealEstateApp.HtmlHelpers;
using System.Net;
using System.Text;

namespace RealEstateApp.Areas.Administrator.Controllers
{
    [Localization]
    public class CategoryController : Controller
    {
        DBDataContext db = new DBDataContext();
        // GET: Administrator/Category
        public ActionResult Index()
        {
            var categories = db.Categories;
            return View(categories);
        }

        public ActionResult Create()
        {
            Category category = new Category();

            return PartialView(category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(category);
            }

            try
            {
                db.Categories.InsertOnSubmit(category);
                db.SubmitChanges();
                var categories = db.Categories;
                return PartialView("Partial/CategoryList", categories);
            }
            catch (Exception ex)
            {
                StringBuilder errorMessage = new StringBuilder(200);
                errorMessage.AppendFormat("<div class=\"validation-summay-errors\" title=\"Server Error\">{0}</div>", ex.GetBaseException().Message);//null değer geldiğinde döndürülen hata
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Content(errorMessage.ToString());
            }
        }

    }
}