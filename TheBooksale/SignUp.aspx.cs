/* 
 * Application Name: The Booksale
 * File: SignUp.aspx.cs
 * File Description: Allows the User to Sign Up for an Account in TheBooksale
 * Author: James L. Gagni Jr.
 * UPOU Student Number: 2016-30148
 * Course: IS 295 - Information System Project
 * Program: Master of Information Systems
 * Date: 7 August 2018
 */

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TheBooksale
{
    public partial class SignUp : System.Web.UI.Page
    {
        string userID = "";
        int userProfileId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //-- Load Latest Ads
                Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }
        }

        protected void ddlProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            //-- BEGIN: Validation Checks
            //-- Check for blank required fields

            //-- Check Password == Retype Password

            //-- Check Display Name, it must not be null if chkDisplayName is true

            //-- Check other conditions, etc

            //-- END: Validation Checks

            //-- Insert Into USR_PROFILE table (then USR_USERS table)
            if (InsertUsrProfile())
                Response.Redirect("SignUpSuccess.aspx"); 
        }

        private bool InsertUsrProfile()
        {
            //-- Insert Into USR_PROFILE table
            
            try
            {
                //-- Retrieve New User Profile Id
                userProfileId = Common.GetNextUsrProfId();

                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlUserProfile.InsertParameters.Clear();
                sqlUserProfile.InsertParameters.Add("prmUsrProfId", userProfileId.ToString());
                sqlUserProfile.InsertParameters.Add("prmLName", txtLName.Text);
                sqlUserProfile.InsertParameters.Add("prmFName", txtFName.Text);
                sqlUserProfile.InsertParameters.Add("prmEmail", txtEmail.Text);
                //sqlUserProfile.InsertParameters.Add("prmDisplayName", txtDisplayName.Text);
                sqlUserProfile.InsertParameters.Add("prmPhone", txtPhone.Text);
                //sqlUserProfile.InsertParameters.Add("prmBirthDate", txtBirthDate.Text);
                //sqlUserProfile.InsertParameters.Add("prmAddress", txtAddress.Text);
                //sqlUserProfile.InsertParameters.Add("prmCityId", ddlCities.SelectedValue);
                //sqlUserProfile.InsertParameters.Add("prmBiography", txtBiography.Text);
                //if (chkDisplayName.Checked)
                //    sqlUserProfile.InsertParameters.Add("prmDisplayFlag", "1");
                //else
                //    sqlUserProfile.InsertParameters.Add("prmDisplayFlag", "0");
                
                //-- Save to Audit Log

                //-- Insert New User Profile Record
                sqlUserProfile.Insert();

                //-- Insert New User Record using the User Profile Id
                InsertUsrUser(userProfileId);

                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private bool InsertUsrUser(int userProfileId)
        {
            //-- Insert Into USR_USER table
            
            try
            {
                //-- Set New Unique User ID
                userID = Common.SetUniqueUserID(txtLName.Text, txtFName.Text);

                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlUser.InsertParameters.Clear();
                sqlUser.InsertParameters.Add("prmUserId", userID);
                sqlUser.InsertParameters.Add("prmUserName", txtUsername.Text);
                sqlUser.InsertParameters.Add("prmPwd", Common.Crypt(txtPassword.Text, 0));
                sqlUser.InsertParameters.Add("prmUsrProfId", userProfileId.ToString());

                //-- Save to Audit Log

                //-- Insert New Record
                sqlUser.Insert();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}