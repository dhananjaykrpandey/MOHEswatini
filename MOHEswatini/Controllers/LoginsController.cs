using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOHEswatini.Models;

namespace MOHEswatini.Controllers
{
    public class LoginsController : Controller
    {
        private readonly DbMOHEswatini _context;

        public LoginsController(DbMOHEswatini context)
        {
            _context = context;
        }

        // GET: mLogins
        public IActionResult Index()
        {
            mLogin mLogin = null;
            return View(mLogin);
            //return View(await _context.MLogins.ToListAsync());
        }
        [HttpPost]
        public IActionResult Index(mLogin mLogin)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    IEnumerable<mLogin> mLogins = null;

                    //using (var client = new HttpClient())
                    //{

                    //    //var user = new IdentityUser { UserName = mLogin.Name, Email = mLogin.EmailID };
                    //    // client.BaseAddress = new Uri(@"https://localhost:44366/api/");
                    //    //client.BaseAddress = new Uri("https://localhost:31/api");
                    //    client.BaseAddress = new Uri(AdminDashBoardConfigVal.AdminDashBoardWebApiClient);
                    //    var responseTask = client.GetAsync("login/" + mLogin.UserID + "/" + mLogin.Password + "");
                    //    responseTask.Wait();

                    //    var result = responseTask.Result;
                    //    if (result.IsSuccessStatusCode)
                    //    {
                    //        var readTask = result.Content.ReadAsAsync<mLogin>();
                    //        readTask.Wait();
                    //        var claims = new List<Claim>
                    //                        {
                    //                            new Claim(ClaimTypes.Name, readTask.Result.Name, ClaimValueTypes.String, "https://localhost:44323")
                    //                        };
                    //        var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    //        var userPrincipal = new ClaimsPrincipal(userIdentity);

                    //        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    //           userPrincipal,
                    //           new AuthenticationProperties
                    //           {
                    //               ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    //               IsPersistent = false,
                    //               AllowRefresh = false
                    //           });

                    //        HttpContext.Session.SetString("login", "true");
                    //        HttpContext.Session.SetString("UserName", readTask.Result.Name);


                    //        var ProjectMenu = client.GetAsync("ProjectMenu/");
                    //        ProjectMenu.Wait();

                    //        var ProjectMenuResult = ProjectMenu.Result.Content.ReadAsStringAsync();
                    //        ProjectMenuResult.Wait();

                    //        HttpContext.Session.SetString("ProjectMenuResult", ProjectMenuResult.Result);

                    //        Response.Cookies.Append("ProjectMenuResult", ProjectMenuResult.Result, new CookieOptions() { Expires = DateTime.Now.AddDays(1) });

                    //        return RedirectToAction("Index", "Home");
                    //    }
                    //    else //web api sent error response 
                    //    {
                    //        //log response status here..

                    //        mLogins = Enumerable.Empty<mLogin>();

                    //        ModelState.AddModelError(string.Empty, "Invalid Login User-ID or Password");
                    //    }
                    //}


                }

                return View();
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Some Problem occure while sending request please report it." + ex.Message.ToString());
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        // GET: mLogins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLogin = await _context.MLogins
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (mLogin == null)
            {
                return NotFound();
            }

            return View(mLogin);
        }

        // GET: mLogins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mLogins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Password,Name,Type,Phone,EmailID")] mLogin mLogin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mLogin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mLogin);
        }

        // GET: mLogins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLogin = await _context.MLogins.FindAsync(id);
            if (mLogin == null)
            {
                return NotFound();
            }
            return View(mLogin);
        }

        // POST: mLogins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserID,Password,Name,Type,Phone,EmailID")] mLogin mLogin)
        {
            if (id != mLogin.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mLoginExists(mLogin.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mLogin);
        }

        // GET: mLogins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mLogin = await _context.MLogins
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (mLogin == null)
            {
                return NotFound();
            }

            return View(mLogin);
        }

        // POST: mLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mLogin = await _context.MLogins.FindAsync(id);
            _context.MLogins.Remove(mLogin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mLoginExists(string id)
        {
            return _context.MLogins.Any(e => e.UserID == id);
        }
    }
}
