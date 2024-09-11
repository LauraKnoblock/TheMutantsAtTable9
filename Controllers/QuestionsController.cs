using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMutantsAtTable9.Models;
using TheMutantsAtTable9.Data;
using TheMutantsAtTable9.ViewModels;

namespace TheMutantsAtTable9.Controllers
{
    public class QuestionsController : Controller

    {
        private QuestionDbContext context;

        public QuestionsController (QuestionDbContext dbContext)
        {
            context= dbContext;
        }

        public IActionResult Index()
        {
            List<Question> questions = context.Questions.ToList();
            return View(questions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddQuestionViewModel addQuestionViewModel = new AddQuestionViewModel();
            return View(addQuestionViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddQuestionViewModel addQuestionViewModel)
        {
            if (ModelState.IsValid)
            {
                Question newQuestion = new Question

                {
                    Name = addQuestionViewModel.Name,
                    Answer = addQuestionViewModel.Answer,
                    Category = addQuestionViewModel.Category,
                };
                context.Questions.Add(newQuestion);
                context.SaveChanges();
                return Redirect("/Questions");
            }
            return View(addQuestionViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.questions = context.Questions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] questionIds)
        {
            foreach (int questionId in questionIds)
            {
                Question? theQuestion = context.Questions.Find(questionId);
                context.Questions.Remove(theQuestion);
            }

            context.SaveChanges();
            return Redirect("/Questions");
        }
    }
}
