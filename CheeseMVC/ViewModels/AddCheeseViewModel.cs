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
        // represents both sides of the form 
        // While displaying and processing the from. 

        // Expect to receive cheese object so we need name and discription 
      
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description is required.")]
        [StringLength(200)]
        public string Description { get; set; }

        //public CheeseType Type { get; set; } // सेलेक्ट गरेर पठाउनको लागि । 
        //public List<SelectListItem> CheeseTypes { get; set; } // देखाउनको लागि । 

        public int CategoryID { get; set; }
        public CheeseCategory Category { get; set; }

        public List<SelectListItem> cheeseCategory;

        public AddCheeseViewModel()
        {

        }
        public AddCheeseViewModel(IEnumerable<CheeseCategory> cheeseCategories)
        {
            //CheeseTypes = new List<SelectListItem>();

            //foreach (var cheeseType in Enum.GetValues(typeof(CheeseType))) 
            //{
            //    CheeseTypes.Add(new SelectListItem
            //    {
            //        Value = ((int)cheeseType).ToString(),
            //        Text = cheeseType.ToString()
            //    }); ;
            //}
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
