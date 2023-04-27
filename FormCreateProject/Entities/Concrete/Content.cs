using FormCreateProject.Entities.Abstract;
using Microsoft.VisualBasic;

namespace FormCreateProject.Entities.Concrete
{
    public class Content:BaseEntity
    {
       
        public Guid? FormId { get; set; }
        public Form? Form { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
