using System.ComponentModel.DataAnnotations;

namespace SimpleExam.ViewModels
{
    public class LessonViewModel
    {
        [Required]
        [MaxLength(3)]
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public byte? Class { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Teacher Name")]
        public string TeacherName { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Teacher Last Name")]
        public string TeacherLastName { get; set; }

        public bool IsEdit { get; set; }
    }
}