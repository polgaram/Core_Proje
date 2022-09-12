using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            //using var c = new Context();
            _context.Remove(t);
            _context.SaveChanges();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            //using var c = new Context();
            return _context.Set<T>().Where(filter).ToList();
        }

        public T GetByID(int id)
        {
            //using var c = new Context();
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            //using var c = new Context();
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            //using var c = new Context();
            _context.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            //using var c = new Context();
            _context.Update(t);
            _context.SaveChanges();
        }
    }
}