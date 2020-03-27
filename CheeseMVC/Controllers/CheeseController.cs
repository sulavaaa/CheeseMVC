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

        //static private List<string> Cheeses = new List<string>();
        //static private Dictionary<string, string> Cheeses = new Dictionary<string, string>();
        //static private List<Cheese> Cheeses = new List<Cheese>();

        private CheeseDbContext _dbContext;
        public CheeseController(CheeseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {

            IEnumerable<Cheese> cheeses = _dbContext.Cheeses.Include(c=>c.Category);
            //List<Cheese> cheeses = _dbContext.Cheeses.FromSqlInterpolated($"Select * from Cheeses").ToList();

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

                // Calling CheeseCategory comparing its id with incoming CategoryID from Cheese Model. 
                // Equvalent to performing join operation.

                int? categoryID = Convert.ToInt32(_dbContext.Categories
                    .Where(x => x.Name == addCheeseViewModel.Name)
                    .Select(x=>x.ID));
                //int result = categoryID.FirstOrDefault();


                //CheeseCategory newCheeseCategory = 
                    //_dbContext.Categories.SingleOrDefault(c => c.ID == addCheeseViewModel.CategoryID);

                // ViewModel to Model to mapping. 
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
            // we have to pass this in as it might contain error message. 
            return View(addCheeseViewModel);



        }

        public IActionResult Remove()
        {
            // IEnumerable for lazy loading. 
            IEnumerable<Cheese> Cheeses = _dbContext.Cheeses;
            List<RemoveCheeseViewModel> removeCheeses = new List<RemoveCheeseViewModel>();
            //IEnumerable<RemoveCheeseViewModel> removeCheeses;
            foreach (var i in Cheeses) 
            {
                removeCheeses.Add(new RemoveCheeseViewModel { ID = i.ID, Name = i.Name });

            } 

            return View(removeCheeses);
        }

        //public IActionResult Edit(int Id) 
        //{
            
        //    Cheese theCheese = _dbContext.Cheeses.SingleOrDefault(x => x.ID == Id);
            

        //    EditCheeseViewModel editCheeseViewModel = new EditCheeseViewModel
        //    { 
        //        ID = theCheese.ID,
        //        Name = theCheese.Name,
        //        Description = theCheese.Description,
        //        Category = theCheese.Category,
                

        //    };

        //    return View("Edit", editCheeseViewModel);   
        //}

        //[HttpPost]
        //public IActionResult Edit(EditCheeseViewModel editCheeseViewModel)
        //{
        //    if (ModelState.IsValid) 
        //    {
        //        Cheese newCheese = new Cheese
        //        {
        //            ID = editCheeseViewModel.ID,
        //            Name = editCheeseViewModel.Name,
        //            Description = editCheeseViewModel.Description,
        //            Category = editCheeseViewModel.Category
        //        };
        //        _dbContext.Cheeses.Update(newCheese);
        //        _dbContext.SaveChanges();
        //        return Redirect("/Cheese");
        //    }

        //    return View(editCheeseViewModel);
        //}

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            // Todo - remove cheeses from the list. 
            foreach (int cheeseId in cheeseIds)
            {
                //CheeseData.Remove(cheeseId);
                
                Cheese theCheese = _dbContext.Cheeses.SingleOrDefault(x => x.ID == cheeseId);
                _dbContext.Cheeses.Remove(theCheese);
            }
            _dbContext.SaveChanges();

            return Redirect("/");
        }

        /// <summary>
        /// Removes Single Cheese Item from Cheese Collection
        /// Unsafe as it is using HttpGet method. 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Cheese theCheese = _dbContext.Cheeses.SingleOrDefault(x => x.ID == Id);
            _dbContext.Cheeses.Remove(theCheese);
            _dbContext.SaveChanges();

            return Redirect("/");
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