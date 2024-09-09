using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMutantsAtTable9.Models;
using TheMutantsAtTable9.Data;

namespace TheMutantsAtTable9.Controllers
{
    public class QuestionsController : Controller

    {


        public IActionResult Index()
        {
            ViewBag.questions = QuestionData.GetAll();
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("/Questions/Add")]
        public IActionResult NewQuestion(Question newQuestion)
        {
            QuestionData.Add(newQuestion);

            return Redirect("/Questions");
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
