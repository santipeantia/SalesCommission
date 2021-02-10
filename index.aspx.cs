using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;
using CrystalDecisions.Shared;


public partial class index : System.Web.UI.Page
{
    dbConnect dbconn = new dbConnect();
    ReportDocument rpt = new ReportDocument();

    string ssql;
    SqlConnection conn = new SqlConnection();
    SqlCommand comm = new SqlCommand();

    DataTable dt = new DataTable();

    public string strMsgAlert = "";
    public string strTblDetail = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetCommission_click(object sender, EventArgs e)
    {
        try
        {
            //string strstartdate = Request.Form["datepickertrans"];
            //string strenddate = Request.Form["datepickerend"];

            //conn = new SqlConnection();
            //conn = dbconn.OpenConn();

            //comm = new SqlCommand("spKeyCut_CommTransaction", conn);
            //comm.CommandType = CommandType.StoredProcedure;
            //comm.Parameters.AddWithValue("@startdate", strstartdate);
            //comm.Parameters.AddWithValue("@enddate", strenddate);

            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = comm;

            //dt = new DataTable();
            //da.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //    Response.Write("<script>alert('Okay, data is have more rows..')</script>");
            //}



        }
        catch (Exception ex)
        {
            //Response.Write("<script>alert('Data Error.., " + ex.Message + " ')</script>");

            //strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
            //                  "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
            //                  "</div>";
        }


    }
}