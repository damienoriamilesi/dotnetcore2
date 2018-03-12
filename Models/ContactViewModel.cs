using System.ComponentModel.DataAnnotations;

namespace coreapp.Models
{
    public class ContactViewModel
    {
        public string Param { get; set; }  
        [Required]
        [MaxLength(250, ErrorMessage = "Too Long.")]
        public string Name { get; set; } 
    }
}