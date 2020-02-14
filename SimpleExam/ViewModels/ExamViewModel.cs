using System;

namespace SimpleExam.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string LessonName { get; set; }

        public string StudentFullName { get; set; }

        public DateTime? Date { get; set; }

        public byte? Mark { get; set; }
    }
}