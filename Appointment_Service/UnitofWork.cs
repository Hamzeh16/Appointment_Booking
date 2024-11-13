using Appointment_Data.Data;
using Appointment_Service.IRepositry;

namespace Appointment_Service
{
    public class UnitofWork : IUnitofWork
    {
        private AppDbContext _db;

        public UnitofWork(AppDbContext db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
