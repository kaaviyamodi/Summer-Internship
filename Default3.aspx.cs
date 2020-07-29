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

public partial class Default3 : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {

  }


  SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString.ToString());
  protected void Button1_Click(object sender, EventArgs e)
  {

    con.Open();
    string s = "select * from StudentInfo where MobileNo=@p1 ";

    SqlCommand cmd = new SqlCommand(s, con);

    cmd.Parameters.AddWithValue("@p1", txtmno.Text);

    SqlDataAdapter da = new SqlDataAdapter(cmd);

    DataTable dt = new DataTable();

    da.Fill(dt);
    con.Close();
    if (dt.Rows.Count > 0)
    {

      txtmno.Text = "";
      Label1.Text = "Mobile No Is All ready Register ";

    }


    else
    {

      con.Open();
      string s1 = "insert into StudentInfo values (@p1,@p2) ";

      SqlCommand cmd1 = new SqlCommand(s1, con);

      cmd1.Parameters.AddWithValue("@p1", txtmno.Text);

      cmd1.Parameters.AddWithValue("@p2", TextBox2.Text);

      cmd1.ExecuteNonQuery();

      con.Close();
      txtmno.Text = "";
      Label1.Text = "Data Inserted ";

    }

  }

}
