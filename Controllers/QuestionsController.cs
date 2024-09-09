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


        public IActionResult Index()
        {
            List<Question> questions = new List<Question>(QuestionData.GetAll());
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
                };
                QuestionData.Add(newQuestion);

                return Redirect("/Questions");
            }
            return View(addQuestionViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.questions = QuestionData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] questionIds)
        {
            foreach (int questionId in questionIds)
            {
                QuestionData.Remove(questionId);
            }
            return Redirect("/Questions");
        }
    }
}
