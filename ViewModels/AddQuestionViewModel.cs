using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TheMutantsAtTable9.Models;

namespace TheMutantsAtTable9.ViewModels
{
    public class AddQuestionViewModel
    {
        [Required(ErrorMessage ="Question is Required.")]
        [StringLength(50, MinimumLength=3, ErrorMessage ="Question should be between 3-50 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Answer is Required.")]
        [StringLength(500,ErrorMessage ="Answer should be less than 500 characters.")]
        public string? Answer { get; set; }

        public Category Category { get; set; } 

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>
        {
      new SelectListItem(Category.History.ToString(), ((int)Category.History).ToString()),
      new SelectListItem(Category.Geography.ToString(), ((int)Category.Geography).ToString()),
      new SelectListItem(Category.Entertainment.ToString(), ((int)Category.Entertainment).ToString()),
      new SelectListItem(Category.Science.ToString(), ((int)Category.Science).ToString()),
      new SelectListItem(Category.Sports.ToString(), ((int)Category.Sports).ToString()),
      new SelectListItem(Category.General.ToString(), ((int)Category.General).ToString())


   };        }


    }

