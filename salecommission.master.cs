using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;

public partial class salecommission :  System.Web.UI.MasterPage
{
    public string strActiveDashboard = "";
    public string strTextRedDashboard = "";

    //public string strActiveSettingGroup = "";

    public string strActiveMasterSetup = "";
    public string strTextCustomerType = "";
    public string strTextCustomerGrade = "";
    public string strTextProductGroup = "";
    public string strTextSpecifier = "";
    public string strTextArchitect = "";
    public string strTextCustomers = "";
    public string strTextProjectsetup = "";
    public string strTextSaleOnspec = "";


    public string strActiveTransaction = "";
    public string strTextRequestForm = "";
    public string strTextArchitectCenter = "";
    public string strTextProjectCenter = "";
    public string strTextWeeklyReport = "";

    public string strFullName = "";
    public string strDept = "";

    public string strActiveReporting = "";
    public string strTextSaleWeeklyReport = "";
    public string strTextNewProjectReport = "";

    public string strTextReportForecasting = "";
    public string strTextSaleIntake = "";
    public string strTextCompanyReport = "";
    public string strTextArchitectReport = "";
    public string strTextProjectReport = "";

    public string strActiveActivity = "";
    public string strTextEventActivity = "";
    public string strTextPremiumGift = "";
    public string strTextSurprise = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //HttpCookie cook = new HttpCookie("testcook");
            //cook = Request.Cookies["Dept"];
            //strDept = cook.ToString();

        }
        catch
        {
        }
    }
}
