using Cede_ASP_MVC_Events_Main.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cede_ASP_MVC_Events_Main.Services.Interfaces
{
    public interface IPersonalService
    {
        Task<List<Personal>> GetPersonals();
    }
}
