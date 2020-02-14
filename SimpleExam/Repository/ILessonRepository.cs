using SimpleExam.Models;
using SimpleExam.ViewModels;
using System.Collections.Generic;

namespace SimpleExam.Repository
{
    public interface ILessonRepository
    {
        IEnumerable<LessonViewModel> GetAll();
        Lesson GetById(string id);
        void Delete(params Lesson[] lessons);
        void Add(Lesson lesson);
        void Update(Lesson lesson);
        void SaveLesson(Lesson lesson);
        void RemoveLesson(string lessonId);
    }
}