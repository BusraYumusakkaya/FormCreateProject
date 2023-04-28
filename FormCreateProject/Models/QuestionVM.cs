using FormCreateProject.Entities.Concrete;

namespace FormCreateProject.Models
{
    public class QuestionVM
    {
        public IEnumerable<Question> Questions { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Guid> Ids { get; set; }
    }
}
