using EventterWebService.Data;
using EventterWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace EventterWebService
{
    /// <summary>
    /// Summary description for PersonalService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PersonalService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<PersonalDto> GetPersonal()
        {
            cnxEventter eventterModel = new cnxEventter();

            List<PersonalDto> listPersonal = new List<PersonalDto>();

            foreach (var item in eventterModel.Personal.ToList())
            {
                PersonalDto personaltemp = new PersonalDto();

                personaltemp.Name = item.Name;
                personaltemp.LastName = item.LastName;
                personaltemp.Phone = item.Phone;
                personaltemp.PersonalId = item.PersonalId;
                personaltemp.IsDeleted = item.IsDeleted;
                personaltemp.Email = item.Email;

                listPersonal.Add(personaltemp);
            }


            //JavaScriptSerializer js = new JavaScriptSerializer();
            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //Context.Response.Write(js.Serialize(listPersonal));

            return listPersonal;
        }
    }
}
