using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cede_ASP_MVC_Events_Main.Helpers
{
    public static class IsPrivateHelper
    {
        public static string GetStatus(bool IsPrivate)
        {
            switch (IsPrivate)
            {
                case true:
                    return "Privado";
                case false:
                    return "Público";
                default:
                    break;
            }

            return "";
        }
    }
}