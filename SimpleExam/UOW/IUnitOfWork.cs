using SimpleExam.Repository;

namespace SimpleExam.UOW
{
    public interface IUnitOfWork
    {
        ILessonRepository LessonRepo { get; }
        IExamRepository ExamRepo { get; }
        IStudentRepository StudentRepo { get; }

        void Commit();
    }
}
