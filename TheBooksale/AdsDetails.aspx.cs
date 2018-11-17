/* 
 * Application Name: The Booksale
 * File: AdsDetails.aspx.cs
 * File Description: Displays details about the Book Ad
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
    public partial class AdsDetails : System.Web.UI.Page
    {
        string userName = "";
        string displayName = "";
        string adsId = ""; 

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Retrieve Ads Id
            adsId = Request.QueryString[0].ToString(); 

            if (!Page.IsPostBack)
            {
                //-- Change menu items if logged in or not
                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                {
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

                    //-- hide "Login to Contact" button and display Seller Contact Details
                    adsActionLoggedIn.Visible = true;
                    adsActionNotLoggedIn.Visible = false;
                    
                    ////-- Load and Display User Contact Information
                    //LoadUserInfo();
                }
                else
                {
                    //-- if not logged in, display "Logging" buttons and hide "My" buttons
                    liHome.Visible = true;
                    liMyAccount.Visible = false;
                    liMyAds.Visible = false;
                    liMyReports.Visible = false;
                    liLogout.Visible = false;
                    liLogin.Visible = true;
                    liSignup.Visible = true;

                    //-- Side NavMenu - if not logged in, display "My" links
                    liSNavMyAccount.Visible = true;
                    liSNavMyAdsAll.Visible = true;
                    liSNavMyAdsPending.Visible = true;
                    liSNavMyReports.Visible = true;

                    //-- hide "Login to Contact" button and display Seller Contact Details
                    adsActionLoggedIn.Visible = true;
                    adsActionNotLoggedIn.Visible = false;
                }

                //-- Display Ad Details and Photos
                if (LoadAdDetails(adsId))
                    LoadAdPhotos(adsId);

                //-- Increment Ad View Counter
                Common.IncrementAdViewCounter(adsId);

                //-- Load Related Ads by Genre (Related Ads Type = 1) using Sub Category
                Common.LoadRelatedAds(1, 8, sqlRelatedAdsByGenre, lvwRelatedByGenre, lblSubCategory.Text, adsId);

                //-- Load Related Ads by Author (Related Ads Type = 2) using Author Name
                Common.LoadRelatedAds(2, 8, sqlRelatedAdsByAuthor, lvwRelatedByAuthor, lblAuthor.Text.Replace(" ", "%"), adsId);

                //-- Load Related Sellers using Author Name and Sub Category
                Common.LoadRelatedSellers(3, sqlRelatedSellers, lvwRelatedSeller, lblSubCategory.Text, 
                    lblAuthor.Text.Replace(" ", "%"), adsId);

                //-- Load Latest Ads 
                Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }
        }

        protected void btnLoginToContact_Click(object sender, EventArgs e)
        {
            //-- Redirect to Login Page
            Response.Redirect("Login.aspx"); 
        }

        private bool LoadUserInfo(string _userName)
        {
            bool showDisplayName = false;

            try
            {
                using (SqlConnection cnUserInfo = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdUserInfo = new SqlCommand(Common.sqlUserInfo, cnUserInfo);
                    cmdUserInfo.CommandType = CommandType.Text;

                    cmdUserInfo.Parameters.Clear();
                    cmdUserInfo.Parameters.AddWithValue("prmUserName", _userName);

                    cnUserInfo.Open();

                    SqlDataReader rdrUserInfo = cmdUserInfo.ExecuteReader();

                    if (rdrUserInfo.HasRows)
                    {
                        while (rdrUserInfo.Read())
                        {
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

                            //-- For 
                            lblForName.Text = displayName; 
                            lblForLocation.Text = rdrUserInfo["CIT_NAME"].ToString() + ", " 
                                + rdrUserInfo["PRV_NAME"].ToString(); 

                            //-- Ad Details
                            lblCity.Text = rdrUserInfo["CIT_NAME"].ToString();
                            lblProvince.Text = rdrUserInfo["PRV_NAME"].ToString();
                            
                            //-- Set Link and Text for View User Profile
                            lnkUserProfile.Attributes.Add("href", "ProfileAds.aspx?XAT=2&XID=" + rdrUserInfo["USR_USER_ID"].ToString());
                            lblLnkViewUserProfile.Text = "View " + displayName + "'s Profile";

                            //-- Contact Information
                            //-- Make sure that the Div is Visible
                            if (adsActionLoggedIn.Visible)
                            {
                                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                                {
                                    lblContactEmail.Text = rdrUserInfo["USR_EMAIL"].ToString();
                                    lblContactPhone.Text = rdrUserInfo["USR_PHONE"].ToString();
                                    lnkReviewSeller.Visible = true;
                                    lnkReviewBuyer.Visible = true; 
                                }
                                else
                                {
                                    lblContactEmail.Text = "(Log-in to show Contact Email)";
                                    lblContactPhone.Text = "(Log-in to show Contact Phone)";
                                    lnkReviewSeller.Visible = false;
                                    lnkReviewBuyer.Visible = false; 
                                }
                                lblContactDisplayName.Text = displayName;

                                //-- set Posted By link 
                                lnkPostedBy.Attributes.Add("href", "ProfileAds.aspx?XAT=2&XID=" + rdrUserInfo["USR_USER_ID"].ToString());
                            }
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
                            //-- Load User Information
                            LoadUserInfo(rdrAdsDetails["USR_USERNAME"].ToString());

                            //-- Ads Title
                            lblTitle.Text = rdrAdsDetails["ADS_TITLE"].ToString();

                            //-- Ads For
                            if (int.Parse(rdrAdsDetails["ADT_ADTYPE_ID"].ToString()) == 1)
                                lblForAdType.Text = "To be bought by ";
                            else
                                lblForAdType.Text = "For sale by ";

                            //-- Ads Details
                            lblAdDetails.Text = rdrAdsDetails["ADS_DESCRIPTION"].ToString();
                            if (rdrAdsDetails["AUT_AUTHOR_ID"].ToString() != Common.autOthers)
                                lblAuthor.Text = rdrAdsDetails["AUT_NAME"].ToString();
                            else
                                lblAuthor.Text = rdrAdsDetails["ADD_AUTHOR_NAME"].ToString();
                            if (rdrAdsDetails["ADS_NEGOTIABLE"].ToString() == "True")
                                lblPrice.Text = rdrAdsDetails["ADS_PRICE"].ToString() + "<br /> <i>(Negotiable)</i>";
                            else
                                lblPrice.Text = rdrAdsDetails["ADS_PRICE"].ToString();
                            lblCategory.Text = rdrAdsDetails["CAT_CATEGORY_NAME"].ToString();
                            lblSubCategory.Text = rdrAdsDetails["SUB_SUBCATEGORY_NAME"].ToString();
                            if (int.Parse(rdrAdsDetails["ADT_ADTYPE_ID"].ToString()) == 1)
                                lblAdType.Text = "To Buy ";
                            else
                                lblAdType.Text = "For Sale";
                            lblPublishDate.Text = String.Format("{0:dd-MMM-yyyy}", rdrAdsDetails["ADS_MODIFIEDDATE"]);
                            lblCondition.Text = rdrAdsDetails["CON_NAME"].ToString();

                            //-- Set Related Genre Header
                            lblRelatedGenre.Text = lblSubCategory.Text;
                            lblRelatedAuthor.Text = lblAuthor.Text; 

                            //-- ??? if Ad is sold, display Review Seller???
                            //-- set link for Review Seller/Buyer button
                            lnkReviewSeller.Attributes.Add("href", "ReviewForSeller.aspx?XAD=&XID=" + rdrAdsDetails["USR_USER_ID"].ToString());
                            lnkReviewBuyer.Attributes.Add("href", "ReviewForBuyer.aspx?XID=" + rdrAdsDetails["USR_USER_ID"].ToString());

                            //-- hide/display Review Seller/Buyer button, unless user is not logged in (hide both)
                            if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                            {
                                //-- Display Review Seller/Buyer button only if user is NOT viewing own posted ad
                                if (Session["userName"].ToString() != rdrAdsDetails["USR_USERNAME"].ToString())
                                {
                                    if (int.Parse(rdrAdsDetails["ADT_ADTYPE_ID"].ToString()) == 1)
                                    {
                                        lnkReviewBuyer.Visible = true;
                                        lnkReviewSeller.Visible = false;
                                    }
                                    else
                                    {
                                        lnkReviewBuyer.Visible = false;
                                        lnkReviewSeller.Visible = true;
                                    }
                                }
                                else
                                {
                                    lnkReviewSeller.Visible = false;
                                    lnkReviewBuyer.Visible = false;
                                }
                            }
                            else
                            {
                                lnkReviewSeller.Visible = false;
                                lnkReviewBuyer.Visible = false;
                            }
                            
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