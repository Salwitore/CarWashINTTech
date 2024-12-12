using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class RecipeDiscountRepository : IGenericDal<RecipeDiscount>, IRecipeDiscountDal
    {
        CarWashesDbContext context = new CarWashesDbContext();

        public RecipeDiscount Get(int id)
        {
            return context.RecipeDiscounts.Find(id);
        }
        public bool Delete(int id)
        {
            var value = context.RecipeDiscounts.Find(id);
            context.RecipeDiscounts.Remove(value);
            return context.SaveChanges() > 0 ? true : false;
        }

        public List<RecipeDiscount> GetList()
        {
            return context.RecipeDiscounts.ToList();
        }

        public bool Insert(RecipeDiscount recipeDiscount)
        {
            context.RecipeDiscounts.Add(recipeDiscount);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(RecipeDiscount recipeDiscount)
        {
            context.RecipeDiscounts.Update(recipeDiscount);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
