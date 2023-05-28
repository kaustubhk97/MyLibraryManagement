using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication2
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillAuthorPublisherValues();
            GridView1.DataBind();
        }

        protected void LinkButton4_Click(object sender, EventArgs e) //Go Button
        {


        }

        protected void Button1_Click(object sender, EventArgs e)//Add Button
        {
            if(checkIfBookExists())
            {
                Response.Write("<script>alert('Book with this ID already exists try some other book ID');</script>");
               
            }
            else
            {
                addnewBook();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)// Update Button
        {

        }

        protected void Button2_Click(object sender, EventArgs e)// Delete Button
        {

        }
        void fillAuthorPublisherValues()
        {
            try
            {

                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select author_name from author_master_tbl";
                SqlCommand cmd = new SqlCommand(q, con);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
              
                 DataTable dt = new DataTable();
                    da.Fill(dt);
                    DropDownList3.DataSource = dt;
                    DropDownList3.DataValueField = "author_name";
                    DropDownList3.DataBind();

                string q2 = "select publisher_name from publisher_master_tbl";

                cmd = new SqlCommand(q2, con);

                da = new SqlDataAdapter(cmd);

                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();



            }
            catch(Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void addnewBook()
        {
            try
            {
                string genres = "";
                foreach (int item in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[item] + ",";
                }

                SqlConnection con = new SqlConnection(constr);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "insert into book_master_tbl(book_id, book_name, genre, author_name, publisher_name, publish_date, language, edition, book_cost, no_of_pages, book_description, actual_stock, current_stock, book_img_link) values(@book_id, @book_name, @genre, @author_name, @publisher_name, @publish_date, @language, @edition, @book_cost, @no_of_pages, @book_description, @actual_stock, @current_stock, @book_img_link) ";

                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
               
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
               


            }
            catch
            {

            }
       
        }
        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(constr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string q = "select * from book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' OR book_name='"+TextBox2.Text.Trim()+"'";

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

    }
}