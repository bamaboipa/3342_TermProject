using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;


namespace TP_User
{
    public class User
    {
        private Byte[] key = { 251, 102, 19, 77, 46, 136, 207, 119, 5, 172, 4, 169, 203, 242, 38, 199 };
        private Byte[] vector = {145, 63, 190, 110, 22, 2, 112, 118, 230, 120, 251, 112, 78, 31, 113, 155};

        private int userID, imagePreferenceID, statusPreferenceID, personalPreferenceID;
        private string eMail, firstName, lastName, address, city, state, password, zip, phone;

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
        public string Zip 
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
        public string Phone {
            get { return phone; }
            set { phone = value; }
        }
        public Boolean addUser(User user)
        { 
            
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            try 
	        {	        
		
                objCommand.Parameters.Clear();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_ADDUSER";

                objCommand.Parameters.AddWithValue("eMAIL", user.eMail);
                objCommand.Parameters.AddWithValue("@FirstName", user.firstName);
                objCommand.Parameters.AddWithValue("@LastName", user.lastName);
                objCommand.Parameters.AddWithValue("@Address", user.address);
                objCommand.Parameters.AddWithValue("@Password", user.password);
                objCommand.Parameters.AddWithValue("@Phone", user.phone);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objDB.CloseConnection();

                return true;

	        }
	        catch (Exception)
	        {
		
	        	return false;
	        }

        }
        public User verifyUser(string eMail, string Password)
        {
            User myUser = new User();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_VERIFYUSER";

            objCommand.Parameters.AddWithValue("@Email", eMail);
            objCommand.Parameters.AddWithValue("@Password", password);

            DataSet dsUser = objDB.GetDataSetUsingCmdObj(objCommand);

           
           
                foreach (DataTable table in dsUser.Tables)
                {
                    if (table.Rows.Count == 0)
	                     {
                        myUser.firstName = "";

                        }
                        else
                        {
                            foreach (DataRow row in table.Rows)
                         {
                        if (row["Email"].ToString().ToLower() == eMail.ToLower() && row["Password"].ToString() == Password)
                        {
                            myUser.eMail = eMail;
                            myUser.password = password;
                            myUser.firstName = row["FirstName"].ToString();
                            myUser.lastName = row["LastName"].ToString();
                            myUser.address = row["Address"].ToString();
                            myUser.ImagePreferenceId = int.Parse(row["ImagePreferenceID"].ToString());
                            myUser.statusPreferenceID = int.Parse(row["StatusPreferenceID"].ToString());
                            myUser.personalPreferenceID = int.Parse(row["PersonalPreferenceID"].ToString());
                        }
                        }
                    }
                } return myUser;
            }
        public DataSet getSecQuestion(string eMail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GETSECQUESTION";

            objCommand.Parameters.AddWithValue("@Email", eMail);

            DataSet dsSecurity = objDB.GetDataSetUsingCmdObj(objCommand);

            objDB.CloseConnection();

            return dsSecurity;
        }
        public Boolean emailExists(string eMail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();
            
            objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "GETUSERBYEMAIL";

                objCommand.Parameters.AddWithValue("@EMail", eMail);


                DataSet dsEmail = objDB.GetDataSetUsingCmdObj(objCommand);
                objDB.CloseConnection();
                Boolean isEmail = false;
                foreach (DataTable table in dsEmail.Tables)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (row["Email"].ToString() == "")
                        {
                            isEmail = false;
                        }
                        else
                        {
                            isEmail = true;
                        }
                    }
                } return isEmail;
           
        }
        public Boolean updatePassword(string password, string eMail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objCommand.Parameters.Clear();

                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UPDATEPASSWORD";

                objCommand.Parameters.AddWithValue("@Email", eMail);
                objCommand.Parameters.AddWithValue("@Password", password);

                objDB.DoUpdateUsingCmdObj(objCommand);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }
        public String encryptPassword(string password)
        {
            string encPassword;
            
            Encoding encoder = new UTF32Encoding();
            byte[] arrTextBytes;

            arrTextBytes = encoder.GetBytes(password);

            RijndaelManaged myEncrypt = new RijndaelManaged();
            MemoryStream myMemStream = new MemoryStream();
            CryptoStream myEncryptStream = new CryptoStream(myMemStream, myEncrypt.CreateEncryptor(key, vector), CryptoStreamMode.Write);

            myEncryptStream.Write(arrTextBytes, 0, arrTextBytes.Length);
            myEncryptStream.FlushFinalBlock();

            myMemStream.Position = 0;
            Byte[] arrEncByte = new Byte[myMemStream.Length];
            myMemStream.Read(arrEncByte, 0, arrEncByte.Length);

            myEncryptStream.Close();
            myMemStream.Close();

            encPassword = Convert.ToBase64String(arrEncByte);
            return encPassword;

        }
        public string decryptPassword(string encPassword)
        {
            Byte[] arrEncPassword = Convert.FromBase64String(encPassword);
            Byte[] arrTExtBytes;
            string password;
            UTF32Encoding encoder = new UTF32Encoding();

            RijndaelManaged myEncrypt = new RijndaelManaged();
            MemoryStream myMemStream = new MemoryStream();
            CryptoStream myDecStream = new CryptoStream(myMemStream, myEncrypt.CreateDecryptor(key, vector), CryptoStreamMode.Write);

            myDecStream.Write(arrEncPassword, 0, arrEncPassword.Length);
            myDecStream.FlushFinalBlock();

            myMemStream.Position = 0;
            arrTExtBytes = new Byte[myMemStream.Length];
            myMemStream.Read(arrTExtBytes, 0, arrTExtBytes.Length);

            password = encoder.GetString(arrTExtBytes);

            return password;
        }
    }  
    
}
