using CandyShopApp.Models;
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

        public IActionResult List(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.OrderBy(c => c.Name);
                currentCategory = "All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.Where(c => c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetCategories
                    .FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory
            });
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
