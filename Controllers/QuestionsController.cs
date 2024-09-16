using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMutantsAtTable9.Models;
using TheMutantsAtTable9.Data;
using TheMutantsAtTable9.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
            List<Question> questions = context.Questions.Include(e => e.Category).ToList();
            return View(questions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<QuestionCategory> categories = context.Categories.ToList();
            AddQuestionViewModel addQuestionViewModel = new AddQuestionViewModel(categories);
            return View(addQuestionViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddQuestionViewModel addQuestionViewModel)
        {
            if (ModelState.IsValid)
            {
                QuestionCategory theCategory = context.Categories.Find(addQuestionViewModel.CategoryId);
                Question newQuestion = new Question
                {
                    Name = addQuestionViewModel.Name,
                    Answer = addQuestionViewModel.Answer,
                    Category = theCategory,
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
