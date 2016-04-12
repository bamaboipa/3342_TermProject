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
            Response.Redirect("UserHomePage.aspx");
        }

        protected void btnSetSecurity_Click(object sender, EventArgs e)
        {
            
            HttpCookie chocolateCookie = Request.Cookies["HoneyCookie"];
            chocolateCookie.Values["Login"] = ddlLoginPreference.SelectedValue;
            string email = chocolateCookie.Values["Email"].ToString();
            if (txtFathersMiddle.Text != "" && txtMaidenName.Text != "" && txtStreet.Text != "")
            {
                DBConnect db = new DBConnect();
                SqlCommand secQuestionsCommand = new SqlCommand();
                secQuestionsCommand.CommandType = CommandType.StoredProcedure;
                secQuestionsCommand.CommandText = "TP_ADDSECQUESTION";
                secQuestionsCommand.Parameters.AddWithValue("@Email", email);
                secQuestionsCommand.Parameters.AddWithValue("@Question", lblMothersName.Text);
                secQuestionsCommand.Parameters.AddWithValue("@Answer", txtMaidenName.Text);
                db.DoUpdateUsingCmdObj(secQuestionsCommand);
                SqlCommand secQuestionsCommand2 = new SqlCommand();
                secQuestionsCommand2.CommandType = CommandType.StoredProcedure;
                secQuestionsCommand2.CommandText = "TP_ADDSECQUESTION";
                secQuestionsCommand2.Parameters.AddWithValue("@Email", email);
                secQuestionsCommand2.Parameters.AddWithValue("@Question", lblFathersMiddle.Text);
                secQuestionsCommand2.Parameters.AddWithValue("@Answer", txtFathersMiddle.Text);
                db.DoUpdateUsingCmdObj(secQuestionsCommand2);
                SqlCommand secQuestionsCommand3 = new SqlCommand();
                secQuestionsCommand3.CommandType = CommandType.StoredProcedure;
                secQuestionsCommand3.CommandText = "TP_ADDSECQUESTION";
                secQuestionsCommand3.Parameters.AddWithValue("@Email", email);
                secQuestionsCommand3.Parameters.AddWithValue("@Question", lblStreet.Text);
                secQuestionsCommand3.Parameters.AddWithValue("@Answer", txtStreet.Text);
                db.DoUpdateUsingCmdObj(secQuestionsCommand3);
                error.Text = "Security Questions Updated!";
                Response.AddHeader("Refresh", "2;URL=UserHomePage.aspx");
            }
            else
            {
                error.Text = "Security Questions Cannot Be Left Blank";
            }
        }

    }
}