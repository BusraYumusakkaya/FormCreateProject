using FormCreateProject.Entities.Concrete;
using FormCreateProject.Models;
using FormCreateProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FormCreateProject.Controllers
{
    public class FormController : Controller
    {
        private readonly IQuestionRepository questionRepository;

        public FormController(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetQuestions()
        {
            var questions = questionRepository.GetAll();
            return Json(questions);
        }

        public IActionResult AddForm(int[] ids, QuestionVM questionVM)
        {
            Content content = new Content();
            Form form=new Form();
            form.Id = (Guid)content.FormId;
            form.Name = questionVM.Name;

            foreach (var item in ids)
            {
                var question = questionRepository.GetById(item.ToString());
                content.Questions.Add(question);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
