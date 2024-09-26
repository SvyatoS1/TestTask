using System.ComponentModel.DataAnnotations;

namespace TestTask.Models
{
    public class Incident
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Account> Accounts { get; set; }

    }
}
