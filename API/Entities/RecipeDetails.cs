using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("RecipeDetails")]
    public class RecipeDetails
    {
        public int Id { get; set; }
        public string Decription { get; set; }
        public Ingredients Ingredients { get; set; }
        public int IngredientsId { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }

    }
}