using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;

namespace _3342_TermProject
{
    public partial class Preferences : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTheme.SelectedIndex = 3;
                ddlFont.SelectedIndex = 2;
                ddlFontColor.SelectedIndex = 1;
                ddlLoginPreference.SelectedIndex = 2;
                ddlPhotos.SelectedIndex = 1;
                ddlProfileInformation.SelectedIndex = 1;
                ddlContactInfo.SelectedIndex = 1;
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            UpdateLoginPreferences();
        }

        private void UpdateLoginPreferences()
        {
            SqlCommand loginPrefCommand = new SqlCommand();
            loginPrefCommand.CommandType = CommandType.StoredProcedure;
            loginPrefCommand.CommandText = "";
        }

    }
}