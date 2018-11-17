/* 
 * Application Name: The Booksale
 * File: UserAds.aspx.cs
 * File Description: Allows a user to look at and update/deactivate their ads
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

namespace TheBooksale
{
    public partial class UserAds : System.Web.UI.Page
    {
        string userName = "";
        int adsListMode = 1; //-- 1 - Published Ads Only, 2 - Pending Ads Only

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Retrieve Mode of Displaying My Ads
            adsListMode = int.Parse(Request.QueryString[0].ToString());

            if (!Page.IsPostBack)
            {
                //-- Change menu items if logged in or not
                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                {
                    userName = Session["userName"].ToString();

                    //-- if logged in, display "My" buttons and hide "Logging" buttons
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

                    ////-- Load Ads By UserId Results
                    //LoadAdsByUserId(Session["userName"].ToString());
                }
                else
                {
                    //-- Redirect to Login page
                    Response.Redirect("Login.aspx");
                }

                ////-- Highlight Selected Ads List and set List Header
                //if (adsListMode == 1)
                //{
                //    liAllMyAds.Attributes.Clear(); 
                //    liPublishedAds.Attributes.Add("class", "active");
                //    liPendingAds.Attributes.Clear();

                //    itaListHeader.Attributes.Add("class", "fa fa-star-o");
                //    lblListHeader.Text = "Published Ads";
                //}
                //else if (adsListMode == 2)
                //{
                //    liAllMyAds.Attributes.Clear(); 
                //    liPublishedAds.Attributes.Clear();
                //    liPendingAds.Attributes.Add("class", "active");

                //    itaListHeader.Attributes.Add("class", "fa fa-hourglass-o");
                //    lblListHeader.Text = "Pending Approval";
                //}
                //else
                //{
                //    liAllMyAds.Attributes.Add("class", "active");
                //    liPublishedAds.Attributes.Clear();
                //    liPendingAds.Attributes.Clear();

                //    itaListHeader.Attributes.Add("class", "fa fa-credit-card");
                //    lblListHeader.Text = "All My Ads";
                //}

                ////-- Load Latest Ads
                //Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }

            if ((!string.IsNullOrEmpty(Session["userName"] as string)))
            {
                //-- Load Ads By UserId Results
                LoadAdsByUserId(Session["userName"].ToString());
            }

            //-- Highlight Selected Ads List and set List Header
            if (adsListMode == 1)
            {
                liAllMyAds.Attributes.Clear();
                liPublishedAds.Attributes.Add("class", "active");
                liPendingAds.Attributes.Clear();

                itaListHeader.Attributes.Add("class", "fa fa-star-o");
                lblListHeader.Text = "Published Ads";
            }
            else if (adsListMode == 2)
            {
                liAllMyAds.Attributes.Clear();
                liPublishedAds.Attributes.Clear();
                liPendingAds.Attributes.Add("class", "active");

                itaListHeader.Attributes.Add("class", "fa fa-hourglass-o");
                lblListHeader.Text = "Pending Approval";
            }
            else
            {
                liAllMyAds.Attributes.Add("class", "active");
                liPublishedAds.Attributes.Clear();
                liPendingAds.Attributes.Clear();

                itaListHeader.Attributes.Add("class", "fa fa-credit-card");
                lblListHeader.Text = "All My Ads";
            }

            //-- Load Latest Ads
            Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);

        }

        private bool LoadAdsByUserId(string _userName)
        {
            try
            {
                sqlMyAds.SelectCommand = Common.sqlAdsByCategory;
                sqlMyAds.SelectCommand += "where usr.usr_username = @prmUserName ";
                if (adsListMode == 1)
                    sqlMyAds.SelectCommand += "and sta.sta_status_id = 2 "; //-- Only Published Book Ads
                else if (adsListMode == 2)
                    sqlMyAds.SelectCommand += "and sta.sta_status_id in (0, 1) "; //-- Only Submitted and Under Review Ads
                else
                    sqlMyAds.SelectCommand += "and sta.sta_status_id <> 99 "; //-- If no filter, ignore Deactivated Ads

                sqlMyAds.SelectParameters.Clear();

                sqlMyAds.SelectParameters.Add("prmUserName", _userName);

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