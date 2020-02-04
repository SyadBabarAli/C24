using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyJarvis
{
    public partial class PendingTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Forces GridView to render thead/tfoot elements
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
            GridView2.UseAccessibleHeader = true;
            GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView2.FooterRow.TableSection = TableRowSection.TableFooter;
            GridView3.UseAccessibleHeader = true;
            GridView3.HeaderRow.TableSection = TableRowSection.TableHeader;
            GridView3.FooterRow.TableSection = TableRowSection.TableFooter;

            DWDataMartEntities db = new DWDataMartEntities();
            List<spGetPendingTicketsStatus_Result> spGetPendingTicketsStatus = new List<spGetPendingTicketsStatus_Result>();
            spGetPendingTicketsStatus = db.spGetPendingTicketsStatus().ToList();
            if (spGetPendingTicketsStatus.Count > 0)
            {
                foreach (var item in spGetPendingTicketsStatus)
                {
                    Active.Text = spGetPendingTicketsStatus.ElementAt(0).Total.ToString();
                    UserPending.Text = spGetPendingTicketsStatus.ElementAt(1).Total.ToString();
                    VendorPending.Text = spGetPendingTicketsStatus.ElementAt(2).Total.ToString();
                    int intTotal = int.Parse(spGetPendingTicketsStatus.ElementAt(0).Total.ToString()) + int.Parse(spGetPendingTicketsStatus.ElementAt(1).Total.ToString()) + int.Parse(spGetPendingTicketsStatus.ElementAt(2).Total.ToString());
                    TotalPending.Text = intTotal.ToString();
                }
            }

            List<spGetPendingTicketsAvgTime_Result> spGetPendingTicketsAvgTime = new List<spGetPendingTicketsAvgTime_Result>();
            spGetPendingTicketsAvgTime = db.spGetPendingTicketsAvgTime().ToList();
            if (spGetPendingTicketsAvgTime.Count > 0)
            {
                foreach (var item in spGetPendingTicketsAvgTime)
                {
                    ActiveAvgTime.Text = spGetPendingTicketsAvgTime.ElementAt(0).Total.ToString();
                    UserPendingAvgTime.Text = spGetPendingTicketsAvgTime.ElementAt(1).Total.ToString();
                    VendorPendingAvgTime.Text = spGetPendingTicketsAvgTime.ElementAt(2).Total.ToString();
                }
            }

            List<spGetPendingTicketsAvgTimeD_Result> spGetPendingTicketsAvgTimeD = new List<spGetPendingTicketsAvgTimeD_Result>();
            spGetPendingTicketsAvgTimeD = db.spGetPendingTicketsAvgTimeD().ToList();
            if (spGetPendingTicketsAvgTimeD.Count > 0)
            {
                foreach (var item in spGetPendingTicketsAvgTimeD)
                {
                    TotalPendingAvgTime.Text = spGetPendingTicketsAvgTimeD.ElementAt(0).Total.ToString();
                }
            }

            //List<spGetT2OffPeakResponseSLAPercentage_Result> spGetT2OffPeakResponseSLAPercentage = new List<spGetT2OffPeakResponseSLAPercentage_Result>();
            //spGetT2OffPeakResponseSLAPercentage = db.spGetT2OffPeakResponseSLAPercentage().ToList();
            //if (spGetT2OffPeakResponseSLAPercentage.Count > 0)
            //{
            //    foreach (var item in spGetT2OffPeakResponseSLAPercentage)
            //    {
            //        T2OffPeakResponseSLAPercentage.Text = spGetT2OffPeakResponseSLAPercentage.ElementAt(0).Total.ToString();
            //    }
            //}
        }
    }
}