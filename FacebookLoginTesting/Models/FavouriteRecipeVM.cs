using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookLoginTesting.Models
{
    public class FavouriteRecipeVM
    {
        public FavouriteRecipeVM(recipe r)
        {
            recipe_id = r.recipe_id;
            ImageName = r.ImageName;
            ImagePath = r.ImagePath;
            recipe_name = r.recipe_name;
        }
        public int recipe_id { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public string recipe_name { get; set; }
        public bool favourite { get; set; }

    }


}