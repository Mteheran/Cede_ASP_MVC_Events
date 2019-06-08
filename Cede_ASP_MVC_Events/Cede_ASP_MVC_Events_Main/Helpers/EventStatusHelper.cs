using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_ASP_MVC_Events_Main.Helpers
{
    public static class EventStatusHelper
    {
        public static string GetStatus(int CurrentStatus)
        {
            switch (CurrentStatus)
            {
                case 1:
                    return "Activo";
                case 0:
                    return "Inactivo";
                case 2:
                    return "Cancelado";
                default:
                    break;
            }

            return "";
        }

        public static string GetStyleStatus(int CurrentStatus)
        {
            switch (CurrentStatus)
            {
                case 1:
                    return "alert-success";
                case 0:
                    return "alert-secondary";
                case 2:
                    return "alert-warning";
                default:
                    break;
            }

            return "";
        }
    }
}