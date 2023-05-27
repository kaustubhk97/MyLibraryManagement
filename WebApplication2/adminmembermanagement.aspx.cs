using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
   
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e) //Delete button
        {
            if(TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert(' Member Id cannot be blank');</script>");
            }
            else
            {
                if(checkIfmemberExists())
                {
                    DeleteMember();
                    ClearForm();
                }
                else
                { 
                Response.Write("<script>alert(' Member with this Id does not exist');</script>");
                }

            }
            
        }
        
        protected void LinkButton1_Click(object sender, EventArgs e) //Success button to set active status
        {
            if(checkIfmemberExists())
            {
                UpdateMemberStatusbyID("active");
            }
            else
            {
                Response.Write("<script>alert(' Member with this Id does not exist');</script>");
            }
           
        }

        protected void LinkButton4_Click(object sender, EventArgs e) //Go button
        {
            if(checkIfmemberExists())
            {
                GetmemberbyID();
            }
            else
            {
                Response.Write("<script>alert(' Member with this Id does not exist');</script>");
            }

        }

        protected void LinkButton2_Click(object sender, EventArgs e)//spinner button to set active pending
        {
            if (checkIfmemberExists())
            {
                UpdateMemberStatusbyID("pending");
            }
            else
            {
                Response.Write("<script>alert(' Member with this Id does not exist');</script>");
            }
           
        }

        protected void LinkButton3_Click(object sender, EventArgs e)//red button to set deactive
        {

            if (checkIfmemberExists())
            {
                UpdateMemberStatusbyID("deactive");
            }
            else
            {
                Response.Write("<script>alert(' Member with this Id does not exist');</script>");
            }
           
        }
        void GetmemberbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from member_master_tbl where member_id='" + TextBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox3.Text= dr.GetValue(2).ToString();
                        TextBox7.Text= dr.GetValue(10).ToString();
                        TextBox8.Text= dr.GetValue(1).ToString();
                        TextBox4.Text= dr.GetValue(3).ToString();
                        TextBox9.Text= dr.GetValue(4).ToString();
                        TextBox10.Text= dr.GetValue(5).ToString();
                        TextBox11.Text= dr.GetValue(6).ToString();
                        TextBox6.Text= dr.GetValue(7).ToString();
                       

                    }
                   

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
        void UpdateMemberStatusbyID(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "update member_master_tbl set account_status='"+status+ "' where member_id='"+TextBox1.Text.Trim()+"'";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Member Status updated');</script>");
               

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           
        }
        void DeleteMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "Delete from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Member Deleted Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkIfmemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from member_master_tbl where member_id='" + TextBox1.Text + "'";

                SqlCommand cmd = new SqlCommand(q, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void ClearForm()
        {
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox4.Text = "";
            TextBox9.Text = "";
            TextBox10.Text ="";
            TextBox11.Text ="";
            TextBox6.Text = "";
            TextBox1.Text = "";
        }
    }
}