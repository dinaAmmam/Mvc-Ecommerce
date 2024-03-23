using System.ComponentModel.DataAnnotations;
namespace Repoteq_task.ViewModel
{
    public class RegisterAccountViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password" , ErrorMessage ="Password and confirm not matched")]
        public string ConfirmPassword { get; set; }
        
    }
}
