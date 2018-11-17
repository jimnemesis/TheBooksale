/* 
 * Application Name: The Booksale
 * File: InfoFaq.aspx.cs
 * File Description: Displays The Booksale's FAQs
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
    public partial class InfoFaq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                //-- Change menu items if logged in or not
                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                {
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
                }
                else
                {
                    //-- if not logged in, display "Logging" buttons and hide "My" buttons
                    liMyAccount.Visible = false;
                    liMyAds.Visible = false;
                    liMyReports.Visible = false;
                    liLogout.Visible = false;
                    liLogin.Visible = true;
                    liSignup.Visible = true;

                    //-- Side NavMenu - if logged in, display "My" links
                    liSNavMyAccount.Visible = false;
                    liSNavMyAdsAll.Visible = false;
                    liSNavMyAdsPending.Visible = false;
                    liSNavMyReports.Visible = false;
                }
            }
        }
    }
}