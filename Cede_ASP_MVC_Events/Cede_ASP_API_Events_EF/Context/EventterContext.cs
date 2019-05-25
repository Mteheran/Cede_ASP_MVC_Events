using Cede_ASP_API_Events_EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_ASP_API_Events_EF.Context
{
    public class EventterContext : DbContext
    {
        public EventterContext() : base("cnx")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Personal> Personal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
