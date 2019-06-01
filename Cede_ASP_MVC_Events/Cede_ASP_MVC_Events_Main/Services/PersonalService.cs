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
    public class PersonalService : IPersonalService
    {
        const string ApiBase = "http://localhost:60469/api/";

        public HttpClient httpClient { get; set; } = new HttpClient();

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
    }
}