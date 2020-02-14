using SimpleExam.Models;
using SimpleExam.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleExam.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Exam> GetAllByLessonId(string lessonId)
        {
            return _context.Exams.Where(e => e.LessonId == lessonId);
        }

        public void Delete(params Exam[] exams)
        {
            _context.Exams.RemoveRange(exams);
        }

        public IEnumerable<ExamViewModel> GetAll()
        {
            return _context.Exams
                .Include(e => e.Lesson)
                .Include(e => e.Student)
                .ToArray()
                .Select(e => new ExamViewModel
                {
                    Id = e.Id,
                    LessonName = e.Lesson.Name,
                    StudentFullName = e.Student.FullName,
                    Date = e.Date,
                    Mark = e.Mark
                })
                .ToList();
        }

        public Exam GetById(int id)
        {
            return _context.Exams.SingleOrDefault(e => e.Id == id);
        }

        public void Add(Exam exam)
        {
            _context.Exams.Add(exam);
        }

        public void Update(Exam exam)
        {
            _context.Entry(exam).State = EntityState.Modified;
        }

        public void SaveExam(Exam exam)
        {
            var examInDb = GetById(exam.Id);
            if (examInDb == null)
            {
                Add(exam);
            }
            else
            {
                examInDb.Date = exam.Date;
                examInDb.LessonId = exam.LessonId;
                examInDb.StudentId = exam.StudentId;
                examInDb.Mark = exam.Mark;
                Update(examInDb);
            }
        }

        public void RemoveExam(int examId)
        {
            var examInDb = GetById(examId);
            if (examInDb != null)
            {
                Delete(examInDb);
            }
        }
    }
}