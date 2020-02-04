using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyJarvis
{
    public partial class Default : System.Web.UI.Page
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        string strCurrent;
        string strResolved;
        string strAvgResponseTime;
        string strAvgResolutionTime;

        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);

            con.Open();
            strCurrent = "spGetCurrentTickets";
            com = new SqlCommand(strCurrent, con);
            SqlDataReader readerCurrent = com.ExecuteReader();
            readerCurrent.Read();
            CurrentTickets.Text = readerCurrent["Total"].ToString();
            readerCurrent.Close();
            con.Close();

            con.Open();
            strResolved = "spGetCurrentResolvedTickets";
            com = new SqlCommand(strResolved, con);
            SqlDataReader readerResolved = com.ExecuteReader();
            readerResolved.Read();
            ResolvedTickets.Text = readerResolved["Total"].ToString();
            readerResolved.Close();
            con.Close();

            con.Open();
            strAvgResponseTime = "spGetAvgResponseTime";
            com = new SqlCommand(strAvgResponseTime, con);
            SqlDataReader readerAvgResponseTime = com.ExecuteReader();
            readerAvgResponseTime.Read();
            AvgResponseTime.Text = readerAvgResponseTime["Total"].ToString();
            readerAvgResponseTime.Close();
            con.Close();

            con.Open();
            strAvgResolutionTime = "spGetAvgResolutionTime";
            com = new SqlCommand(strAvgResolutionTime, con);
            SqlDataReader readerAvgResolutionTime = com.ExecuteReader();
            readerAvgResolutionTime.Read();
            AvgResolutionTime.Text = readerAvgResolutionTime["Total"].ToString();
            readerAvgResolutionTime.Close();
            con.Close();

            DWDataMartEntities db = new DWDataMartEntities();

            List<spGetT2OffPeakResponseSLAStatus_Result> spGetT2OffPeakResponseSLAStatus = new List<spGetT2OffPeakResponseSLAStatus_Result>();
            spGetT2OffPeakResponseSLAStatus = db.spGetT2OffPeakResponseSLAStatus().ToList();
            try
            {
                if (spGetT2OffPeakResponseSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2OffPeakResponseSLAStatus)
                    {
                        lblOffPeakTotalMet.Text = spGetT2OffPeakResponseSLAStatus.ElementAt(0).Total.ToString();
                        lblOffPeakTotalBreached.Text = spGetT2OffPeakResponseSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblOffPeakTotalBreached.Text = "0";
            }

            List<spGetT2OffPeakAvgResponseTime_Result> spGetT2OffPeakAvgResponseTime = new List<spGetT2OffPeakAvgResponseTime_Result>();
            spGetT2OffPeakAvgResponseTime = db.spGetT2OffPeakAvgResponseTime().ToList();
            if (spGetT2OffPeakAvgResponseTime.Count > 0)
            {
                foreach (var item in spGetT2OffPeakAvgResponseTime)
                {
                    lblOffPeakAvgTime.Text = spGetT2OffPeakAvgResponseTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2OnSiteResponseSLAStatus_Result> spGetT2OnSiteResponseSLAStatus = new List<spGetT2OnSiteResponseSLAStatus_Result>();
            spGetT2OnSiteResponseSLAStatus = db.spGetT2OnSiteResponseSLAStatus().ToList();
            try
            {
                if (spGetT2OnSiteResponseSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2OnSiteResponseSLAStatus)
                    {
                        lblOnSiteTotalMet.Text = spGetT2OnSiteResponseSLAStatus.ElementAt(0).Total.ToString();
                        lblOnSiteTotalBreached.Text = spGetT2OnSiteResponseSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblOnSiteTotalBreached.Text = "0";
            }

            List<spGetT2OnSiteAvgResponseTime_Result> spGetT2OnSiteAvgResponseTime = new List<spGetT2OnSiteAvgResponseTime_Result>();
            spGetT2OnSiteAvgResponseTime = db.spGetT2OnSiteAvgResponseTime().ToList();
            if (spGetT2OnSiteAvgResponseTime.Count > 0)
            {
                foreach (var item in spGetT2OnSiteAvgResponseTime)
                {
                    lblOnSiteAvgTime.Text = spGetT2OnSiteAvgResponseTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2CentralSLAStatus_Result> spGetT2CentralSLAStatus = new List<spGetT2CentralSLAStatus_Result>();
            spGetT2CentralSLAStatus = db.spGetT2CentralSLAStatus().ToList();
            try
            {
                if (spGetT2CentralSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2CentralSLAStatus)
                    {
                        lblCentralTotalResMet.Text = spGetT2CentralSLAStatus.ElementAt(0).Total.ToString();
                        lblCentralTotalResBreached.Text = spGetT2CentralSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblCentralTotalResBreached.Text = "0";
            }

            List<spGetT2CentralAvgResolutionTime_Result> spGetT2CentralAvgResolutionTime = new List<spGetT2CentralAvgResolutionTime_Result>();
            spGetT2CentralAvgResolutionTime = db.spGetT2CentralAvgResolutionTime().ToList();
            if (spGetT2CentralAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2CentralAvgResolutionTime)
                {
                    lblCentralAvgResTime.Text = spGetT2CentralAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2CommunicationsSLAStatus_Result> spGetT2CommunicationsSLAStatus = new List<spGetT2CommunicationsSLAStatus_Result>();
            spGetT2CommunicationsSLAStatus = db.spGetT2CommunicationsSLAStatus().ToList();
            try
            {
                if (spGetT2CommunicationsSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2CommunicationsSLAStatus)
                    {
                        lblCommTotalResMet.Text = spGetT2CommunicationsSLAStatus.ElementAt(0).Total.ToString();
                        lblCommTotalResBreached.Text = spGetT2CommunicationsSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblCommTotalResBreached.Text = "0";
            }

            List<spGetT2CommunicationsAvgResolutionTime_Result> spGetT2CommunicationsAvgResolutionTime = new List<spGetT2CommunicationsAvgResolutionTime_Result>();
            spGetT2CommunicationsAvgResolutionTime = db.spGetT2CommunicationsAvgResolutionTime().ToList();
            if (spGetT2CommunicationsAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2CommunicationsAvgResolutionTime)
                {
                    lblCommAvgResTime.Text = spGetT2CommunicationsAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2GulshanSLAStatus_Result> spGetT2GulshanSLAStatus = new List<spGetT2GulshanSLAStatus_Result>();
            spGetT2GulshanSLAStatus = db.spGetT2GulshanSLAStatus().ToList();
            try
            {
                if (spGetT2GulshanSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2GulshanSLAStatus)
                    {
                        lblGulshanTotalMet.Text = spGetT2GulshanSLAStatus.ElementAt(0).Total.ToString();
                        lblGulshanTotalBreached.Text = spGetT2GulshanSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblGulshanTotalBreached.Text = "0";
            }

            List<spGetT2GulshanAvgResolutionTime_Result> spGetT2GulshanAvgResolutionTime = new List<spGetT2GulshanAvgResolutionTime_Result>();
            spGetT2GulshanAvgResolutionTime = db.spGetT2GulshanAvgResolutionTime().ToList();
            if (spGetT2GulshanAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2GulshanAvgResolutionTime)
                {
                    lblGulshanAvgResTime.Text = spGetT2GulshanAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2NetworksSLAStatus_Result> spGetT2NetworksSLAStatus = new List<spGetT2NetworksSLAStatus_Result>();
            spGetT2NetworksSLAStatus = db.spGetT2NetworksSLAStatus().ToList();
            try
            {
                if (spGetT2NetworksSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2NetworksSLAStatus)
                    {
                        lblNetworkTotalResMet.Text = spGetT2NetworksSLAStatus.ElementAt(0).Total.ToString();
                        lblNetworkTotalResBreached.Text = spGetT2NetworksSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblNetworkTotalResBreached.Text = "0";
            }

            List<spGetT2NetworksAvgResolutionTime_Result> spGetT2NetworksAvgResolutionTime = new List<spGetT2NetworksAvgResolutionTime_Result>();
            spGetT2NetworksAvgResolutionTime = db.spGetT2NetworksAvgResolutionTime().ToList();
            if (spGetT2NetworksAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2NetworksAvgResolutionTime)
                {
                    lblNetworkAvgResTime.Text = spGetT2NetworksAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2OffPeakSLAStatus_Result> spGetT2OffPeakSLAStatus = new List<spGetT2OffPeakSLAStatus_Result>();
            spGetT2OffPeakSLAStatus = db.spGetT2OffPeakSLAStatus().ToList();
            try
            {
                if (spGetT2OffPeakSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2OffPeakSLAStatus)
                    {
                        lblOffPeakTotalResMet.Text = spGetT2OffPeakSLAStatus.ElementAt(0).Total.ToString();
                        lblOffPeakTotalResBreached.Text = spGetT2OffPeakSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblOffPeakTotalResBreached.Text = "0";
            }

            List<spGetT2OffPeakAvgResolutionTime_Result> spGetT2OffPeakAvgResolutionTime = new List<spGetT2OffPeakAvgResolutionTime_Result>();
            spGetT2OffPeakAvgResolutionTime = db.spGetT2OffPeakAvgResolutionTime().ToList();
            if (spGetT2OffPeakAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2OffPeakAvgResolutionTime)
                {
                    lblOffPeakAvgResTime.Text = spGetT2OffPeakAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2OffSiteSLAStatus_Result> spGetT2OffSiteSLAStatus = new List<spGetT2OffSiteSLAStatus_Result>();
            spGetT2OffSiteSLAStatus = db.spGetT2OffSiteSLAStatus().ToList();
            try
            {
                if (spGetT2OffSiteSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2OffSiteSLAStatus)
                    {
                        lblOffSiteTotalResMet.Text = spGetT2OffSiteSLAStatus.ElementAt(0).Total.ToString();
                        lblOffSiteTotalResBreached.Text = spGetT2OffSiteSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblOffSiteTotalResBreached.Text = "0";
            }

            List<spGetT2OffSiteAvgResolutionTime_Result> spGetT2OffSiteAvgResolutionTime = new List<spGetT2OffSiteAvgResolutionTime_Result>();
            spGetT2OffSiteAvgResolutionTime = db.spGetT2OffSiteAvgResolutionTime().ToList();
            if (spGetT2OffSiteAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2OffSiteAvgResolutionTime)
                {
                    lblOffSiteAvgResTime.Text = spGetT2OffSiteAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }

            List<spGetT2OnSiteSLAStatus_Result> spGetT2OnSiteSLAStatus = new List<spGetT2OnSiteSLAStatus_Result>();
            spGetT2OnSiteSLAStatus = db.spGetT2OnSiteSLAStatus().ToList();
            try
            {
                if (spGetT2OnSiteSLAStatus.Count > 0)
                {
                    foreach (var item in spGetT2OnSiteSLAStatus)
                    {
                        lblOnSiteTotalResMet.Text = spGetT2OnSiteSLAStatus.ElementAt(0).Total.ToString();
                        lblOnSiteTotalResBreached.Text = spGetT2OnSiteSLAStatus.ElementAt(1).Total.ToString();
                    }
                }
            }
            catch
            {
                lblOnSiteTotalResBreached.Text = "0";
            }

            List<spGetT2OnSiteAvgResolutionTime_Result> spGetT2OnSiteAvgResolutionTime = new List<spGetT2OnSiteAvgResolutionTime_Result>();
            spGetT2OnSiteAvgResolutionTime = db.spGetT2OnSiteAvgResolutionTime().ToList();
            if (spGetT2OnSiteAvgResolutionTime.Count > 0)
            {
                foreach (var item in spGetT2OnSiteAvgResolutionTime)
                {
                    lblOnSiteAvgResTime.Text = spGetT2OnSiteAvgResolutionTime.ElementAt(0).Total.ToString();
                }
            }
        }
    }
}