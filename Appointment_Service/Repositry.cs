using Appointment_Data.Data;
using Appointment_Service.IRepositry;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Appointment_Service
{
    public class Repositry<T> : IRepositry<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;

        public Repositry(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filtter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
