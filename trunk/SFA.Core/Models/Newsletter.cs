using System.ComponentModel.DataAnnotations;

namespace SFA.Core.Models
{
    public class Newsletter
    {
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
