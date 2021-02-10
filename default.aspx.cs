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


public partial class _default : System.Web.UI.Page
{
    dbConnect dbconn = new dbConnect();
    ReportDocument rpt = new ReportDocument();

    string ssql;
    SqlConnection conn = new SqlConnection();
    SqlCommand comm = new SqlCommand();

    DataTable dt = new DataTable();

    public string strMsgAlert = "";
    public string strTblDetail = "";

    public string strstartdate;
    public string strenddate;
    public string strispaid;

    public string strTblDetails = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        //    Public Sub msgOKonly(ByVal Message As String)
        //    Dim strScript As String = "<script language = JavaScript > "
        //    strScript += "alert(""" & Message & """);"
        //    strScript += "</script>"
        //    If(Not Page.IsStartupScriptRegistered("clientScript")) Then
        //        Page.RegisterStartupScript("clientScript", strScript)
        //    End If
        //End Sub

        if (!IsPostBack)
        {
            DateTime datenow = DateTime.Now;
            var startDate = new DateTime(datenow.Year, datenow.Month, 1);

            Session["startdate"] = startDate.ToString("yyyy-MM-dd");
            Session["enddate"] = datenow.ToString("yyyy-MM-dd");
        }
        else
        {

        }
    }

   
    public void btnGetCommission_click(object sender, EventArgs e)
    {
        try
        {
            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];

            conn = new SqlConnection();
            conn = dbconn.OpenConn();
            
            comm = new SqlCommand("spKeyCut_CommTransaction", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@startdate", strstartdate);
            comm.Parameters.AddWithValue("@enddate", strenddate);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //Response.Write("<script>alert('Okay, data is have more rows..')</script>");

                ssql = "delete from KeyCut_CommTransaction where arDocuDate between '"+ strstartdate +"' and '"+ strenddate +"' ";
                comm = new SqlCommand(ssql, conn);
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
                
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    conn = dbconn.OpenConn();
                    string BrchID = dt.Rows[i]["BrchID"].ToString();
                    string DocuDate = dt.Rows[i]["DocuDate"].ToString();
                    string InvNo = dt.Rows[i]["InvNo"].ToString();
                    string CustID = dt.Rows[i]["CustID"].ToString();
                    string CustName = dt.Rows[i]["CustName"].ToString();
                    string ProductCode = dt.Rows[i]["ProductCode"].ToString();
                    string GoodGroupName = dt.Rows[i]["GoodGroupName"].ToString();
                    string GoodCode = dt.Rows[i]["GoodCode"].ToString();
                    string GoodName1 = dt.Rows[i]["GoodName1"].ToString();
                    string Amount = dt.Rows[i]["Amount"].ToString();
                    string RF = dt.Rows[i]["RF"].ToString();
                    string RentAmount = dt.Rows[i]["RentAmount"].ToString();
                    string TotalPrice = dt.Rows[i]["TotalPrice"].ToString();
                    string RentCom = dt.Rows[i]["RentCom"].ToString();
                    string RentOther = dt.Rows[i]["RentOther"].ToString();
                    string NetCom = dt.Rows[i]["NetCom"].ToString();
                    string NetPrice = dt.Rows[i]["NetPrice"].ToString();
                    string NetRF_B = dt.Rows[i]["NetRF_B"].ToString();
                    string NetRF_P = dt.Rows[i]["NetRF_P"].ToString();
                    string NetCutSale = dt.Rows[i]["NetCutSale"].ToString();
                    string TotalCutSale = dt.Rows[i]["TotalCutSale"].ToString();
                    string SaleName = dt.Rows[i]["SaleName"].ToString();
                    string Project = dt.Rows[i]["Project"].ToString();
                    string ContactName = dt.Rows[i]["ContactName"].ToString();
                    string CardID = dt.Rows[i]["CardID"].ToString();
                    string CheqDate = dt.Rows[i]["CheqDate"].ToString();
                    string DocuNo = dt.Rows[i]["DocuNo"].ToString();
                    string arDocuDate = dt.Rows[i]["arDocuDate"].ToString();
                    string Pre_CutR1 = dt.Rows[i]["Pre_CutR1"].ToString();
                    string NetPreCutR1 = dt.Rows[i]["NetPreCutR1"].ToString();
                    string CommAmount = dt.Rows[i]["CommAmount"].ToString();


                    ssql = "insert into KeyCut_CommTransaction (BrchID, DocuDate, InvNo, CustID, CustName, ProductCode, GoodGroupName, GoodCode,  " +
                           "    GoodName1, Amount, RF, RentAmount, TotalPrice, RentCom, RentOther, NetCom, NetPrice, NetRF_B, NetRF_P, " +
                           "    NetCutSale, TotalCutSale, SaleName, Project, ContactName, CardID, CheqDate, DocuNo, arDocuDate, PercentProcessFee, " +
                           "    AmountProcessFee, GrandCommission, isPaid, DatePaid, isRemark, EmpCode, LastedUpdate) " +
                           "values (@BrchID, @DocuDate, @InvNo, @CustID, @CustName, @ProductCode, @GoodGroupName, @GoodCode,  " +
                           "    @GoodName1, @Amount, @RF, @RentAmount, @TotalPrice, @RentCom, @RentOther, @NetCom, @NetPrice, @NetRF_B, @NetRF_P, " +
                           "    @NetCutSale, @TotalCutSale, @SaleName, @Project, @ContactName, @CardID, @CheqDate, @DocuNo, @arDocuDate, @PercentProcessFee, " +
                           "    @AmountProcessFee, @GrandCommission, @isPaid, @DatePaid, @isRemark, @EmpCode, @LastedUpdate) ";
                    comm = new SqlCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = ssql;
                    comm.Connection = conn;
                    comm.Parameters.Clear();

                    comm.Parameters.Add("@BrchID", SqlDbType.NVarChar).Value = BrchID;
                    comm.Parameters.Add("@DocuDate", SqlDbType.NVarChar).Value = DocuDate;
                    comm.Parameters.Add("@InvNo", SqlDbType.NVarChar).Value = InvNo;
                    comm.Parameters.Add("@CustID", SqlDbType.NVarChar).Value = CustID;
                    comm.Parameters.Add("@CustName", SqlDbType.NVarChar).Value = CustName;
                    comm.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = ProductCode;
                    comm.Parameters.Add("@GoodGroupName", SqlDbType.NVarChar).Value = GoodGroupName;
                    comm.Parameters.Add("@GoodCode", SqlDbType.NVarChar).Value = GoodCode;
                    comm.Parameters.Add("@GoodName1", SqlDbType.NVarChar).Value = GoodName1;
                    comm.Parameters.Add("@Amount", SqlDbType.Float).Value = decimal.Parse(Amount);
                    comm.Parameters.Add("@RF", SqlDbType.Float).Value = decimal.Parse(RF);
                    comm.Parameters.Add("@RentAmount", SqlDbType.Float).Value = decimal.Parse(RentAmount);
                    comm.Parameters.Add("@TotalPrice", SqlDbType.Float).Value = decimal.Parse(TotalPrice);
                    comm.Parameters.Add("@RentCom", SqlDbType.Float).Value = decimal.Parse(RentCom);
                    comm.Parameters.Add("@RentOther", SqlDbType.Float).Value = decimal.Parse(RentOther);
                    comm.Parameters.Add("@NetCom", SqlDbType.Float).Value = decimal.Parse(NetCom);
                    comm.Parameters.Add("@NetPrice", SqlDbType.Float).Value = decimal.Parse(NetPrice);
                    comm.Parameters.Add("@NetRF_B", SqlDbType.Float).Value = decimal.Parse(NetRF_B);
                    comm.Parameters.Add("@NetRF_P", SqlDbType.Float).Value = decimal.Parse(NetRF_P);
                    comm.Parameters.Add("@NetCutSale", SqlDbType.Float).Value = decimal.Parse(NetCutSale);
                    comm.Parameters.Add("@TotalCutSale", SqlDbType.Float).Value = decimal.Parse(TotalCutSale);
                    comm.Parameters.Add("@SaleName", SqlDbType.NVarChar).Value = SaleName;
                    comm.Parameters.Add("@Project", SqlDbType.NVarChar).Value = Project;
                    comm.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = ContactName;
                    comm.Parameters.Add("@CardID", SqlDbType.NVarChar).Value = CardID;
                    comm.Parameters.Add("@CheqDate", SqlDbType.NVarChar).Value = CheqDate;
                    comm.Parameters.Add("@DocuNo", SqlDbType.NVarChar).Value = DocuNo;
                    comm.Parameters.Add("@arDocuDate", SqlDbType.DateTime).Value = DateTime.Parse(arDocuDate);
                    comm.Parameters.Add("@PercentProcessFee", SqlDbType.Float).Value = decimal.Parse(Pre_CutR1);
                    comm.Parameters.Add("@AmountProcessFee", SqlDbType.Float).Value = decimal.Parse(NetPreCutR1);
                    comm.Parameters.Add("@GrandCommission", SqlDbType.Float).Value = decimal.Parse(CommAmount);
                    comm.Parameters.Add("@isPaid", SqlDbType.NVarChar).Value = "0";
                    comm.Parameters.Add("@DatePaid", SqlDbType.NVarChar).Value = DBNull.Value;
                    comm.Parameters.Add("@isRemark", SqlDbType.NVarChar).Value = DBNull.Value;
                    comm.Parameters.Add("@EmpCode", SqlDbType.NVarChar).Value = DBNull.Value;
                    comm.Parameters.Add("@LastedUpdate", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                
                GetUpdateSaleCommissionFinal(strstartdate, strenddate);

                GetDataSaleCommission(strstartdate, strenddate);
                               
            }

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;

            //string datepickertrans = Request.Form["datepickertrans"];
            //string datepickerend = Request.Form["datepickerend"];

  


        }
        catch (Exception ex)
        {
            //Response.Write("<script>alert('Data Error.., "+ex.Message+" ')</script>");

            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                              "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
                              "</div>";

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;
        }        
    }

    protected void GetUpdateSaleCommissionFinal(string startdate, string enddate)
    {
        try
        {
            conn = new SqlConnection();
            conn = dbconn.OpenConn();

            comm = new SqlCommand("spKeyCut_CommTransactionFinal", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@strstartdate", startdate);
            comm.Parameters.AddWithValue("@strenddate", enddate);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;

            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                for (int i = 0; i <= dt2.Rows.Count - 1; i++)
                {
                    conn = dbconn.OpenConn();
                    string BrchID = dt2.Rows[i]["BrchID"].ToString();
                    string DocuDate = dt2.Rows[i]["DocuDate"].ToString();
                    string InvNo = dt2.Rows[i]["InvNo"].ToString();
                    string CustID = dt2.Rows[i]["CustID"].ToString();
                    string CustName = dt2.Rows[i]["CustName"].ToString();
                    string ProductCode = dt2.Rows[i]["ProductCode"].ToString();
                    string GoodGroupName = dt2.Rows[i]["GoodGroupName"].ToString();
                    string GoodCode = dt2.Rows[i]["GoodCode"].ToString();
                    string GoodName1 = dt2.Rows[i]["GoodName1"].ToString();
                    string Amount = dt2.Rows[i]["Amount"].ToString();
                    string RF = dt2.Rows[i]["RF"].ToString();
                    string RentAmount = dt2.Rows[i]["RentAmount"].ToString();
                    string TotalPrice = dt2.Rows[i]["TotalPrice"].ToString();
                    string RentCom = dt2.Rows[i]["RentCom"].ToString();
                    string RentOther = dt2.Rows[i]["RentOther"].ToString();
                    string NetCom = dt2.Rows[i]["NetCom"].ToString();
                    string NetPrice = dt2.Rows[i]["NetPrice"].ToString();
                    string NetRF_B = dt2.Rows[i]["NetRF_B"].ToString();
                    string NetRF_P = dt2.Rows[i]["NetRF_P"].ToString();
                    string NetCutSale = dt2.Rows[i]["NetCutSale"].ToString();
                    string TotalCutSale = dt2.Rows[i]["TotalCutSale"].ToString();
                    string SaleName = dt2.Rows[i]["SaleName"].ToString();
                    string Project = dt2.Rows[i]["Project"].ToString();

                    string RecpName = dt2.Rows[i]["RecpName"].ToString(); // ผู้รับเช็ค
                    string ContactName = dt2.Rows[i]["ContactName"].ToString();  // หัก ณ ที่จ่าย
                    
                    string CardID = dt2.Rows[i]["CardID"].ToString();
                    string CheqDate = dt2.Rows[i]["CheqDate"].ToString();
                    string DocuNo = dt2.Rows[i]["xDocuNo"].ToString();
                    string arDocuDate = dt2.Rows[i]["arDocuDate"].ToString();
                    string PercentProcessFee = dt2.Rows[i]["PercentProcessFee"].ToString();
                    string AmountProcessFee = dt2.Rows[i]["AmountProcessFee"].ToString();
                    string GrandCommission = dt2.Rows[i]["GrandCommission"].ToString();


                    ssql = "select * from KeyCut_CommTransactionFinal where BrchID='"+ BrchID + "' and DocuDate='"+ DocuDate + "' " + 
                            " and InvNo='"+ InvNo + "' and CustID='"+ CustID + "' and ProductCode='"+ ProductCode + "' and  GoodCode ='"+ GoodCode + "' ";
                    DataTable dt3 = new DataTable();
                    dt3 = dbconn.GetDataTable(ssql);

                    if (dt3.Rows.Count > 0)
                    {
                        // to do something or nothing..
                    }
                    else
                    {
                        // not found data --> insert new records
                        ssql = "insert into KeyCut_CommTransactionFinal (BrchID, DocuDate, InvNo, CustID, CustName, ProductCode, GoodGroupName, " +
                               "    GoodCode, GoodName1, Amount, RF, RentAmount, TotalPrice, RentCom, RentOther, NetCom, NetPrice, NetRF_B, " +
                               "    NetRF_P, NetCutSale, TotalCutSale, SaleName, Project, " +
                               "    ContactName, RecpName, CardID, CheqDate, DocuNo, arDocuDate, " +
                               "    PercentProcessFee, AmountProcessFee, GrandCommission, isPaid, DatePaid, isRemark, EmpCode, LastedUpdate) " +
                               "values (@BrchID, @DocuDate, @InvNo, @CustID, @CustName, @ProductCode, @GoodGroupName, " +
                               "    @GoodCode, @GoodName1, @Amount, @RF, @RentAmount, @TotalPrice, @RentCom, @RentOther, @NetCom, @NetPrice, @NetRF_B, " +
                               "    @NetRF_P, @NetCutSale, @TotalCutSale, @SaleName, @Project, @ContactName, @RecpName, @CardID, @CheqDate, @DocuNo, @arDocuDate, " +
                               "    @PercentProcessFee, @AmountProcessFee, @GrandCommission, @isPaid, @DatePaid, @isRemark, @EmpCode, @LastedUpdate) ";

                        comm = new SqlCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = ssql;
                        comm.Connection = conn;
                        comm.Parameters.Clear();
                        comm.Parameters.Add("@BrchID", SqlDbType.NVarChar).Value = BrchID;
                        comm.Parameters.Add("@DocuDate", SqlDbType.NVarChar).Value = DocuDate;
                        comm.Parameters.Add("@InvNo", SqlDbType.NVarChar).Value = InvNo;
                        comm.Parameters.Add("@CustID", SqlDbType.NVarChar).Value = CustID;
                        comm.Parameters.Add("@CustName", SqlDbType.NVarChar).Value = CustName;
                        comm.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = ProductCode;
                        comm.Parameters.Add("@GoodGroupName", SqlDbType.NVarChar).Value = GoodGroupName;
                        comm.Parameters.Add("@GoodCode", SqlDbType.NVarChar).Value = GoodCode;
                        comm.Parameters.Add("@GoodName1", SqlDbType.NVarChar).Value = GoodName1;
                        comm.Parameters.Add("@Amount", SqlDbType.Float).Value = decimal.Parse(Amount);
                        comm.Parameters.Add("@RF", SqlDbType.Float).Value = decimal.Parse(RF);
                        comm.Parameters.Add("@RentAmount", SqlDbType.Float).Value = decimal.Parse(RentAmount);
                        comm.Parameters.Add("@TotalPrice", SqlDbType.Float).Value = decimal.Parse(TotalPrice);
                        comm.Parameters.Add("@RentCom", SqlDbType.Float).Value = decimal.Parse(RentCom);
                        comm.Parameters.Add("@RentOther", SqlDbType.Float).Value = decimal.Parse(RentOther);
                        comm.Parameters.Add("@NetCom", SqlDbType.Float).Value = decimal.Parse(NetCom);
                        comm.Parameters.Add("@NetPrice", SqlDbType.Float).Value = decimal.Parse(NetPrice);
                        comm.Parameters.Add("@NetRF_B", SqlDbType.Float).Value = decimal.Parse(NetRF_B);
                        comm.Parameters.Add("@NetRF_P", SqlDbType.Float).Value = decimal.Parse(NetRF_P);
                        comm.Parameters.Add("@NetCutSale", SqlDbType.Float).Value = decimal.Parse(NetCutSale);
                        comm.Parameters.Add("@TotalCutSale", SqlDbType.Float).Value = decimal.Parse(TotalCutSale);
                        comm.Parameters.Add("@SaleName", SqlDbType.NVarChar).Value = SaleName;
                        comm.Parameters.Add("@Project", SqlDbType.NVarChar).Value = Project;

                        comm.Parameters.Add("@RecpName", SqlDbType.NVarChar).Value = RecpName;  // ผู้รับเช็ค
                        comm.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = ContactName; // หัก ณ ที่จ่าย
                       
                        comm.Parameters.Add("@CardID", SqlDbType.NVarChar).Value = CardID;
                        comm.Parameters.Add("@CheqDate", SqlDbType.NVarChar).Value = CheqDate;
                        comm.Parameters.Add("@DocuNo", SqlDbType.NVarChar).Value = DocuNo;
                        comm.Parameters.Add("@arDocuDate", SqlDbType.DateTime).Value = DateTime.Parse(arDocuDate);
                        comm.Parameters.Add("@PercentProcessFee", SqlDbType.Float).Value = decimal.Parse(PercentProcessFee);
                        comm.Parameters.Add("@AmountProcessFee", SqlDbType.Float).Value = decimal.Parse(AmountProcessFee);
                        comm.Parameters.Add("@GrandCommission", SqlDbType.Float).Value = decimal.Parse(GrandCommission);
                        comm.Parameters.Add("@isPaid", SqlDbType.NVarChar).Value = "0";
                        comm.Parameters.Add("@DatePaid", SqlDbType.NVarChar).Value = DBNull.Value;
                        comm.Parameters.Add("@isRemark", SqlDbType.NVarChar).Value = DBNull.Value;
                        comm.Parameters.Add("@EmpCode", SqlDbType.NVarChar).Value = DBNull.Value;
                        comm.Parameters.Add("@LastedUpdate", SqlDbType.DateTime).Value = DateTime.Now.ToString();
                        comm.ExecuteNonQuery();

                    }
                    conn.Close();
                }
            }    
        }
        catch (Exception ex)
        {
            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                              "      <strong>พบข้อผิดพลาด..! GetUpdateSaleCommissionFinal</strong> " + ex.Message + " " +
                              "</div>";
        }
    }

    protected void GetDataSaleCommission(string strstartdate, string strenddate)
    {
        try
        {
            ssql = "SELECT   ID, BrchID, convert(nvarchar(10), DocuDate, 126) DocuDate, InvNo, CustID, CustName, ProductCode, GoodGroupName, GoodCode, GoodName1, " +
                  "     Amount, RF, RentAmount, TotalPrice, RentCom, RentOther, NetCom, NetPrice, NetRF_B, NetRF_P, NetCutSale, " +
                  "     TotalCutSale, SaleName, Project, RecpName, ContactName, CardID, CheqDate, DocuNo, convert(nvarchar(10), arDocuDate, 126) as arDocuDate, PercentProcessFee, " +
                  "     AmountProcessFee, GrandCommission, case when isPaid=0 then 'ยังไม่จ่าย' when isPaid=2 then 'แบ่งชำระบางส่วน' else 'ชำระแล้ว' end as isPaid, convert(nvarchar(10), DatePaid, 126) as  DatePaid, isRemark, EmpCode, LastedUpdate  " +
                  "     ,ContactName2, CardID2, ContactName3, CardID3, isPaidType " +
                  "     , GrandCommission * 0.05 as gVat, GrandCommission - (GrandCommission * 0.05) as gwVat " +
                  "FROM KeyCut_CommTransactionFinal " +
                  "WHERE arDocuDate between '" + strstartdate + "' and  '" + strenddate + "' ";

            //ssql = "exec spKeyCut_CommTransactionFinal2 '" + strstartdate + "',  '" + strenddate + "' ";


            DataTable dtFinal = new DataTable();
            dtFinal = dbconn.GetDataTable(ssql);

            if (dtFinal.Rows.Count > 0)
            {
                for (int i = 0; i <= dtFinal.Rows.Count - 1; i++)
                {
                    string ID = dtFinal.Rows[i]["ID"].ToString();
                    string BrchID = dtFinal.Rows[i]["BrchID"].ToString();
                    string DocuDate = dtFinal.Rows[i]["DocuDate"].ToString();
                    string InvNo = dtFinal.Rows[i]["InvNo"].ToString();
                    string CustID = dtFinal.Rows[i]["CustID"].ToString();
                    string CustName = dtFinal.Rows[i]["CustName"].ToString();
                    string ProductCode = dtFinal.Rows[i]["ProductCode"].ToString();
                    string GoodGroupName = dtFinal.Rows[i]["GoodGroupName"].ToString();
                    string GoodCode = dtFinal.Rows[i]["GoodCode"].ToString();
                    string GoodName1 = dtFinal.Rows[i]["GoodName1"].ToString();
                    string Amount = dtFinal.Rows[i]["Amount"].ToString();
                    string RF = dtFinal.Rows[i]["RF"].ToString();
                    string RentAmount = dtFinal.Rows[i]["RentAmount"].ToString();
                    string TotalPrice = dtFinal.Rows[i]["TotalPrice"].ToString();
                    string RentCom = dtFinal.Rows[i]["RentCom"].ToString();
                    string RentOther = dtFinal.Rows[i]["RentOther"].ToString();
                    string NetCom = dtFinal.Rows[i]["NetCom"].ToString();
                    string NetPrice = dtFinal.Rows[i]["NetPrice"].ToString();
                    string NetRF_B = dtFinal.Rows[i]["NetRF_B"].ToString();
                    string NetRF_P = dtFinal.Rows[i]["NetRF_P"].ToString();
                    string NetCutSale = dtFinal.Rows[i]["NetCutSale"].ToString();
                    string TotalCutSale = dtFinal.Rows[i]["TotalCutSale"].ToString();
                    string SaleName = dtFinal.Rows[i]["SaleName"].ToString();
                    string Project = dtFinal.Rows[i]["Project"].ToString();

                    string RecpName = dtFinal.Rows[i]["RecpName"].ToString(); // ผู้รับเช็ค
                    string ContactName = dtFinal.Rows[i]["ContactName"].ToString(); // หัก ณ ที่จ่าย
                    
                    string CardID = dtFinal.Rows[i]["CardID"].ToString();
                    string CheqDate = dtFinal.Rows[i]["CheqDate"].ToString();
                    string DocuNo = dtFinal.Rows[i]["DocuNo"].ToString();
                    string arDocuDate = dtFinal.Rows[i]["arDocuDate"].ToString();
                    string PercentProcessFee = dtFinal.Rows[i]["PercentProcessFee"].ToString();
                    string AmountProcessFee = dtFinal.Rows[i]["AmountProcessFee"].ToString();
                    string GrandCommission = dtFinal.Rows[i]["GrandCommission"].ToString();
                    string isPaid = dtFinal.Rows[i]["isPaid"].ToString();
                    string DatePaid = dtFinal.Rows[i]["DatePaid"].ToString();
                    string isRemark = dtFinal.Rows[i]["isRemark"].ToString();
                    string EmpCode = dtFinal.Rows[i]["EmpCode"].ToString();
                    string LastedUpdate = dtFinal.Rows[i]["LastedUpdate"].ToString();
                    string ContactName2 = dtFinal.Rows[i]["ContactName2"].ToString();
                    string CardID2 = dtFinal.Rows[i]["CardID2"].ToString();
                    string ContactName3 = dtFinal.Rows[i]["ContactName3"].ToString();
                    string CardID3 = dtFinal.Rows[i]["CardID3"].ToString();
                    string isPaidType = dtFinal.Rows[i]["isPaidType"].ToString();
                    string gVat = dtFinal.Rows[i]["gVat"].ToString();
                    string gwVat = dtFinal.Rows[i]["gwVat"].ToString();

                    string cssTextHilight = "text-blue";
                    if (isPaid == "ชำระแล้ว")
                    {
                        cssTextHilight = "text-blue";
                    }
                    else
                    {
                        cssTextHilight = "text-red";
                    }

                    strTblDetail += "<tr> " +
                                            "<td class=\"hidden\">" + ID + "</td>" +
                                            "<td class=\"hidden\"> " + BrchID + "</td>" +
                                            "<td> " + DocuDate + "</td>" +
                                            "<td> " + InvNo + "</td>" +
                                            "<td class=\"hidden\">" + CustID + "</td>" +
                                            "<td class=\""+ cssTextHilight + "\">" + CustName + "</td>" +
                                            "<td class=\"hidden\">" + ProductCode + "</td>" +
                                            "<td>" + GoodGroupName + "</td>" +
                                            "<td class=\"hidden\">" + GoodCode + "</td>" +
                                            "<td>" + GoodName1 + "</td>" +
                                            "<td>" + Amount + "</td>" +
                                            "<td>" + RF + "</td>" +
                                            "<td>" + RentAmount + "</td>" +
                                            "<td>" + TotalPrice + "</td>" +
                                            "<td>" + RentCom + "</td>" +
                                            "<td>" + RentOther + "</td>" +
                                            "<td>" + NetCom + "</td>" +
                                            "<td>" + NetPrice + "</td>" +
                                            "<td>" + NetRF_B + "</td>" +
                                            "<td>" + NetRF_P + "</td>" +
                                            "<td>" + NetCutSale + "</td>" +
                                            "<td>" + TotalCutSale + "</td>" +
                                            "<td>" + SaleName + "</td>" +
                                            "<td>" + Project + "</td>" +

                                            "<td>" + RecpName + "</td>" +  // ผู้รับเช็ค
                                            "<td>" + ContactName + "</td>" +  // หัก ณ ที่จ่าย
                                            
                                            "<td>" + CardID + "</td>" +
                                            "<td>" + CheqDate + "</td>" +
                                            "<td>" + DocuNo + "</td>" +
                                            "<td>" + arDocuDate + "</td>" +
                                            "<td>" + PercentProcessFee + "</td>" +
                                            "<td>" + AmountProcessFee + "</td>" +
                                            "<td>" + GrandCommission + "</td>" +

                                            "<td>" + gVat + "</td>" +
                                            "<td>" + gwVat + "</td>" +

                                            "<td class=\"" + cssTextHilight + "\">" + isPaid + "</td>" +
                                            "<td>" + DatePaid + "</td>" +
                                            "<td>" + isRemark + "</td>" +
                                            "<td class=\"hidden\">" + ContactName2 + "</td>" +
                                            "<td class=\"hidden\">" + CardID2 + "</td>" +
                                            "<td class=\"hidden\">" + ContactName3 + "</td>" +
                                            "<td class=\"hidden\">" + CardID3 + "</td>" +
                                            "<td class=\"hidden\">" + isPaidType + "</td>" +                                            

                                       "</tr> ";
                }
            }
        }
        catch (Exception ex)
        {
            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                              "      <strong>พบข้อผิดพลาด..! GetDataSaleCommission</strong> " + ex.Message + " " +
                              "</div>";
        }
    }

    protected void btnUpdateData_click(object sender, EventArgs e)
    {
        try
        {
            string strservername = System.Environment.MachineName;
            string ID = Request.Form["txtID"];
            string CustID = Request.Form["txtCustID"];
            string CustName = Request.Form["txtCustName"];
            string SaleName = Request.Form["txtSaleName"];
            string RentOther = Request.Form["txtRentOther"];
            string Project = Request.Form["txtProject"];
            string ContactName = Request.Form["txtContactName"];
            string RecpName = Request.Form["txtRecpName"];
            string CardID = Request.Form["txtCardID"];
            string CheqDate = Request.Form["txtCheqDate"];
            string DocuNo = Request.Form["txtDocuNo"];
            string arDocuDate = Request.Form["datearDocuDate"];
            string PercentProcessFee = Request.Form["txtPercentProcessFee"];
            string AmountProcessFee = Request.Form["txtAmountProcessFee"];
            string GrandCommission = Request.Form["txtGrandCommission"];
            string isPaid = Request.Form["selectisPaid"];
            string DatePaid = Request.Form["dateDatePaid"];
            string isRemark = Request.Form["txtisRemark"];
            string EmpCode = strservername;
            string LastedUpdate = DateTime.Now.ToString();
            string ContactName2 = Request.Form["txtContactName2"];
            string CardID2 = Request.Form["txtCardID2"];
            string ContactName3 = Request.Form["txtContactName3"];
            string CardID3 = Request.Form["txtCardID3"];
            string isPaidType = Request.Form["selectisPaidType"];

            ssql = "select * from KeyCut_CommTransactionFinal where id='" + ID + "' and isPaidType='0' ";

            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            if (dt.Rows.Count != 0)
            {
                if (CustID != "" & ContactName != "")
                {
                    ssql = "select * from KeyCut_CommRece where CustID='" + CustID + "' ";
                    dt = new DataTable();
                    dt = dbconn.GetDataTable(ssql);

                    if (dt.Rows.Count == 0)
                    {
                        conn = new SqlConnection();
                        conn = dbconn.OpenConn();

                        ssql = "insert into KeyCut_CommRece (CustID, CustName, ContactName, CardID, isDelete) " +
                               "values ('" + CustID + "', '" + CustName + "', '" + ContactName + "', '" + CardID + "', '1') ";

                        comm = new SqlCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = ssql;
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        conn = new SqlConnection();
                        conn = dbconn.OpenConn();

                        ssql = "update KeyCut_CommRece set ContactName='" + ContactName + "', CardID='" + CardID + "', isDelete='1' " +
                               "where CustID='" + CustID + "' ";

                        comm = new SqlCommand();
                        comm.CommandType = CommandType.Text;
                        comm.CommandText = ssql;
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                if (ID != "" & Project != "")
                {
                    conn = new SqlConnection();
                    conn = dbconn.OpenConn();

                    ssql = "update KeyCut_CommTransactionFinal set RentOther=@RentOther, Project=@Project, SaleName=@SaleName, RecpName=@RecpName, ContactName=@ContactName, CardID=@CardID,  " +
                           "    CheqDate=@CheqDate, DocuNo=@DocuNo, arDocuDate=@arDocuDate, PercentProcessFee=@PercentProcessFee, AmountProcessFee=@AmountProcessFee, " +
                           "    GrandCommission=@GrandCommission, isRemark=@isRemark, EmpCode=@EmpCode, LastedUpdate=@LastedUpdate " +
                           "    , ContactName2=@ContactName2, CardID2=@CardID2, ContactName3=@ContactName3, CardID3=@CardID3 " +
                           "where ID=@ID ";
                    comm = new SqlCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = ssql;
                    comm.Connection = conn;
                    comm.Parameters.Clear();
                    comm.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
                    comm.Parameters.Add("@RentOther", SqlDbType.NVarChar).Value = RentOther;
                    comm.Parameters.Add("@Project", SqlDbType.NVarChar).Value = Project;
                    comm.Parameters.Add("@SaleName", SqlDbType.NVarChar).Value = SaleName;

                    comm.Parameters.Add("@RecpName", SqlDbType.NVarChar).Value = RecpName;  // ผู้รับเช็ค
                    comm.Parameters.Add("@ContactName", SqlDbType.NVarChar).Value = ContactName; // หัก ณ ที่จ่าย
                   
                    comm.Parameters.Add("@CardID", SqlDbType.NVarChar).Value = CardID;
                    comm.Parameters.Add("@CheqDate", SqlDbType.NVarChar).Value = CheqDate;
                    comm.Parameters.Add("@DocuNo", SqlDbType.NVarChar).Value = DocuNo;
                    comm.Parameters.Add("@arDocuDate", SqlDbType.NVarChar).Value = arDocuDate;
                    comm.Parameters.Add("@PercentProcessFee", SqlDbType.NVarChar).Value = PercentProcessFee;
                    comm.Parameters.Add("@AmountProcessFee", SqlDbType.NVarChar).Value = AmountProcessFee;
                    comm.Parameters.Add("@GrandCommission", SqlDbType.NVarChar).Value = GrandCommission;
                    //comm.Parameters.Add("@isPaid", SqlDbType.NVarChar).Value = isPaid;
                    //comm.Parameters.Add("@DatePaid", SqlDbType.NVarChar).Value = DatePaid;  //, DatePaid, isPaidType
                    comm.Parameters.Add("@isRemark", SqlDbType.NVarChar).Value = isRemark;
                    comm.Parameters.Add("@EmpCode", SqlDbType.NVarChar).Value = EmpCode;
                    comm.Parameters.Add("@LastedUpdate", SqlDbType.NVarChar).Value = LastedUpdate;
                    comm.Parameters.Add("@ContactName2", SqlDbType.NVarChar).Value = ContactName2;
                    comm.Parameters.Add("@CardID2", SqlDbType.NVarChar).Value = CardID2;
                    comm.Parameters.Add("@ContactName3", SqlDbType.NVarChar).Value = ContactName3;
                    comm.Parameters.Add("@CardID3", SqlDbType.NVarChar).Value = CardID3;
                    //comm.Parameters.Add("@isPaidType", SqlDbType.NVarChar).Value = isPaidType;
                    comm.ExecuteNonQuery();
                    conn.Close();
                }

                strstartdate = Session["startdate"].ToString(); // Request.Form["datepickertrans"];
                strenddate = Session["enddate"].ToString(); // Request.Form["datepickerend"];
            }
            GetDataSaleCommission(strstartdate, strenddate);
        }
        catch (Exception ex)
        {
            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                              "      <strong>พบข้อผิดพลาด..! btnUpdateData</strong> " + ex.Message + " " +
                              "</div>";

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;
        }

    }

    protected void btnDelete_click(object sender, EventArgs e)
    {
        try
        {
            string ID = Request.Form["txtID"];
            conn = new SqlConnection();
            conn = dbconn.OpenConn();

            ssql = "select * from KeyCut_CommTransactionFinal where id='" + ID + "' and isPaid='0' ";

            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            if (dt.Rows.Count != 0)
            {
                ssql = "delete from KeyCut_CommTransactionFinal where id='" + ID + "' ";

                comm = new SqlCommand();
                comm.CommandType = CommandType.Text;
                comm.CommandText = ssql;
                comm.Connection = conn;
                comm.ExecuteNonQuery();
                conn.Close();                
            }

            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];

            GetDataSaleCommission(strstartdate, strenddate);

        }
        catch (Exception ex)
        {
            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                             "      <strong>พบข้อผิดพลาด..! btnDelete</strong> " + ex.Message + " " +
                             "</div>";
            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;
        }
    }

    protected void btnExportExcel_click(object sender, EventArgs e)
    {
        try
        {
            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];

            //ssql = "select * from KeyCut_CommTransactionFinal where arDocuDate between '" + strstartdate + "' AND '" + strenddate + "'";
            ssql = "exec spKeyCut_CommReport '"+ strstartdate + "', '"+ strenddate + "'";
            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            GridView GridviewExport = new GridView();

            if (dt.Rows.Count != 0)
            {

                GridviewExport.DataSource = dt;
                GridviewExport.DataBind();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=ExportReport"+ strstartdate + "_" + strenddate + ".xls");
                Response.ContentType = "application/ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridviewExport.RenderControl(hw);
                string style = @"<style> td { mso-number-format:\@;} </style>";
                Response.Write(style);
                Response.Write(sw.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void btnDownload_click(object sender, EventArgs e)
    {
        try
        {
            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];
            strispaid = "2";

            ssql = "exec spKeyCut_CommReport3 '" + strstartdate + "', '" + strenddate + "', '"+ strispaid  + "'";
            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            if (dt.Rows.Count != 0)
            {
                rpt = new ReportDocument();
                rpt.Load(Server.MapPath("pages/reports/rptSaleCommission.rpt"));

                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();

                Tables CrTables;

                crConnectionInfo.ServerName = "192.168.1.4";
                crConnectionInfo.DatabaseName = "db_ampelweb";
                crConnectionInfo.UserID = "Ampel";
                crConnectionInfo.Password = "Amp7896321";
                CrTables = rpt.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)

                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }


                string gmonth = (Convert.ToDateTime(strenddate)).ToString("MMMM");
                int gyear = int.Parse((Convert.ToDateTime(strenddate)).ToString("yyyy"));

                rpt.SetParameterValue("@startdate", strstartdate);
                rpt.SetParameterValue("@enddate", strenddate);
                rpt.SetParameterValue("@ispaid", strispaid);
                rpt.SetParameterValue("pMonth", gmonth);
                rpt.SetParameterValue("pYear", gyear);

                //// this code is not support Chrome Browser...
                //rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "SaleCommission" + gmonth +","+ gyear);


                //please change above coding to this below..
                System.IO.Stream oStream = null;
                byte[] byteArray = null;
                oStream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rpt.Close();
                rpt.Dispose();
            }
        }
        catch (Exception ex)
        {

        }
    }
    
}