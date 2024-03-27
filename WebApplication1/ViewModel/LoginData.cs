using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class LoginData
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
