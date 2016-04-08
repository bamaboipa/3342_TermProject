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
    public partial class styleTester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string eMail = txtNewAccountEmail.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string password = txtNewAccountPassword.Text;
            string phone = txtPhoneNumber.Text;

            if (eMail == "" || firstName == "" || lastName == "" || address == "" || password == "" || phone == "")
            {
                lblRegResponse.Text = "Please Complete the Entire Form Before Continuing";
                lblRegResponse.Visible = true;

            }
            else
            {
                User myUser = new User();
                myUser.EMail = eMail;
                myUser.FirstName = firstName;
                myUser.LastName = lastName;
                myUser.Address = address;
                myUser.Password = password;
                myUser.Phone = phone;

                if (myUser.addUser(myUser) == true)
                {
                    Session["myUser"] = myUser;
                    HttpCookie yourCookie = new HttpCookie("HoneyCookie");
                    //yourCookie.Value["Login"];
                    Response.Redirect("Preferences.aspx");
                }
                else
                {
                    lblRegResponse.Text = "Well This is embarrassing";
                    lblRegResponse.Visible = true;
                }

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User myUser = new User();
            myUser.EMail = txtEmail.Text;
            myUser.Password = txtPassword.Text;
            if (myUser.EMail == "")
            {
                lblLogIn.Text = "Please Enter a Valid Email Address";
                lblLogIn.Visible = true;
            }
            else if (myUser.Password == "")
            {
                lblLogIn.Text = "Please Enter a Password";
                lblLogIn.Visible = true;
            }
            else if (myUser.emailExists(myUser.EMail) == true)
            {
                myUser.verifyUser(txtEmail.Text, txtPassword.Text);
                if (myUser.FirstName == "")
                {
                    lblLogIn.Text = "Username and Password Combination in incorrect";
                    lblLogIn.Visible = true;
                }
                else
                {
                    Session["myUser"] = myUser;
                    Response.Redirect("");
                }
            }
            else
            {
                lblLogIn.Text = "Opps, we can't seem to find your email.  Please Register!";
                lblLogIn.Visible = true;
            }
            
            
        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Session["email"] = email;
            Response.Redirect("PasswordRecover.aspx");
        }
      
        
    }
}