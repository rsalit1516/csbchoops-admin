using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Scores_Components;
using System.Text.RegularExpressions;


public partial class TeamsSwap : System.Web.UI.Page
{
    int TournamentID = 0;
    int DivisionID;
    int UserID = 0;
    string UserName = string.Empty;
    int UserType = 0;
    clsScores oTeam = new clsScores();
    private void Page_Load(object sender, EventArgs e)
    {
        Housekeeping();
        if (!IsPostBack)
        {
            GetTournamentInfo();
            GetDivisions();
            AddSubItem();
        }

        bool isNum = int.TryParse(lblDivisionID.Text, out DivisionID);
        if (isNum) { FillTeamInGrid(DivisionID); }
        else { FillTeamInGrid(-1); }

    }

    private void GetTournamentInfo()
    {
        DataTable rsData = new DataTable();
        clsScores oTournament = new clsScores();
        try
        {
            rsData = oTournament.GetTournament(TournamentID.ToString());
            lblTournament.Text = rsData.Rows[0]["Name"].ToString();
            lblFrom.Text = rsData.Rows[0]["StartDate"].ToString();
            lblTo.Text = rsData.Rows[0]["EndDate"].ToString();
            Menu1.Items[0].SubMenu.Items[2].NavigateUrl = "http://" + rsData.Rows[0]["Website"].ToString();
            Menu1.Items[0].SubMenu.Items[2].ToolTip = rsData.Rows[0]["Website"].ToString();
        }
        catch (Exception ex)
        {
            MsgBox("ERROR Loading Tournament:" + ex.Message);
        }
        finally
        {
            oTournament = null;
        }
    }

    private void GetDivisions()
    {
        DataTable rsData = new DataTable();
        clsScores oDivision = new clsScores();
        try
        {
            rsData = oDivision.GetDivisions(TournamentID.ToString());
            Grid1.DataSource = rsData;
            Grid1.DataBind();
        }
        catch (Exception ex)
        {
            MsgBox("ERROR Loading Divisions:" + ex.Message);
        }
        finally
        {
            oDivision = null;
        }
    }

    private void FillTeamInGrid(int divisionID)
    {
        DataTable rsData = new DataTable();
        clsScores oTeams = new clsScores();
        try
        {
            rsData = oTeams.GetTeams(lblTID.Text, divisionID, 0);
            if (rsData.Rows.Count != 0)
            {
                grvTeams.DataSource = rsData;
                grvTeams.DataBind();
            }
            else
            {   //Other wise add a emtpy "New Row" to the datatable and then hide it after binding.       
                rsData.Rows.Add(rsData.NewRow());
                grvTeams.DataSource = rsData;
                grvTeams.DataBind();
                grvTeams.Rows[0].Visible = false;
            }

        }
        catch (Exception ex)
        {
            MsgBox("ERROR Loading Grid:" + ex.Message);
        }
        finally
        {
            oTeams = null;
        }
    }

    protected void Grid1_ItemCommand(object sender, EO.Web.GridCommandEventArgs e)
    {
        //Check whether it is from our client side
        //JavaScript call
        if (e.CommandName == "select")
        {
            lblDivisionID.Text = e.Item.Cells[0].Value.ToString();
            lblGender.Text = e.Item.Cells[2].Value.ToString();
            lblGradeID.Text = e.Item.Cells[4].Value.ToString();
            FillTeamInGrid(Convert.ToInt32(e.Item.Cells[0].Value));
            //LoadTeams(e.Item.Cells[2].Value.ToString(), Convert.ToInt32(e.Item.Cells[4].Value));
        }
    }

