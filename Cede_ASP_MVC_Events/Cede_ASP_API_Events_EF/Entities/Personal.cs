using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_ASP_API_Events_EF.Entities
{
    public class Personal
    {
        [Key]
        public Guid PersonalId { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; }

        [Required]
        [MaxLength(120)]
        public string LastName { get; set; }

        [MaxLength(120)]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsDeleted { get; set; } = false;

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(20)]
        public string Phone2 { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
