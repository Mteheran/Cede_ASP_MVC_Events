using Cede_ASP_MVC_Events_Main.Models;
using Cede_ASP_MVC_Events_Main.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Cede_ASP_MVC_Events_Main.Services
{
    public class PersonalService : BaseService, IPersonalService
    {
        public async Task<List<Personal>> GetPersonals()
        {
            var result = await httpClient.GetAsync($"{ApiBase}/personal");

            if (result.IsSuccessStatusCode)
            {
                var parseResult = JsonConvert.DeserializeObject<List<Personal>>(await result.Content.ReadAsStringAsync());

                return parseResult;
            }

            return new List<Personal>();
        }

        public async Task<Personal> GetPersonalbyId(string Id)
        {
            var result = await httpClient.GetAsync($"{ApiBase}/personal/{Id}");

            if (result.IsSuccessStatusCode)
            {
                var parseResult = JsonConvert.DeserializeObject<Personal>(await result.Content.ReadAsStringAsync());

                return parseResult;
            }

            return new Personal();
        }

        public async Task<bool> SavePersonal(Personal personal)
        {
            string bodyRequest = JsonConvert.SerializeObject(personal);

            var content = new StringContent(bodyRequest, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage result = await httpClient.PutAsync($"{ApiBase}/personal/{personal.PersonalId}", content);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}