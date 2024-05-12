using System.ComponentModel.DataAnnotations;

namespace BitirmePrjs.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string sifre { get; set; }
    }
}
