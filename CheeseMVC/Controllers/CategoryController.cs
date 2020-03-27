using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext _cheeseDbContext;
        public CategoryController(CheeseDbContext cheeseDbContext)
        {
            _cheeseDbContext = cheeseDbContext;
        }
        public IActionResult Index()
        {
            //var categories = _cheeseDbContext.Categories;

            return View();
        }
    }
}