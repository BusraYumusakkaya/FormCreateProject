using FormCreateProject.AppDbContext;
using FormCreateProject.Entities.Concrete;
using FormCreateProject.Repositories.Abstract;

namespace FormCreateProject.Repositories.Concrete
{
    public class KullaniciRepository : GenericRepository<User>, IKullaniciRepository
    {
        private readonly FormDbContext db;
        public KullaniciRepository(FormDbContext db) : base(db)
        {
            this.db = db;
        }

        public User GetByUsernameAndPassword(string name, string sifre)
        {
            return db.Users.Where(a => a.Name == name && a.Password == sifre).SingleOrDefault();
        }
    }
}
