using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LinkToolbar.Models;
using Microsoft.Ajax.Utilities;

namespace LinkToolbar.Controllers
{
    public class ToolbarController : Controller
    {
        public ActionResult Index(string href)
        {
            ToolbarViewModel toolbarViewModel = new ToolbarViewModel
            {
                FrameTarget = href
            };
            
            using (var db = new LinkToolbarContext())
            {
                toolbarViewModel.Links = db.Links.Include(l=>l.Links).ToList().Where(l=>!l.ParentId.HasValue);
            }
            return View(toolbarViewModel);
        }

    }
}
