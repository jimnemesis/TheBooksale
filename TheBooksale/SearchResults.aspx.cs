/* 
 * Application Name: The Booksale
 * File: SearchResults.aspx.cs
 * File Description: Displays the ads that meet the search results
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
    public partial class SearchResults : System.Web.UI.Page
    {
        int searchCategory = 0;
        int searchLocation = 0; 
        string searchKeyword = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            searchCategory = int.Parse(Request.QueryString[0].ToString());
            searchLocation = int.Parse(Request.QueryString[1].ToString());

            if (Request.QueryString[2].ToString() != "")
                searchKeyword = Request.QueryString[2].ToString();

            if (!Page.IsPostBack)
            {
                //searchCategory = int.Parse(Request.QueryString[0].ToString()); 
                //searchLocation = int.Parse(Request.QueryString[1].ToString());

                //if (Request.QueryString[2].ToString() != "")
                //    searchKeyword = Request.QueryString[2].ToString();

                ////-- Load Category List onto the DDL
                //Common.LoadCategoryDDL(ddlCategories);

                ////-- Load Locations (filtered with existing ads only) 
                ////Common.LoadLocationDDL(ddlLocations, 1, true, ""); 
                //Common.LoadLocationDDL(ddlLocations, 1, false, ""); //-- TEMP for test display all

                ////-- Load Filter Conditions
                //Common.LoadConditionsDDL(ddlFltConditions);

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
                    //-- if not logged in, display "Logging" buttons and hide "My" buttons
                    liHome.Visible = true;
                    liMyAccount.Visible = false;
                    liMyAds.Visible = false;
                    liMyReports.Visible = false;
                    liLogout.Visible = false;
                    liLogin.Visible = true;
                    liSignup.Visible = true;

                    //-- Side NavMenu - if not logged in, hide "My" links
                    liSNavMyAccount.Visible = false;
                    liSNavMyAdsAll.Visible = false;
                    liSNavMyAdsPending.Visible = false;
                    liSNavMyReports.Visible = false;
                }

                ////-- Load Ads By Search Results
                //LoadAdsBySearch(searchKeyword, searchCategory, searchLocation, "");

                //lblSearchKeyword.Text = "'" + searchKeyword + "', Category: " + Common.GetCatNameById(searchCategory)
                //    + ", Location: " + Common.GetPrvNameById(searchLocation);
                
                //-- Load Filter Conditions
                Common.LoadConditionsDDL(ddlFltConditions);
            }

            //-- Load Category List onto the DDL
            Common.LoadCategoryDDL(ddlCategories);

            //-- Load Locations (filtered with existing ads only) 
            //Common.LoadLocationDDL(ddlLocations, 1, true, ""); 
            Common.LoadLocationDDL(ddlLocations, 1, false, ""); //-- TEMP for test display all

            //-- Load Ads By Search Results
            LoadAdsBySearch(searchKeyword, searchCategory, searchLocation, "");

            lblSearchKeyword.Text = "'" + searchKeyword + "', Category: " + Common.GetCatNameById(searchCategory)
                + ", Location: " + Common.GetPrvNameById(searchLocation);

            //-- Load Category Filter List
            LoadCategoryFilterList();

            //-- Load Latest Ads
            Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
        }


        private bool LoadCategoryFilterList()
        {
            try
            {
                using (SqlConnection cnCategoryFilterList = new SqlConnection(Common.cnBooksaleDB))
                {
                    SqlCommand cmdCategoryFilterList = new SqlCommand(Common.sqlCategories, cnCategoryFilterList);
                    cmdCategoryFilterList.CommandType = CommandType.Text;

                    cnCategoryFilterList.Open();

                    SqlDataReader rdrCategoryFilterList = cmdCategoryFilterList.ExecuteReader();

                    if (rdrCategoryFilterList.HasRows)
                    {
                        while (rdrCategoryFilterList.Read())
                        {
                            HtmlGenericControl li = new HtmlGenericControl("li");

                            HtmlGenericControl anchor = new HtmlGenericControl("a");
                            anchor.Attributes.Add("href", "Categories.aspx?XCA=" + rdrCategoryFilterList["CAT_CATEGORY_ID"].ToString());

                            HtmlGenericControl italic = new HtmlGenericControl("i");
                            italic.Attributes.Add("class", rdrCategoryFilterList["CAT_ICON_FA"].ToString());

                            HtmlGenericControl span = new HtmlGenericControl("span");
                            span.Attributes.Add("class", "category-counter");
                            span.InnerText = "(" + rdrCategoryFilterList["COUNT_ADS"].ToString() + ")";

                            HtmlGenericControl spanCategoryName = new HtmlGenericControl("span");
                            spanCategoryName.InnerText = rdrCategoryFilterList["CAT_CATEGORY_NAME"].ToString() + " ";

                            anchor.Controls.Add(italic);
                            anchor.Controls.Add(spanCategoryName);
                            anchor.Controls.Add(span);

                            li.Controls.Add(anchor);
                            lstCategories.Controls.Add(li);
                        }
                    }

                    rdrCategoryFilterList.Close();
                    cmdCategoryFilterList.Dispose();
                    cnCategoryFilterList.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool LoadAdsBySearch(string _searchKeyword, int _searchCategory, int _searchLocation, string _filterString)
        {
            try
            {
                sqlSearchItems.SelectCommand = Common.sqlAdsByCategory;
                sqlSearchItems.SelectCommand += "where sta.sta_status_id = 2 "; //-- Only Published Book Ads
                sqlSearchItems.SelectCommand += "and ((upper(ads.ads_title) like '%' + @prmSearchKeyword + '%') ";
                sqlSearchItems.SelectCommand += "    or (upper(ads.ads_description) like '%' + @prmSearchKeyword + '%') ";
                sqlSearchItems.SelectCommand += "    or (upper(addt.add_author_name) like '%' + @prmSearchKeyword + '%') ";
                sqlSearchItems.SelectCommand += "    or (upper(aut.aut_name) like '%' + @prmSearchKeyword + '%')) ";
                sqlSearchItems.SelectParameters.Clear();

                //-- Replace all spaces in search keyword with %
                _searchKeyword = _searchKeyword.Replace(' ', '%');

                if (_searchKeyword != "")
                    sqlSearchItems.SelectParameters.Add("prmSearchKeyword", _searchKeyword.ToUpper());
                else
                    sqlSearchItems.SelectParameters.Add("prmSearchKeyword", "JAMES GAGNI"); //-- Shouldn't occur, but if it does, default to me

                //-- if Category is not All, filter by Category
                if (_searchCategory >= 1)
                {
                    sqlSearchItems.SelectCommand += "and cat.cat_category_id = @prmCategoryId ";
                    sqlSearchItems.SelectParameters.Add("prmCategoryId", _searchCategory.ToString());
                }

                //-- if Location is not All, filter by Location
                if (_searchLocation >= 1)
                {
                    sqlSearchItems.SelectCommand += "and prv.prv_province_id = @prmProvinceId ";
                    sqlSearchItems.SelectParameters.Add("prmProvinceId", _searchLocation.ToString());
                }

                //-- Filter by Condition and/or Price 
                if (_filterString != "")
                {
                    sqlSearchItems.SelectCommand += _filterString; 
                }

                sqlSearchItems.SelectCommand += "order by ads.ads_title ";

                lvwSearchItems.DataSource = null;
                lvwSearchItems.DataSourceID = sqlSearchItems.ID;

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
        
        protected void btnFilterApply_Click(object sender, EventArgs e)
        {
            //-- Build filter string
            string filterString = FilterBuildString();
            if (filterString != "")
                LoadAdsBySearch(searchKeyword, searchCategory, searchLocation, filterString);
        }

        private string FilterBuildString()
        {
            string filterString = "";
            lblFilter.Text = ""; 

            try
            {
                //-- Set Conditions Filter if "All" is not selected
                if (ddlFltConditions.SelectedIndex >= 1)
                {
                    filterString += " and con.con_condition_id = " + ddlFltConditions.SelectedValue + " ";
                    lblFilter.Text += "Condition = '" + ddlFltConditions.Items[ddlFltConditions.SelectedIndex].Text + "', "; 
                }

                //-- Set Conditions for Price if both Minimum and Maximum are not blank
                if ((txtFltMinimum.Text.Trim() != "") && (txtFltMaximum.Text.Trim() != ""))
                {
                    filterString += " and ads.ads_price between '" + txtFltMinimum.Text 
                        + "' and '" + txtFltMaximum.Text + "' ";
                    lblFilter.Text += "Price = " + txtFltMinimum.Text + " to " + txtFltMaximum.Text + ", ";
                }

                //-- Remove final comma and space ", " if lblFilter is not blank, else set to "None"
                if (lblFilter.Text.Trim() != "")
                    lblFilter.Text = lblFilter.Text.Substring(0, lblFilter.Text.Length - 2); 
                else
                    lblFilter.Text = "None";

                return filterString;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void btnFilterRemove_Click(object sender, EventArgs e)
        {
            //-- Clear Filter String
            LoadAdsBySearch(searchKeyword, searchCategory, searchLocation, "");

            //-- Reset filters
            ddlFltConditions.SelectedIndex = 0;
            txtFltMinimum.Text = ""; 
            txtFltMaximum.Text = "";

            lblFilter.Text = "None"; 
        }
    }
}