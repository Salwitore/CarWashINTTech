using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    /// <summary>
    /// Tarife indirimi
    /// </summary>
    public class RecipeDiscount
    {
        [Key]
        public int RecipeDiscountId { get; set; }
        public double Discount { get; set; }
        public ICollection<Recipe>? Recipes { get; set; }
    }
}
