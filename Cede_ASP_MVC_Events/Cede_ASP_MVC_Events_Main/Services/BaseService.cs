using System.Configuration;
using System.Net.Http;

namespace Cede_ASP_MVC_Events_Main.Services
{
    public class BaseService
    {
        protected string ApiBase = ConfigurationManager.AppSettings["ApiUrl"].ToString();

        protected HttpClient httpClient { get; set; } = new HttpClient();
    }
}