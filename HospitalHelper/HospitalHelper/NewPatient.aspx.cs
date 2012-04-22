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
            Tpid.Attributes.Add("onkeypress", "if(event.keyCode==13){document.all.Button1.Click();return false;}"); 


            if (Request.QueryString["PID"] != null)
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
                conn.Close();
            }
        }

        protected void Bsave_Click(object sender, EventArgs e)
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT PID FROM PATIENT WHERE PID=@PID", conn);
            comm.Parameters.Add("@PID", Tpid.Text);
            comm.ExecuteNonQuery();
            SqlDataReader reader = comm.ExecuteReader();


            if (reader.HasRows)//update
            {
                reader.Close();
                comm = new SqlCommand("UPDATE [PATIENT] SET [PNAME] = @PNAME, [PMARRIAGE] = @PMARRIAGE, [PFOLK] = @PFOLK, [PNATION] = @PNATION, [PBIRTHDAY] = @PBIRTHDAY, [PSEX] = @PSEX, [PRELIGE] = @PRELIGE, [PDEGREE] = @PDEGREE, [PEDUCATION] = @PEDUCATION, [PBIRTHCITY] = @PBIRTHCITY, [PBIRTHDISTRICT] = @PBIRTHDISTRICT, [PNATIVECITY] = @PNATIVECITY, [PNATIVEDISTRICT] = @PNATIVEDISTRICT, [PPROPERTY] = @PPROPERTY, [PFEETYPE] = @PFEETYPE, [PCARDNUM] = @PCARDNUM, [PJOB] = @PJOB, [PWORKUNIT] = @PWORKUNIT, [PWORKPLACE] = @PWORKPLACE, [PWORKTEL] = @PWORKTEL, [PWORKPOST] = @PWORKPOST, [PRESIDENCEPLACE] = @PRESIDENCEPLACE, [PHOMETEL] = @PHOMETEL, [PHOMECITY] = @PHOMECITY, [PHOMEDISTRICT] = @PHOMEDISTRICT, [PHOMEPLACE] = @PHOMEPLACE, [PCONNAME] = @PCONNAME, [PCONRELATION] = @PCONRELATION, [PCONPLACE] = @PCONPLACE, [PCONTEL] = @PCONTEL, [PCONPOST] = @PCONPOST, [PCONWORKUNIT] = @PCONWORKUNIT, [PCONHISTORYPEO] = @PCONHISTORYPEO, [PCOMMENT] = @PCOMMENT WHERE [PID] = @PID", conn);
            }
            else //insert
            {
                reader.Close();
                comm = new SqlCommand("INSERT INTO [PATIENT] ([PID], [PNAME], [PMARRIAGE], [PFOLK], [PNATION], [PBIRTHDAY],[PSEX], [PRELIGE], [PDEGREE], [PEDUCATION], [PBIRTHCITY], [PBIRTHDISTRICT], [PNATIVECITY], [PNATIVEDISTRICT], [PPROPERTY], [PFEETYPE], [PCARDNUM], [PJOB], [PWORKUNIT], [PWORKPLACE], [PWORKTEL], [PWORKPOST], [PRESIDENCEPLACE], [PHOMETEL], [PHOMECITY], [PHOMEDISTRICT], [PHOMEPLACE], [PCONNAME], [PCONRELATION], [PCONPLACE], [PCONTEL], [PCONPOST], [PCONWORKUNIT], [PCONHISTORYPEO], [PCOMMENT]) VALUES (@PID, @PNAME, @PMARRIAGE, @PFOLK, @PNATION, @PBIRTHDAY, @PSEX, @PRELIGE, @PDEGREE, @PEDUCATION, @PBIRTHCITY, @PBIRTHDISTRICT, @PNATIVECITY, @PNATIVEDISTRICT, @PPROPERTY, @PFEETYPE, @PCARDNUM, @PJOB, @PWORKUNIT, @PWORKPLACE, @PWORKTEL, @PWORKPOST, @PRESIDENCEPLACE, @PHOMETEL, @PHOMECITY, @PHOMEDISTRICT, @PHOMEPLACE, @PCONNAME, @PCONRELATION, @PCONPLACE, @PCONTEL, @PCONPOST, @PCONWORKUNIT, @PCONHISTORYPEO, @PCOMMENT)", conn);               
            }
            comm.Parameters.Add("@PID", Tpid.Text);
            comm.Parameters.Add("@PNAME", Tpname.Text);
            comm.Parameters.Add("@PMARRIAGE", Tpmarriage.Text);
            comm.Parameters.Add("@PFOLK", Tpfolk.Text);
            comm.Parameters.Add("@PNATION", Tpnation.Text);
            comm.Parameters.Add("@PBIRTHDAY", Tpbirthday.Text);
            comm.Parameters.Add("@PSEX", Tsex.Text);

            comm.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("FindPatient.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "info", "alert('yeah!')", true);
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalData"].ConnectionString;
            SqlConnection conn = new SqlConnection(strcon);
            conn.Open();

            SqlCommand comm = new SqlCommand("SELECT * FROM PATIENT WHERE PID=@PID", conn);
            comm.Parameters.Add("@PID", Tpid.Text.Trim());
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Tpname.Text = reader.GetString(1).ToString();
            }
        }
    }
}