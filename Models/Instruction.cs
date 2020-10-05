using System.ComponentModel.DataAnnotations;

namespace MVC_Core_REST.Models
{
    public class Instruction
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]

        public string Line { get; set; }
        [Required]

        public string Platform { get; set; }

    }
}