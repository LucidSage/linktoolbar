using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkToolbar.Models;
using Microsoft.Ajax.Utilities;

namespace LinkToolbar.Controllers
{
    public class ToolbarController : Controller
    {
        public ActionResult Index(string href)
        {
            if (!string.IsNullOrWhiteSpace(href))
            {
                ViewBag.frameTarget = href;
            }

            using (var db = new LinkToolbarContext())
            {
                ViewBag.links = db.Links.Include("Links").DistinctBy((link => link.LinkId));
            }
            return View();
        }

    }
}
