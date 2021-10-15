using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Web.Models;
using WebApplication_Web.Repository.IRepository;

namespace WebApplication_Web.Controllers
{
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository _nationalParkRepository;
         public NationalParkController(INationalParkRepository nationalParkRepository)
        {
            _nationalParkRepository = nationalParkRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data =await _nationalParkRepository.GetAllAsync(SD.NationalParkAPIPath) });
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            NationalPark nationalPark = new NationalPark();
            if (id == null)
                return View(nationalPark);
            else
            {
                nationalPark = await _nationalParkRepository.GetAsync(SD.NationalParkAPIPath, id.GetValueOrDefault());
                if (nationalPark == null)
                    return NotFound();
                return View(nationalPark);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(NationalPark nationalPark)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    nationalPark.Picture = p1;
                }

                else
                {
                    var objFromDb = await _nationalParkRepository.GetAsync(SD.NationalParkAPIPath, nationalPark.Id);
                    nationalPark.Picture = objFromDb.Picture;
                }
                if (nationalPark.Id == 0)
                {
                    await _nationalParkRepository.CreateAsync(SD.NationalParkAPIPath, nationalPark);
                }
                else
                {
                    await _nationalParkRepository.UpdateAsync(SD.NationalParkAPIPath + nationalPark.Id, nationalPark);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(nationalPark);
            }
        }
        
    }
}
