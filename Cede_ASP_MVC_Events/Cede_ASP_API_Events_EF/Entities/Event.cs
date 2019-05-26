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
        [MaxLength(120)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int Status { get; set; } = 1;
        public bool IsDeleted { get; set; } = false;
        public virtual Personal Personal { get; set; }
    }
}
