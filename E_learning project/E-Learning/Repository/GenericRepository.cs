using E_Learning.Interface;
using E_Learning.Models;
using E_Learning_Platform.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:class
    {
       E_LearningContext context;
        private DbSet<T> table;
        public GenericRepository(E_LearningContext _context)
        {
            context= _context;
            table = context.Set<T>();
        }
        public List<T> GetAll()
        {
           return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Update(obj);
            context.SaveChanges();
        }
        public void Delete(T obj)
        {
            table.Remove(obj);
            context.SaveChanges();
        }
    }
}
