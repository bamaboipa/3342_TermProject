using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using TP_User;

namespace _3342_TermProject
{
    public partial class PasswordRecover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User myUser = new User();
            int count = 0;
            Session["count"] = count;
            count = (int)Session["count"];
            string email = (string)Session["email"];
            if (!IsPostBack)
            {

                if (email == "")
                {
                    divEmail.Visible = true;
                }
                else
                {
                    DataSet dsSecCheck = myUser.getSecQuestion(email);
                    txtSecQuest.Text = dsSecCheck.Tables[0].Rows[count]["SecurityQuestion"].ToString();
                    divQuestion.Visible = true;
                }
            }


        }

        protected void btnGetPassword_Click(object sender, EventArgs e)
        {
            int count = (int)Session["count"];
            string email = (string)Session["email"];
            DataSet dsSecQuest = (DataSet)Session["dsSecQuest"];
            if (count < dsSecQuest.Tables[0].Rows.Count && txtSecAnswer.Text == dsSecQuest.Tables[0].Rows[count]["SecAnswer"].ToString())
            {
                
                    divQuestion.Visible = false;
                    divPassword.Visible = true;
            }
            else if (count < dsSecQuest.Tables[0].Rows.Count && txtSecAnswer.Text != dsSecQuest.Tables[0].Rows[count]["SecAnswer"].ToString())
            {
                count++;
            }
            else
            {
                lblResponseQuestion.Text = "You have exhausted your attempts, account is locked!";
                lblResponseQuestion.Visible = true;
                Response.AddHeader("Refresh", "5;URL=Registration.aspx");
            }
            

        }

        protected void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            User myUser = new User();
            int count = 0;
            myUser.EMail = txtUserName.Text;
            DataSet dsSecQuest = myUser.getSecQuestion(myUser.EMail);
            Session["dsSecQuest"] = dsSecQuest;
            if (dsSecQuest.Tables[0].Rows.Count == 0)
            {
                lblResponseEmail.Text = "Email Not Found, Redirecting to Registraion Page";
                lblResponseEmail.Visible = true;
                Response.AddHeader("Refresh", "5;URL=Registration.aspx");
            }
            else
            {
                divEmail.Visible = false;
                string email = dsSecQuest.Tables[0].Rows[count]["Email"].ToString();
                Session["email"] = email;
                txtSecQuest.Text = dsSecQuest.Tables[0].Rows[count]["SecurityQuestion"].ToString();
                divQuestion.Visible = true;
            }
        }
    }
}