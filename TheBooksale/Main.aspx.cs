/* 
 * Application Name: The Booksale
 * File: Main.aspx.cs
 * File Description: The Main Page 
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

using System.Diagnostics; 

namespace TheBooksale
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //-- Load Category List onto the DDL
                Common.LoadCategoryDDL(ddlCategories);

                //-- Load Locations (filtered with existing ads only) 
                //Common.LoadLocationDDL(ddlLocations, 1, true, ""); 
                Common.LoadLocationDDL(ddlLocations, 1, false, ""); //-- TEMP for test display all

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

            //-- Load Main List of Categories
            LoadCategoriesMain();

            //-- Load Counter Values
            LoadCounters(); 

            //-- Load 8 Latest Book Ads
            Common.LoadLatestAds(8, sqlLatestAds, lvwLatestAds);
        }

        private bool LoadCategoriesMain()
        {
            try
            {
                using (SqlConnection cnCategoryMain = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdCategoryMain = new SqlCommand(Common.sqlCategories, cnCategoryMain);
                    cmdCategoryMain.CommandType = CommandType.Text;

                    cnCategoryMain.Open();

                    SqlDataReader rdrCategoryMain = cmdCategoryMain.ExecuteReader();

                    if (rdrCategoryMain.HasRows)
                    {
                        double delayCounter = 0.0; 

                        while (rdrCategoryMain.Read())
                        {
                            HtmlGenericControl div = new HtmlGenericControl("div");
                            div.Attributes.Add("class", "col-md-2 col-sm-3 col-xs-6 f-category wow fadeIn");
                            div.Attributes.Add("data-wow-delay", delayCounter.ToString() + "s"); 

                            HtmlGenericControl anchor = new HtmlGenericControl("a");
                            anchor.Attributes.Add("href", "Categories.aspx?XCA=" + rdrCategoryMain["CAT_CATEGORY_ID"].ToString());
                            //anchor.InnerText = rdrCategoryMain["CAT_CATEGORY_NAME"].ToString();

                            HtmlGenericControl div1 = new HtmlGenericControl("div");
                            div1.Attributes.Add("class", "icon"); 

                            HtmlGenericControl italic = new HtmlGenericControl("i");
                            italic.Attributes.Add("class", rdrCategoryMain["CAT_ICON_FA"].ToString());

                            div1.Controls.Add(italic); 

                            HtmlGenericControl h6 = new HtmlGenericControl("h6");
                            h6.InnerText = rdrCategoryMain["CAT_CATEGORY_NAME"].ToString();

                            anchor.Controls.Add(div1);
                            anchor.Controls.Add(h6); 
                            
                            div.Controls.Add(anchor);
                            divCategories.Controls.Add(div);

                            delayCounter += 0.2;
                        }
                    }

                    rdrCategoryMain.Close();
                    cmdCategoryMain.Dispose();
                    cnCategoryMain.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //-- Redirect to Search Results page with Search Keyword
            Response.Redirect("SearchResults.aspx?XCT=" + ddlCategories.SelectedValue 
                + "&XLC=" + ddlLocations.SelectedValue + "&XSR=" + Server.UrlEncode(txtSearch.Text)); 
        }

        private bool LoadCounters()
        {
            try
            {
                using (SqlConnection cnCounters = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdCounters = new SqlCommand(Common.sqlAdsCount, cnCounters);
                    cmdCounters.CommandType = CommandType.Text;

                    cnCounters.Open();

                    SqlDataReader rdrCounters = cmdCounters.ExecuteReader();

                    if (rdrCounters.HasRows)
                    {
                        while (rdrCounters.Read())
                        {
                            lblCtrAdsTotal.Text = rdrCounters["COUNT_ADSTOTAL"].ToString();
                            lblCtrLocations.Text = rdrCounters["COUNT_CITIES"].ToString();
                            lblCtrUsersActive.Text = rdrCounters["COUNT_USERSACTIVE"].ToString();
                            lblCtrAdsToday.Text = rdrCounters["COUNT_ADSTODAY"].ToString();
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