/* 
 * Application Name: The Booksale
 * File: RepOffers.aspx.cs
 * File Description: Displays the Offers (Looking to Buy Book Ads) report
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
    public partial class RepOffers : System.Web.UI.Page
    {
        int categoryFilter = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString[0].ToString() != "")
                categoryFilter = int.Parse(Request.QueryString[0].ToString());

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
                    Response.Redirect("Login.aspx"); 
                }

                //-- Load Filter Conditions
                Common.LoadConditionsDDL(ddlFltConditions);

            }

            //-- Load Ads - To Buy Ads Only (AdType = 1)
            LoadAdsByAdtType(1, categoryFilter, "");

            //-- Load Filter by Category based on Ad Type (Buyers' Ads only)
            LoadCategoryFilterListByAdType(1, categoryFilter);

            //-- Load Latest Ads
            Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
        }
        
        private bool LoadCategoryFilterListByAdType(int _adType, int _categoryFilter)
        {
            string sqlCategoriesByAdtType = ""; 

            try
            {
                lblHdrCategory.Text = "All Categories";

                using (SqlConnection cnCategoryFilterList = new SqlConnection(Common.cnBooksaleDB))
                {
                    //-- change Categories sql statement to filter To Buy Ads Only (AdtTypeId = 1)
                    sqlCategoriesByAdtType = Common.sqlCategories;
                    sqlCategoriesByAdtType = sqlCategoriesByAdtType.Replace("and ads.sta_status_id = 2 ", 
                        "and ads.sta_status_id = 2 and ads.adt_adtype_id = " + _adType.ToString() + " "); 

                    SqlCommand cmdCategoryFilterList = new SqlCommand(sqlCategoriesByAdtType, cnCategoryFilterList);
                    cmdCategoryFilterList.CommandType = CommandType.Text;

                    cnCategoryFilterList.Open();

                    SqlDataReader rdrCategoryFilterList = cmdCategoryFilterList.ExecuteReader();

                    if (rdrCategoryFilterList.HasRows)
                    {
                        while (rdrCategoryFilterList.Read())
                        {
                            HtmlGenericControl li = new HtmlGenericControl("li");

                            HtmlGenericControl anchor = new HtmlGenericControl("a");
                            anchor.Attributes.Add("href", "RepOffers.aspx?XCA=" + rdrCategoryFilterList["CAT_CATEGORY_ID"].ToString());

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

                            //-- TEMP: Since this is where the CatName can be easily retrieved, use it to update lblHdrCategory
                            if (int.Parse(rdrCategoryFilterList["CAT_CATEGORY_ID"].ToString()) == _categoryFilter)
                                lblHdrCategory.Text = rdrCategoryFilterList["CAT_CATEGORY_NAME"].ToString();
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
        
        private bool LoadAdsByAdtType(int _adtType, int _categoryId, string _filterString)
        {
            try
            {
                sqlOfferItems.SelectCommand = Common.sqlAdsByCategory;
                sqlOfferItems.SelectCommand += "where sta.sta_status_id = 2 "; //-- Only Published Book Ads
                sqlOfferItems.SelectCommand += "and ads.adt_adtype_id = " + _adtType.ToString() + " "; 

                sqlOfferItems.SelectParameters.Clear();

                if (_categoryId != 0)
                {
                    sqlOfferItems.SelectCommand += "and cat.cat_category_id = @prmCategoryId ";
                    sqlOfferItems.SelectParameters.Clear();
                    sqlOfferItems.SelectParameters.Add("prmCategoryId", _categoryId.ToString());
                }

                //-- Filter by Condition and/or Price 
                if (_filterString != "")
                {
                    sqlOfferItems.SelectCommand += _filterString;
                }

                lvwOfferItems.DataSource = null;
                lvwOfferItems.DataSourceID = sqlOfferItems.ID;

                lvwOfferItems.DataBind();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void btnFilterApply_Click(object sender, EventArgs e)
        {
            //-- Build filter string
            string filterString = FilterBuildString();
            if (filterString != "")
                //-- Load Ads - To Buy Ads Only (AdType = 1)
                LoadAdsByAdtType(1, categoryFilter, filterString); 
        }

        protected void btnFilterRemove_Click(object sender, EventArgs e)
        {
            //-- Clear Filter String
            LoadAdsByAdtType(1, categoryFilter, "");

            //-- Reset filters
            ddlFltConditions.SelectedIndex = 0;
            txtFltMinimum.Text = "";
            txtFltMaximum.Text = "";

            lblFilter.Text = "None";
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

    }
}