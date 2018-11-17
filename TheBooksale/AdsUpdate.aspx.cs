/* 
 * Application Name: The Booksale
 * File: AdsUpdate.aspx.cs
 * File Description: Allows the user to update the contents of the ad
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
    public partial class AdsUpdate : System.Web.UI.Page
    {
        string userId = "";
        string userName = "";
        string displayName = "";
        string adsId = "";
        int updateMethod = 1; //-- 1 = Edit, 2 = Deactivate
        int lastAdDetailsId = 0;
        int lastAdPhotoId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Retrieve update Method
            updateMethod = int.Parse(Request.QueryString[0].ToString());

            //-- Retrieve Ads Id
            adsId = Request.QueryString[1].ToString();

            if (!Page.IsPostBack)
            {
                //-- if Update Method is Deactivate (2), redirect to Delete Confirmation page
                if (updateMethod == 2)
                    Response.Redirect("AdsDeleteConfirm.aspx?XAD=" + adsId);

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
                    
                    //-- Load Ad Status
                    Common.LoadStatusDDL(ddlStatus);
                    //-- Remove "All" from the list
                    Common.RemoveFromDDL(ddlStatus, "All");
                    //-- Retain only Submitted (0), Published (2), Reserved (4) and Sold (5)
                    Common.RemoveFromDDL(ddlStatus, "1");
                    Common.RemoveFromDDL(ddlStatus, "3");
                    Common.RemoveFromDDL(ddlStatus, "99"); 

                    //-- Load Authors
                    Common.LoadAuthorsDDL(ddlAuthors);

                    ////-- Load User Contact Information
                    //LoadUserInfo();
                    
                    //-- Display Ad Details and Photos
                    if (LoadAdDetails(adsId))
                        LoadAdPhotos(adsId);

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
            //-- Submit Ad Changes and Save into Table
            //-- Return Value: bool
            
            try
            {
                //-- Recreate Parameters, then Update Record using SqlDataSource object
                sqlAdsMain.UpdateParameters.Clear();

                sqlAdsMain.UpdateParameters.Add("prmAdTypeId", ddlAdTypes.SelectedValue);
                sqlAdsMain.UpdateParameters.Add("prmSubCategoryId", ddlSubCategories.SelectedValue);
                sqlAdsMain.UpdateParameters.Add("prmConditionId", ddlConditions.SelectedValue);
                sqlAdsMain.UpdateParameters.Add("prmPrice", txtPrice.Text);
                sqlAdsMain.UpdateParameters.Add("prmTitle", txtTitle.Text);
                sqlAdsMain.UpdateParameters.Add("prmDescription", txtDescription.Text);
                if (chkNegotiable.Checked)
                    sqlAdsMain.UpdateParameters.Add("prmNegotiable", "1");
                else
                    sqlAdsMain.UpdateParameters.Add("prmNegotiable", "0");
                sqlAdsMain.UpdateParameters.Add("prmAdsId", adsId);
                //-- TEMP Only - Automatically set to Published if not Reserved or Sold
                if ((ddlStatus.SelectedValue != "4") && (ddlStatus.SelectedValue != "5"))
                    sqlAdsMain.UpdateParameters.Add("prmStatus", "2");
                else
                    sqlAdsMain.UpdateParameters.Add("prmStatus", ddlStatus.SelectedValue); 

                //-- Save to Audit Log


                //-- Save Ads Photos (currently maxed at 3)
                for (int i = 1; i <= Common.maxPhotos; i++)
                {
                    //-- if a new Photo is uploaded, run SubmitPhoto function
                    FileUpload fupImageCurrent = (FileUpload)PostForm.FindControl("fupAdImg" + i.ToString());

                    if (fupImageCurrent.HasFile)
                        PostSubmitPhotos(adsId, i);
                    //else
                    //    DeleteOldPhoto(adsId, i);
                }
                    

                //-- Save Ads Details
                PostSubmitDetails(adsId);

                //-- Update main Ads Record
                sqlAdsMain.Update();

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
                //-- Recreate Parameters, then Update Record using SqlDataSource object
                sqlAdDetails.UpdateParameters.Clear();
                
                sqlAdDetails.UpdateParameters.Add("prmAdsid", _adsId);
                sqlAdDetails.UpdateParameters.Add("prmAuthorId", ddlAuthors.SelectedValue);

                if (ddlAuthors.SelectedValue == Common.autOthers)
                    sqlAdDetails.UpdateParameters.Add("prmAuthorName", hdnAuthor.Value);
                else
                    sqlAdDetails.UpdateParameters.Add("prmAuthorName", "");

                //-- Save to Audit Log

                //-- Update Ad Details Record
                sqlAdDetails.Update();

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
            int photoId = 0;
            string photoPath = ""; 

            try
            {
                using (SqlConnection cnAdsPhotos = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAdsPhotos = new SqlCommand(Common.sqlAdPhotosOrder, cnAdsPhotos);
                    //-- Add filter for order
                    cmdAdsPhotos.CommandType = CommandType.Text;

                    cmdAdsPhotos.Parameters.Clear();
                    cmdAdsPhotos.Parameters.AddWithValue("prmAdsId", _adsId);
                    cmdAdsPhotos.Parameters.AddWithValue("prmOrder", _order);

                    cnAdsPhotos.Open();

                    SqlDataReader rdrAdsPhotos = cmdAdsPhotos.ExecuteReader();

                    //-- if Existing, Retrieve Photo Ids from table and Update
                    if (rdrAdsPhotos.HasRows)
                    {
                        while (rdrAdsPhotos.Read())
                        {
                            photoId = int.Parse(rdrAdsPhotos["PHO_PHOTO_ID"].ToString());
                            photoPath = rdrAdsPhotos["PHO_PATH"].ToString();

                            SavePhotoPath(_adsId, _order, photoId, photoPath);
                        }
                    }
                    else
                    //-- if New, Insert into Table
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
                    }

                    rdrAdsPhotos.Close();
                    cmdAdsPhotos.Dispose();
                    cnAdsPhotos.Close();
                }

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
            //--    - if there is no parameter for PhotoId, it's meant for New Photos
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

                //-- Insert Photos Record
                sqlAdPhotos.Insert();

                return (lastAdPhotoId + 1).ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private string SavePhotoPath(string _adsId, int _order, int _photoId, string _photoPath)
        {
            //-- SavePhotoPath
            //-- Save Photo at the Server Folder and store filepath into Table
            //--    - if there is no parameter for PhotoId, it's meant for Existing Photos
            //-- Parameters: 
            //--   _adsId (string)
            //--   _order (int)
            //--   _photoId (int)
            //--   _photoPath (string)
            //-- Return Value: bool

            FileUpload fupImageCurrent;

            try
            {
                //-- set current fupImage
                fupImageCurrent = (FileUpload)PostForm.FindControl("fupAdImg" + _order.ToString());
                
                string photoFileName = Path.GetFileName(fupImageCurrent.FileName);

                //-- if current filename and new filename are different, then update. else ignore.
                if (Common.pathPhotosAds + "/" + _adsId + "/" + photoFileName != _photoPath)
                {
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

                    //-- Delete old photo
                    if (System.IO.File.Exists(Server.MapPath("~/" + _photoPath)))
                        System.IO.File.Delete(Server.MapPath("~/" + _photoPath));

                    //-- Save File into designated server folder, remove first if existing
                    if (System.IO.File.Exists(Server.MapPath(adSpecificFolderPath + "/" + photoFileName)))
                        System.IO.File.Delete(Server.MapPath(adSpecificFolderPath + "/" + photoFileName));
                    fupImageCurrent.SaveAs(Server.MapPath(adSpecificFolderPath + "/" + photoFileName));

                    //-- Close the file
                    fupImageCurrent.FileContent.Close();

                    //-- Recreate Parameters, then Update record
                    sqlAdPhotos.UpdateParameters.Clear();
                    sqlAdPhotos.UpdateParameters.Add("prmPhotoId", _photoId.ToString());
                    sqlAdPhotos.UpdateParameters.Add("prmCaption", "");
                    sqlAdPhotos.UpdateParameters.Add("prmPath", Common.pathPhotosAds + "/" + _adsId + "/" + photoFileName);
                    sqlAdPhotos.UpdateParameters.Add("prmOrder", _order.ToString());

                    //-- Save to Audit Log

                    //-- Update Photos Record
                    sqlAdPhotos.Update();
                }

                return _photoId.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        private bool LoadAdDetails(string _adsId)
        {
            bool showDisplayName = false;

            try
            {
                using (SqlConnection cnAdDetails = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAdDetails = new SqlCommand(Common.sqlAdDetails, cnAdDetails);
                    cmdAdDetails.CommandType = CommandType.Text;

                    cmdAdDetails.Parameters.Clear();
                    cmdAdDetails.Parameters.AddWithValue("prmAdsId", _adsId);

                    cnAdDetails.Open();

                    SqlDataReader rdrAdsDetails = cmdAdDetails.ExecuteReader();

                    if (rdrAdsDetails.HasRows)
                    {
                        while (rdrAdsDetails.Read())
                        {
                            //-- Category, SubCategory and Ad Type
                            ddlCategories.SelectedValue = rdrAdsDetails["CAT_CATEGORY_ID"].ToString();
                            ddlSubCategories.SelectedValue = rdrAdsDetails["SUB_SUBCATEGORY_ID"].ToString();
                            ddlAdTypes.SelectedValue = rdrAdsDetails["ADT_ADTYPE_ID"].ToString();

                            //-- Condition, Author and Status
                            ddlConditions.SelectedValue = rdrAdsDetails["CON_CONDITION_ID"].ToString();
                            ddlAuthors.SelectedValue = rdrAdsDetails["AUT_AUTHOR_ID"].ToString();
                            //-- if selected Author is not Others, set author Texbox and Hidden values as selected
                            if (ddlAuthors.SelectedValue != Common.autOthers)
                            {
                                txtAuthor.Text = ddlAuthors.Items[ddlAuthors.SelectedIndex].Text;
                                hdnAuthor.Value = ddlAuthors.Items[ddlAuthors.SelectedIndex].Text;
                                txtAuthor.ReadOnly = true; 
                            }
                            else
                            {
                                //-- Else load from Ad Details Author name field
                                txtAuthor.Text = rdrAdsDetails["ADD_AUTHOR_NAME"].ToString();
                                hdnAuthor.Value = rdrAdsDetails["ADD_AUTHOR_NAME"].ToString();
                                txtAuthor.ReadOnly = false; 
                            }
                            ddlStatus.SelectedValue = rdrAdsDetails["STA_STATUS_ID"].ToString(); 

                            //-- Other Ads Info
                            txtTitle.Text = rdrAdsDetails["ADS_TITLE"].ToString();
                            txtDescription.Text = rdrAdsDetails["ADS_DESCRIPTION"].ToString();
                            txtPrice.Text = rdrAdsDetails["ADS_PRICE"].ToString();
                            if (rdrAdsDetails["ADS_NEGOTIABLE"].ToString() == "True")
                                chkNegotiable.Checked = true;
                            else
                                chkNegotiable.Checked = false; 
                        }
                    }

                    rdrAdsDetails.Close();
                    cmdAdDetails.Dispose();
                    cnAdDetails.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool LoadAdPhotos(string _adsId)
        {
            try
            {
                using (SqlConnection cnAdPhotos = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdAdPhotos = new SqlCommand(Common.sqlAdPhotos, cnAdPhotos);
                    cmdAdPhotos.CommandType = CommandType.Text;

                    cmdAdPhotos.Parameters.Clear();
                    cmdAdPhotos.Parameters.AddWithValue("prmAdsId", _adsId);

                    cnAdPhotos.Open();

                    SqlDataReader rdrAdPhotos = cmdAdPhotos.ExecuteReader();

                    if (rdrAdPhotos.HasRows)
                    {
                        Image imgAds;
                        int counterImgAds = 1;

                        while (rdrAdPhotos.Read())
                        {
                            imgAds = (Image)divOwlDemo.FindControl("imgAds" + counterImgAds.ToString());

                            imgAds.AlternateText = rdrAdPhotos["PHO_CAPTION"].ToString();
                            imgAds.ImageUrl = rdrAdPhotos["PHO_PATH"].ToString();

                            counterImgAds++;
                        }
                    }

                    rdrAdPhotos.Close();
                    cmdAdPhotos.Dispose();
                    cnAdPhotos.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}