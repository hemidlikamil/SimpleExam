using SimpleExam.Models;
using System.Data.Entity.ModelConfiguration;

namespace SimpleExam.EntityConfigurations
{
    public class LessonConfiguration : EntityTypeConfiguration<Lesson>
    {
        public LessonConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnType("char");

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar");

            Property(c => c.TeacherName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");

            Property(c => c.TeacherLastName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");
        }
    }
}