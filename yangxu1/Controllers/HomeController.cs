using DemoModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yangxu1.Service;

namespace yangxu1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaService _cinemaService;

        //构造函数注入
        public HomeController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院列表";

            return View(await _cinemaService.GetAllAsync());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if(ModelState.IsValid)
            {
                await _cinemaService.AddAsync(model);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Cinema model)
        {
            if(ModelState.IsValid)
            {
                var exist = await _cinemaService.GetByIdAsync(id);
                if(exist==null)
                {
                    return NotFound();
                }
                exist.Name = model.Name;
                exist.Location = model.Location;
                exist.Capacity = model.Capacity;
            }

            return RedirectToAction("Action");
        }
    }
}
