using SimpleExam.Models;
using System.Data.Entity.ModelConfiguration;

namespace SimpleExam.EntityConfigurations
{
    public class ExamConfiguration : EntityTypeConfiguration<Exam>
    {
        public ExamConfiguration()
        {
            Property(c => c.Date)
                .HasColumnType("date");
        }
    }
}