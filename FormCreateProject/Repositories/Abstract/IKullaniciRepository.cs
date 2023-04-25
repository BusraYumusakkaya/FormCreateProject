using FormCreateProject.Entities.Concrete;

namespace FormCreateProject.Repositories.Abstract
{
    public interface IKullaniciRepository : IRepository<User>
    {
        User GetByUsernameAndPassword(string name, string sifre);
    }
}
