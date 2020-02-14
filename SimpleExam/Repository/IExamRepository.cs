using SimpleExam.Models;
using SimpleExam.ViewModels;
using System.Collections.Generic;

namespace SimpleExam.Repository
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetAllByLessonId(string lessonId);
        void Delete(params Exam[] exams);
        IEnumerable<ExamViewModel> GetAll();
        Exam GetById(int id);
        void Add(Exam exam);
        void Update(Exam exam);
        void SaveExam(Exam exam);
        void RemoveExam(int examId);
    }
}