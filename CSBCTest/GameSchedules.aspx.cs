using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.Mail;
using CSBC.Components;

namespace CSBC.Admin.Web
{
    public partial class GameSchedules : BaseForm
    {
        private int EmailsSent;
        private string ErrorMsg;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Title"] = "Games";
            base.Page_Load(sender, e);
		if (Page.IsPostBack == false) {
			
			Session["AccessType"] = AccessType();
			Calendar1.SelectedDate = Now;
			//Format(Now(), "d/m/y")

			this.Calendar1.TodaysDate = Now();
			this.Calendar1.TodayDayStyle.BackColor = Drawing.Color.LightGray;

			
			//Me.txtTitle.Focus()

			LoadCombos();
		}
        }

        protected override void SetUser()
        {
            base.SetUser();
              if (Session["AccessType"] == "R") {
				btnSave.Enabled = false;
				btnNew.Enabled = false;
				btnSend.Enabled = false;
			}
        }
	
	private void UpdRow(Int16 ScheduleNo, Int16 GameNumber)
	{

		Season.clsGames oGames = new Season.clsGames();
		try {
			oGames.GameDate = mskDate.Text;
			oGames.GameTime = txtTime.Text;
			oGames.LocationNumber = cmbVenues.SelectedItem.Value;
			oGames.Home = txtHome.Text;
			oGames.Visitor = txtVisitor.Text;
			oGames.Descr = txtDescr.Text;
			if (lblPlayoff.Visible == true) {
				oGames.GameType = "P";
			} else {
				oGames.GameType = "R";
			}
			oGames.UpdateGame(ScheduleNo, GameNumber);
		} catch (Exception ex) {
			lblError.Text = "UpdRow:" + ex.Message;
		} finally {
			oGames = null;
		}
	}

	private void ClearFields()
	{
		cmbDivisions.SelectedIndex = 0;
		lblPlayoff.Visible = false;
		mskDate.Text = "";
		txtTime.Text = "";
		txtHome.Text = "";
		txtVisitor.Text = "";
		cmbVenues.SelectedIndex = 0;
		lblError.Text = "";
		txtDescr.Text = "";
	}

	private void ADDRow()
	{
		Season.clsGames oGames = new Season.clsGames();
		try {
			var _with1 = oGames;
			_with1.GameDate = mskDate.Text;
			_with1.GameTime = txtTime.Text;
			_with1.Home = txtHome.Text;
			_with1.Visitor = txtVisitor.Text;
			_with1.LocationNumber = cmbVenues.SelectedItem.Value;
			_with1.Descr = txtDescr.Text;
			_with1.AddRecord(Session["CompanyID"], cmbDivisions.SelectedItem.Value);
		} catch (Exception ex) {
			Session["ErrorMSG"] = "ADDRow::" + ex.Message;
		} finally {
			oGames = null;
		}
	}

	private void btnSave_Click(System.Object sender, System.EventArgs e)
	{
		if (Information.IsNumeric(Session["ScheduleNo"])) {
			//If lblPlayoff.Visible = True Then
			if (errorRTN() == true) {
				MsgBox("ERROR: " + lblError.Text);
				return;
			} else {
				UpdRow(Session["ScheduleNo"], Session["GameNumber"]);
				MsgBox("Changes successfully completed");
				LoadGames();
				cmbDivisions.Enabled = false;
			}
		} else {
			if (errorRTN() == true) {
				MsgBox("ERROR: " + lblError.Text);
				return;
			} else {
				ADDRow();
				MsgBox("New Record Added Successfully");
				LoadGames();
				cmbDivisions.Enabled = false;
			}
		}
	}

	private bool errorRTN()
	{
		bool functionReturnValue = false;
		functionReturnValue = false;
		if (cmbDivisions.SelectedIndex == 0) {
			lblError.Text = "Division missing";
			functionReturnValue = true;
			cmbDivisions.Focus();
		}
		if (string.IsNullOrEmpty(mskDate.Text)) {
			lblError.Text = "Date missing";
			functionReturnValue = true;
			mskDate.Focus();
		}
		if (string.IsNullOrEmpty(txtTime.Text)) {
			lblError.Text = "Time missing";
			functionReturnValue = true;
			txtTime.Focus();
		}
		if (cmbVenues.SelectedIndex == 0) {
			lblError.Text = "Location missing";
			functionReturnValue = true;
			cmbVenues.Focus();
		}
		if (functionReturnValue == true)
			Response.End();
		return functionReturnValue;
	}

