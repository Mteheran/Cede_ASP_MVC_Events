//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cede_ASP_MVC_Events_EntityFramework.EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public System.Guid EventId { get; set; }
        public System.Guid PersonalId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime EventDate { get; set; }
        public bool IsPrivate { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int Status { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Personal Personal { get; set; }
    }
}
