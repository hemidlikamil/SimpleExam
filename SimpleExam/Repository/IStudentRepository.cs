using SimpleExam.Models;
using SimpleExam.ViewModels;
using System.Collections.Generic;

namespace SimpleExam.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<StudentViewModel> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(params Student[] students);
        void SaveStudent(Student student);
        void RemoveStudent(int studentId);
    }
}