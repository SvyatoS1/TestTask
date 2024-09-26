using System.ComponentModel.DataAnnotations;

namespace TestTask.Requests
{
    public class IncidentRequest
    {
        [Required]
        public string AccountName { get; set; }

        [Required]
        public string ContactFirstName { get; set; }

        [Required]
        public string ContactLastName { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        public string IncidentName { get; set; }

        [Required]
        public string IncidentDescription { get; set; }
    }
}
