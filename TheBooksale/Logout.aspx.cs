/* 
 * Application Name: The Booksale
 * File: Logout.aspx.cs
 * File Description: The Logout Page 
 * Author: James L. Gagni Jr.
 * UPOU Student Number: 2016-30148
 * Course: IS 295 - Information System Project
 * Program: Master of Information Systems
 * Date: 28 August 2018
 */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheBooksale
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //-- Clear Sessions
            Session.Clear(); 

            //-- Redirect to Main Page
            Response.Redirect("Main.aspx"); 
        }
    }
}