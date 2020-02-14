using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleExam.ViewModels
{
    public class ExamSaveModel
    {
        public int Id { get; set; }

        public IEnumerable<LessonViewModel> Lessons { get; set; }

        [Required]
        public string LessonId { get; set; }

        public IEnumerable<StudentViewModel> Students { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [Range(1, 255)]
        public byte? Mark { get; set; }
    }
}