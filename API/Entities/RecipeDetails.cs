using API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("RecipeDetails")]
    public class RecipeDetails
    {
        public float Quantity { get; set; }
        public MeasureUnitEnum MesureUnit { get; set; }

        public int IngredientsId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}