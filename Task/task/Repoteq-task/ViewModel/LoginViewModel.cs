using System.ComponentModel.DataAnnotations;
namespace Repoteq_task.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
        public bool isPersisite { get; set; }
    }
}
