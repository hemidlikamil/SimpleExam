using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleExam.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public byte? Class { get; set; }
    }
}