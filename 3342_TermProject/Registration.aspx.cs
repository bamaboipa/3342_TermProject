using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using TP_User;
using System.Web.Security;

namespace _3342_TermProject
{
    public partial class styleTester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie myCookie = Request.Cookies["HoneyCookie"];
                if (Request.Cookies["HoneyCookie"] != null)
                {
                    User myUser = new User();
                    //HttpCookie myCookie = Request.Cookies["HoneyCookie"];
                    string logIn = myCookie.Values["LogIn"];
                    myUser.EMail = myCookie.Values["Email"];
                    myUser.Password = myUser.encryptPassword(myCookie.Values["Password"]);
                    if (myUser.EMail != "" && myUser.Password != "")
                    {
                        myUser = myUser.verifyUser(txtEmail.Text, txtPassword.Text);
                        Session["myUser"] = myUser;
                        Response.Redirect("UserHomePage.aspx");

                    }
                    else if (myUser.EMail != "" && myUser.Password == "")
                    {
                        txtEmail.Text = myUser.EMail;

                    }
                    else
                    {
                        txtEmail.Text = "";
                        txtPassword.Text = "";
                    }
                }
            }
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
                    DBConnect db = new DBConnect();
                    SqlCommand addToPreferences = new SqlCommand();
                    addToPreferences.CommandType = CommandType.StoredProcedure;
                    addToPreferences.CommandText = "TP_ADDUSERTOPREFERENCES";
                    addToPreferences.Parameters.AddWithValue("@email", myUser.EMail);
                    db.DoUpdateUsingCmdObj(addToPreferences);
                    Session["myUser"] = myUser;
                    HttpCookie yourCookie = new HttpCookie("HoneyCookie");
                    yourCookie.Values["LogIn"] = "";
                    yourCookie.Values["Email"] = myUser.EMail;
                    yourCookie.Values["Password"] = "";
                    yourCookie.Expires = new DateTime(2023, 1, 1);
                    Response.Cookies.Add(yourCookie);
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
            HttpCookie yourCookie = new HttpCookie("HoneyCookie");
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
               myUser = myUser.verifyUser(txtEmail.Text, txtPassword.Text);
                if (myUser.FirstName == "")
                {
                    lblLogIn.Text = "Username and Password Combination is incorrect";
                    lblLogIn.Visible = true;
                }
                if (chkStayLoggedIn.Checked)
                {
                    string encPassword = myUser.encryptPassword(txtPassword.Text);

                   
                    yourCookie.Values["LogIn"] = "Auto";
                    yourCookie.Values["Email"] = myUser.EMail;
                    yourCookie.Values["Password"] = encPassword;
                    yourCookie.Expires = new DateTime(2023, 1, 1);
                    

                    Session["myUser"] = myUser;
                    Response.Redirect("UserHomePage.aspx");
                }
                else
                {
                    yourCookie.Values["LogIn"] = "Fast";
                    yourCookie.Values["Email"] = myUser.EMail;
                    yourCookie.Expires = new DateTime(2023, 1, 1);
                    
                    Session["myUser"] = myUser;
                    Response.Redirect("UserHomePage.aspx");
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