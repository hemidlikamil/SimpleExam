using SimpleExam.Models;
using SimpleExam.Repository;
using System;

namespace SimpleExam.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private bool _disposed;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public ILessonRepository LessonRepo => new LessonRepository(_context);
        public IExamRepository ExamRepo => new ExamRepository(_context);
        public IStudentRepository StudentRepo => new StudentRepository(_context);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}