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

public partial class report_commission_payment : System.Web.UI.Page
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
            strispaid = Request.Form["selectisPaid"];

            GetDataSaleCommission(strstartdate, strenddate, strispaid);

            Session["startdate"] = strstartdate;
            Session["enddate"] = strenddate;

            Session["sel0"] = "";
            Session["sel1"] = "";
            Session["sel2"] = "";
            Session["sel3"] = "";

            if (strispaid == "0")
            {
                Session["sel0"] = "selected";
            }
            else if (strispaid == "1")
            {
                Session["sel1"] = "selected";
            }
            else if (strispaid == "2")
            {
                Session["sel2"] = "selected";
            }
            else if (strispaid == "3")
            {
                Session["sel3"] = "selected";
            }
            else
            {
                Session["sel0"] = "";
                Session["sel1"] = "";
                Session["sel2"] = "";
                Session["sel3"] = "";
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

    protected void GetDataSaleCommission(string strstartdate, string strenddate, string strispaid)
    {
        try
        {
            ssql = "SELECT   ID, BrchID, convert(nvarchar(10), DocuDate, 126) DocuDate, InvNo, CustID, CustName, ProductCode, GoodGroupName, GoodCode, GoodName1, " +
                  "     Amount, RF, RentAmount, TotalPrice, RentCom, RentOther, NetCom, NetPrice, NetRF_B, NetRF_P, NetCutSale, " +
                  "     TotalCutSale, SaleName, Project, RecpName, ContactName, CardID, CheqDate, DocuNo, convert(nvarchar(10), arDocuDate, 126) as arDocuDate, PercentProcessFee, " +
                  "     AmountProcessFee, GrandCommission, case when isPaid=0 then 'ยังไม่จ่าย' when isPaid=3 then 'รอทำจ่ายเช็ค' else 'ชำระแล้ว' end as isPaid, convert(nvarchar(10), DatePaid, 126) as  DatePaid, isRemark, EmpCode, LastedUpdate  " +
                  "     ,ContactName2, CardID2, ContactName3, CardID3, isPaidType " +
                  "     , GrandCommission * 0.05 as gVat, GrandCommission - (GrandCommission * 0.05) as gwVat " +
                  "FROM KeyCut_CommTransactionFinal ";

            if ((strispaid == "0") || (strispaid == "1") || (strispaid == "3"))
            {
                ssql += " WHERE arDocuDate between '" + strstartdate + "' and  '" + strenddate + "' and isPaid='" + strispaid + "' ";
            }
            else
            {
                ssql += " WHERE arDocuDate between '" + strstartdate + "' and  '" + strenddate + "' ";
            }

            //ssql = "exec spKeyCut_CommReport2 '"+ strstartdate + "',  '"+ strenddate  + "', '"+ strispaid + "' ";

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

                    string RecpName = dtFinal.Rows[i]["RecpName"].ToString();
                    string ContactName = dtFinal.Rows[i]["ContactName"].ToString();
                    
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
                                            "<td class=\"" + cssTextHilight + "\">" + CustName + "</td>" +
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

                                            "<td>" + RecpName + "</td>" +
                                            "<td>" + ContactName + "</td>" +
                                            
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

    protected void btnExportExcel_click(object sender, EventArgs e)
    {
        try
        {
            strstartdate = Request.Form["datepickertrans"];
            strenddate = Request.Form["datepickerend"];
            strispaid = Request.Form["selectisPaid"];

            ssql = "exec spKeyCut_CommReport2 '"+ strstartdate + "',  '"+ strenddate  + "', '"+ strispaid + "' ";
            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            GridView GridviewExport = new GridView();

            if (dt.Rows.Count != 0)
            {

                GridviewExport.DataSource = dt;
                GridviewExport.DataBind();

                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=ExportReportCommission" + strstartdate + "_" + strenddate + ".xls");
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
            strispaid = Request.Form["selectisPaid"];

            //ssql = "select * from KeyCut_CommTransactionFinal where arDocuDate between '" + strstartdate + "' AND '" + strenddate + "'";
            ssql = "exec spKeyCut_CommReport3 '" + strstartdate + "', '" + strenddate + "', '" + strispaid + "'";
            dt = new DataTable();
            dt = dbconn.GetDataTable(ssql);

            //GridView GridviewExport = new GridView();

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