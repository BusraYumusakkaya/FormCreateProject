using FormCreateProject.AppDbContext;
using FormCreateProject.Entities.Concrete;
using FormCreateProject.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FormCreateProject.Repositories.Concrete
{
    public class FormRepository : GenericRepository<Form>, IFormRepository
    {
        private readonly FormDbContext db;
        public FormRepository(FormDbContext db) : base(db)
        {
            this.db = db;
        }

        public IEnumerable<Form> GetAllIncludeContents()
        {
            return db.Forms.Include(s => s.Contents);
        }
    }
}
