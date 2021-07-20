using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class Repository<T> : IRepository<T> where T : class
    {

        //Dependency Injection
        protected CloneMovieShopDbContext _cloneMovieShopDbContext;
        //for the construtor we used dependency injection to create the connection.
        public Repository(CloneMovieShopDbContext cMovieShopDbContext){
            _cloneMovieShopDbContext=cMovieShopDbContext;
        }

        public void Add(T entity)
        {
            _cloneMovieShopDbContext.Set<T>().Add(entity);//save in memory
            _cloneMovieShopDbContext.SaveChanges();//send to database, finish the query
        }

        public void Delete(T entity)
        {
            _cloneMovieShopDbContext.Set<T>().Remove(entity);
            _cloneMovieShopDbContext.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _cloneMovieShopDbContext.Set<T>().Where(where).AsEnumerable();
            foreach (var obj in objects)
                _cloneMovieShopDbContext.Set<T>().Remove(obj);
            _cloneMovieShopDbContext.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _cloneMovieShopDbContext.Set<T>().Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _cloneMovieShopDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _cloneMovieShopDbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _cloneMovieShopDbContext.Set<T>().Where(where).ToList();
        }

        public void Update(T entity)
        {
            _cloneMovieShopDbContext.Entry(entity).State = EntityState.Modified;
            _cloneMovieShopDbContext.SaveChanges();
        }
    }
}
