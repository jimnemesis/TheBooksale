/* 
 * Application Name: The Booksale
 * File: ForgotPasswordSuccess.aspx.cs
 * File Description: The page that is Displayed when the password has been sent to the authorized email
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
    public partial class ForgotPasswordSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //-- Load Latest Ads
                Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }
        }
    }
}