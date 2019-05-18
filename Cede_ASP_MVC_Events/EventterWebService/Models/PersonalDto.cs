using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventterWebService.Models
{
    public class PersonalDto
    {
        public System.Guid PersonalId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Phone { get; set; }
    }
}