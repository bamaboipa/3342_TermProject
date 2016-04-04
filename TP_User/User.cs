using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace TP_User
{
    public class User
    {
        private int userID, imagePreferenceID, statusPreferenceID, personalPreferenceID, zip;
        private string eMail, firstName, lastName, address, city, state, password;

        public int UserId 
        {
            get {return userID;}
            set { userID = value; }
        }
        public int ImagePreferenceId 
        {
            get { return imagePreferenceID; }
            set { imagePreferenceID = value; }
        }
        public int StatusPreferenceId 
        {
            get { return statusPreferenceID; }
            set { statusPreferenceID = value; }
        }
        public int PersonalPreferenceId 
        {
            get { return personalPreferenceID; }
            set { personalPreferenceID = value; }
        }
        public int Zip 
        {
            get { return zip; }
            set { zip = value; }
        }
        public string EMail 
        {
            get { return eMail; }
            set { eMail = value; }
        }
        public string FirstName 
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName 
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Address 
        {
            get { return address; }
            set { address = value; }
        }
        public string City 
        {
            get { return city; }
            set { city = value; }
        }
        public string State 
        {
            get { return state; }
            set { state = value; }
        }
        public string Password 
        {
            get { return password; }
            set { password = value; }
        }
        public Boolean addUser(User user)
        { 
            User myUser = new User();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            try 
	        {	        
		
                objCommand.Parameters.Clear();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ADDUSER";

                objCommand.Parameters.AddWithValue("eMAIL", myUser.eMail);
                objCommand.Parameters.AddWithValue("@FirstName", firstName);
                objCommand.Parameters.AddWithValue("@LastName", lastName);
                objCommand.Parameters.AddWithValue("@Address", user.address);
                objCommand.Parameters.AddWithValue("@City", city);
                objCommand.Parameters.AddWithValue("@State", state);
                objCommand.Parameters.AddWithValue("@Zip", user.zip);
                objCommand.Parameters.AddWithValue("@Password", user.password);
                objCommand.Parameters.AddWithValue("@ImagePreferenceId", user.imagePreferenceID);
                objCommand.Parameters.AddWithValue("@StatusPreferenceId", user.statusPreferenceID);
                objCommand.Parameters.AddWithValue("@ContactPreferenceID", user.personalPreferenceID);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objDB.CloseConnection();

                return true;

	        }
	        catch (Exception)
	        {
		
	        	return false;
	        }

        }
    }   
    
}
