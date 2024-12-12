using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        IGenericService<Recipe> recipeManager;


        public RecipeController()
        {
            this.recipeManager = new RecipeManager();
        }


        /// <summary>
        /// Tarife ekler
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPost("recipe")]
        public IActionResult RecipeAdd(Recipe r)
        {
            Model model = new Model();
            model = recipeManager.InsertBL(r);
            return StatusCode((int)model.Status, model.models ?? model.StatuMessage);
        }

        /// <summary>
        /// Tarife siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("recipe")]
        public IActionResult RecipeDelete(int id)
        {
            Model model = new Model();
            model = recipeManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Tarifeleri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("recipe")]
        public IActionResult RecipeGet(int id)
        {
            Model model = new Model();
            model = recipeManager.GetBL(id);
            return Ok(model);
        }

        /// <summary>
        /// Tarifeleri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("recipes")]
        public IActionResult RecipeGetList()
        {
            Model model = new Model();
            model = recipeManager.GetAllListBL();
            return Ok(model);
        }

        /// <summary>
        /// Tarife güncelleme
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        [HttpPut("recipe")]
        public IActionResult RecipeUpdate(Recipe r)
        {
            Model model = new Model();
            model = recipeManager.UpdateBL(r);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }


        /// <summary>
        /// Toplu tarife ekler
        /// </summary>
        /// <param name="recipes"></param>
        /// <returns></returns>
        [HttpPost("recipes")]
        public IActionResult AllRecipeAdd([FromBody] List<Recipe> recipes)
        {
            foreach (var item in recipes)
            {
                recipeManager.InsertBL(item);
            }
            return Ok();
        }
    }
}
