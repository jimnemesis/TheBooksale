/* 
 * Application Name: The Booksale
 * File: AdsDeleteConfirm.aspx.cs
 * File Description: A Confirmation page before an ad is deactivated
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
    public partial class AdsDeleteConfirm : System.Web.UI.Page
    {
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

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (DeactivateAd(adsId))
                Response.Redirect("AdsDeleteSuccess.aspx"); 
        }

        private bool DeactivateAd(string _adsId)
        {
            //-- DeactivateAd
            //-- UPdate ad and set status to 99 for Deactivated
            //-- Parameters:
            //--    _adsId (string)
            //-- Return Value: bool

            try
            {
                //-- Recreate Parameters, then Update Record using SqlDataSource object
                sqlAdsMain.UpdateParameters.Clear();
                
                sqlAdsMain.UpdateParameters.Add("prmAdsId", adsId);

                //-- Save to Audit Log

                //-- Update main Ads Record
                sqlAdsMain.Update();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}