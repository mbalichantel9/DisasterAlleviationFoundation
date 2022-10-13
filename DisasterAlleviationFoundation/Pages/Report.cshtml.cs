using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundation.Pages
{
    public class ReportModel : PageModel
    {

        public void OnGet()
        {

        }

        public void viewMonetary()
        {
            Response.Redirect("ViewMonetary");
        }
        public void viewDonations()
        {
            Response.Redirect("Register");
        }
    }

  

}
