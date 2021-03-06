﻿using System.Linq;
using PieShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using PieShop.Web.Core;

namespace PieShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);
            var viewModel = new HomeViewModel
            {
                Title = "Pie Overview",
                Pies = pies.ToList()
            };
            return View(viewModel);
        }

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }  

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}