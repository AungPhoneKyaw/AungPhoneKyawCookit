using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookLoginTesting.Models
{
    public class Post_RecipeIngredientInstructionVM
    {
        public Post_RecipeIngredientInstructionVM()
        {

        }
        public Post_RecipeIngredientInstructionVM(post_recipe post_recipe, List<post_ingredient> post_ingredient, List<post_instruction> post_instruction)
        {
            this.post_recipe_id = post_recipe.post_recipe_id;
            //this.userid = post_recipe.userid;
            this.post_recipe_name = post_recipe.post_recipe_name;
            this.post_ImageName = post_recipe.post_ImageName;
            this.post_ingredient = post_ingredient;
            this.post_instruction = post_instruction;
        }

        public int post_recipe_id { get; set; }
        public string post_ImageName { get; set; }
        public int userid { get; set; }
        public string post_recipe_name { get; set; }


        public List<post_ingredient> post_ingredient { get; set; }
        public List<post_instruction> post_instruction { get; set; }
    }
}