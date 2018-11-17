/* 
 * Application Name: The Booksale
 * File: UserAccount.aspx.cs
 * File Description: Displays The Booksale user's account and allows updates or changes to their profile
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
using System.IO;

using System.Diagnostics;

namespace TheBooksale
{
    public partial class MyAccountHome : System.Web.UI.Page
    {
        string userName = "";
        string displayName = ""; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ////-- Load Category List onto the DDL
                //Common.LoadCategoryDDL(ddlCategories);

                ////-- Load Locations (filtered with existing ads only) 
                ////Common.LoadLocationDDL(ddlLocations, 1, true, ""); 
                //Common.LoadLocationDDL(ddlLocations, 1, false, ""); //-- TEMP for test display all
                
                //-- Change menu items if logged in or not
                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                {
                    userName = Session["userName"].ToString();

                    //-- if logged in, display "My" buttons and hide "Logging" buttons
                    liHome.Visible = true;
                    liMyAccount.Visible = true;
                    liMyAds.Visible = true;
                    liMyReports.Visible = true;
                    liLogout.Visible = true;
                    liLogin.Visible = false;
                    liSignup.Visible = false;

                    //-- Side NavMenu - if logged in, display "My" links
                    liSNavMyAccount.Visible = true;
                    liSNavMyAdsAll.Visible = true;
                    liSNavMyAdsPending.Visible = true;
                    liSNavMyReports.Visible = true;

                    //-- Load Provinces
                    Common.LoadLocationDDL(ddlProvinces, 1, false, "");

                    //-- Load User Information (and photo) into the controls
                    LoadUserInfo(); 
                }
                else
                {
                    //-- Redirect to Login page
                    Response.Redirect("Login.aspx"); 
                }
                
                //-- Load Latest Ads
                Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }
            
        }

        protected void ddlProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {

            //-- If there's a specific province selected, filter
            if (ddlProvinces.SelectedIndex >= 1)
            {
                //-- Load Cities 
                Common.LoadLocationDDL(ddlCities, 2, false, ddlProvinces.SelectedValue);
            }
        }

        private bool LoadUserInfo()
        {
            bool showDisplayName = false; 

            try
            {
                using (SqlConnection cnUserInfo = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdUserInfo = new SqlCommand(Common.sqlUserInfo, cnUserInfo);
                    cmdUserInfo.CommandType = CommandType.Text;

                    cmdUserInfo.Parameters.Clear();
                    cmdUserInfo.Parameters.AddWithValue("prmUserName", userName); 

                    cnUserInfo.Open();

                    SqlDataReader rdrUserInfo = cmdUserInfo.ExecuteReader();

                    if (rdrUserInfo.HasRows)
                    {
                        while (rdrUserInfo.Read())
                        {
                            //-- save Profile and User Ids into hidden objects
                            hdnUsrProfileId.Value = rdrUserInfo["USR_PROFILE_ID"].ToString();
                            hdnUsrUserId.Value = rdrUserInfo["USR_USER_ID"].ToString();

                            if ((rdrUserInfo["USR_SHOWDISPLAY"] != null) && (rdrUserInfo["USR_SHOWDISPLAY"].ToString() != ""))
                                showDisplayName = bool.Parse(rdrUserInfo["USR_SHOWDISPLAY"].ToString()); 

                            //-- set displayName variable value
                            if (showDisplayName)
                                if (rdrUserInfo["USR_DISPLAY"].ToString().Trim() != "")
                                    displayName = rdrUserInfo["USR_DISPLAY"].ToString();
                                else
                                    displayName = rdrUserInfo["USR_FIRSTNAME"].ToString(); 
                            else
                                displayName = rdrUserInfo["USR_FIRSTNAME"].ToString();

                            //-- if both Display Name and First Name are blank, use Last Name, else blank
                            if (displayName.Trim() == "")
                                displayName = rdrUserInfo["USR_LASTNAME"].ToString();


                            //-- Profile Header
                            lblProfileName.Text = displayName;
                            if (rdrUserInfo["USR_PHOTO"].ToString() != "")
                                imgProfilePhoto.ImageUrl = "~/" + Common.pathPhotosUsers + "/" + hdnUsrUserId.Value + "/" 
                                    + rdrUserInfo["USR_PHOTO"].ToString();
                            else
                                imgProfilePhoto.ImageUrl = "~/" + Common.pathPhotosUsers + "/user.png";

                            //-- Greetings
                            lblGreetName.Text = displayName;

                            //-- Profile Contents
                            txtFName.Text = rdrUserInfo["USR_FIRSTNAME"].ToString();
                            txtLName.Text = rdrUserInfo["USR_LASTNAME"].ToString();
                            txtDisplayName.Text = rdrUserInfo["USR_DISPLAY"].ToString();
                            txtEmail.Text = rdrUserInfo["USR_EMAIL"].ToString();
                            txtAddress.Text = rdrUserInfo["USR_ADDRESS"].ToString();
                            if (rdrUserInfo["PRV_PROVINCE_ID"] != null)
                            {
                                ddlProvinces.SelectedValue = rdrUserInfo["PRV_PROVINCE_ID"].ToString();
                                
                                //-- Load Cities
                                Common.LoadLocationDDL(ddlCities, 2, false, ddlProvinces.SelectedValue);

                                ddlCities.SelectedValue = rdrUserInfo["CIT_CITY_ID"].ToString();
                            }
                            txtPhone.Text = rdrUserInfo["USR_PHONE"].ToString();
                            if (rdrUserInfo["USR_DATEOFBIRTH"] != null)
                                txtBirthDate.Text = Convert.ToDateTime(rdrUserInfo["USR_DATEOFBIRTH"].ToString()).ToString("yyyy-MM-dd");
                            txtBiography.Text = rdrUserInfo["USR_BIOGRAPHY"].ToString();

                            //-- Set Close Account Link 
                            lnkUserDelete.Attributes.Add("href", "UserDeleteConfirm.aspx?XUI=" + hdnUsrUserId.Value); 

                            //-- Account Settings -- Retrieve it?

                            //-- Preferences
                            if (showDisplayName)
                                chkDisplayName.Checked = true;
                            else
                                chkDisplayName.Checked = false;
                        }
                    }

                    rdrUserInfo.Close();
                    cmdUserInfo.Dispose();
                    cnUserInfo.Close();
                }

                return true; 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //-- BEGIN: Validation Checks
            //-- Check for blank required fields

            //-- Check Password == Retype Password

            //-- Check Display Name, it must not be null if chkDisplayName is true

            //-- Check other conditions, etc

            //-- END: Validation Checks

            //-- Update USR_PROFILE table (then USR_USERS table)
            if (UpdateUsrProfile())
                Response.Redirect("UserAccountSuccess.aspx");
        }
        
        private bool UpdateUsrProfile()
        {
            //-- Update USR_PROFILE table

            try
            {
                //-- Recreate Parameters, then Update record using SqlDataSource object
                sqlUserProfile.UpdateParameters.Clear();
                sqlUserProfile.UpdateParameters.Add("prmUsrProfId", hdnUsrProfileId.Value);
                sqlUserProfile.UpdateParameters.Add("prmLName", txtLName.Text);
                sqlUserProfile.UpdateParameters.Add("prmFName", txtFName.Text);
                sqlUserProfile.UpdateParameters.Add("prmDisplayName", txtDisplayName.Text);
                sqlUserProfile.UpdateParameters.Add("prmAddress", txtAddress.Text);
                sqlUserProfile.UpdateParameters.Add("prmCityId", ddlCities.SelectedValue);
                sqlUserProfile.UpdateParameters.Add("prmDateOfBirth", txtBirthDate.Text);
                sqlUserProfile.UpdateParameters.Add("prmBiography", txtBiography.Text);

                //-- Save to Audit Log

                //-- Insert New User Profile Record
                sqlUserProfile.Update();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool UpdateUsrProfilePhoto()
        {
            //-- Update USR_PROFILE table for Photo only

            try
            {
                //-- Validation on Photo Filetype
                if (fupUsrImage.PostedFile.ContentType != "image/jpeg")
                {
                    throw new Exception("Only JPEG files are accepted!");
                }

                //-- Validation on Photo Filesize
                if (fupUsrImage.PostedFile.ContentLength >= 1048576)
                {
                    throw new Exception("The file has to be less than 1MB");
                }

                //-- If UserId folder does not exist in User Images folder, create
                string usrSpecificFolderPath = "~/" + Common.pathPhotosUsers + "/" + hdnUsrUserId.Value;
                if (!System.IO.Directory.Exists(Server.MapPath(usrSpecificFolderPath)))
                    System.IO.Directory.CreateDirectory(Server.MapPath(usrSpecificFolderPath));

                //-- Save File into designated server folder, remove first if existing
                string photoFileName = Path.GetFileName(fupUsrImage.FileName);
                if (System.IO.File.Exists(Server.MapPath(usrSpecificFolderPath + "/" + photoFileName)))
                    System.IO.File.Delete(Server.MapPath(usrSpecificFolderPath + "/" + photoFileName));
                fupUsrImage.SaveAs(Server.MapPath(usrSpecificFolderPath + "/" + photoFileName));

                //-- Close the file
                fupUsrImage.FileContent.Close();

                //-- Recreate Parameters, then Update record using SqlDataSource object
                sqlUserProfilePhoto.UpdateParameters.Clear();
                sqlUserProfilePhoto.UpdateParameters.Add("prmUsrProfId", hdnUsrProfileId.Value);
                sqlUserProfilePhoto.UpdateParameters.Add("prmPhotoFileName", fupUsrImage.FileName);

                //-- Save to Audit Log

                //-- Update User Profile Record
                sqlUserProfilePhoto.Update();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool UpdateUsrProfileDisplay()
        {
            //-- Update USR_PROFILE table for Display flag only

            try
            {
                //-- Recreate Parameters, then Update record using SqlDataSource object
                sqlUserProfileDisplay.UpdateParameters.Clear();
                sqlUserProfileDisplay.UpdateParameters.Add("prmUsrProfId", hdnUsrProfileId.Value);
                if (chkDisplayName.Checked)
                    sqlUserProfileDisplay.UpdateParameters.Add("prmDisplayFlag", "1");
                else
                    sqlUserProfileDisplay.UpdateParameters.Add("prmDisplayFlag", "0");

                //-- Save to Audit Log

                //-- Update User Profile Record
                sqlUserProfileDisplay.Update();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool UpdateUsrUser()
        {
            //-- Update USR_USER table

            try
            {
                //-- Recreate Parameters, then Update Record using SqlDataSource object
                sqlUser.UpdateParameters.Clear();
                sqlUser.UpdateParameters.Add("prmUserId", hdnUsrUserId.Value);
                sqlUser.UpdateParameters.Add("prmPwd", Common.Crypt(txtPassword.Text, 0));

                //-- Save to Audit Log

                //-- Insert New Record
                sqlUser.Update();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); 
                return false;
            }

        }

        protected void btnUpdatePhoto_Click(object sender, EventArgs e)
        {
            //-- BEGIN: Validation Checks
            //-- Check for blank required fields
            if (!fupUsrImage.HasFile)
                return; 

            //-- END: Validation Checks

            //-- Update USR_PROFILE table
            if (UpdateUsrProfilePhoto())
                Response.Redirect("UserAccountSuccess.aspx");
        }

        protected void btnUpdateSecurity_Click(object sender, EventArgs e)
        {

            //-- BEGIN: Validation Checks
            //-- Check for blank required fields

            //-- Check Password == Retype Password
            
            //-- END: Validation Checks

            //-- Update USR_USERS table 
            if (UpdateUsrUser())
                Response.Redirect("UserAccountSuccess.aspx");
        }

        protected void btnUpdateDisplay_Click(object sender, EventArgs e)
        {
            //-- BEGIN: Validation Checks
            //-- Check Display Name, it must not be null if chkDisplayName is true
            
            //-- END: Validation Checks

            //-- Update USR_PROFILE table 
            if (UpdateUsrProfileDisplay())
                Response.Redirect("UserAccountSuccess.aspx");
        }
    }
}