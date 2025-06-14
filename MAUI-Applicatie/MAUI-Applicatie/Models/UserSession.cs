using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Applicatie.Models;
public static class UserSession
{
    public static string LoggedInUser { get; set; }
    public static Account LoggedInAccount { get; set; }
}

