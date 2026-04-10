using System.ComponentModel.DataAnnotations;

namespace Contact_Form_with_Async_Validation.Models
{
    public class ContactSubmission
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
