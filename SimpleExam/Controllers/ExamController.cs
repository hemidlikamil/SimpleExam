using SimpleExam.Models;
using SimpleExam.UOW;
using SimpleExam.ViewModels;
using System.Web.Mvc;

namespace SimpleExam.Controllers
{
    public class ExamController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = _unitOfWork.ExamRepo.GetAll();
            return View(viewModel);
        }

        public ActionResult New()
        {
            var lessons = _unitOfWork.LessonRepo.GetAll();
            var students = _unitOfWork.StudentRepo.GetAll();
            var viewModel = new ExamSaveModel
            {
                Lessons = lessons,
                Students = students
            };
            return View("ExamForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var exam = _unitOfWork.ExamRepo.GetById(id);
            if (exam == null)
            {
                return HttpNotFound();
            }

            var lessons = _unitOfWork.LessonRepo.GetAll();
            var students = _unitOfWork.StudentRepo.GetAll();

            var viewModel = new ExamSaveModel
            {
                Id = exam.Id,
                Date = exam.Date,
                Mark = exam.Mark,
                LessonId = exam.LessonId,
                StudentId = exam.StudentId,
                Lessons = lessons,
                Students = students
            };
            return View("ExamForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _unitOfWork.ExamRepo.RemoveExam(id);
            _unitOfWork.Commit();
            return Json("OK");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ExamSaveModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ExamForm", viewModel);
            }

            var exam = new Exam
            {
                Id = viewModel.Id,
                Date = viewModel.Date.Value,
                LessonId = viewModel.LessonId,
                StudentId = viewModel.StudentId,
                Mark = viewModel.Mark ?? 0
            };
            _unitOfWork.ExamRepo.SaveExam(exam);

            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}