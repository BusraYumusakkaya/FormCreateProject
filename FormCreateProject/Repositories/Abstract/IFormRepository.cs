using FormCreateProject.Entities.Concrete;

namespace FormCreateProject.Repositories.Abstract
{
    public interface IFormRepository : IRepository<Form>
    {
        IEnumerable<Form> GetAllIncludeContents();
        Form GetByIdIncludeQuestions(Guid id);
    }
}
