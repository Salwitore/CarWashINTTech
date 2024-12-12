using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    /// <summary>
    /// Tarife
    /// </summary>
    public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        public int RecipeDiscountId { get; set; }
        public string RecipeName { get; set; }
        public int RecipePrice { get; set; }
        public ICollection<Customer>? Customers { get; set; }

        public ICollection<RecipeDiscount>? RecipeDiscounts { get; set; }


    }
}
