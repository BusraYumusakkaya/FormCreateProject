

using FormCreateProject.AppDbContext;
using FormCreateProject.Entities.Concrete;
using FormCreateProject.Repositories.Abstract;

namespace FormCreateProject.Repositories.Concrete
{
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        private readonly FormDbContext db;
        public ContentRepository(FormDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
