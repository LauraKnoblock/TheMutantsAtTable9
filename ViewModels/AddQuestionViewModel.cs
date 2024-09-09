using System.ComponentModel.DataAnnotations;

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


    }
}
