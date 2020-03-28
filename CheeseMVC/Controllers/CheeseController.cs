using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        /// <summary>
        /// Get me some Cheese
        /// </summary>
        /// <returns></returns>
        /// 

        

        private CheeseDbContext _dbContext;
        public CheeseController(CheeseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IEnumerable<Cheese> cheeses = _dbContext.Cheeses.Include(c=>c.Category);
            return View(cheeses);
        }

 

        public IActionResult Add()
        {
            // Transfer data through 
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel(_dbContext.Categories);
            return View(addCheeseViewModel);
        }


        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses 

                int? categoryID = Convert.ToInt32(_dbContext.Categories
                    .Where(x => x.Name == addCheeseViewModel.Name)
                    .Select(x=>x.ID));
               
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    CategoryID = (int)categoryID
                };
                _dbContext.Cheeses.Add(newCheese);
                _dbContext.SaveChanges();
                return Redirect("/Cheese");
            }
            
            return View(addCheeseViewModel);



        }

       

        public IActionResult Category(int Id) 
        {
            if (Id == 0) 
            {
                return Redirect("/Category/Index");
            }

            CheeseCategory theCategory = _dbContext.Categories.
                Include(cat => cat.Cheeses).
                Single(cat => cat.ID == Id);

            // To query from the 
            // Other side of the relationship

            /*
            ICollection<Cheese> theChesses = _dbContext.Cheeses.
                Include(c=>c.Category).
                Where(c.CategoryID == Id).ToList();
            */
            ViewBag.Title = "Cheeses in Category: " + theCategory.Name;
            return View("Index", theCategory.Cheeses);
        }


    }
}