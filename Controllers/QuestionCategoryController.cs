using Microsoft.AspNetCore.Mvc;
using TheMutantsAtTable9.Data;
using TheMutantsAtTable9.Models;
using TheMutantsAtTable9.ViewModels;


namespace TheMutantsAtTable9.Controllers
{
    public class QuestionCategoryController : Controller
    {
        private QuestionDbContext context;

        public QuestionCategoryController(QuestionDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<QuestionCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        [Route("QuestionCategory/Create")]
        public IActionResult Create()
        {
            AddQuestionCategoryViewModel addQuestionCategoryViewModel = new AddQuestionCategoryViewModel();

            return View(addQuestionCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateQuestionCategoryForm(AddQuestionCategoryViewModel addQuestionCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                QuestionCategory theCategory = new QuestionCategory
                {
                    Name = addQuestionCategoryViewModel.Name,
                };

                context.Categories.Add(theCategory);
                context.SaveChanges();

                return Redirect("/QuestionCategory");
            }
            return View("Create", addQuestionCategoryViewModel);
    }
    }
}

