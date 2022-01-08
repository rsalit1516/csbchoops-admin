using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSBC.Core.Data;
using CSBC.Core.Models;
using Microsoft.Ajax.Utilities;

namespace CSBC.Admin.Web
{
    public partial class Header : System.Web.UI.UserControl
    {
        public int ActiveSeasonId {
            get { return Convert.ToInt32(Session["SeasonID"]); }
            set
            {
                var seasonrep = new SeasonRepository(new CSBCDbContext());
                lblActiveSeason.Text = seasonrep.GetSeason((int)Session["CompanyID"], value).Description;                   
            } 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
               var rep = new UserRepository(new CSBCDbContext());
               var user = rep.GetById((int)Session["UserID"]);
               lblUser.Text = "Welcome " + user.Name;
               var title = "No Page Selected";
               if (Session["Title"] != null)
               {
                   title = Session["Title"].ToString();
               }
               lblTitle.Text = title;
               LoadSeasons();
               ddlSeasons.SelectedValue = ActiveSeasonId.ToString();
           }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Create an event handler for the master page's PricesDoubled event
            Master.SeasonChanged += new EventHandler(Master_SeasonChanged);
        }

        private void Master_SeasonChanged(object sender, EventArgs e)
        {
            ActiveSeasonId = Convert.ToInt32(Session["SeasonID"]);
        }
        protected void LoadSeasons()
        {
            using (var context = new CSBCDbContext())
            {
                var rep = new SeasonRepository(context);
                var seasons = rep.GetSeasons(1);
                ddlSeasons.DataSource = seasons;
                ddlSeasons.DataBind();
                ddlSeasons.DataValueField = "SeasonID";
                ddlSeasons.DataTextField = "Sea_Desc";
            }
        }
    }
}