using Cede_ASP_MVC_Events_Main.Models;
using Cede_ASP_MVC_Events_Main.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Cede_ASP_MVC_Events_Main.Services.WebServices
{
    public class WebPersonalService: IPersonalService
    {
        public async Task<List<Personal>> GetPersonals()
        {
            List<wsPersonalService.PersonalDto> personalList = 
                (await new wsPersonalService.PersonalServiceSoapClient().GetPersonalAsync()).Body.GetPersonalResult.ToList();

            List<Personal> listToReturn = new List<Personal>();

            foreach (var item in personalList)
            {
                Personal objPerson = new Personal();
                objPerson.Name = item.Name;
                objPerson.LastName = item.LastName;
                objPerson.PersonalId = item.PersonalId;
                objPerson.IsDeleted = item.IsDeleted.Value;
                objPerson.Phone = item.Phone;

                listToReturn.Add(objPerson);
            }

            return listToReturn;
        }
    }
}