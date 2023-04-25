using Microsoft.VisualBasic;

namespace FormCreateProject.Entities.Concrete
{
    public class Content
    {
       
        public Guid Id { get; set; }
        public Guid? FormId { get; set; }
        public Form? Form { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
