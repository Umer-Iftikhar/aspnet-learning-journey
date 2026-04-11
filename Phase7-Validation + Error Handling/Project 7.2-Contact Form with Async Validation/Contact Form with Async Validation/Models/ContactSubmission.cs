using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Contact_Form_with_Async_Validation.Models
{
    public class ContactSubmission
    {
        [
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Remote(action: "ValidateEmail", controller: "Contact", ErrorMessage = "This email is already in use.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Subject { get; set; } = string.Empty;

        [StringLength(1000, MinimumLength = 10)]
        public string? Message { get; set; }

        public DateTime SubmittedAt { get; set; } 
}
