using System.ComponentModel.DataAnnotations;

namespace NewApiProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
 
        [Required]
        public int Marks { get; set; }
    }
}
