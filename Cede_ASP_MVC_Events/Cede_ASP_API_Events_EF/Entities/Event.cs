using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_ASP_API_Events_EF.Entities
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public Guid PersonalId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Personal Personal { get; set; }
    }
}
