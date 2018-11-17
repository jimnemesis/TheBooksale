/* 
 * Application Name: The Booksale
 * File: AdsPost.aspx.cs
 * File Description: Allows the registered user to Post the Ad
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

namespace TheBooksale
{
    public partial class AdsPost : System.Web.UI.Page
    {
        string userId = "";
        string userName = "";
        string displayName = "";
        string adsId = "";
        int lastAdDetailsId = 0;
        int lastAdPhotoId = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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

                    //-- Load Category List onto the DDL
                    Common.LoadCategoryDDL(ddlCategories);
                    //-- Remove "All" from the list
                    Common.RemoveFromDDL(ddlCategories, "0");

                    //-- Load SubCategories 
                    Common.LoadSubCategoryDDL(ddlSubCategories, ddlCategories.SelectedValue);
                    
                    //-- Load Ad Types
                    Common.LoadAdTypesDDL(ddlAdTypes);

                    //-- Load Ad Conditions
                    Common.LoadConditionsDDL(ddlConditions);
                    //-- Remove "All" from the list
                    Common.RemoveFromDDL(ddlConditions, "All");

                    //-- Load Authors
                    Common.LoadAuthorsDDL(ddlAuthors);
                    //-- if default selected Author is not "Other", set txtAuthor as ReadOnly
                    if (ddlAuthors.SelectedValue != Common.autOthers)
                        txtAuthor.ReadOnly = true;
                    else
                        txtAuthor.ReadOnly = false; 

                    ////-- Load User Contact Information
                    //LoadUserInfo();

                    Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
                }
                else
                {
                    //-- Redirect to Login page
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                {
                    userName = Session["userName"].ToString();
                }
            }

            //-- Load User Contact Information
            LoadUserInfo();
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-- Reload SubCategories 
            Common.LoadSubCategoryDDL(ddlSubCategories, ddlCategories.SelectedValue);
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
                            userId = rdrUserInfo["USR_USER_ID"].ToString();

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

                            //-- Contact Information
                            txtDisplayName.Text = displayName;
                            txtEmail.Text = rdrUserInfo["USR_EMAIL"].ToString();
                            txtPhone.Text = rdrUserInfo["USR_PHONE"].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //-- Validation 
                if (PostValidate())
                {
                    if (PostSubmit())
                        //-- Redirect to Posting Success page
                        Response.Redirect("AdsPostSuccess.aspx"); 
                }

            }
            catch (Exception ex)
            {

            }
        }

        private bool PostValidate()
        {
            //-- PostValidate
            //-- Validation before Submitting Ad
            //-- Return Value: bool

            bool showDisplayName = false;

            try
            {

                //-- Must always have a Main Photo 
                if (!fupAdImg1.HasFile)
                {
                    //-- Message: Your Book Ad must always have a main photo
                    return false;
                }

                //using (SqlConnection cnUserInfo = new SqlConnection(Common.cnBooksaleDB))
                //{
                //    SqlCommand cmdUserInfo = new SqlCommand(Common.sqlUserInfo, cnUserInfo);
                //    cmdUserInfo.CommandType = CommandType.Text;

                //    cmdUserInfo.Parameters.Clear();
                //    cmdUserInfo.Parameters.AddWithValue("prmUserName", userName);

                //    cnUserInfo.Open();

                //    SqlDataReader rdrUserInfo = cmdUserInfo.ExecuteReader();

                //    if (rdrUserInfo.HasRows)
                //    {
                //        while (rdrUserInfo.Read())
                //        {
                //            if ((rdrUserInfo["USR_SHOWDISPLAY"] != null) && (rdrUserInfo["USR_SHOWDISPLAY"].ToString() != ""))
                //                showDisplayName = bool.Parse(rdrUserInfo["USR_SHOWDISPLAY"].ToString());

                //            //-- set displayName variable value
                //            if (showDisplayName)
                //                if (rdrUserInfo["USR_DISPLAY"].ToString().Trim() != "")
                //                    displayName = rdrUserInfo["USR_DISPLAY"].ToString();
                //                else
                //                    displayName = rdrUserInfo["USR_FIRSTNAME"].ToString();
                //            else
                //                displayName = rdrUserInfo["USR_FIRSTNAME"].ToString();

                //            //-- if both Display Name and First Name are blank, use Last Name, else blank
                //            if (displayName.Trim() == "")
                //                displayName = rdrUserInfo["USR_LASTNAME"].ToString();

                //            //-- Contact Information
                //            txtDisplayName.Text = displayName;
                //            txtEmail.Text = rdrUserInfo["USR_EMAIL"].ToString();
                //            txtPhone.Text = rdrUserInfo["USR_PHONE"].ToString();
                //        }
                //    }

                //    rdrUserInfo.Close();
                //    cmdUserInfo.Dispose();
                //    cnUserInfo.Close();
                //}

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool PostSubmit()
        {
            //-- PostSubmit
            //-- Submit Ad and Save into Table
            //-- Return Value: bool


            try
            {
                //-- Retrieve New User Ads Id
                adsId = Common.SetUniqueAdsId(userId);

                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlAdsMain.InsertParameters.Clear();

                sqlAdsMain.InsertParameters.Add("prmAdsId", adsId);
                sqlAdsMain.InsertParameters.Add("prmAdTypeId", ddlAdTypes.SelectedValue);
                sqlAdsMain.InsertParameters.Add("prmUserId", userId);
                sqlAdsMain.InsertParameters.Add("prmSubCategoryId", ddlSubCategories.SelectedValue);
                sqlAdsMain.InsertParameters.Add("prmConditionId", ddlConditions.SelectedValue);
                sqlAdsMain.InsertParameters.Add("prmPrice", txtPrice.Text);
                sqlAdsMain.InsertParameters.Add("prmTitle", txtTitle.Text);
                sqlAdsMain.InsertParameters.Add("prmDescription", txtDescription.Text);
                if (chkNegotiable.Checked)
                    sqlAdsMain.InsertParameters.Add("prmNegotiable", "1");
                else
                    sqlAdsMain.InsertParameters.Add("prmNegotiable", "0");

                //-- Save to Audit Log

                //-- Insert main Ads Record
                sqlAdsMain.Insert();

                //-- Save Ads Details
                PostSubmitDetails(adsId);

                //-- Save Ads Photos (currently maxed at 3)
                for (int i = 1; i <= Common.maxPhotos; i++)
                    PostSubmitPhotos(adsId, i);

                //-- Insert New Record for Ad View Counter
                sqlAdViewCounter.InsertParameters.Clear();
                sqlAdViewCounter.InsertParameters.Add("prmAdsId", adsId);
                sqlAdViewCounter.Insert(); 

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private bool PostSubmitDetails(string _adsId)
        {
            //-- PostSubmitDetails
            //-- Save Ad Details into Table
            //-- Parameters: 
            //--   _adsId (string)
            //-- Return Value: bool

            try
            {
                //-- Retrieve Last Ad Details Id
                lastAdDetailsId = int.Parse(Common.GetMaxAdsDetailsId());

                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlAdDetails.InsertParameters.Clear();

                sqlAdDetails.InsertParameters.Add("prmAdDetailsId", (lastAdDetailsId + 1).ToString());
                sqlAdDetails.InsertParameters.Add("prmAdsid", _adsId);
                sqlAdDetails.InsertParameters.Add("prmAuthorId", ddlAuthors.SelectedValue);
                if (ddlAuthors.SelectedValue == Common.autOthers)
                    sqlAdDetails.InsertParameters.Add("prmAuthorName", hdnAuthor.Value);
                else
                    sqlAdDetails.InsertParameters.Add("prmAuthorName", "");

                //-- Save to Audit Log

                //-- Insert Ad Details Record
                sqlAdDetails.Insert();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private bool PostSubmitPhotos(string _adsId, int _order)
        {
            //-- PostSubmitPhotos
            //-- Save Ad Photos Mapping Data into Table
            //-- Parameters: 
            //--   _adsId (string)
            //--   _order (int)
            //-- Return Value: bool

            string photoIdNew = ""; 

            try
            {
                //-- Store Photo and filepath
                photoIdNew = SavePhotoPath(_adsId, _order); 
                if (photoIdNew == "")
                {
                    throw new Exception("Photo was not saved successfully!"); 
                }
                
                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlAdPhotosMap.InsertParameters.Clear();

                sqlAdPhotosMap.InsertParameters.Add("prmAdsId", _adsId);
                sqlAdPhotosMap.InsertParameters.Add("prmPhotoId", photoIdNew);

                //-- Save to Audit Log

                //-- Insert Ad Mapping Photos Record
                sqlAdPhotosMap.Insert();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private string SavePhotoPath(string _adsId, int _order)
        {
            //-- SavePhotoPath
            //-- Save Photo at the Server Folder and store filepath into Table
            //-- Parameters: 
            //--   _adsId (string)
            //--   _order (int)
            //-- Return Value: bool

            FileUpload fupImageCurrent;

            try
            {
                //-- set current fupImage
                fupImageCurrent = (FileUpload)PostForm.FindControl("fupAdImg" + _order.ToString());

                //-- Validation on Photo Filetype
                if (fupImageCurrent.PostedFile.ContentType != "image/jpeg")
                {
                    throw new Exception("Only JPEG files are accepted!");
                }

                //-- Validation on Photo Filesize
                if (fupImageCurrent.PostedFile.ContentLength >= 2097152)
                {
                    throw new Exception("The file has to be less than 2MB");
                }

                //-- If AdsId folder does not exist in Ads Images folder, create
                string adSpecificFolderPath = "~/" + Common.pathPhotosAds + "/" + _adsId;
                if (!System.IO.Directory.Exists(Server.MapPath(adSpecificFolderPath)))
                    System.IO.Directory.CreateDirectory(Server.MapPath(adSpecificFolderPath));

                //-- Save File into designated server folder, remove first if existing
                string photoFileName = Path.GetFileName(fupImageCurrent.FileName);
                if (System.IO.File.Exists(Server.MapPath(adSpecificFolderPath + "/" + photoFileName)))
                    System.IO.File.Delete(Server.MapPath(adSpecificFolderPath + "/" + photoFileName)); 
                fupImageCurrent.SaveAs(Server.MapPath(adSpecificFolderPath + "/" + photoFileName));

                //-- Close the file
                fupImageCurrent.FileContent.Close(); 

                //-- Get Last Photo Id
                lastAdPhotoId = int.Parse(Common.GetMaxAdsPhotoId()); 

                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlAdPhotos.InsertParameters.Clear();

                sqlAdPhotos.InsertParameters.Add("prmPhotoId", (lastAdPhotoId + 1).ToString());
                sqlAdPhotos.InsertParameters.Add("prmCaption", "");
                sqlAdPhotos.InsertParameters.Add("prmPath", Common.pathPhotosAds + "/" + _adsId + "/" + photoFileName);
                sqlAdPhotos.InsertParameters.Add("prmOrder", _order.ToString());

                //-- Save to Audit Log

                //-- Insert Ad Mapping Photos Record
                sqlAdPhotos.Insert();

                return (lastAdPhotoId + 1).ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }
    }
}