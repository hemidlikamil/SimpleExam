using SimpleExam.Models;
using SimpleExam.UOW;
using SimpleExam.ViewModels;
using System.Web.Mvc;

namespace SimpleExam.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = _unitOfWork.StudentRepo.GetAll();
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new StudentViewModel();
            return View("StudentForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var student = _unitOfWork.StudentRepo.GetById(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Class = student.Class
            };
            return View("StudentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _unitOfWork.StudentRepo.RemoveStudent(id);
            _unitOfWork.Commit();
            return Json("OK");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("StudentForm", viewModel);
            }

            var student = new Student
            {
                Name = viewModel.Name,
                LastName = viewModel.LastName,
                Class = viewModel.Class.Value
            };

            _unitOfWork.StudentRepo.SaveStudent(student);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}