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
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool? IsDeleted { get; set; }
        public string Phone { get; set; }
         
        public virtual ICollection<Event> Events { get; set; }
    }
}
