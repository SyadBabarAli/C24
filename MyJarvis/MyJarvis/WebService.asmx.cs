using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyJarvis
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public class TicketsTrendEnity
        {
            public int Hour { get; set; }
            public int Reported { get; set; }
            public int Resolved { get; set; }
        }

        public class T2OffPeakAvgResponseTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2OnSiteAvgResponseTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2OffPeakResponseSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2OnSiteResponseSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2CommunicationsAvgResolutionTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2GulshanAvgResolutionTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2NetworksAvgResolutionTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2OffPeakAvgResolutionTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2OffSiteAvgResolutionTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2OnSiteAvgResolutionTimeEnity
        {
            public string SupportGroup { get; set; }
            public int Total { get; set; }
        }

        public class T2CommunicationsSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2GulshanSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2NetworksSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2OffPeakSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2OffSiteSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class T2OnSiteSLAStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class PendingTicketsStatusEnity
        {
            public string Status { get; set; }
            public int Total { get; set; }
        }

        public class ActiveTicketsStackedEntity
        {
            public string SupportGroup { get; set; }
            public int Age1 { get; set; }
            public int Age2 { get; set; }
            public int Age3 { get; set; }
            public int Age4 { get; set; }
        }

        [WebMethod]
        public List<TicketsTrendEnity> TicketsTrend()
        {
            List<TicketsTrendEnity> ticketstrendinfo = new List<TicketsTrendEnity>();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetTicketsTrendHours";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "TicketsTrendHours");

                    DataTable dtTicketsTrendHours = ds.Tables["TicketsTrendHours"];

                    cmd.CommandText = "spGetTicketsTrend";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "TicketsTrend");

                    DataTable dtTicketsTrend = ds1.Tables["TicketsTrend"];

                    DataTable dtCombine = dtTicketsTrendHours;

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtTicketsTrend.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["Hour"].ToString() == dtTicketsTrend.Rows[j]["Hour"].ToString())
                                dtCombine.Rows[i]["Reported"] = dtTicketsTrend.Rows[j]["Reported"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtTicketsTrend.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["Hour"].ToString() == dtTicketsTrend.Rows[j]["Hour"].ToString())
                                dtCombine.Rows[i]["Resolved"] = dtTicketsTrend.Rows[j]["Resolved"];
                        }
                    }

                    foreach (DataRow dr in dtCombine.Rows)
                    {
                        ticketstrendinfo.Add(new TicketsTrendEnity
                        {
                            Hour = Convert.ToInt32(dr["Hour"]),
                            Reported = Convert.ToInt32(dr["Reported"]),
                            Resolved = Convert.ToInt32(dr["Resolved"])
                        });
                    }
                }
            }
            return ticketstrendinfo;
        }

        //[WebMethod]
        //public List<TicketsTrendEnity> TicketsTrend()
        //{
        //    List<TicketsTrendEnity> ticketstrendinfo = new List<TicketsTrendEnity>();
        //    DataSet ds = new DataSet();
        //    using (SqlConnection con = new SqlConnection(strConnString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "spGetTicketsTrend";
        //            cmd.Connection = con;
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //            {
        //                da.Fill(ds, "TicketsTrend");
        //            }
        //        }
        //    }
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables["TicketsTrend"].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables["TicketsTrend"].Rows)
        //                {
        //                    ticketstrendinfo.Add(new TicketsTrendEnity
        //                    {
        //                        Hour = Convert.ToInt32(dr["Hour"]),
        //                        Reported = Convert.ToInt32(dr["Reported"]),
        //                        Resolved = Convert.ToInt32(dr["Resolved"])
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return ticketstrendinfo;
        //}

        //[WebMethod]
        //public List<TicketsTrendEnity> TicketsTrendActivity()
        //{
        //    List<TicketsTrendEnity> ticketstrendactivityinfo = new List<TicketsTrendEnity>();
        //    DataSet ds = new DataSet();
        //    using (SqlConnection con = new SqlConnection(strConnString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "spGetTicketsTrendActivity";
        //            cmd.Connection = con;
        //            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //            {
        //                da.Fill(ds, "TicketsTrendActivity");
        //            }
        //        }
        //    }
        //    if (ds != null)
        //    {
        //        if (ds.Tables.Count > 0)
        //        {
        //            if (ds.Tables["TicketsTrendActivity"].Rows.Count > 0)
        //            {
        //                foreach (DataRow dr in ds.Tables["TicketsTrendActivity"].Rows)
        //                {
        //                    ticketstrendactivityinfo.Add(new TicketsTrendEnity
        //                    {
        //                        Reported = Convert.ToInt32(dr["Reported"]),
        //                        Resolved = Convert.ToInt32(dr["Resolved"])
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    return ticketstrendactivityinfo;
        //}

        [WebMethod]
        public List<T2OffPeakAvgResponseTimeEnity> T2OffPeakAvgResponseTime()
        {
            List<T2OffPeakAvgResponseTimeEnity> t2pffpeakavgresponsetimeinfo = new List<T2OffPeakAvgResponseTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OffPeakAvgResponseTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OffPeakAvgResponseTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OffPeakAvgResponseTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OffPeakAvgResponseTime"].Rows)
                        {
                            t2pffpeakavgresponsetimeinfo.Add(new T2OffPeakAvgResponseTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2pffpeakavgresponsetimeinfo;
        }

        [WebMethod]
        public List<T2OnSiteAvgResponseTimeEnity> T2OnSiteAvgResponseTime()
        {
            List<T2OnSiteAvgResponseTimeEnity> t2onsiteavgresponsetimeinfo = new List<T2OnSiteAvgResponseTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OnSiteAvgResponseTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OnSiteAvgResponseTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OnSiteAvgResponseTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OnSiteAvgResponseTime"].Rows)
                        {
                            t2onsiteavgresponsetimeinfo.Add(new T2OnSiteAvgResponseTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2onsiteavgresponsetimeinfo;
        }

        [WebMethod]
        public List<T2OffPeakResponseSLAStatusEnity> T2OffPeakResponseSLAStatus()
        {
            List<T2OffPeakResponseSLAStatusEnity> t2offpeakresponseslastatusinfo = new List<T2OffPeakResponseSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OffPeakResponseSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OffPeakResponseSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OffPeakResponseSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OffPeakResponseSLAStatus"].Rows)
                        {
                            t2offpeakresponseslastatusinfo.Add(new T2OffPeakResponseSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2offpeakresponseslastatusinfo;
        }

        [WebMethod]
        public List<T2OnSiteResponseSLAStatusEnity> T2OnSiteResponseSLAStatus()
        {
            List<T2OnSiteResponseSLAStatusEnity> t2onsiteresponseslastatusinfo = new List<T2OnSiteResponseSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OnSiteResponseSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OnSiteResponseSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OnSiteResponseSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OnSiteResponseSLAStatus"].Rows)
                        {
                            t2onsiteresponseslastatusinfo.Add(new T2OnSiteResponseSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2onsiteresponseslastatusinfo;
        }

        [WebMethod]
        public List<T2CommunicationsAvgResolutionTimeEnity> T2CommunicationsAvgResolutionTime()
        {
            List<T2CommunicationsAvgResolutionTimeEnity> t2communicationsavgresolutiontimeinfo = new List<T2CommunicationsAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2CommunicationsAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2CommunicationsAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2CommunicationsAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2CommunicationsAvgResolutionTime"].Rows)
                        {
                            t2communicationsavgresolutiontimeinfo.Add(new T2CommunicationsAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2communicationsavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2GulshanAvgResolutionTimeEnity> T2GulshanAvgResolutionTime()
        {
            List<T2GulshanAvgResolutionTimeEnity> t2gulshanavgresolutiontimeinfo = new List<T2GulshanAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2GulshanAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2GulshanAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2GulshanAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2GulshanAvgResolutionTime"].Rows)
                        {
                            t2gulshanavgresolutiontimeinfo.Add(new T2GulshanAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2gulshanavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2NetworksAvgResolutionTimeEnity> T2NetworksAvgResolutionTime()
        {
            List<T2NetworksAvgResolutionTimeEnity> t2networksavgresolutiontimeinfo = new List<T2NetworksAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2NetworksAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2NetworksAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2NetworksAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2NetworksAvgResolutionTime"].Rows)
                        {
                            t2networksavgresolutiontimeinfo.Add(new T2NetworksAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2networksavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2OffPeakAvgResolutionTimeEnity> T2OffPeakAvgResolutionTime()
        {
            List<T2OffPeakAvgResolutionTimeEnity> t2offpeakavgresolutiontimeinfo = new List<T2OffPeakAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OffPeakAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OffPeakAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OffPeakAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OffPeakAvgResolutionTime"].Rows)
                        {
                            t2offpeakavgresolutiontimeinfo.Add(new T2OffPeakAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2offpeakavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2OffSiteAvgResolutionTimeEnity> T2OffSiteAvgResolutionTime()
        {
            List<T2OffSiteAvgResolutionTimeEnity> t2offsiteavgresolutiontimeinfo = new List<T2OffSiteAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OffSiteAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OffSiteAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OffSiteAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OffSiteAvgResolutionTime"].Rows)
                        {
                            t2offsiteavgresolutiontimeinfo.Add(new T2OffSiteAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2offsiteavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2OnSiteAvgResolutionTimeEnity> T2OnSiteAvgResolutionTime()
        {
            List<T2OnSiteAvgResolutionTimeEnity> t2onsiteavgresolutiontimeinfo = new List<T2OnSiteAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OnSiteAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OnSiteAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OnSiteAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OnSiteAvgResolutionTime"].Rows)
                        {
                            t2onsiteavgresolutiontimeinfo.Add(new T2OnSiteAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2onsiteavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2OnSiteAvgResolutionTimeEnity> T2CentralAvgResolutionTime()
        {
            List<T2OnSiteAvgResolutionTimeEnity> t2centralavgresolutiontimeinfo = new List<T2OnSiteAvgResolutionTimeEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2CentralAvgResolutionTime";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2CentralAvgResolutionTime");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2CentralAvgResolutionTime"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2CentralAvgResolutionTime"].Rows)
                        {
                            t2centralavgresolutiontimeinfo.Add(new T2OnSiteAvgResolutionTimeEnity
                            {
                                SupportGroup = dr["SupportGroup"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2centralavgresolutiontimeinfo;
        }

        [WebMethod]
        public List<T2CommunicationsSLAStatusEnity> T2CommunicationsSLAStatus()
        {
            List<T2CommunicationsSLAStatusEnity> t2communicationsslastatusinfo = new List<T2CommunicationsSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2CommunicationsSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2CommunicationsSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2CommunicationsSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2CommunicationsSLAStatus"].Rows)
                        {
                            t2communicationsslastatusinfo.Add(new T2CommunicationsSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2communicationsslastatusinfo;
        }

        [WebMethod]
        public List<T2GulshanSLAStatusEnity> T2GulshanSLAStatus()
        {
            List<T2GulshanSLAStatusEnity> t2gulshanslastatusinfo = new List<T2GulshanSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2GulshanSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2GulshanSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2GulshanSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2GulshanSLAStatus"].Rows)
                        {
                            t2gulshanslastatusinfo.Add(new T2GulshanSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2gulshanslastatusinfo;
        }

        [WebMethod]
        public List<T2NetworksSLAStatusEnity> T2NetworksSLAStatus()
        {
            List<T2NetworksSLAStatusEnity> t2networksslastatusinfo = new List<T2NetworksSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2NetworksSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2NetworksSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2NetworksSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2NetworksSLAStatus"].Rows)
                        {
                            t2networksslastatusinfo.Add(new T2NetworksSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2networksslastatusinfo;
        }

        [WebMethod]
        public List<T2OffPeakSLAStatusEnity> T2OffPeakSLAStatus()
        {
            List<T2OffPeakSLAStatusEnity> t2offpeakslastatusinfo = new List<T2OffPeakSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OffPeakSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OffPeakSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OffPeakSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OffPeakSLAStatus"].Rows)
                        {
                            t2offpeakslastatusinfo.Add(new T2OffPeakSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2offpeakslastatusinfo;
        }

        [WebMethod]
        public List<T2OffSiteSLAStatusEnity> T2OffSiteSLAStatus()
        {
            List<T2OffSiteSLAStatusEnity> t2offsiteslastatusinfo = new List<T2OffSiteSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OffSiteSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OffSiteSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OffSiteSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OffSiteSLAStatus"].Rows)
                        {
                            t2offsiteslastatusinfo.Add(new T2OffSiteSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2offsiteslastatusinfo;
        }

        [WebMethod]
        public List<T2OnSiteSLAStatusEnity> T2OnSiteSLAStatus()
        {
            List<T2OnSiteSLAStatusEnity> t2onsiteslastatusinfo = new List<T2OnSiteSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2OnSiteSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2OnSiteSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2OnSiteSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2OnSiteSLAStatus"].Rows)
                        {
                            t2onsiteslastatusinfo.Add(new T2OnSiteSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2onsiteslastatusinfo;
        }

        [WebMethod]
        public List<T2OnSiteSLAStatusEnity> T2CentralSLAStatus()
        {
            List<T2OnSiteSLAStatusEnity> t2centralslastatusinfo = new List<T2OnSiteSLAStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetT2CentralSLAStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "T2CentralSLAStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["T2CentralSLAStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["T2CentralSLAStatus"].Rows)
                        {
                            t2centralslastatusinfo.Add(new T2OnSiteSLAStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return t2centralslastatusinfo;
        }

        [WebMethod]
        public List<PendingTicketsStatusEnity> PendingTicketsStatus()
        {
            List<PendingTicketsStatusEnity> pendingticketsstatusinfo = new List<PendingTicketsStatusEnity>();
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "spGetPendingTicketsStatus";
                    cmd.Connection = con;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds, "PendingTicketsStatus");
                    }
                }
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["PendingTicketsStatus"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables["PendingTicketsStatus"].Rows)
                        {
                            pendingticketsstatusinfo.Add(new PendingTicketsStatusEnity
                            {
                                Status = dr["Status"].ToString(),
                                Total = Convert.ToInt32(dr["Total"])
                            });
                        }
                    }
                }
            }
            return pendingticketsstatusinfo;
        }

        [WebMethod]
        public List<ActiveTicketsStackedEntity> ActiveTicketsStacked()
        {
            List<ActiveTicketsStackedEntity> activeticketsstackedinfo = new List<ActiveTicketsStackedEntity>();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSupportGroups";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "sg");

                    DataTable dtsg = ds.Tables["sg"];

                    cmd.CommandText = "spGet3DaysTickets";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "Age1");

                    DataTable dt3days = ds1.Tables["Age1"];

                    cmd.CommandText = "spGet6DaysTickets";
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2, "Age2");

                    DataTable dt6days = ds2.Tables["Age2"];

                    cmd.CommandText = "spGet16DaysTickets";
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "Age3");

                    DataTable dt16days = ds3.Tables["Age3"];

                    cmd.CommandText = "spGet30DaysTickets";
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "Age4");

                    DataTable dt30days = ds4.Tables["Age4"];

                    DataTable dtCombine = dtsg;

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt3days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt3days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["3 to 5 days"] = dt3days.Rows[j]["3 to 5 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt6days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt6days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["6 to 15 days"] = dt6days.Rows[j]["6 to 15 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt16days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt16days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["16 to 30 days"] = dt16days.Rows[j]["16 to 30 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt30days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt30days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["Above 30 days"] = dt30days.Rows[j]["Above 30 days"];
                        }
                    }

                    foreach (DataRow dr in dtCombine.Rows)
                    {
                        activeticketsstackedinfo.Add(new ActiveTicketsStackedEntity
                        {
                            SupportGroup = dr["SupportGroup"].ToString(),
                            Age1 = Convert.ToInt32(dr["3 to 5 days"]),
                            Age2 = Convert.ToInt32(dr["6 to 15 days"]),
                            Age3 = Convert.ToInt32(dr["16 to 30 days"]),
                            Age4 = Convert.ToInt32(dr["Above 30 days"])
                        });
                    }
                }
            }
            return activeticketsstackedinfo;
        }

        [WebMethod]
        public List<ActiveTicketsStackedEntity> UPTicketsStacked()
        {
            List<ActiveTicketsStackedEntity> upticketsstackedinfo = new List<ActiveTicketsStackedEntity>();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSupportGroupsUP";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "sg");

                    DataTable dtsg = ds.Tables["sg"];

                    cmd.CommandText = "spGet3DaysTicketsUP";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "Age1");

                    DataTable dt3days = ds1.Tables["Age1"];

                    cmd.CommandText = "spGet6DaysTicketsUP";
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2, "Age2");

                    DataTable dt6days = ds2.Tables["Age2"];

                    cmd.CommandText = "spGet16DaysTicketsUP";
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "Age3");

                    DataTable dt16days = ds3.Tables["Age3"];

                    cmd.CommandText = "spGet30DaysTicketsUP";
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "Age4");

                    DataTable dt30days = ds4.Tables["Age4"];

                    DataTable dtCombine = dtsg;

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt3days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt3days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["3 to 5 days"] = dt3days.Rows[j]["3 to 5 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt6days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt6days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["6 to 15 days"] = dt6days.Rows[j]["6 to 15 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt16days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt16days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["16 to 30 days"] = dt16days.Rows[j]["16 to 30 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt30days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt30days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["Above 30 days"] = dt30days.Rows[j]["Above 30 days"];
                        }
                    }

                    foreach (DataRow dr in dtCombine.Rows)
                    {
                        upticketsstackedinfo.Add(new ActiveTicketsStackedEntity
                        {
                            SupportGroup = dr["SupportGroup"].ToString(),
                            Age1 = Convert.ToInt32(dr["3 to 5 days"]),
                            Age2 = Convert.ToInt32(dr["6 to 15 days"]),
                            Age3 = Convert.ToInt32(dr["16 to 30 days"]),
                            Age4 = Convert.ToInt32(dr["Above 30 days"])
                        });
                    }
                }
            }
            return upticketsstackedinfo;
        }

        [WebMethod]
        public List<ActiveTicketsStackedEntity> VPTicketsStacked()
        {
            List<ActiveTicketsStackedEntity> vpticketsstackedinfo = new List<ActiveTicketsStackedEntity>();
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spGetSupportGroupsVP";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "sg");

                    DataTable dtsg = ds.Tables["sg"];

                    cmd.CommandText = "spGet3DaysTicketsVP";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "Age1");

                    DataTable dt3days = ds1.Tables["Age1"];

                    cmd.CommandText = "spGet6DaysTicketsVP";
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2, "Age2");

                    DataTable dt6days = ds2.Tables["Age2"];

                    cmd.CommandText = "spGet16DaysTicketsVP";
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "Age3");

                    DataTable dt16days = ds3.Tables["Age3"];

                    cmd.CommandText = "spGet30DaysTicketsVP";
                    SqlDataAdapter da4 = new SqlDataAdapter(cmd);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "Age4");

                    DataTable dt30days = ds4.Tables["Age4"];

                    DataTable dtCombine = dtsg;

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt3days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt3days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["3 to 5 days"] = dt3days.Rows[j]["3 to 5 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt6days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt6days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["6 to 15 days"] = dt6days.Rows[j]["6 to 15 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt16days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt16days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["16 to 30 days"] = dt16days.Rows[j]["16 to 30 days"];
                        }
                    }

                    for (int i = 0; i < dtCombine.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt30days.Rows.Count; j++)
                        {
                            if (dtCombine.Rows[i]["SupportGroup"].ToString() == dt30days.Rows[j]["SupportGroup"].ToString())
                                dtCombine.Rows[i]["Above 30 days"] = dt30days.Rows[j]["Above 30 days"];
                        }
                    }

                    foreach (DataRow dr in dtCombine.Rows)
                    {
                        vpticketsstackedinfo.Add(new ActiveTicketsStackedEntity
                        {
                            SupportGroup = dr["SupportGroup"].ToString(),
                            Age1 = Convert.ToInt32(dr["3 to 5 days"]),
                            Age2 = Convert.ToInt32(dr["6 to 15 days"]),
                            Age3 = Convert.ToInt32(dr["16 to 30 days"]),
                            Age4 = Convert.ToInt32(dr["Above 30 days"])
                        });
                    }
                }
            }
            return vpticketsstackedinfo;
        }
    }
}
