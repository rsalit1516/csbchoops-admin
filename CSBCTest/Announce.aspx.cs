using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSBC.Admin.Web
{
    public partial class Announce : BaseForm
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Title"] = "Announcements";
            //Session["AccessType"] = AccessType();

        }
    }
}