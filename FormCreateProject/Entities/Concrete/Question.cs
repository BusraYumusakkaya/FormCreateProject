using FormCreateProject.Entities.Abstract;
using Microsoft.Data.SqlClient.Server;
using System.ComponentModel.DataAnnotations;

namespace FormCreateProject.Entities.Concrete
{
    public class Question : BaseEntity
    {
       
        public bool Required { get; set; }
        public string DataType { get; set; }
        public ICollection<Content>Contents { get; set; }
    }
}
