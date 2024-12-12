using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Dataflow;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeDiscountController : Controller
    {
        IGenericService<RecipeDiscount> recipeDiscountManager;
       

        public RecipeDiscountController()
        {
            this.recipeDiscountManager = new RecipeDiscountManager();
        }

        /// <summary>
        /// Tarife indirimi ekler
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("recipediscount")]
        public IActionResult AddRecipeDiscount(RecipeDiscount r)
        {
            Model model = new Model();
            model = recipeDiscountManager.InsertBL(r);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);

        }

        /// <summary>
        /// Tarife indirimi siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("recipediscount")]
        public IActionResult DeleteRecipeDiscount(int id)
        {
            Model model = new Model();
            model = recipeDiscountManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Tarife indirimlerini listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("recipediscount")]
        public IActionResult GetRecipeDiscount(int id)
        {
            var value = recipeDiscountManager.GetBL(id);
            return Ok(value);
        }

        /// <summary>
        /// Tarife indirimlerini listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("recipediscounts")]
        public IActionResult GetAllRecipeDiscount()
        {
            var value = recipeDiscountManager.GetAllListBL();
            return Ok(value);
        }

        /// <summary>
        /// Tarife indirimi günceller
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPut("recipediscount")]
        public IActionResult UpdateRecipeDiscount(RecipeDiscount r)
        {
            Model model = new Model();
            model = recipeDiscountManager.UpdateBL(r);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

    }
}