     protected void grvTeams_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvTeams.EditIndex = -1;
        FillTeamInGrid(Convert.ToInt32(lblDivisionID.Text));
    }

     protected void grvTeams_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvTeams.EditIndex = e.NewEditIndex;
        FillTeamInGrid(Convert.ToInt32(lblDivisionID.Text));
    }

    protected void grvTeams_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        DropDownList ddlDivTeams = (DropDownList)grvTeams.Rows[e.RowIndex].FindControl("ddlDivTeams");
        //oTeam.TeamID = Convert.ToInt32(ddlDivTeams.Text);
        oTeam.UserName = lblUser.Text;
            //oTeam.UpdateTeam(Convert.ToInt32(lblTID.Text), Convert.ToInt32(grvTeams.DataKeys[e.RowIndex].Values[0].ToString()));
        oTeam.SwapTeams(Convert.ToInt32(lblTID.Text), Convert.ToInt32(grvTeams.DataKeys[e.RowIndex].Values[0].ToString()), Convert.ToInt32(ddlDivTeams.Text));
        grvTeams.EditIndex = -1;
        FillTeamInGrid(Convert.ToInt32(lblDivisionID.Text));
       
    }

    protected void MenuItemClickHandler(object sender, EO.Web.NavigationItemEventArgs e)
    {
        if (e.MenuItem.Value == "TeamsList")
        {
            HttpContext.Current.Session["TournamentID"] = TournamentID.ToString();
            HttpContext.Current.Session["TournamentName"] = lblTournament.Text;
            ResponseHelper.Redirect("Reports.aspx?Report=TeamsList", "_blank", "");
        }
        if (e.MenuItem.Value == "Summary")
        {
            HttpContext.Current.Session["TournamentID"] = TournamentID.ToString();
            HttpContext.Current.Session["TournamentName"] = lblTournament.Text;
            ResponseHelper.Redirect("Reports.aspx?Report=Summary", "_blank", "");
        }
        if (e.MenuItem.Value == "SiteGames")
        {
            HttpContext.Current.Session["TournamentID"] = TournamentID.ToString();
            HttpContext.Current.Session["TournamentName"] = lblTournament.Text;
            ResponseHelper.Redirect("Reports.aspx?Report=Site&ID=0", "_blank", "");
        }

        string Str = e.MenuItem.Value;
        double Num;
        bool isNum = double.TryParse(Str, out Num);
        if (isNum)
        {
            HttpContext.Current.Session["TournamentID"] = TournamentID.ToString();
            HttpContext.Current.Session["TournamentName"] = lblTournament.Text;
            ResponseHelper.Redirect("Reports.aspx?Report=Site&ID=" + e.MenuItem.Value, "_blank", "");
        }

    }

    protected void AddSubItem()
    {
        string Label;
        string URL;
        DateTime StartDate;
        DateTime EndDate;
        int idx = 0;
        DataTable rsData = new DataTable();
        clsScores oSites = new clsScores();
        try
        {
            Menu1.Items[12].SubMenu.Items[0].NavigateUrl = Menu1.Items[12].SubMenu.Items[0].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[1].NavigateUrl = Menu1.Items[12].SubMenu.Items[1].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[2].NavigateUrl = Menu1.Items[12].SubMenu.Items[2].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[4].NavigateUrl = Menu1.Items[12].SubMenu.Items[4].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[5].NavigateUrl = Menu1.Items[12].SubMenu.Items[5].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[6].NavigateUrl = Menu1.Items[12].SubMenu.Items[6].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[7].NavigateUrl = Menu1.Items[12].SubMenu.Items[7].NavigateUrl + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[3].SubMenu.Items.Clear();

            rsData = oSites.GetSiteSlots(TournamentID.ToString());
            URL = "Reports.aspx?Report=Site&ID=0";
            URL = URL + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
            Menu1.Items[12].SubMenu.Items[3].SubMenu.Items.Add("All Sites");
            StartDate = Convert.ToDateTime(lblFrom.Text);
            EndDate = Convert.ToDateTime(lblTo.Text);
            Menu1.Items[12].SubMenu.Items[3].SubMenu.Items[0].SubMenu.Items.Add("All Days").NavigateUrl = URL + "&Date=0";
            idx = 1;
            while (StartDate <= EndDate)
            {
                URL = "Reports.aspx?Report=Site&ID=0";
                //URL = "Reports.aspx?Report=Site&ID=" + rsData.Rows[0]["LocationID"].ToString();
                URL = URL + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
                Menu1.Items[12].SubMenu.Items[3].SubMenu.Items[0].SubMenu.Items.Add(StartDate.ToString("dddd MMM dd")).NavigateUrl = URL + "&Date=" + StartDate.ToString();
                Menu1.Items[12].SubMenu.Items[3].SubMenu.Items[0].SubMenu.Items[idx].TargetWindow = "_blank";
                StartDate = StartDate.AddDays(1);
                idx = idx + 1;
            }

            for (int i = 0; i <= rsData.Rows.Count - 1; i++)
            {
                Label = rsData.Rows[i]["LocationName"].ToString();
                URL = "Reports.aspx?Report=Site&ID=" + rsData.Rows[i]["LocationID"].ToString();
                URL = URL + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;

                Menu1.Items[12].SubMenu.Items[3].SubMenu.Items.Add(Label);

                StartDate = Convert.ToDateTime(lblFrom.Text);
                idx = 0;
                Menu1.Items[12].SubMenu.Items[3].SubMenu.Items[i + 1].SubMenu.Items.Add("All Days").NavigateUrl = URL + "&Date=0";
                while (StartDate <= EndDate)
                {
                    URL = "Reports.aspx?Report=Site&ID=" + rsData.Rows[i]["LocationID"].ToString();
                    URL = URL + "&TID=" + TournamentID.ToString() + "&TournamentName=" + lblTournament.Text;
                    Menu1.Items[12].SubMenu.Items[3].SubMenu.Items[i + 1].SubMenu.Items.Add(StartDate.ToString("dddd MMM dd")).NavigateUrl = URL + "&Date=" + StartDate.ToString();
                    Menu1.Items[12].SubMenu.Items[3].SubMenu.Items[i + 1].SubMenu.Items[idx].TargetWindow = "_blank";
                    StartDate = StartDate.AddDays(1);
                    idx = idx + 1;
                }
            }

        }
        catch (Exception ex)
        {
            MsgBox("ERROR Loading Sites:" + ex.Message);
        }
        finally
        {
            oSites = null;
        }
    }

    public static class ResponseHelper
    {
        public static void Redirect(string url, string target, string windowFeatures)
        {
            HttpContext context = HttpContext.Current;

            if ((String.IsNullOrEmpty(target) ||
                target.Equals("_self", StringComparison.OrdinalIgnoreCase)) &&
                String.IsNullOrEmpty(windowFeatures))
            {

                context.Response.Redirect(url);
            }
            else
            {
                Page page = (Page)context.Handler;
                if (page == null)
                {
                    throw new InvalidOperationException(
                        "Cannot redirect to new window outside Page context.");
                }
                url = page.ResolveClientUrl(url);

                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }

                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page,
                    typeof(Page),
                    "Redirect",
                    script,
                    true);
            }
        }
    }

    private void MsgBox(string Message)
    {
        MsgBox1.Show("ScoRboT", Message, null, new EO.Web.MsgBoxButton("~/images/button_ok.gif"));
    }

    private void Housekeeping()
    {
        //Grab the cookie
        HttpCookie Scorbot = Request.Cookies["ScorbotInfo"];
        //Check to make sure the cookie exists
        if (Scorbot == null)
        {
            Server.Transfer("~/Login.aspx");
        }
        else
        {
            Scorbot.Expires = DateTime.Now.AddDays(1);
            Response.AppendCookie(Scorbot);
        }
        //Write the cookie value
        TournamentID = Convert.ToInt32(Scorbot["TournamentID"].ToString());
        lblTID.Text = TournamentID.ToString();
        UserID = Convert.ToInt32(Scorbot["UserID"].ToString());
        UserName = Scorbot["UserName"].ToString();
        lblUser.Text = UserName;
        UserType = Convert.ToInt32(Scorbot["UserType"].ToString());
    }

}
