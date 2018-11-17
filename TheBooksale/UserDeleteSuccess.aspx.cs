/* 
 * Application Name: The Booksale
 * File: UserDeleteSuccess.aspx.cs
 * File Description: The page that is Displayed when a user account is successfully closed
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
    public partial class UserDeleteSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Clear Sessions
            Session.Clear();

            //-- Side NavMenu - if logged in, display "My" links
            liSNavMyAccount.Visible = false;
            liSNavMyAdsAll.Visible = false;
            liSNavMyAdsPending.Visible = false;
            liSNavMyReports.Visible = false;

        }
    }
}