	private void btnDelete_Click(System.Object sender, System.EventArgs e)
	{
		//1) Put a label control beneath your button but sets its Visible property to false.  Name it lblConfirm.
		//2) Set the CommandArgument property of your button to "Confirm" (u can use any string, but "Confirm" will do for this example).
		//3) In your server-side click event, do this:
		if (Session["USERACCESS"] == "R")
			return;
		Button btn = (Button)sender;
		if (string.IsNullOrEmpty(lblDeleteDate.Text))
			btn.CommandArgument = "Confirm";
		if (btn.CommandArgument == "Confirm") {
			lblDeleteDate.Text = "*Click Delete button again to confirm.*";
			lblDeleteDate.Visible = true;
			btn.CommandArgument = "Delete";
		} else if (btn.CommandArgument == "Delete") {
			if (Session["ScheduleNo"] > 0) {
				DELRow(Session["ScheduleNo"], Session["GameNumber"]);
				ClearFields();
				LoadGames();
				Session["ScheduleNo"] = 0;
			}
			lblDeleteDate.Text = "";
			lblDeleteDate.Visible = false;
			btn.CommandArgument = "Confirm";
			cmbDivisions.Enabled = false;
		}

		//You are using the label as a message box of sorts and the CommandArgument of the button to tell the click event whether 
		//you need to confirm or have confirmed.
	}

	private void DELRow(Int16 ScheduleNumber, Int16 GameNumber)
	{
		if (Session["AccessType"] == "R")
			return;
		Season.clsGames oGames = new Season.clsGames();
		try {
			oGames.DELRow(ScheduleNumber, GameNumber);
		} catch (Exception ex) {
			lblError.Text = ex.Message;
		} finally {
			oGames = null;
		}
	}

	private void LoadCombos()
	{
		LoadVenues();
		LoadDivisions();
		LoadGames();
		if (Session["ScheduleNo"] > "")
			LoadTeams();
		LoadEmails(0);
	}

	private void LoadVenues()
	{
		Season.clsGames oVenues = new Season.clsGames();
		DataTable rsData = default(DataTable);
		DataRow dRow = default(DataRow);
		try {
			rsData = oVenues.LoadVenues(0, Session["CompanyID"]);
			//, cmbDivisions.SelectedValue())
			dRow = rsData.NewRow;
			dRow("LocationNumber") = 0;
			if (rsData.Rows.Count == 0) {
				dRow("LocationName") = "NO Venues";
			} else {
				dRow("LocationName") = " ";
				rsData.Rows.InsertAt(dRow, 0);
			}
			var _with2 = cmbVenues;
			_with2.DataSource = rsData;
			_with2.DataValueField = "LocationNumber";
			_with2.DataTextField = "LocationName";
			_with2.DataBind();
		} catch (Exception ex) {
			lblError.Text = "LoadVenues::" + ex.Message;
		} finally {
			oVenues = null;
		}
	}

	private void LoadDivisions()
	{
		Season.ClsDivisions oDivisions = new Season.ClsDivisions();
		DataTable rsData = default(DataTable);
		DataRow dRow = default(DataRow);
		try {
			rsData = oDivisions.LoadDivision(0, Session["CompanyID"], Session["SeasonID"], "DivisionID, Div_Desc as Division");
			dRow = rsData.NewRow;
			dRow("DivisionID") = 0;
			if (rsData.Rows.Count == 0) {
				dRow("Division") = "NO Division";
			} else {
				dRow("Division") = " ";
				rsData.Rows.InsertAt(dRow, 0);
			}
			var _with3 = cmbDivisions;
			_with3.DataSource = rsData;
			_with3.DataValueField = "DivisionID";
			_with3.DataTextField = "Division";
			_with3.DataBind();
		} catch (Exception ex) {
			lblError.Text = "LoadDivisions::" + ex.Message;
		} finally {
			oDivisions = null;
		}
	}

	private void LoadTeams()
	{
		Season.ClsTeams oTeams = new Season.ClsTeams();
		DataTable rsData = default(DataTable);
		try {
			rsData = oTeams.LoadDivisionTeams(Session["ScheduleNo"], Session["CompanyID"], Session["SeasonID"], true);
			txtHome.Text = rsData.Rows(0).Item("Home");
		} catch (Exception ex) {
			lblError.Text = "LoadTeams::" + ex.Message;
		} finally {
			oTeams = null;
		}
	}

