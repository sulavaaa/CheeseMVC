using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        
      
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description is required.")]
        [StringLength(200)]
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public CheeseCategory Category { get; set; }

        public List<SelectListItem> cheeseCategory;

        public AddCheeseViewModel()
        {

        }
        public AddCheeseViewModel(IEnumerable<CheeseCategory> cheeseCategories)
        {
           
            cheeseCategory = new List<SelectListItem>();

            if (!cheeseCategories.Any()) 
            {
                cheeseCategory.Add(new SelectListItem
                {
                    Value = '0'.ToString(),
                    Text = "Empty"
                });
                return;
            }
            foreach (var category in cheeseCategories) 
            {
                cheeseCategory.Add(new SelectListItem { 
                    Value = CategoryID.ToString(),
                    Text = Category.Name

                });
            }

        }
    }
}
