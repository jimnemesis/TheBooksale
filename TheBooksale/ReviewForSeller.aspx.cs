/* 
 * Application Name: The Booksale
 * File: ReviewForSeller.aspx.cs
 * File Description: Allows a user to submit a Review for a Seller
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
    public partial class ReviewForSeller : System.Web.UI.Page
    {
        string userId = "";
        string userName = ""; 
        string adsId = "";
        int lastReviewId = 0; 

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Retrieve Ads Id
            adsId = Request.QueryString[0].ToString();
            userId = Request.QueryString[1].ToString();

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

                    //-- Load Rating Stars the DDL
                    Common.LoadReviewStars(ddlRating);

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

            //-- if AdsId is provided, load User Info via Ads Id
            if (adsId.Trim().Length >= 1)
                //-- Load Seller information for Review based on Ad Details
                LoadAdDetails(adsId);
            else
                //-- if AdsId is null and UserId is provided, load User Info via UserId
                LoadUserInfo(userId); 
        }

        private bool LoadAdDetails(string _adsId)
        {
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
                            //-- Seller Name
                            lblSellerName.Text = rdrAdsDetails["USR_FIRSTNAME"].ToString() 
                                + " " + rdrAdsDetails["USR_LASTNAME"].ToString();

                            hdnUserId.Value = rdrAdsDetails["USR_USER_ID"].ToString();
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


        private bool LoadUserInfo(string _userId)
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
                            //-- Name
                            lblSellerName.Text = rdrUserInfo["USR_FIRSTNAME"].ToString()
                                + " " + rdrUserInfo["USR_LASTNAME"].ToString();

                            hdnUserId.Value = rdrUserInfo["USR_USER_ID"].ToString();
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
                //-- Retrieve Last Review Id
                lastReviewId = int.Parse(Common.GetMaxReviewId());

                //-- Recreate Parameters, then Insert New Record using SqlDataSource object
                sqlAdReview.InsertParameters.Clear();

                sqlAdReview.InsertParameters.Add("prmRvwId", (lastReviewId + 1).ToString());
                sqlAdReview.InsertParameters.Add("prmUserId", Session["userId"].ToString());
                sqlAdReview.InsertParameters.Add("prmRvwForUserId", hdnUserId.Value);
                sqlAdReview.InsertParameters.Add("prmRate", ddlRating.SelectedValue);
                sqlAdReview.InsertParameters.Add("prmReview", txtReview.Text);

                //-- Save to Audit Log

                //-- Insert Review Record
                sqlAdReview.Insert();

                Response.Redirect("ReviewSuccess.aspx"); 
            }
            catch (Exception ex)
            {

            }
        }
    }
}