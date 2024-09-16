using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TheMutantsAtTable9.Models;

namespace TheMutantsAtTable9.ViewModels
{
    public class AddQuestionViewModel
    {
        [Required(ErrorMessage = "Question is Required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Question should be between 3-50 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Answer is Required.")]
        [StringLength(500, ErrorMessage = "Answer should be less than 500 characters.")]
        public string? Answer { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public List<SelectListItem>? Categories { get; set; }


        public AddQuestionViewModel(List<QuestionCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }
        }

        public AddQuestionViewModel()
        {
        }

    }
}


