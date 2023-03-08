using System.ComponentModel.DataAnnotations;

namespace PersonAPI.Dtos
{
    public class PersonCreateDto
    {

        // [Required]
        // public string? FullName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Telephone { get; set; }
        public string? DoB { get; set; }
    }
}