	private void LoadGames()
	{
		Season.clsGames oGames = new Season.clsGames();
		DataTable rsData = default(DataTable);
		try {
			rsData = oGames.GetDayGames(Session["CompanyID"], Session["SeasonID"], Calendar1.SelectedDate.Date);
			if (rsData.Rows.Count > 0) {
				btnSend.Enabled = true;
				var _with4 = grdGames;
				_with4.DataSource = rsData;
				_with4.DataBind();
				var _with5 = _with4.DisplayLayout.Bands(0).Columns;
				//Incluir Division descr and ID
				_with5.FromKey("GameDate").Hidden = true;
				_with5.FromKey("GameTime").Hidden = true;
				_with5.FromKey("GameType").Hidden = true;
				_with5.FromKey("ScheduleNumber").Hidden = true;
				_with5.FromKey("DivisionID").Hidden = true;
				_with5.FromKey("LocationNumber").Hidden = true;
				_with5.FromKey("GameNumber").Hidden = true;
				_with5.FromKey("HomeTeam").Hidden = true;
				_with5.FromKey("VisitorTeam").Hidden = true;
				_with5.FromKey("Descr").Hidden = true;
				_with5.FromKey("LocationName").CellStyle.HorizontalAlign = HorizontalAlign.Center;
				_with5.FromKey("LocationName").Width = 120;
				_with5.FromKey("Division").CellStyle.HorizontalAlign = HorizontalAlign.Center;
				_with5.FromKey("Division").Width = 150;
				//.FromKey("Date").Format = "ddd MM/dd/yyyy"
				//.FromKey("Date").CellStyle.HorizontalAlign = HorizontalAlign.Right
				_with5.FromKey("GameDateTime").Width = 150;
				_with5.FromKey("GameDateTime").CellStyle.HorizontalAlign = HorizontalAlign.Center;
				_with5.FromKey("Teams").Width = 120;
				_with5.FromKey("Teams").CellStyle.HorizontalAlign = HorizontalAlign.Center;
				//.FromKey("Location").HeaderStyle.HorizontalAlign = HorizontalAlign.Left
			} else {
				btnSend.Enabled = false;
				grdGames.Rows.Clear();
				grdGames.Clear();
			}
			lblError.Text = "";
		} catch (Exception ex) {
			lblError.Text = "LoadGames:" + ex.Message;
		} finally {
			oGames = null;
			rsData = null;
		}
	}

	public void MsgBox(string Message)
	{
		Label strScript = new Label();
		strScript.Text = "<SCRIPT LANGUAGE='JavaScript'>" + Environment.NewLine + "window.alert('" + Message + "')</script>";
		Page.Controls.Add(strScript);
	}

	protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
	{
		ClearFields();
		if (this.Calendar1.TodaysDate != this.Calendar1.SelectedDate) {
			this.Calendar1.TodayDayStyle.BackColor = Drawing.Color.White;
		}

		LoadGames();
	}

	private void btnSend_Click(System.Object sender, System.EventArgs e)
	{
		if (Session["AccessType"] == "R")
			return;
		SendEmails();
		for (Int16 I = 0; I <= lstEmails.Items.Count - 1; I++) {
			lstEmails.Items(I).Selected = false;
		}
	}

	private void LoadEmails(Int32 iGroupType)
	{
		Profile.ClsHouseholds oEmails = new Profile.ClsHouseholds();
		DataTable rsData = default(DataTable);
		try {
			rsData = oEmails.LoadEmails(iGroupType, Session["CompanyID"], Session["SeasonID"]);
			lstEmails.Items.Clear();
			if (rsData.Rows.Count > 0) {
				//   |||||   Set the DataValueField to the Primary Key
				lstEmails.DataValueField = "Email";
				//   |||||   Set the DataTextField to the text/data you want to display
				lstEmails.DataTextField = "Name";
				//   |||||   Set the DataSource the the OleDBDataReader's result
				lstEmails.DataSource = rsData;
				//   |||||   Bind the Source Data to the Web/Server Control
				lstEmails.DataBind();

			}
			for (Int16 I = 0; I <= lstEmails.Items.Count - 1; I++) {
				lstEmails.Items(I).Selected = true;
			}
		} catch (Exception ex) {
			lblError.Text = "LoadEmails::" + ex.Message;
		} finally {
			oEmails = null;
		}
	}

