using System.ComponentModel.DataAnnotations;

namespace StudentGradeTracker.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 100)]
        public int Grade { get; set; }
    }
}
