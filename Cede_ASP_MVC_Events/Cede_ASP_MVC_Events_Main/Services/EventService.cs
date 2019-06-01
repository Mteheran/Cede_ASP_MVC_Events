using Cede_ASP_MVC_Events_Main.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Cede_ASP_MVC_Events_Main.Services
{
    public class EventService
    {
        const string ApiBase = "http://localhost:60469/api/";

        public HttpClient httpClient { get; set; } = new HttpClient();

        public async Task<List<Event>> GetPersonals()
        {
            var result = await httpClient.GetAsync($"{ApiBase}/event");

            if (result.IsSuccessStatusCode)
            {
                var parseResult = JsonConvert.DeserializeObject<List<Event>>(await result.Content.ReadAsStringAsync());

                return parseResult;
            }

            return new List<Event>();
        }
    }
}