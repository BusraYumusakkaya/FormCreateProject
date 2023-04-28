using FormCreateProject.Entities.Abstract;
using Microsoft.Data.SqlClient.Server;

namespace FormCreateProject.Entities.Concrete
{
    public class Form : BaseEntity
    {
        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CretedBy { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
