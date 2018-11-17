/* 
 * Application Name: The Booksale
 * File: UserDeleteConfirm.aspx.cs
 * File Description: The page that is Displayed To Confirm if a user account is to be closed
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
    public partial class UserDeleteConfirm : System.Web.UI.Page
    {
        string userId = ""; 

        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Retrieve User Id
            userId = Request.QueryString[0].ToString();

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
            if (DeactivateUser(userId))
                Response.Redirect("UserDeleteSuccess.aspx");
        }
        
        private bool DeactivateUser(string _userId)
        {
            //-- DeactivateUser
            //-- Close User Account and set status to 0 for Inactive
            //-- Parameters:
            //--    _userId (string)
            //-- Return Value: bool

            try
            {
                //-- Recreate Parameters, then Update Record using SqlDataSource object
                sqlUser.UpdateParameters.Clear();

                sqlUser.UpdateParameters.Add("prmUserId", _userId);

                //-- Save to Audit Log

                //-- Update main Ads Record
                sqlUser.Update();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}