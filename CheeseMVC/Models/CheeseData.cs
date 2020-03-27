//using CheeseMVC.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace CheeseMVC.Models
//{
//    public class CheeseData
//    {
         
//        static private List<Cheese> cheeses = new List<Cheese>();
//        //Extracted the data management from controllers.
//        // Every thing is static here. 

//        /// <summary>
//        /// Get all the Cheese data. 
//        /// </summary>
//        /// <returns></returns>
//        public static List<Cheese> GetAll() 
//        {
//            return cheeses;
//        }
        
//        /// <summary>
//        /// Adds a cheese data to collections of cheeses.
//        /// </summary>
//        /// <param name="newCheese"></param>
//        public static void Add(Cheese newCheese) 
//        {
//            cheeses.Add(newCheese);
//        }
      
//        /// <summary>
//        /// Removes a single cheese from collection of cheeses.
//        /// </summary>
//        /// <param name="id"></param>
//        public static void Remove(int id) 
//        {
//            Cheese cheeseToRemove = GetById(id);
//            cheeses.Remove(cheeseToRemove);
//        }

//        //public static void Update(int id) 
//        //{
//        //    Cheese cheeseToRemove = GetById(id);

//        //}

//        /// <summary>
//        /// Retrevies a single Cheese item from collection of Cheeses.
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>

//        public static Cheese GetById(int id) 
//        {
//            return cheeses.SingleOrDefault(x => x.CheeseId == id);
//        }
//    }
//}
  