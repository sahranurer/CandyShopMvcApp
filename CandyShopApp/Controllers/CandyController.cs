using CandyShopApp.Models.CandyOp;
using CandyShopApp.Models.CategoryOp;
using CandyShopApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShopApp.Controllers
{
    public class CandyController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;


        public CandyController(ICandyRepository candyRepository, ICategoryRepository categoryRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            var candy = new CandyListViewModel();
            candy.Candies = _candyRepository.GetAllCandy;
            candy.CurrentCategory = "Bestsellers";
            return View(candy);
        }

        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);
            if (candy is null)
            {
                return NotFound();
            }
            return View(candy);
        }
    }
}
