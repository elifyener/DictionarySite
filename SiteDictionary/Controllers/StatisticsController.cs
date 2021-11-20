using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDictionary.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: Statistics
        public ActionResult Index()
        {
            using (Context c = new Context())
            {

                ViewBag.CategoryCount = c.Categories.Count();

                ViewBag.CategoryHeadingCount = c.Headings.Count(x => x.CategoryID == 2).ToString();
                
                ViewBag.WriterWithALetterCount = c.Writers.Count(x => x.WriterName.Contains("a") || x.WriterName.Contains("A")).ToString();
                
                ViewBag.CategoryNameMaxHeading = c.Categories.Where(u => u.CategoryID == c.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
                
                ViewBag.DifferenceOfTruAndFalse = c.Categories.Where(x => x.CategoryStatus == true).Count() -
                c.Categories.Where(x => x.CategoryStatus == false).Count();
                return View();

            }
        }
    }
}