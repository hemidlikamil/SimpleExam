namespace SimpleExam.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public byte Class { get; set; }
        public string FullName => Name + " " + LastName;

    }
}