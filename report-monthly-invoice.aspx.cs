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

public partial class report_monthly_invoice : System.Web.UI.Page
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
    public string strrentcom;

    public string strTblDetails = "";

    protected void Page_Load(object sender, EventArgs e)
    {
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
            strrentcom = Request.Form["selectRentCom"];

            GetDataSaleCommission(strstartdate, strenddate, strrentcom);

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;

            Session["sel0"] = " ";
            Session["sel1"] = " ";
            Session["sel2"] = " ";

            if (strrentcom == "0")
            {
                Session["sel0"] = "selected";
            }
            else if (strrentcom == "1")
            {
                Session["sel1"] = "selected";
            }
            else if (strrentcom == "2")
            {
                Session["sel2"] = "selected";
            }
            else
            {
                Session["sel0"] = "";
                Session["sel1"] = "";
                Session["sel2"] = "";
            }

        }
        catch (Exception ex)
        {
            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                              "      <strong>พบข้อผิดพลาด..!</strong> " + ex.Message + " " +
                              "</div>";

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;
        }
    }

    protected void GetDataSaleCommission(string strstartdate, string strenddate, string strRentCom)
    {
        try
        {
            ssql = "SELECT row_number()over(order by DocuDate) as No, convert(nvarchar(10), DocuDate, 126) as DocuDate,InvNo,ProductCode,Product,GoodGroupCode,GoodGroupName,GoodCode,Model,GoodName,Amount, " +
                   "    RF,RentAmount,TotalPrice,RentCom,NetCom,RentOther,NetPrice,NetRF_B,NetRF_P,NetCutSale, NetItem, " +
                   "    GoodPattnCode,GoodPattnName,GoodColorCode,GoodColorName,CustCode,CustName,CustTypeCode,CustTypeName, " +
                   "    sRemark,GoodClassCode,GoodClassName,EmpCode,SaleName,Trs_P,JobsCode,JobsName,CustPONo " +
                  "FROM V_DataGolden_SaleCo ";

            if ((strRentCom == "0"))
            {
                ssql += " WHERE DocuDate between '" + strstartdate + "' and  '" + strenddate + "' and RentCom <= 0 ";
            }
            else if ((strRentCom == "1"))
            {
                ssql += " WHERE DocuDate between '" + strstartdate + "' and  '" + strenddate + "' and RentCom > 0 ";
            }
            else
            {
                ssql += " WHERE DocuDate between '" + strstartdate + "' and  '" + strenddate + "' ";
            }

            //ssql = "exec spKeyCut_CommReport2 '"+ strstartdate + "',  '"+ strenddate  + "', '"+ strispaid + "' ";

            DataTable dtFinal = new DataTable();
            dtFinal = dbconn.GetDataTable(ssql);

            if (dtFinal.Rows.Count > 0)
            {
                for (int i = 0; i <= dtFinal.Rows.Count - 1; i++)
                {
                    string No = dtFinal.Rows[i]["No"].ToString();
                    string DocuDate = dtFinal.Rows[i]["DocuDate"].ToString();
                    string InvNo = dtFinal.Rows[i]["InvNo"].ToString();
                    string ProductCode = dtFinal.Rows[i]["ProductCode"].ToString();
                    string Product = dtFinal.Rows[i]["Product"].ToString();
                    string GoodGroupCode = dtFinal.Rows[i]["GoodGroupCode"].ToString();
                    string GoodGroupName = dtFinal.Rows[i]["GoodGroupName"].ToString();
                    string GoodCode = dtFinal.Rows[i]["GoodCode"].ToString();
                    string Model = dtFinal.Rows[i]["Model"].ToString();
                    string GoodName = dtFinal.Rows[i]["GoodName"].ToString();
                    string Amount = dtFinal.Rows[i]["Amount"].ToString();
                    string RF = dtFinal.Rows[i]["RF"].ToString();
                    string RentAmount = dtFinal.Rows[i]["RentAmount"].ToString();
                    string TotalPrice = dtFinal.Rows[i]["TotalPrice"].ToString();
                    string RentCom = dtFinal.Rows[i]["RentCom"].ToString();
                    string NetCom = dtFinal.Rows[i]["NetCom"].ToString();
                    string RentOther = dtFinal.Rows[i]["RentOther"].ToString();
                    string NetPrice = dtFinal.Rows[i]["NetPrice"].ToString();
                    string NetRF_B = dtFinal.Rows[i]["NetRF_B"].ToString();
                    string NetRF_P = dtFinal.Rows[i]["NetRF_P"].ToString();
                    string NetCutSale = dtFinal.Rows[i]["NetCutSale"].ToString();
                    string NetItem = dtFinal.Rows[i]["NetItem"].ToString();
                    string GoodPattnCode = dtFinal.Rows[i]["GoodPattnCode"].ToString();
                    string GoodPattnName = dtFinal.Rows[i]["GoodPattnName"].ToString();
                    string GoodColorCode = dtFinal.Rows[i]["GoodColorCode"].ToString();
                    string GoodColorName = dtFinal.Rows[i]["GoodColorName"].ToString();
                    string CustCode = dtFinal.Rows[i]["CustCode"].ToString();
                    string CustName = dtFinal.Rows[i]["CustName"].ToString();
                    string CustTypeCode = dtFinal.Rows[i]["CustTypeCode"].ToString();
                    string CustTypeName = dtFinal.Rows[i]["CustTypeName"].ToString();
                    string sRemark = dtFinal.Rows[i]["sRemark"].ToString();
                    string GoodClassCode = dtFinal.Rows[i]["GoodClassCode"].ToString();
                    string GoodClassName = dtFinal.Rows[i]["GoodClassName"].ToString();
                    string EmpCode = dtFinal.Rows[i]["EmpCode"].ToString();
                    string SaleName = dtFinal.Rows[i]["SaleName"].ToString();
                    string Trs_P = dtFinal.Rows[i]["Trs_P"].ToString();
                    string JobsCode = dtFinal.Rows[i]["JobsCode"].ToString();
                    string JobsName = dtFinal.Rows[i]["JobsName"].ToString();
                    string CustPONo = dtFinal.Rows[i]["CustPONo"].ToString();



                    strTblDetail += "<tr> " +
                                            "<td> " + No + "</td>" +
                                            "<td> " + DocuDate + "</td>" +
                                            "<td class=\"text-blue\"> " + InvNo + "</td>" +
                                            "<td> " + ProductCode + "</td>" +
                                            "<td> " + Product + "</td>" +
                                            "<td> " + GoodGroupCode + "</td>" +
                                            "<td> " + GoodGroupName + "</td>" +
                                            "<td> " + GoodCode + "</td>" +
                                            "<td> " + Model + "</td>" +
                                            "<td> " + GoodName + "</td>" +
                                            "<td> " + Amount + "</td>" +
                                            "<td> " + RF + "</td>" +
                                            "<td> " + RentAmount + "</td>" +
                                            "<td> " + TotalPrice + "</td>" +
                                            "<td> " + RentCom + "</td>" +
                                            "<td> " + NetCom + "</td>" +
                                            "<td> " + RentOther + "</td>" +
                                            "<td> " + NetPrice + "</td>" +
                                            "<td> " + NetRF_B + "</td>" +
                                            "<td> " + NetRF_P + "</td>" +
                                            "<td> " + NetCutSale + "</td>" +
                                            "<td> " + NetItem + "</td>" +
                                            "<td> " + GoodPattnCode + "</td>" +
                                            "<td> " + GoodPattnName + "</td>" +
                                            "<td> " + GoodColorCode + "</td>" +
                                            "<td> " + GoodColorName + "</td>" +
                                            "<td> " + CustCode + "</td>" +
                                            "<td> " + CustName + "</td>" +
                                            "<td> " + CustTypeCode + "</td>" +
                                            "<td> " + CustTypeName + "</td>" +
                                            "<td> " + sRemark + "</td>" +
                                            "<td> " + GoodClassCode + "</td>" +
                                            "<td> " + GoodClassName + "</td>" +
                                            "<td> " + EmpCode + "</td>" +
                                            "<td> " + SaleName + "</td>" +
                                            "<td> " + Trs_P + "</td>" +
                                            "<td> " + JobsCode + "</td>" +
                                            "<td> " + JobsName + "</td>" +
                                            "<td> " + CustPONo + "</td>" +
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

    protected void btnExportExcel_click(object sender, EventArgs e)
    {
        try
        {
            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];
            strrentcom = Request.Form["selectRentCom"];

            ssql = "SELECT row_number()over(order by DocuDate) as No, convert(nvarchar(10), DocuDate, 126) as DocuDate,InvNo,ProductCode,Product,GoodGroupCode,GoodGroupName,GoodCode,Model,GoodName,Amount, " +
                   "    RF,RentAmount,TotalPrice,RentCom,NetCom,RentOther,NetPrice,NetRF_B,NetRF_P,NetCutSale, NetItem, " +
                   "    GoodPattnCode,GoodPattnName,GoodColorCode,GoodColorName,CustCode,CustName,CustTypeCode,CustTypeName, " +
                   "    sRemark,GoodClassCode,GoodClassName,EmpCode,SaleName,Trs_P,JobsCode,JobsName,CustPONo " +
                  "FROM V_DataGolden_SaleCo ";

            if ((strrentcom == "0"))
            {
                ssql += " WHERE DocuDate between '" + strstartdate + "' and  '" + strenddate + "' and RentCom <= 0 ";
            }
            else if ((strrentcom == "1"))
            {
                ssql += " WHERE DocuDate between '" + strstartdate + "' and  '" + strenddate + "' and RentCom > 0 ";
            }
            else
            {
                ssql += " WHERE DocuDate between '" + strstartdate + "' and  '" + strenddate + "' ";
            }
            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            GridView GridviewExport = new GridView();

            if (dt.Rows.Count != 0)
            {

                GridviewExport.DataSource = dt;
                GridviewExport.DataBind();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=ExportMonthlyInvoice" + strstartdate + "_" + strenddate + ".xls");
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

    protected void btnUpdateData_click(object sender, EventArgs e)
    {
        try
        {
            string strCustCode = Request.Form["txtCustCode"];
            string strCustName = Request.Form["txtCustName"];
            string strContactName = Request.Form["txtContactName"];
            string strCardID = Request.Form["txtCardID"];

            ssql = "select * from [192.168.1.1].[dbwins_amp9].[dbo].[EMCust]  where CustCode = '" + strCustCode.Trim() + "' ";

            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            if (dt.Rows.Count > 0)
            {
                string strCustID = dt.Rows[0]["CustID"].ToString();

                ssql = "select * from KeyCut_CommRece where CustID='" + strCustID + "' ";

                DataTable dt1 = new DataTable();
                dt1 = dbconn.GetDataTable(ssql);

                if (dt1.Rows.Count == 0)
                {
                    conn = new SqlConnection();
                    conn = dbconn.OpenConn();

                    ssql = "insert into KeyCut_CommRece (CustID, CustName, ContactName, CardID, isDelete)  " +
                           "values ('"+strCustID+ "', '" + strCustName + "', '" + strContactName + "', '" + strCardID + "', '1') ";

                    comm = new SqlCommand();
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = ssql;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
            }

            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];
            strrentcom = Request.Form["selectRentCom"];

            GetDataSaleCommission(strstartdate, strenddate, strrentcom);

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;
        }
        catch (Exception ex)
        {
            strMsgAlert = "<div class=\"alert alert-danger box-title txtLabel\"> " +
                              "      <strong>พบข้อผิดพลาด..! GetDataSaleCommission</strong> " + ex.Message + " " +
                              "</div>";
        }
    }
}
