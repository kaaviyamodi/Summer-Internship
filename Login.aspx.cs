using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }
  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString());
  protected void Button1_Click(object sender, EventArgs e)
  {
    con.Open();
    string s = "select * from StudentInfo where MobileNo=@p1 and Password=@p2 ";

    SqlCommand cmd = new SqlCommand(s, con);

    cmd.Parameters.AddWithValue("@p1", txtmno.Text);

    cmd.Parameters.AddWithValue("@p2", TextBox2.Text);
    SqlDataAdapter da = new SqlDataAdapter(cmd);

    DataTable dt = new DataTable();

    da.Fill(dt);
    con.Close();
    if (dt.Rows.Count > 0)
    {

     
      Label1.Text = "Login Done.... ";
      Session["Mno"] = txtmno.Text;
      txtmno.Text = "";
      Response.Redirect("LoginIn.aspx");

    }

    else
    {
      txtmno.Text = "";
      Label1.Text = "Invalild Mobile No Or Password.. ";

    }
  }

}
