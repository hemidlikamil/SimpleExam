using SimpleExam.Models;
using SimpleExam.UOW;
using SimpleExam.ViewModels;
using System.Web.Mvc;

namespace SimpleExam.Controllers
{
    public class LessonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LessonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var viewModel = _unitOfWork.LessonRepo.GetAll();
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new LessonViewModel { IsEdit = false };
            return View("LessonForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var lesson = _unitOfWork.LessonRepo.GetById(id);
            if (lesson == null)
            {
                return HttpNotFound();
            }

            var viewModel = new LessonViewModel
            {
                Id = lesson.Id,
                Name = lesson.Name,
                Class = lesson.Class,
                TeacherLastName = lesson.TeacherLastName,
                TeacherName = lesson.TeacherName,
                IsEdit = true
            };
            return View("LessonForm", viewModel);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            _unitOfWork.LessonRepo.RemoveLesson(id);
            _unitOfWork.Commit();
            return Json("OK");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(LessonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("LessonForm", viewModel);
            }

            var lesson = new Lesson
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Class = viewModel.Class.Value,
                TeacherName = viewModel.TeacherName,
                TeacherLastName = viewModel.TeacherLastName
            };
            _unitOfWork.LessonRepo.SaveLesson(lesson);

            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}