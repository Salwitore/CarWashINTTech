using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        readonly IGenericService<Appointment> appointmentManager;
        public AppointmentController()
        {
            this.appointmentManager = new AppointmentManager();
        }


        [HttpDelete("appointment")]
        public IActionResult Delete(int id)
        {
            Model model = new Model();
            model = appointmentManager.DeleteBL(id);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        [HttpGet("appointment")]
        public IActionResult GetAppointment(int id)
        {
            var value = appointmentManager.GetBL(id);
            return Ok(value);
        }

        [HttpGet("appointments")]
        public IActionResult GetAppointmentList()
        {
            var value = appointmentManager.GetAllListBL();
            return Ok(value);
        }

        /// <summary>
        /// Randevu oluşturur
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPost("appointment")]
        public IActionResult AddAppointment([FromBody] Appointment appointment)

        {
            Model model = new Model();
            model = appointmentManager.InsertBL(appointment);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Randevu günceller
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        [HttpPut("appointment")]
        public IActionResult UpdateAppointment(Appointment appointment)
        {
            Model model = new Model();
            model = appointmentManager.UpdateBL(appointment);
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
        }

        /// <summary>
        /// Toplu randevu oluşturur
        /// </summary>
        /// <param name="appointments"></param>
        /// <returns></returns>
        [HttpPost("appointments")]
        public IActionResult AllAppointmentAdd([FromBody] List<Appointment> appointments)
        {
            Model model = new Model();
            foreach (var appointment in appointments)
            {
                appointmentManager.InsertBL(appointment);
            }
            return Ok();
        }

        /// <summary>
        /// Randevu durumunu günceller
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("appointmentstatus")]
        public IActionResult UpdateAppointmnent([FromQuery] int id)
        {
            Model model = new Model();
            CarWashesDbContext context = new CarWashesDbContext();
            var value = context.Appointments.Find(id);
            if (value == null)
            {
                model.StatuMessage = "Randevu bulunamadı";
                model.Status = System.Net.HttpStatusCode.NotFound;
                return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
            }
            else if (value.AppointmentStatus == false)
            {
                value.AppointmentStatus = true;
                model = appointmentManager.UpdateBL(value);
                model.Status = System.Net.HttpStatusCode.OK;
                return StatusCode((int)model.Status, model.StatuMessage ?? model.models);
            }
            model.Status = System.Net.HttpStatusCode.NotFound;
            model.StatuMessage = "İşlem başarısız.";
            return StatusCode((int)model.Status, model.StatuMessage ?? model.models);

            //bu id ye sahip bir randevuyu çek
            //status true çek
            //update'e gönder
            //return ok 
        }



    }
}