	private void SendEmails()
	{
		System.Net.Mail.MailMessage oEmail = new System.Net.Mail.MailMessage();
		SmtpClient oSmtp = new SmtpClient("mail.csbchoops.net");
		string EmailBody = null;
		oSmtp = new SmtpClient("mail.csbchoops.net");
		oSmtp.Host = "mail.csbchoops.net";
		oSmtp.Credentials = new System.Net.NetworkCredential("registrar@csbchoops.net", "csbc0317");
		oSmtp.Port = 25;

		EmailBody = "<table border='3' WIDTH = '500'>";
		EmailBody += "<tr bgcolor='#99CCFF'><th>Location Name</th><th>Division</th><th align='center'>Game Time</th><th>Teams</th></tr>";
		for (long idx = 0; idx <= grdGames.Rows.Count - 1; idx++) {
			EmailBody += "<tr><td>" + grdGames.DisplayLayout.Rows(idx).Cells(1).Text;
			EmailBody += "</td><td>" + grdGames.DisplayLayout.Rows(idx).Cells(2).Text;
			EmailBody += "</td><td>" + grdGames.DisplayLayout.Rows(idx).Cells(4).Text;
			EmailBody += "</td><td>" + grdGames.DisplayLayout.Rows(idx).Cells(5).Text + "</td></tr>";
		}
		EmailBody += "</table>";


		for (Int16 I = 0; I <= lstEmails.Items.Count - 1; I++) {
			if (IsEmail(lstEmails.Items(I).Value) == true & lstEmails.Items(I).Selected == true) {
				oEmail = new System.Net.Mail.MailMessage();
				oEmail.From = new System.Net.Mail.MailAddress("registration@csbchoops.net");
				oEmail.To.Add(lstEmails.Items(I).Value);
				oEmail.IsBodyHtml = true;
				oEmail.Subject = Strings.Format(Calendar1.SelectedDate, "ddd MMM/dd/yyyy") + " Games Scheduled";
				oEmail.Body = EmailBody;
				if (GoodEmail(oSmtp, oEmail) == true)
					EmailsSent += 1;
				oEmail.Dispose();
				oEmail = null;
			}
		}

		if (EmailsSent == 0) {
			lblError.Text = ErrorMsg + " (0) Email(s) sent!";
		} else {
			lblError.Text = "(" + EmailsSent + ") Email(s) sent!";
		}
		//txtSubject.Text = ""
		//htmlMail.Text = ""
	}

	private bool IsEmail(string Email)
	{
		bool functionReturnValue = false;
		string pattern = "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$";
		Match emailAddressMatch = Regex.Match(Email, pattern);
		if (emailAddressMatch.Success) {
			functionReturnValue = true;
		} else {
			functionReturnValue = false;
		}
		return functionReturnValue;
	}

	private bool GoodEmail(object oSmtp, object oEmail)
	{
		bool functionReturnValue = false;
		functionReturnValue = true;
		try {
			oSmtp.Send(oEmail);
		} catch (Exception ex) {
			ErrorMsg = "Unable to send mail!  " + ex.Message;
			functionReturnValue = false;
		}
		return functionReturnValue;
	}

	protected void grdGames_DblClick(object sender, Infragistics.WebUI.UltraWebGrid.ClickEventArgs e)
	{
		SelectGame();
	}

	protected void grdGames_SelectedRowsChange(object sender, Infragistics.WebUI.UltraWebGrid.SelectedRowsEventArgs e)
	{
		SelectGame();
	}

	private void SelectGame()
	{
		ClearFields();
		Session["ScheduleNo"] = grdGames.DisplayLayout.ActiveRow.Cells(7).Text();
		Session["GameNumber"] = grdGames.DisplayLayout.ActiveRow.Cells(9).Text();
		Session["LocationNumber"] = grdGames.DisplayLayout.ActiveRow.Cells(8).Text();
		Session["GameType"] = grdGames.DisplayLayout.ActiveRow.Cells(6).Text();
		if (Session["GameType"] == "P") {
			lblPlayoff.Visible = true;
			btnDelete.Enabled = true;
			txtHome.Enabled = true;
			txtVisitor.Enabled = true;
			txtDescr.Visible = true;
		} else {
			lblPlayoff.Visible = false;
			btnDelete.Enabled = false;
			txtHome.Enabled = false;
			txtVisitor.Enabled = false;
			txtDescr.Visible = false;
			cmbDivisions.Enabled = false;
		}
		cmbVenues.SelectedIndex = grdGames.DisplayLayout.ActiveRow.Cells(8).Text();
		cmbDivisions.SelectedValue = grdGames.DisplayLayout.ActiveRow.Cells(12).Text();
		txtDescr.Text = grdGames.DisplayLayout.ActiveRow.Cells(13).Text();
		txtHome.Text = grdGames.DisplayLayout.ActiveRow.Cells(10).Text();
		if (txtDescr.Text == txtHome.Text)
			txtHome.Text = "";
		txtVisitor.Text = grdGames.DisplayLayout.ActiveRow.Cells(11).Text();
		mskDate.Text = grdGames.DisplayLayout.ActiveRow.Cells(0).Text();
		txtTime.Text = grdGames.DisplayLayout.ActiveRow.Cells(4).Text();
	}

	protected void btnNew_Click(object sender, System.EventArgs e)
	{
		ClearFields();
		Session.Remove("ScheduleNo");
		Session.Remove("GameNumber");
		Session.Remove("LocationNumber");
		Session.Remove("GameType");

		cmbDivisions.Enabled = true;
		btnSave.Enabled = true;
		cmbDivisions.Focus();
	}

}