using FormCreateProject.AppDbContext;
using FormCreateProject.Entities.Concrete;
using FormCreateProject.Repositories.Abstract;

namespace FormCreateProject.Repositories.Concrete
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly FormDbContext db;
        public QuestionRepository(FormDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
