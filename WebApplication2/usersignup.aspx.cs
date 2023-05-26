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
    public partial class usersignup : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(checkMemberExists())
            {
                Response.Write("<script>alert('Member already exists please use different id');</script>");
            }
            else 
            {
                signUpNewMember();
            }
            
        }

        //user define method

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from member_master_tbl where member_id='"+TextBox8.Text+"'";

                SqlCommand cmd = new SqlCommand(q, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if(dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


                con.Close();
                Response.Write("<script>alert('Sign Up Successfully');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
           
        }

        void signUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "INSERT INTO member_master_tbl (full_name, dob, contact_no, email, state, city, pincode, full_address, member_id, password, account_status) VALUES (@full_name, @dob, @contact_no, @email, @state, @city, @pincode, @full_address, @member_id, @password, @account_status)";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@full_name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@email", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@city", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@pincode", TextBox7.Text);
                    cmd.Parameters.AddWithValue("@full_address", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@member_id", TextBox8.Text);
                    cmd.Parameters.AddWithValue("@password", TextBox9.Text);
                    cmd.Parameters.AddWithValue("@account_status", "pending");

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Sign Up Successfully');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}