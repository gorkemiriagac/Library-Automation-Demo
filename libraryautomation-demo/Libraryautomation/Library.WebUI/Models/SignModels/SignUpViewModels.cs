using System.ComponentModel.DataAnnotations;

namespace Library.WebUI.Models.SignModels
{
    public record SignUpViewModels(string FullName, [Required] string Email, [Required] string Password, [Required] string ConfirmPassword);
    
}
