using System;

namespace SimpleExam.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public Lesson Lesson { get; set; }
        public string LessonId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public byte Mark { get; set; }
    }
}