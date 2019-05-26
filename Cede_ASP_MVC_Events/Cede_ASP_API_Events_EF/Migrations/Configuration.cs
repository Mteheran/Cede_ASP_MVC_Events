namespace Cede_ASP_API_Events_EF.Migrations
{
    using Cede_ASP_API_Events_EF.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cede_ASP_API_Events_EF.Context.EventterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cede_ASP_API_Events_EF.Context.EventterContext";
        }

        protected override void Seed(Cede_ASP_API_Events_EF.Context.EventterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Personal.AddOrUpdate(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Miguel", LastName = "Teheran" });
            context.Personal.AddOrUpdate(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Sebastian", LastName = "Garcia" });
            context.Personal.AddOrUpdate(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Iris", LastName = "Correa" });
            context.Personal.AddOrUpdate(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "Julian", LastName = "Tobon" });
            context.Personal.AddOrUpdate(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000005"), Name = "Camille", LastName = "Jimenez" });
            context.Personal.AddOrUpdate(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000006"), Name = "Arturo", LastName = "Gomez" });

            context.Events.AddOrUpdate(new Event() { EventId = Guid.Parse("00000000-0000-0000-0000-000000000101"),  PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Event 1", EventDate = new DateTime(2019,05,01)});
            context.Events.AddOrUpdate(new Event() { EventId = Guid.Parse("00000000-0000-0000-0000-000000000102"), PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Event 2", EventDate = new DateTime(2019, 04, 10) });            context.Events.AddOrUpdate(new Event() { EventId = Guid.Parse("00000000-0000-0000-0000-000000000103"), PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000003"), Name = "Concierto", EventDate = new DateTime(2019, 12, 01) });            context.Events.AddOrUpdate(new Event() { EventId = Guid.Parse("00000000-0000-0000-0000-000000000104"), PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000004"), Name = "partido", EventDate = new DateTime(2019, 10, 08) });

        }
    }
}
