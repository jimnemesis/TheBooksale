/* 
 * Application Name: The Booksale
 * File: ProfileAds.aspx.cs
 * File Description: Displays a User Profile with their Ads
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

namespace TheBooksale
{
    public partial class ProfileAds : System.Web.UI.Page
    {
        string userName = "";
        string adForUserId = "";
        string displayName = "";
        int adType = 2; //-- 1 - Ads To Buy, 2 - Ads For Sale

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Retrieve Mode of Displaying My Ads
            adType = int.Parse(Request.QueryString[0].ToString());
            adForUserId = Request.QueryString[1].ToString();

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

                    //-- Side NavMenu - if not logged in, hide "My" links
                    liSNavMyAccount.Visible = false;
                    liSNavMyAdsAll.Visible = false;
                    liSNavMyAdsPending.Visible = false;
                    liSNavMyReports.Visible = false;
                }

                ////-- Highlight Selected Ads List and set List Header
                //if (adType == 1)
                //{
                //    liAdsForSale.Attributes.Clear();
                //    liAdsToBuy.Attributes.Add("class", "active");

                //    itaListHeader.Attributes.Add("class", "fa fa-shopping-cart");
                //    lblListHeader.Text = "Book Ads - Looking To Buy";
                //}
                //else if (adType == 2)
                //{
                //    liAdsForSale.Attributes.Add("class", "active");
                //    liAdsToBuy.Attributes.Clear();

                //    itaListHeader.Attributes.Add("class", "fa fa-shopping-basket");
                //    lblListHeader.Text = "Book Ads - For Sale";
                //}

                ////-- Set links for SideBar menu
                //lnkAdsForSale.Attributes.Add("href", "ProfileAds.aspx?XAT=2&XID=" + adForUserId);
                //lnkAdsToBuy.Attributes.Add("href", "ProfileAds.aspx?XAT=1&XID=" + adForUserId);
                //lnkReviewAsSeller.Attributes.Add("href", "ProfileRatings.aspx?XRV=2&XID=" + adForUserId);
                //lnkReviewAsBuyer.Attributes.Add("href", "ProfileRatings.aspx?XRV=1&XID=" + adForUserId);

                ////-- Load User Info
                //LoadUserRvwInfo(adForUserId);

                ////-- Load Ads By UserId
                //LoadAdsByUserId(adForUserId, adType);

                ////-- Load Latest Ads
                //Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }

            //-- Highlight Selected Ads List and set List Header
            if (adType == 1)
            {
                liAdsForSale.Attributes.Clear();
                liAdsToBuy.Attributes.Add("class", "active");

                itaListHeader.Attributes.Add("class", "fa fa-shopping-cart");
                lblListHeader.Text = "Book Ads - Looking To Buy";
            }
            else if (adType == 2)
            {
                liAdsForSale.Attributes.Add("class", "active");
                liAdsToBuy.Attributes.Clear();

                itaListHeader.Attributes.Add("class", "fa fa-shopping-basket");
                lblListHeader.Text = "Book Ads - For Sale";
            }

            //-- Set links for SideBar menu
            lnkAdsForSale.Attributes.Add("href", "ProfileAds.aspx?XAT=2&XID=" + adForUserId);
            lnkAdsToBuy.Attributes.Add("href", "ProfileAds.aspx?XAT=1&XID=" + adForUserId);
            lnkReviewAsSeller.Attributes.Add("href", "ProfileRatings.aspx?XRV=2&XID=" + adForUserId);
            lnkReviewAsBuyer.Attributes.Add("href", "ProfileRatings.aspx?XRV=1&XID=" + adForUserId);

            //-- Load User Info
            LoadUserRvwInfo(adForUserId);

            //-- Load Ads By UserId
            LoadAdsByUserId(adForUserId, adType);

            //-- Load Latest Ads
            Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
        }

        private bool LoadUserRvwInfo(string _userId)
        {
            bool showDisplayName = false;

            try
            {
                using (SqlConnection cnUserInfo = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdUserInfo = new SqlCommand(Common.sqlUserInfoByUserId, cnUserInfo);
                    cmdUserInfo.CommandType = CommandType.Text;

                    cmdUserInfo.Parameters.Clear();
                    cmdUserInfo.Parameters.AddWithValue("prmUserId", _userId);

                    cnUserInfo.Open();

                    SqlDataReader rdrUserInfo = cmdUserInfo.ExecuteReader();

                    if (rdrUserInfo.HasRows)
                    {
                        while (rdrUserInfo.Read())
                        {
                            //-- Store UserName 
                            hdnUserName.Value = rdrUserInfo["USR_USERNAME"].ToString(); 

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

                            if (rdrUserInfo["USR_PHOTO"].ToString() != "")
                                imgProfilePhoto.ImageUrl = "~/" + Common.pathPhotosUsers + "/" + _userId + "/"
                                    + rdrUserInfo["USR_PHOTO"].ToString();
                            else
                                imgProfilePhoto.ImageUrl = "~/" + Common.pathPhotosUsers + "/user.png";

                            lblProfileName.Text = displayName;
                            lblUserDateCreated.Text = Convert.ToDateTime(rdrUserInfo["USR_DATE_CREATED"].ToString()).ToString("yyyy-MM-dd");
                            lblLocation.Text = rdrUserInfo["CIT_NAME"].ToString() + ", " + rdrUserInfo["PRV_NAME"].ToString();
                            lblBiography.Text = rdrUserInfo["USR_BIOGRAPHY"].ToString();
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

        private bool LoadAdsByUserId(string _userId, int _adType)
        {
            try
            {
                sqlMyAds.SelectCommand = Common.sqlAdsByCategory;
                sqlMyAds.SelectCommand += "where usr.usr_user_id = @prmUserId ";
                sqlMyAds.SelectCommand += "and ads.adt_adtype_id = @prmAdTypeId ";

                sqlMyAds.SelectParameters.Clear();

                sqlMyAds.SelectParameters.Add("prmUserId", _userId);
                sqlMyAds.SelectParameters.Add("prmAdTypeId", _adType.ToString());

                sqlMyAds.SelectCommand += "order by ads.ads_title ";

                lvwMyAds.DataSource = null;
                lvwMyAds.DataSourceID = sqlMyAds.ID;

                lvwMyAds.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}