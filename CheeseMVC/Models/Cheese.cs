using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public CheeseType Type { get; set; }


        /// <summary>
        /// Foreign key 
        /// </summary>
        public int CategoryID { get; set; }
        /// <summary>
        /// Navigation Property
        /// </summary>
        public CheeseCategory Category { get; set; }


    }
}
