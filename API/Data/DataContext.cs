using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        
        }
       
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeDetails> RecipeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeDetails>()
               .HasKey(bc => new { bc.IngredientsId, bc.RecipeId });

            modelBuilder.Entity<RecipeDetails>()
                .HasOne(bc => bc.Ingredient)
                .WithMany(b => b.RecipeDetailsList)
                .HasForeignKey(bc => bc.IngredientsId);

            modelBuilder.Entity<RecipeDetails>()
                .HasOne(bc => bc.Recipe)
                .WithMany(c => c.RecipeDetailsList)
                .HasForeignKey(bc => bc.RecipeId);

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category(){ Id=1, CategoryName = "Pizza", CategoryPhotoUrl = "https://podravkaiovariations.azureedge.net/2a7e4ce6-631f-11eb-a783-0242ac120051/v/f2b1f6a6-64bc-11eb-b6c2-0242ac130010/1600x1200-f2b21938-64bc-11eb-9498-0242ac130010.jpeg" },
                    new Category(){ Id=2, CategoryName = "Pasta", CategoryPhotoUrl = "https://www.budgetbytes.com/wp-content/uploads/2013/07/Creamy-Spinach-Tomato-Pasta-bowl-500x500.jpg" },
                    new Category(){ Id=3, CategoryName = "Pancakes", CategoryPhotoUrl = "https://tmbidigitalassetsazure.blob.core.windows.net/rms3-prod/attachments/37/1200x1200/Chocolate-Lover-s-Pancakes_EXPS_TOHCA19_133776_B03_15_3b_rms.jpg" }
                );

            modelBuilder.Entity<Ingredient>()
                .HasData(
                    new Ingredient() { Id=1, IngredientsName = "Flour", Price = 32, PurchaseMesureUnit = Enums.MeasureUnitEnum.kg, PurchaseQuantity = 25F },
                    new Ingredient() { Id=2, IngredientsName = "Oil", Price = 5.30F, PurchaseMesureUnit = Enums.MeasureUnitEnum.L, PurchaseQuantity = 1F },
                    new Ingredient() { Id = 3, IngredientsName = "Nutella", Price = 10.90F, PurchaseMesureUnit = Enums.MeasureUnitEnum.kg, PurchaseQuantity = 1 }
                );

            modelBuilder.Entity<Recipe>()
                .HasData(
                    new Recipe() { Id = 1, CategoryId = 1, RecipeName = "Margerita", Description = "Pizza sa sirom" }
                );

            modelBuilder.Entity<RecipeDetails>()
                .HasData(
                    new RecipeDetails() { RecipeId = 1, IngredientsId = 1, Quantity = 150, MesureUnit = Enums.MeasureUnitEnum.g },
                    new RecipeDetails() { RecipeId = 1, IngredientsId = 2, Quantity = 20, MesureUnit = Enums.MeasureUnitEnum.ml }
                );
        }
    }
}