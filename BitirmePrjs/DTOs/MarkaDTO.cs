using System.ComponentModel.DataAnnotations;

namespace BitirmePrjs.DTOs
{
    public class MarkaDTO
    {
        [Required]
        public string markaAd { get; set; }

        [Required]

        public IFormFile? image { get; set; }

        public string imgUrl { get; set; }
    }
}
