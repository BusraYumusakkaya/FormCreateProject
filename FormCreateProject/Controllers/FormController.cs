using FormCreateProject.Entities.Concrete;
using FormCreateProject.Models;
using FormCreateProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FormCreateProject.Controllers
{
    public class FormController : Controller
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IFormRepository formRepository;
        private readonly IContentRepository contentRepository;

        public FormController(IQuestionRepository questionRepository,IFormRepository formRepository,IContentRepository contentRepository)
        {
            this.questionRepository = questionRepository;
            this.formRepository = formRepository;
            this.contentRepository = contentRepository;
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

            form.Name = questionVM.Name;
            form.Description = questionVM.Description;
            form.CretedBy = 1;
            formRepository.Add(form);
            content.Name = "";
            content.FormId = form.Id;
            contentRepository.Add(content);
           
            foreach (var item in ids)
            {
                var question = questionRepository.GetById(item.ToString());
                content.Questions.Add(question);
            }
            contentRepository.Update(content);
            

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult GetForms()
        {
            IEnumerable<Form>forms = formRepository.GetAll();
            return Json(forms);
        }
    }
}
