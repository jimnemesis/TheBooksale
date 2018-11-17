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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmailPhone.Focus(); 

            if (!Page.IsPostBack)
            {
                //-- Load Latest Ads
                Common.LoadLatestAds(6, sqlLatestAds, lvwLatestAds);
            }
        }

        protected void btnSendPwd_Click(object sender, EventArgs e)
        {
            if (txtEmailPhone.Text != "")
            {
                //-- Get User Password via Email
                if (GetPassword(txtEmailPhone.Text) != "")
                {
                    msgPassword.Visible = false;
                    msgPassword.Attributes.Add("class", "");
                    msgPassword.InnerText = "";

                    //-- Send Password via Email
                    Response.Redirect("ForgotPasswordSuccess");
                }
                else
                {
                    msgPassword.Visible = true;
                    msgPassword.Attributes.Add("class", "text-danger shake animated h3 text-center");
                    msgPassword.InnerText = "That Phone/Email was not found!";
                }
            }
            else
            {
                msgPassword.Visible = true;
                msgPassword.Attributes.Add("class", "text-danger shake animated h3 text-center");
                msgPassword.InnerText = "The textbox cannot be blank!";
            }

        }

        private string GetPassword(string _emailPhone)
        {
            string pwd = ""; 
            try
            {
                using (SqlConnection cnGetPwd = new SqlConnection(Common.cnBooksaleDB))
                {
                    //-- Add Case Sensitive Password Where condition to SQL Script
                    SqlCommand cmdGetPwd = new SqlCommand(Common.sqlUserInfoByEmailPhone, cnGetPwd);
                    cmdGetPwd.CommandType = CommandType.Text;
                    cmdGetPwd.Parameters.AddWithValue("prmEmailPhone", _emailPhone);
                    cnGetPwd.Open();
                    SqlDataReader rdrGetPwd = cmdGetPwd.ExecuteReader();

                    if (rdrGetPwd.HasRows)
                    {
                        while (rdrGetPwd.Read())
                        {
                            pwd = Common.Crypt(rdrGetPwd["USR_PASSWORD"].ToString(), 1); 
                        }

                        cnGetPwd.Close();

                        return pwd;
                        //-- END: create session via SP --//
                    }
                    else
                    {
                        cnGetPwd.Close();
                        return "";
                    }
                }

                return pwd; 
            }
            catch (Exception ex)
            {
                return ""; 
            }
        }
    }
}