using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repository
{
    public class AppointmentRepository : IGenericDal<Appointment>, IAppointmentDal
    {
        CarWashesDbContext context = new CarWashesDbContext();
        public bool Delete(int id)
        {
            var value = context.Appointments.Find(id);
            context.Appointments.Remove(value);
            return context.SaveChanges() > 0 ? true : false;
        }

        public Appointment Get(int id)
        {
            return context.Appointments.Find(id);
        }

        public List<Appointment> GetList()
        {
            return context.Appointments.ToList();
        }

        public bool Insert(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Update(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
