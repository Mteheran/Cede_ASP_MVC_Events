using Cede_ASP_MVC_Events_Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_ASP_MVC_Events_Base.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public Guid PersonalId { get; set; }        
        private string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsDelete { get; set; }
        public EventStatus Status { get; set; }
    }
}