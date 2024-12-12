using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        IGenericService<Customer> customerManager;


        public CustomerController()
        {
            this.customerManager = new CustomerManager();
        }

        /// <summary>
        /// Müşteri siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("customer")]
        public IActionResult CustomerDelete(int id)
        {
            Model model = new Model();
            model = customerManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Müşterileri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("customer")]
        public IActionResult CustomerGet(int id)
        {
            Model model = new Model();
            model = customerManager.GetBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Müşterileri listeler
        /// </summary>
        /// <returns></returns>
        [HttpGet("customers")]
        public IActionResult CustomerList()
        {
            Model model = new Model();
            model = customerManager.GetAllListBL();
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Müşteri ekler
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost("customer")]
        public IActionResult CustomerAdd([FromBody] Customer customer)
        {
            Model model = new Model();
            model = customerManager.InsertBL(customer);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Müşteri günceller
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("customer")]
        public IActionResult CustomerUpdate([FromBody] Customer customer)
        {
            Model model = new Model();
            model = customerManager.UpdateBL(customer);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Toplu müşteri ekler
        /// </summary>
        /// <param name="customers"></param>
        /// <returns></returns>
        [HttpPost("customers")]
        public IActionResult CustomerAddRange([FromBody] List<Customer> customers)
        {
            Model model = new Model();
            foreach (var item in customers)
            {
                model = customerManager.InsertBL(item);

                continue;
            }
            return Ok(model);
        }


        /// <summary>
        /// Müşteriyi abone eder
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customers"></param>
        /// <returns></returns>
        [HttpPost("subscribe")]
        public IActionResult CustomerSubscribe(int id)
        {
            Model model = new Model();

            var customer = customerManager.GetBL(id);
            if (customer == null)
            {

            }
            // customers = customerManager.GetAllListBL();


            customer.Subscriber = true;
            customerManager.UpdateBL(customer);
            model.models = customer;


            return Ok(model);
        }

        /// <summary>
        /// Müşteriyi abonelikten çıkarır
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customers"></param>
        /// <returns></returns>
        [HttpPut("subscribe")]
        public IActionResult CustomerSubscribeDisable(int id, List<Customer> customers)
        {
            Model model = new Model();
            bool evet = true;
            foreach (var customer in customers)
            {
                if (customer.CustomerId == id && customer.Subscriber == true)
                {
                    //Abonelikten Çıkmak 
                    if (evet)
                    {
                        customer.Subscriber = false;
                        customerManager.UpdateBL(customer);
                        model.models = customer;
                    }
                }
            }
            return Ok(model);
        }

    }
}
