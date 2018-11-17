/* 
 * Application Name: The Booksale
 * File: RepDashboard.aspx.cs
 * File Description: Displays the Dashboard report
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
using System.Web.UI.HtmlControls;

namespace TheBooksale
{
    public partial class RepDashboard : System.Web.UI.Page
    {
        string userName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

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

                    LoadUserInfo(userName);

                }
                else
                {
                    //-- Redirect to Login page
                    Response.Redirect("Login.aspx");
                }
            }

            //-- Load 8 Latest Book Ads
            Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
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
                            //-- Load Counter Values
                            LoadCounterByUsers(rdrUserInfo["USR_USER_ID"].ToString());
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


        private bool LoadCounterByUsers(string _userId)
        {
            try
            {
                using (SqlConnection cnCounters = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdCounters = new SqlCommand(Common.sqlUserCount, cnCounters);
                    cmdCounters.CommandType = CommandType.Text;

                    cmdCounters.Parameters.Clear();
                    cmdCounters.Parameters.AddWithValue("prmUserId", _userId); 

                    cnCounters.Open();

                    SqlDataReader rdrCounters = cmdCounters.ExecuteReader();

                    if (rdrCounters.HasRows)
                    {
                        while (rdrCounters.Read())
                        {
                            lblCtrMyAdsTotal.Text = rdrCounters["COUNT_ADSTOTAL"].ToString();
                            lblCtrMyAdsViewsTotal.Text = rdrCounters["COUNT_VIEWSTOTAL"].ToString();
                            lblCtrMyReviewsForMe.Text = rdrCounters["COUNT_REVIEWSFORME"].ToString();
                            lblCtrMyReviewsByMe.Text = rdrCounters["COUNT_REVIEWSBYME"].ToString();
                            lblCtrMyAdsReserved.Text = rdrCounters["COUNT_ADSRESERVED"].ToString();
                            lblCtrMyAdsSold.Text = rdrCounters["COUNT_ADSSOLD"].ToString();
                        }
                    }

                    rdrCounters.Close();
                    cmdCounters.Dispose();
                    cnCounters.Close();
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