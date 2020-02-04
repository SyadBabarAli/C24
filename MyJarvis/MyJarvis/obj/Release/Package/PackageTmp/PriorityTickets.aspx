<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PriorityTickets.aspx.cs" Inherits="MyJarvis.PriorityTickets" %>
<%@ Import Namespace="System.Web.Optimization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        Last refreshed on <span><%: DateTime.Now %></span>
        <div class="panel panel-teal-inverse">
            <div class="panel-heading">
                Yearly Priority Tickets
            </div>
            <div class="panel-body">
        <ul class="nav nav-tabs">
            <li><a href="#2016" data-toggle="tab">2016</a>
            </li>
            <li class="active"><a href="#2017" data-toggle="tab">2017</a>
            </li>
        </ul>
        <form runat="server">
        <div class="tab-content">
            <div class="tab-pane fade" id="2016">
                        <div class="row">
                            <div class="col-lg-6">
                        <div id="priority-spline2016"></div>
                            </div>
                        <div class="col-lg-6">
                        <div id="priority-column2016"></div>
                            </div>
                        </div>
                <hr />
        <div class="row">
            <div class="col-lg-12">
                <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="table table-striped table-bordered" ShowFooter="true">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                                <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" ReadOnly="True" SortExpression="CreatedDate"></asp:BoundField>
                                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                                <asp:BoundField DataField="SupportGroup" HeaderText="SupportGroup" ReadOnly="True" SortExpression="SupportGroup"></asp:BoundField>
                                <asp:BoundField DataField="ResolvedBy" HeaderText="ResolvedBy" SortExpression="ResolvedBy"></asp:BoundField>
                                <asp:BoundField DataField="ResolutionDescription" HeaderText="ResolutionDescription" SortExpression="ResolutionDescription"></asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DWDataMartConnectionString %>' SelectCommand="spGetPriorityTickets2016" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </div>
            </div>
            <div class="tab-pane fade active in" id="2017">
                <div class="row">
                            <div class="col-lg-6">
                        <div id="priority-spline2017"></div>
                            </div>
                        <div class="col-lg-6">
                        <div id="priority-column2017"></div>
                            </div>
                        </div>
                <hr />
        <div class="row">
            <div class="col-lg-12">
                <div class="table-responsive">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="table table-striped table-bordered" ShowFooter="true">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" ReadOnly="True" SortExpression="CreatedDate"></asp:BoundField>
                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                            <asp:BoundField DataField="SupportGroup" HeaderText="SupportGroup" ReadOnly="True" SortExpression="SupportGroup"></asp:BoundField>
                            <asp:BoundField DataField="ResolvedBy" HeaderText="ResolvedBy" SortExpression="ResolvedBy"></asp:BoundField>
                            <asp:BoundField DataField="ResolutionDescription" HeaderText="ResolutionDescription" SortExpression="ResolutionDescription"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DWDataMartConnectionString %>' SelectCommand="spGetPriorityTickets2017" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                </div>
            </div>
        </div>
            </div>
        </div>
        </form>
            </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <%: Scripts.Render("~/bundles/prioritypage")  %>
    <script>
        $(document).ready(function () {
            $('#<%= GridView1.ClientID %>').DataTable({
                "paging": false,
                "order": [1, "desc"]
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            $('#<%= GridView2.ClientID %>').DataTable({
                "paging": false,
                "order": [1, "desc"]
            });
        });
    </script>
</asp:Content>
