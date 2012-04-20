using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HospitalHelper
{
    public partial class NewPatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT * FROM PATIENT WHERE PID=@PID", conn);
            comm.Parameters.Add("@PID", Request.QueryString["PID"]);
            comm.ExecuteNonQuery();
            SqlDataReader reader = comm.ExecuteReader();
            reader.Read();
            Tpname.Text = reader.GetString(1);
            
        }

        protected void Bsave_Click(object sender, EventArgs e)
        {
           
        }
    }
}