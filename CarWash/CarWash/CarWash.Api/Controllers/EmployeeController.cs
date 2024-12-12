using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IGenericService<Employee> employeeManager;

        public EmployeeController()
        {
            this.employeeManager = new EmployeeManager();
        }

        /// <summary>
        /// İşçi ekler
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost("employee")]
        public IActionResult EmployeeAdd([FromBody] Employee e)
        {
            Model model = new Model();
            model = employeeManager.InsertBL(e);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);

        }

        /// <summary>
        /// İşçi siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("employee")]
        public IActionResult EmployeeDelete(int id)
        {
            Model model = new Model();
            model = employeeManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// İşçi getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("employee")]
        public IActionResult EmployeeGet(int id)
        {
            Model model = new Model();
            model = employeeManager.GetBL(id);
            return Ok(model);
        }

        /// <summary>
        /// İşçi getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("employees")]
        public IActionResult EmployeesGet()
        {
            var values = employeeManager.GetAllListBL();
            return Ok(values);
        }

        /// <summary>
        /// İşçi günceller
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPut("employee")]
        public IActionResult EmployeeUpdate(Employee e)
        {
            Model model = new Model();
            model = employeeManager.UpdateBL(e);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }


        /// <summary>
        /// Toplu işçi ekler
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        [HttpPost("employees")]
        public IActionResult EmployeeAddRange(List<Employee> employees)
        {
            foreach (var item in employees)
            {
                employeeManager.InsertBL(item);
            }

            return Ok(employees);

        }

    }
}