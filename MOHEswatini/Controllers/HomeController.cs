using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MOHEswatini.Models;
using Rotativa.AspNetCore;

namespace MOHEswatini.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbMOHEswatini _context;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(DbMOHEswatini context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        
        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUS()
        {
            return View();
        }
        public IActionResult SearchResult()
        {
           List<mDiseaseSurveillance> mDisease = new List<mDiseaseSurveillance>();
            return View(mDisease);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchResult(string passportno)
        {
            if (passportno == null || passportno.Trim()=="")
            {
                return NotFound();
            }

            var mDis = _context.mDiseaseSurveillances.Where(Passport => Passport.PassportNo.ToUpper().Trim() == passportno.ToUpper().Trim()).ToList();
            if (mDis==null)
            {
                return View();
            }
            return View(mDis);
        }
        public IActionResult Print(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDiseaseSurveillance = _context.mDiseaseSurveillances.FirstOrDefault(m => m.iID == id);
            //return View(mDiseaseSurveillance);
            //ViewData["Message"] = "Your contact page.";

            //return new ViewAsPdf("~/Views/DiseaseSurveillances/Print.cshtml", mDiseaseSurveillance);

            var demoViewLandscape = new ViewAsPdf("~/Views/DiseaseSurveillances/Print.cshtml", mDiseaseSurveillance)
            {
                FileName = "Disease Surveillances Form.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 }
            };
            return demoViewLandscape;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
