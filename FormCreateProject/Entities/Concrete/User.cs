using FormCreateProject.Entities.Abstract;

namespace FormCreateProject.Entities.Concrete
{
    public class User : BaseEntity
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
    
}
