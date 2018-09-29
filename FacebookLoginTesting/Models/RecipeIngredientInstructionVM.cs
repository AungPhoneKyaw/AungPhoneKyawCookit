using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookLoginTesting.Models
{
    public class RecipeIngredientInstructionVM
    {
        public RecipeIngredientInstructionVM()
        {

        }
        public RecipeIngredientInstructionVM(recipe recipe, List<ingredient> ingredients, List<instruction> instructions)
        {
            this.recipe_id = recipe.recipe_id;
            this.recipe_name = recipe.recipe_name;
            this.Image = recipe.ImageName;
            this.ingredients = ingredients;
            this.instructions = instructions;
        }

        public int recipe_id { get; set; }
        public string Image { get; set; }
        public string recipe_name { get; set; }

        public List<ingredient> ingredients { get; set; }
        public List<instruction> instructions { get; set; }
    }
}