using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication2
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)// Go Button
        {
            getPublisherDetails();
        }

        protected void Button2_Click(object sender, EventArgs e)// Add Button
        {
            if(checkIfPublisherExists())
            {
                Response.Write("<script>alert('Publisher with this ID already exists, Try again using another ID');</script>");
            }
            else
            {
                addPublisher();
                clearForm();
               
            }

        }

        protected void Button3_Click(object sender, EventArgs e)// Update button
        {
            if(checkIfPublisherExists())
            {
                updatePublisher();
                clearForm();

            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID is not available');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)// Delete button
        {
            if(checkIfPublisherExists())
            {
                deletePublisher();
                clearForm();
            }
            else
            {
                Response.Write("<script>alert('Publisher with this ID is not available');</script>");
            }
        }
        void getPublisherDetails()
        {
            SqlConnection con = new SqlConnection(constr);
            string q = "select * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                TextBox2.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid Author ID');</script>");
            }
        }
        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "Delete from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "'";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Publisher Deleted Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "Select * from publisher_master_tbl where publisher_id='"+TextBox1.Text.Trim()+ "'";

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
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message.ToString() + "'');</script>");
                return false;
            }
        }
        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();

                }
                string q = "update publisher_master_tbl set publisher_name='"+TextBox2.Text.Trim()+ "' where publisher_id='"+TextBox1.Text.Trim()+"'";
               using (SqlCommand cmd=new SqlCommand(q,con))
                {
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                Response.Write("<script>alert('Publisher Updated Successfully');</script>");
                GridView1.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "insert into publisher_master_tbl (publisher_id,publisher_name) values(@publisher_id,@publisher_name)";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                Response.Write("<script>alert('Publisher added Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message.ToString()+"'');</script>");
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}