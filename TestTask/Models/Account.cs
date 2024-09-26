using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        [ForeignKey(nameof(IncidentName))]
        public string IncidentName { get; set; }
        public Incident Incident { get; set; }
    }
}
