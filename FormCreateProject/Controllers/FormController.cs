using FormCreateProject.AppDbContext;
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
        private readonly FormDbContext db;
       

        public FormController(IQuestionRepository questionRepository,IFormRepository formRepository)
        {
            this.questionRepository = questionRepository;
            this.formRepository = formRepository;
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
            Form form=new Form();

            form.Name = questionVM.Name;
            form.Description = questionVM.Description;
            form.CretedBy = 1;
            formRepository.Add(form);
            HashSet<Question> questions = new HashSet<Question>();
            foreach (var item in questionVM.Ids)
            {
                var question = questionRepository.GetById(item.ToString());
                questions.Add(question);
            }
            form.Questions = questions;

            var returner = formRepository.Update(form);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult GetForms()
        {
            IEnumerable<Form>forms = formRepository.GetAll();
            return Json(forms);
        }
        //[HttpGet]
        public IActionResult GetToForm(Guid id)
        {
           var form = formRepository.GetByIdIncludeQuestions(id);

            ViewFormVM viewFormVM = new ViewFormVM();
            viewFormVM.Name = form.Name;
            viewFormVM.Description = form.Description;
            viewFormVM.CreateAt = form.CreateAt;
            viewFormVM.FormQuestions = form.Questions;

            return View(viewFormVM) ;

        }
    }
}
