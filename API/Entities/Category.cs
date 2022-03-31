using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities{

    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPhotoUrl {get;set;}

        public List<Recipe> Recipes { get; set; }
    }
}