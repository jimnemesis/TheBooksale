/* 
 * Application Name: The Booksale
 * File: Default.aspx.cs
 * File Description: The app's default page. Just used for redirection
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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Redirect to Main Page
            Response.Redirect("Main.aspx"); 
        }
    }
}