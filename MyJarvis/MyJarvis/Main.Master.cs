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
    public partial class Main : System.Web.UI.MasterPage
    {
        string strConnString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string strPending;
        string strPriority;

        SqlCommand com;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            strPending = "spGetPendingTickets";
            com = new SqlCommand(strPending, con);
            SqlDataReader readerPending = com.ExecuteReader();
            readerPending.Read();
            PendingTickets.Text = readerPending["Total"].ToString();
            readerPending.Close();
            con.Close();

            con.Open();
            strPriority = "spGetCurrentPriorityTickets";
            com = new SqlCommand(strPriority, con);
            SqlDataReader readerPriority = com.ExecuteReader();
            readerPriority.Read();
            PriorityTickets.Text = readerPriority["Total"].ToString();
            readerPriority.Close();
            con.Close();
        }
    }
}