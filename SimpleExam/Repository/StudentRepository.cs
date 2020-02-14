using SimpleExam.Models;
using SimpleExam.ViewModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SimpleExam.Repository
{
    class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<StudentViewModel> GetAll()
        {
            return _context.Students.ToList()
                .Select(m => new StudentViewModel { Id = m.Id, Name = m.Name, LastName = m.LastName, Class = m.Class });
        }

        public Student GetById(int id)
        {
            return _context.Students.SingleOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Delete(params Student[] students)
        {
            _context.Students.RemoveRange(students);
        }

        public void SaveStudent(Student student)
        {
            var studentInDb = GetById(student.Id);
            if (studentInDb == null)
            {
                Add(student);
            }
            else
            {
                studentInDb.Name = student.Name;
                studentInDb.LastName = student.LastName;
                studentInDb.Class = student.Class;
                Update(studentInDb);
            }
        }

        public void RemoveStudent(int studentId)
        {
            var studentInDb = GetById(studentId);
            if (studentInDb != null)
            {
                Delete(studentInDb);
            }
        }
    }
}