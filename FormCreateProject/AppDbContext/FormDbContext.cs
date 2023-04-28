using FormCreateProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FormCreateProject.AppDbContext
{
    public class FormDbContext :DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(a => a.FirstName).HasMaxLength(50).IsRequired();
            builder.Entity<User>().Property(a => a.LastName).HasMaxLength(50).IsRequired();

            builder.Entity<Form>().Property(a => a.Name).HasMaxLength(50).IsRequired();

            builder.Entity<Question>().Property(a => a.Name).HasMaxLength(50).IsRequired();

            builder.Entity<Question>().HasData(new Question
            {
                Id = Guid.NewGuid(),
                Name = "Ad",
                Required = true,
                DataType = "string"
            });
            builder.Entity<Question>().HasData(new Question
            {
                Id = Guid.NewGuid(),
                Name = "Soyad",
                Required = true,
                DataType = "string"
            });
            builder.Entity<Question>().HasData(new Question
            {
                Id = Guid.NewGuid(),
                Name = "Yaş",
                Required = false,
                DataType = "number"
            });
            builder.Entity<Question>().HasData(new Question
            {
                Id = Guid.NewGuid(),
                Name = "Doğum Tarihi",
                Required = false,
                DataType = "date"
            });
            builder.Entity<Question>().HasData(new Question
            {
                Id = Guid.NewGuid(),
                Name = "E-posta",
                Required = false,
                DataType = "email"
            });
            builder.Entity<Question>().HasData(new Question
            {
                Id = Guid.NewGuid(),
                Name = "Telefon",
                Required = false,
                DataType = "number"
            });

           

            builder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                Name="BusraYumusakkaya",
                FirstName = "Büşra",
                LastName = "Yumuşakkaya",
                Password = "Busra123."
            });
            base.OnModelCreating(builder);
        }

    }
}
