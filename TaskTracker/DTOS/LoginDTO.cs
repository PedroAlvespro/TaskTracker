using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DTOS
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(40, MinimumLength = 11, ErrorMessage = "A senha deve ter entre 11 e 40 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A senha deve ter entre 8 e 100 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "A senha deve conter: mínimo 8 caracteres, 1 letra maiúscula, 1 minúscula, 1 número e 1 caractere especial")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
