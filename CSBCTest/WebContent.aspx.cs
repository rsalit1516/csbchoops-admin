using CSBC.Core.Data;
using CSBC.Core.Repositories;
using System;
using System.Linq;

namespace CSBC.Admin.Web
{
    public partial class WebContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadWebContent();
                LoadLookups();
            }
        }

        private void LoadLookups()
        {
            var repo = new WebContentTypeRepository(new CSBCDbContext());
            var records = repo.GetAll();
            ddlType.DataTextField = "WebContentTypeDescription";
            ddlType.DataValueField = "WebContentTypeId";
            ddlType.DataSource = records.ToList();
            ddlType.DataBind();

        }

        private void LoadWebContent()
        {
            GetActiveContent();
        }

        private void GetActiveContent()
        {
            var repo = new WebContentRepository(new CSBCDbContext());
            var content = repo.GetActiveWebContent(1).ToList();
            gridContent.DataSource = content;
            gridContent.DataBind();
        }

        protected void gridContent_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToString() == "Select")
            {
                var value = Int32.Parse(e.CommandArgument.ToString());
                var repo = new WebContentRepository(new CSBCDbContext());
                var content = repo.GetById(value);
                txtTitle.Text = content.Title;
                txtSubTitle.Text = content.SubTitle;
                txtDateAndTime.Text = content.DateAndTime;
                txtExpiration.Text = content.ExpirationDate.Value.ToShortDateString();
                txtBody.Text = content.Body;
                txtLocation.Text = content.Location;
                ddlType.SelectedValue = content.WebContentTypeId.ToString();
                txtWebContentId.Value = value.ToString();

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CSBC.Core.Models.WebContent content = GetFormValues();
            Save(content);
        }

        private void Save(CSBC.Core.Models.WebContent content)
        {
            var repo = new WebContentRepository(new CSBCDbContext());
            if (content.WebContentId == 0)
            {
                repo.Insert(GetFormValues());
            }
            else
            {
                repo.Update(GetFormValues());
            }
        }

        private CSBC.Core.Models.WebContent GetFormValues()
        {
            var content = new CSBC.Core.Models.WebContent();

            content.Title = txtTitle.Text;
            content.SubTitle = txtSubTitle.Text;
            content.DateAndTime = txtDateAndTime.Text;
            content.ExpirationDate = Convert.ToDateTime(txtExpiration.Text);
            content.Body = txtBody.Text;
            content.Location = txtLocation.Text;
            content.CompanyId = 1;
            content.ModifiedDate = DateTime.Today;
            content.Type = ddlType.SelectedItem.Text;
            content.WebContentTypeId = Int32.Parse(ddlType.SelectedItem.Value);
            content.WebContentId = txtWebContentId.Value == "" ? 0 : Int32.Parse(txtWebContentId.Value);
            return content;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void New()
        {
            txtTitle.Text = "";
            txtSubTitle.Text = "";
            txtDateAndTime.Text = "";
            txtExpiration.Text = DateTime.Today.AddMonths(3).ToShortDateString();
            txtBody.Text = "";
            txtLocation.Text = "";
            txtWebContentId.Value = "0";
            txtExpiration.Text = DateTime.Now.AddDays(60).ToShortDateString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Cancel()
        {
            txtTitle.Text = "";
            txtSubTitle.Text = "";
            txtDateAndTime.Text = "";
            txtExpiration.Text = DateTime.Today.AddMonths(3).ToShortDateString();
            txtBody.Text = "";
            txtLocation.Text = "";
        }

        protected void chkShowExpired_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowExpired.Checked)
            {
                GetAllContent();
            }
            else
            {
                GetActiveContent();
            }
        }

        private void GetAllContent()
        {
            var repo = new WebContentRepository(new CSBCDbContext());
            var content = repo.GetAll().ToList();
            gridContent.DataSource = content;
            gridContent.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtWebContentId.Value != "0" || txtWebContentId.Value != "")
            {
                var repo = new WebContentRepository(new CSBCDbContext());
                var item = repo.GetById(Int32.Parse(txtWebContentId.Value));
                repo.Delete(item);
            }
        }
    }
}