using System.ComponentModel.DataAnnotations;

namespace MovieRental.Dtos.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        [StringLength(200, ErrorMessage = "Full Name cannot be longer than 200 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Card Number is required.")]
        [StringLength(50, ErrorMessage = "Card Number cannot be longer than 50 characters.")]
        public string CardNumber { get; set; }
    }
}
