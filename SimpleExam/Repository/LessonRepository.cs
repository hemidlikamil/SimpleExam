using SimpleExam.Models;
using SimpleExam.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleExam.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<LessonViewModel> GetAll()
        {
            return _context.Lessons.ToList()
                .Select(l => new LessonViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Class = l.Class,
                    TeacherName = l.TeacherName,
                    TeacherLastName = l.TeacherLastName
                });
        }

        public Lesson GetById(string id)
        {
            return _context.Lessons.SingleOrDefault(l => l.Id == id);
        }

        public void Delete(params Lesson[] lessons)
        {
            _context.Lessons.RemoveRange(lessons);
        }

        public void Add(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
        }

        public void Update(Lesson lesson)
        {
            _context.Entry(lesson).State = EntityState.Modified;
        }

        public void SaveLesson(Lesson lesson)
        {
            var lessonInDb = GetById(lesson.Id);
            if (lessonInDb == null)
            {
                Add(lesson);
            }
            else
            {
                lessonInDb.Name = lesson.Name;
                lessonInDb.Class = lesson.Class;
                lessonInDb.TeacherLastName = lesson.TeacherLastName;
                lessonInDb.TeacherName = lesson.TeacherName;
                Update(lessonInDb);
            }
        }

        public void RemoveLesson(string lessonId)
        {
            var exams = _context.Exams.Where(e => e.LessonId == lessonId).ToArray();
            _context.Exams.RemoveRange(exams);

            var lesson = GetById(lessonId);
            Delete(lesson);
        }
    }
}