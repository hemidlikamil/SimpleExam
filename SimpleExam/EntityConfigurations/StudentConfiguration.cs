using System.Data.Entity.ModelConfiguration;
using SimpleExam.Models;

namespace SimpleExam.EntityConfigurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(c => c.Name)
                .HasMaxLength(30)
                .HasColumnType("varchar");

            Property(c => c.LastName)
                .HasMaxLength(30)
                .HasColumnType("varchar");
        }
    }
}