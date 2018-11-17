/* 
 * Application Name: The Booksale
 * File: Login.aspx.cs
 * File Description: The Login Page 
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {//-- Change menu items if logged in or not
                if ((!string.IsNullOrEmpty(Session["userName"] as string)))
                {
                    //-- Side NavMenu - if logged in, display "My" links
                    liSNavMyAccount.Visible = true;
                    liSNavMyAdsAll.Visible = true;
                    liSNavMyAdsPending.Visible = true;
                    liSNavMyReports.Visible = true;
                }
                else
                {
                    //-- Side NavMenu - if logged in, display "My" links
                    liSNavMyAccount.Visible = false;
                    liSNavMyAdsAll.Visible = false;
                    liSNavMyAdsPending.Visible = false;
                    liSNavMyReports.Visible = false;
                }

                //-- Load Latest Ads
                Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }

            txtUsername.Focus(); 
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtUsername.Text.Trim() != "") || (txtPassword.Text.Trim() != ""))
            {
                //-- Check Login 
                if (GetUserInfo())
                {
                    //-- if Username and Password are valid
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    //-- if Username/Password is Invalid

                    //-- if vsErrorLogin session is null
                    if (Session["loginError"].ToString() == "")
                    {
                        //-- Display Error Message on Log-in page
                        msgLogin.Visible = true;
                        msgLogin.Attributes.Add("class", "text-danger shake animated h3 text-center");
                        msgLogin.InnerText = "Invalid Username or Password!";
                    }
                    else
                    {
                        //-- Display "The Booksale is unavailable" page
                        Response.Redirect("Unavailable.aspx");
                    }
                }
            }
            else
            {
                msgLogin.Visible = true;
                msgLogin.Attributes.Add("class", "text-danger shake animated h3 text-center");
                msgLogin.InnerText = "Username or Password cannot be blank!";
            }

        }

        private bool GetUserInfo()
        {
            //-- Get User Information 

            string userName, userPwd;

            try
            {
                //-- Retrieve Information for Currently Logged User and Save into Session variables --//
                txtUsername.Text = txtUsername.Text.Trim();
                Session["userName"] = txtUsername.Text;
                userName = Session["userName"].ToString();

                txtPassword.Text = txtPassword.Text.Trim();
                Session["userPwd"] = txtPassword.Text;
                userPwd = Session["userPwd"].ToString();

                //-- find UserId in DB
                using (SqlConnection cnSqlUserInfo = new SqlConnection(Common.cnBooksaleDB))
                {
                    //-- Add Case Sensitive Password Where condition to SQL Script
                    SqlCommand cmdUserInfo = new SqlCommand(Common.sqlUserInfo
                        + "and usr.usr_password = @prmUserPwd "
                        + "COLLATE SQL_Latin1_General_CP1_CS_AS ", cnSqlUserInfo);
                    cmdUserInfo.CommandType = CommandType.Text;
                    cmdUserInfo.Parameters.AddWithValue("prmUserName", userName);
                    cmdUserInfo.Parameters.AddWithValue("prmUserPwd", Common.Crypt(userPwd, 0));
                    cnSqlUserInfo.Open();
                    SqlDataReader rdrUserInfo = cmdUserInfo.ExecuteReader();

                    if (rdrUserInfo.HasRows)
                    {
                        while (rdrUserInfo.Read())
                        {
                            Session["roleId"] = rdrUserInfo["ROL_ROLE_ID"].ToString().Trim();
                            Session["userLName"] = rdrUserInfo["USR_LASTNAME"].ToString().Trim();
                            Session["userFName"] = rdrUserInfo["USR_FIRSTNAME"].ToString().Trim();
                            Session["roleDesc"] = rdrUserInfo["ROL_DESCRIPTION"].ToString().Trim();
                            Session["userId"] = rdrUserInfo["USR_USER_ID"].ToString().Trim();
                        }

                        cnSqlUserInfo.Close();

                        return true;
                        //-- END: create session via SP --//
                    }
                    else
                    {
                        cnSqlUserInfo.Close();
                        Session["loginError"] = "";
                        Session["userName"] = "";
                        Session["userPwd"] = "";
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["loginError"] = "Get User Info - Error: " + ex.Message.Trim();
                Session["loginError"] += "</br>Source: " + ex.Source.ToString();
                Session["loginError"] += "</br>StackTrace: " + ex.StackTrace.ToString();
                Session["loginError"] += "</br>TargetSite: " + ex.TargetSite.ToString();
                return false;
            }

        }
    }
}