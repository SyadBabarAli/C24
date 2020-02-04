<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyJarvis.Default" %>
<%@ Import Namespace="System.Web.Optimization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="stats stats-fixed">
        <div class="container">
            <div class="row text-center" style="color:#ffffff;">
                <div class="col-md-3 col-md-offset-3">
                    Start Date: <%= DateTime.Now.AddHours(-24) %>
                </div>
                <div class="col-md-3">
                    End Date: <%: DateTime.Now %>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <div class="panel panel-teal" data-toggle="tooltip" data-placement="bottom" title="Tickets Reported">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-support fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="CurrentTickets" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <div>Tickets Reported</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="panel panel-teal" data-toggle="tooltip" data-placement="bottom" title="Tickets Resolved">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-thumbs-up fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="ResolvedTickets" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <div>Tickets Resolved</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="panel panel-teal" data-toggle="tooltip" data-placement="bottom" title="Avg. Response Time in Minutes">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-reply fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="AvgResponseTime" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <div>Avg. Response Time (M)</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="panel panel-teal" data-toggle="tooltip" data-placement="bottom" title="Avg. Resolution Time in Minutes">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-xs-3">
                                    <i class="fa fa-clock-o fa-4x"></i>
                                </div>
                                <div class="col-xs-9 text-right">
                                    <div class="huge">
                                        <asp:Label ID="AvgResolutionTime" runat="server" Text="0"></asp:Label>
                                    </div>
                                    <div>Avg. Resolution Time (M)</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="space visible-lg"></div>--%>
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <i class="fa fa-area-chart"></i>Ticket Trend (Last 24 hours) <span class="pull-right"><%= DateTime.Now.AddHours(-24).ToString("yyyy-MM-dd") %></span> <span class="pull-right circle-passed-hour"></span> <span class="pull-right"><%= DateTime.Now.ToString("yyyy-MM-dd") %></span> <span class="pull-right circle-current-hour"></span>
                        <br class="visible-xs" /><br class="visible-xs" />
                    </div>
                    <div class="panel-body">
                        <div id="TicketsTrend"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="panel panel-warning">
                <div class="panel-heading text-center text-uppercase"><h4>Response Performance</h4></div>
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 Off-Peak</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2OffPeakResponseSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2OffPeakAvgResponseTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Response Time: 30 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Response Time: <asp:Label ID="lblOffPeakAvgTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOffPeakTotalMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOffPeakTotalBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 On-Site</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2OnSiteResponseSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2OnSiteAvgResponseTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Response Time: 30 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Response Time: <asp:Label ID="lblOnSiteAvgTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOnSiteTotalMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOnSiteTotalBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
            <div class="row">
            <div class="panel panel-success">
                <div class="panel-heading text-center text-uppercase"><h4>Resolution Performance</h4></div>
                <div class="panel-body">
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 Central</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2CentralSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2CentralAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 120 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblCentralAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblCentralTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblCentralTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 Communication</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2CommunicationsSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2CommunicationsAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblCommAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblCommTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblCommTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 Gulshan</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2GulshanSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2GulshanAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblGulshanAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblGulshanTotalMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblGulshanTotalBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 Networks</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2NetworksSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2NetworksAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblNetworkAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblNetworkTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblNetworkTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 Off-Peak</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2OffPeakSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2OffPeakAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblOffPeakAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOffPeakTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOffPeakTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 On-Site</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2OnSiteSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2OnSiteAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblOnSiteAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOnSiteTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOnSiteTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default" style="display:none;">
                            <br />
                            <h4 class="text-center">IT T2 Off-Site</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2OffSiteSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2OffSiteAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblOffSiteAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOffSiteTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOffSiteTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-md-offset-3">
                        <%--<div class="panel panel-default">
                            <br />
                            <h4 class="text-center">IT T2 On-Site</h4>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div id="T2OnSiteSLAStatus"></div>
                                    </div>
                                    <div class="col-md-6">
                                        <div id="T2OnSiteAvgResolutionTime"></div>
                                    </div>
                                    <div class="col-xs-12 col-md-8 col-md-offset-2">
                                        <ul class="list-group" style="margin-bottom:0;">
                                            <li class="list-group-item text-center">
                                                Target Resolution Time: 180 Minutes
                                            </li>
                                            <li class="list-group-item text-center">
                                                Average Resolution Time: <asp:Label ID="lblOnSiteAvgResTime" runat="server"></asp:Label> Minutes
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-green"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Met <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOnSiteTotalResMet" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="list-group-item">
                                                <div class="row">
                                                    <div class="col-xs-1">
                                                        <div class="circle-red"></div>
                                                    </div>
                                                    <div class="col-xs-10">
                                                        SLA Breached <span class="pull-right" style="margin-left:2px;">Tickets</span> <asp:Label ID="lblOnSiteTotalResBreached" runat="server" CssClass="pull-right"></asp:Label>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                        <p class="text-muted"><small>*SLA = Service Level Agreement</small></p>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <%: Scripts.Render("~/bundles/frontpage")  %>
</asp:Content>
