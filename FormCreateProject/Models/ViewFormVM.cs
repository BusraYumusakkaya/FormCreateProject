using FormCreateProject.Entities.Concrete;

namespace FormCreateProject.Models
{
    public class ViewFormVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<Question> FormQuestions { get; set; }
    }
}
