using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class adminlogin : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from admin_login_tbl where username='" + TextBox1.Text + "'AND password='" + TextBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        //Response.Write("<script>alert(' Login Successful ' );</script>");

                        Session["username"] = dr.GetValue(0).ToString();
                        Session["fullname"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                        
                    }
                    Response.Redirect("homepage.aspx");

                }
                else
                {
                    Response.Write("<script>alert(' please check login credentials once again ');</script>");
                }

                /*SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count>=1)
                {
                    Session["username"] = dr.GetValue(8).ToString();
                    Session["fullname"] = dr.GetValue(0).ToString();
                    Session["role"] = "User";
                    Session["status"] = dr.GetValue(10).ToString();
                    Response.Redirect("adminauthormanagement.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Check User Credentials again');</script>");
                }*/


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}