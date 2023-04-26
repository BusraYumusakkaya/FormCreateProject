using FormCreateProject.Entities.Concrete;

namespace FormCreateProject.Models
{
    public class QuestionVM
    {
        public IEnumerable<Question> Questions { get; set; }
        public string Name { get; set; }
    }
}
