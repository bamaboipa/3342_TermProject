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
            DBConnect db = new DBConnect();
            HttpCookie chocolateCookie = Request.Cookies["HoneyCookie"];
            chocolateCookie.Values["Login"] = ddlLoginPreference.SelectedValue;
            string email = chocolateCookie.Values["Email"].ToString();
            SqlCommand privacyCommand = new SqlCommand();
            privacyCommand.CommandType = CommandType.StoredProcedure;
            privacyCommand.CommandText = "TP_UPDATEPRIVACY";
            privacyCommand.Parameters.AddWithValue("@email", email);
            privacyCommand.Parameters.AddWithValue("@imagePref", ddlPhotos.SelectedValue);
            privacyCommand.Parameters.AddWithValue("@statusPref", ddlProfileInformation.SelectedValue);
            privacyCommand.Parameters.AddWithValue("@personalPref", ddlContactInfo.SelectedValue);
            db.DoUpdateUsingCmdObj(privacyCommand);
            SqlCommand themeCommand = new SqlCommand();
            themeCommand.CommandType = CommandType.StoredProcedure;
            themeCommand.CommandText = "TP_UPDATETHEME";
            themeCommand.Parameters.AddWithValue("@email", email);
            themeCommand.Parameters.AddWithValue("@bannerColor", ddlTheme.SelectedValue);
            themeCommand.Parameters.AddWithValue("@font", ddlFont.SelectedValue);
            themeCommand.Parameters.AddWithValue("@fontColor", ddlFontColor.SelectedValue);
            db.DoUpdateUsingCmdObj(themeCommand);
            
        }

    }
}