using FormCreateProject.AppDbContext;
using FormCreateProject.Entities.Abstract;
using FormCreateProject.Repositories.Abstract;

namespace FormCreateProject.Repositories.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly FormDbContext db;

        public GenericRepository(FormDbContext db)
        {
            this.db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                db.Set<T>().Add(entity);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                db.Set<T>().Remove(entity);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().FirstOrDefault(x => x.Id == id);
            //return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public T SingleOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().SingleOrDefault(predicate);
        }

        public bool Update(T entity)
        {

            try
            {
                //Update metodu içine gönderilen entity'de id varsa ilgili id'ye sahip entity'yi update eder, id yok ise add gibi çalışır. Bu sebeple tek bir AddOrUpdate metodu da kullanılabilir
                db.Set<T>().Update(entity);
                return db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
