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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)//Add
        {
            if(checkIfAuthorExists())
            {
                Response.Write("<script>alert('author with this id already exists');</script>");
            }
            else
            {
                addNewAuthor();
                clearForm();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)//Update
        {
            if (checkIfAuthorExists())
            {
                updateAuthor();
                clearForm();


            }
            else
            {
                Response.Write("<script>alert('author does not exists');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)//Delete
        {
            if (checkIfAuthorExists())
            {
                deleteAuthor();
                clearForm();
            }
            else
            {
                Response.Write("<script>alert('author does not exists');</script>");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)// Go button
        {
            getAuthorByID();
        }
        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "Delete from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Author Deleted Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "'";

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
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
               
            }
        }
        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "Update author_master_tbl set author_name= @author_name where author_id='" + TextBox1.Text.Trim()+"'";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                   
                    cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Author Updated Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "INSERT INTO author_master_tbl (author_id,author_name) VALUES (@author_id,@author_name)";

                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());
 
                    // Execute the query
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                Response.Write("<script>alert('Author added Successfully');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from author_master_tbl where author_id='" + TextBox1.Text + "'";

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
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}