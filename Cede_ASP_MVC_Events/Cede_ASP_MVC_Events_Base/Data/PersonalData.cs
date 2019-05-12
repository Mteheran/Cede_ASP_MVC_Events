using Cede_ASP_MVC_Events_Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_ASP_MVC_Events_Base.Data
{
    public static class PersonalData
    {
        private static List<Personal> Personals { get; set; } = new List<Personal>();

        public static List<Personal> GetPersonals()
        {
            if (Personals.Count == 0)
            {
                Personals.Add(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "Anderson", LastName = "Zapata", IsDeleted = false });
                Personals.Add(new Personal() { PersonalId = Guid.Parse("00000000-0000-0000-0000-000000000002"), Name = "Laura", LastName = "Arbelaez", IsDeleted = false });                
            }

            return Personals;
        }

        public static bool SavePersonal(Personal personal)
        {
            personal.PersonalId = Guid.NewGuid();
            Personals.Add(personal);

            return true;
        }

        public static bool UpdatePersonal(Personal personal)
        {
            Personals[Personals.IndexOf(Personals.FirstOrDefault(x => x.PersonalId == personal.PersonalId))] = personal;

            return true;
        }
    }
}