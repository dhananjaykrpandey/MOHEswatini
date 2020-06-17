using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MOHEswatini.Models;

namespace MOHEswatini.Controllers
{
    public class DiseaseSurveillancesController : Controller
    {
        private readonly DbMOHEswatini _context;

        public DiseaseSurveillancesController(DbMOHEswatini context)
        {
            _context = context;
        }

        // GET: DiseaseSurveillances
        public async Task<IActionResult> Index()
        {
            return View(await _context.mDiseaseSurveillances.ToListAsync());
        }

        // GET: DiseaseSurveillances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDiseaseSurveillance = await _context.mDiseaseSurveillances
                .FirstOrDefaultAsync(m => m.iID == id);
            if (mDiseaseSurveillance == null)
            {
                return NotFound();
            }

            return View(mDiseaseSurveillance);
        }

        // GET: DiseaseSurveillances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiseaseSurveillances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("iID,ArrivalDate,ArrivedBy,VehicleNo,PointOfEntry,SeatNo,Name,ContactNo,PassportNo,Age,Gender,RecentlyVisitedCountry1,NoOfDaysSpend1,RecentlyVisitedCountry2,NoOfDaysSpend2,RecentlyVisitedCountry3,NoOfDaysSpend13,RecentlyVisitedCountry4,NoOfDaysSpend4,PhysicalAddress,PhysicalContactNo,CountryOfResidence,Headache,Bleeding,Fever,Cough,GeneralBodyPain,Diarrhea,Vomiting,SoreThroat,Polio,YellowFever,Malaria,Others,OthersVaccine,HealthFacility,CovidTested,CovidTestingDate,CovidTestingLab,CovidTestingKitNo,CovidTestResult")] mDiseaseSurveillance mDiseaseSurveillance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mDiseaseSurveillance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDiseaseSurveillance);
        }

        // GET: DiseaseSurveillances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDiseaseSurveillance = await _context.mDiseaseSurveillances.FindAsync(id);
            if (mDiseaseSurveillance == null)
            {
                return NotFound();
            }
            return View(mDiseaseSurveillance);
        }

        // POST: DiseaseSurveillances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("iID,ArrivalDate,ArrivedBy,VehicleNo,PointOfEntry,SeatNo,Name,ContactNo,PassportNo,Age,Gender,RecentlyVisitedCountry1,NoOfDaysSpend1,RecentlyVisitedCountry2,NoOfDaysSpend2,RecentlyVisitedCountry3,NoOfDaysSpend13,RecentlyVisitedCountry4,NoOfDaysSpend4,PhysicalAddress,PhysicalContactNo,CountryOfResidence,Headache,Bleeding,Fever,Cough,GeneralBodyPain,Diarrhea,Vomiting,SoreThroat,Polio,YellowFever,Malaria,Others,OthersVaccine,HealthFacility,CovidTested,CovidTestingDate,CovidTestingLab,CovidTestingKitNo,CovidTestResult")] mDiseaseSurveillance mDiseaseSurveillance)
        {
            if (id != mDiseaseSurveillance.iID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDiseaseSurveillance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mDiseaseSurveillanceExists(mDiseaseSurveillance.iID))
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
            return View(mDiseaseSurveillance);
        }

        // GET: DiseaseSurveillances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDiseaseSurveillance = await _context.mDiseaseSurveillances
                .FirstOrDefaultAsync(m => m.iID == id);
            if (mDiseaseSurveillance == null)
            {
                return NotFound();
            }

            return View(mDiseaseSurveillance);
        }

        // POST: DiseaseSurveillances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDiseaseSurveillance = await _context.mDiseaseSurveillances.FindAsync(id);
            _context.mDiseaseSurveillances.Remove(mDiseaseSurveillance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mDiseaseSurveillanceExists(int id)
        {
            return _context.mDiseaseSurveillances.Any(e => e.iID == id);
        }
    }
}
