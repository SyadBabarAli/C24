﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyJarvis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DWDataMartEntities : DbContext
    {
        public DWDataMartEntities()
            : base("name=DWDataMartEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<spGetPendingTicketsAvgTime_Result> spGetPendingTicketsAvgTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetPendingTicketsAvgTime_Result>("spGetPendingTicketsAvgTime");
        }
    
        public virtual ObjectResult<spGetPendingTicketsAvgTimeD_Result> spGetPendingTicketsAvgTimeD()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetPendingTicketsAvgTimeD_Result>("spGetPendingTicketsAvgTimeD");
        }
    
        public virtual ObjectResult<spGetPendingTicketsStatus_Result> spGetPendingTicketsStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetPendingTicketsStatus_Result>("spGetPendingTicketsStatus");
        }
    
        public virtual ObjectResult<spGetT2OffPeakResponseSLAPercentage_Result> spGetT2OffPeakResponseSLAPercentage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffPeakResponseSLAPercentage_Result>("spGetT2OffPeakResponseSLAPercentage");
        }
    
        public virtual ObjectResult<spGetT2CentralAvgResolutionTime_Result> spGetT2CentralAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2CentralAvgResolutionTime_Result>("spGetT2CentralAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2CentralSLAStatus_Result> spGetT2CentralSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2CentralSLAStatus_Result>("spGetT2CentralSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2CommunicationsAvgResolutionTime_Result> spGetT2CommunicationsAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2CommunicationsAvgResolutionTime_Result>("spGetT2CommunicationsAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2CommunicationsSLAStatus_Result> spGetT2CommunicationsSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2CommunicationsSLAStatus_Result>("spGetT2CommunicationsSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2GulshanAvgResolutionTime_Result> spGetT2GulshanAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2GulshanAvgResolutionTime_Result>("spGetT2GulshanAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2GulshanSLAStatus_Result> spGetT2GulshanSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2GulshanSLAStatus_Result>("spGetT2GulshanSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2NetworksAvgResolutionTime_Result> spGetT2NetworksAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2NetworksAvgResolutionTime_Result>("spGetT2NetworksAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2NetworksSLAStatus_Result> spGetT2NetworksSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2NetworksSLAStatus_Result>("spGetT2NetworksSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2OffPeakAvgResolutionTime_Result> spGetT2OffPeakAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffPeakAvgResolutionTime_Result>("spGetT2OffPeakAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2OffPeakAvgResponseTime_Result> spGetT2OffPeakAvgResponseTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffPeakAvgResponseTime_Result>("spGetT2OffPeakAvgResponseTime");
        }
    
        public virtual ObjectResult<spGetT2OffPeakResponseSLAStatus_Result> spGetT2OffPeakResponseSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffPeakResponseSLAStatus_Result>("spGetT2OffPeakResponseSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2OffPeakSLAStatus_Result> spGetT2OffPeakSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffPeakSLAStatus_Result>("spGetT2OffPeakSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2OffSiteAvgResolutionTime_Result> spGetT2OffSiteAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffSiteAvgResolutionTime_Result>("spGetT2OffSiteAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2OffSiteSLAStatus_Result> spGetT2OffSiteSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OffSiteSLAStatus_Result>("spGetT2OffSiteSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2OnSiteAvgResolutionTime_Result> spGetT2OnSiteAvgResolutionTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OnSiteAvgResolutionTime_Result>("spGetT2OnSiteAvgResolutionTime");
        }
    
        public virtual ObjectResult<spGetT2OnSiteAvgResponseTime_Result> spGetT2OnSiteAvgResponseTime()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OnSiteAvgResponseTime_Result>("spGetT2OnSiteAvgResponseTime");
        }
    
        public virtual ObjectResult<spGetT2OnSiteResponseSLAStatus_Result> spGetT2OnSiteResponseSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OnSiteResponseSLAStatus_Result>("spGetT2OnSiteResponseSLAStatus");
        }
    
        public virtual ObjectResult<spGetT2OnSiteSLAStatus_Result> spGetT2OnSiteSLAStatus()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetT2OnSiteSLAStatus_Result>("spGetT2OnSiteSLAStatus");
        }
    }
}
