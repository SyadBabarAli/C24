<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PendingTickets.aspx.cs" Inherits="MyJarvis.PendingTickets" %>
<%@ Import Namespace="System.Web.Optimization" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="container">
        Last refreshed on <span><%: DateTime.Now %></span>
        <div class="row">
                    <div class="col-lg-12">
                        <%--<div class="circle"><asp:Label ID="T2OffPeakResponseSLAPercentage" runat="server" Text="Label"></asp:Label></div>--%>
                        <div class="panel panel-warning">
                            <div class="panel-heading">
                                Ticket Status (> 2 days)
                            </div>
                            <div class="panel-body">
                                <div class="col-lg-6">
                                    <div id="PendingTicketsStatus"></div>
                                </div>
                                <div class="col-lg-3">
					    <div class="panel panel-orange">
						    <div class="panel-heading">
							    <div class="row">
								    <div class="col-xs-3">
									    <i class="fa fa-plug fa-5x"></i>
								    </div>
								    <div class="col-xs-9 text-right">
                                        <div>Active (IT Pending)</div>
                                        <asp:Label ID="Active" runat="server" Text="0" class="huge"></asp:Label>
								    </div>
							    </div>
						    </div>
						    <!-- <a href="#"> -->
							    <div class="panel-footer">
								    <span class="pull-left">Average Days</span>
								    <span class="pull-right"><asp:Label ID="ActiveAvgTime" runat="server" Text="0"></asp:Label></span>
								    <div class="clearfix"></div>
							    </div>
						    <!-- </a> -->
					    </div>
				    </div>
            <div class="col-lg-3">
					    <div class="panel panel-brown">
						    <div class="panel-heading">
							    <div class="row">
								    <div class="col-xs-3">
									    <i class="fa fa-user fa-5x"></i>
								    </div>
								    <div class="col-xs-9 text-right">
                                        <div>User Pending</div>
                                        <asp:Label ID="UserPending" runat="server" Text="0" class="huge"></asp:Label>
								    </div>
							    </div>
						    </div>
							<!-- <a href="#"> -->
								<div class="panel-footer">
									<span class="pull-left">Average Days</span>
									<span class="pull-right"><asp:Label ID="UserPendingAvgTime" runat="server" Text="0"></asp:Label></span>
									<div class="clearfix"></div>
								</div>
							<!-- </a> -->
					    </div>
				    </div>
            <div class="col-lg-3">
					    <div class="panel panel-blue">
						    <div class="panel-heading">
							    <div class="row">
								    <div class="col-xs-3">
									    <i class="fa fa-wrench fa-5x"></i>
								    </div>
								    <div class="col-xs-9 text-right">
                                        <div>Vendor Pending</div>
                                        <asp:Label ID="VendorPending" runat="server" Text="0" class="huge"></asp:Label>
								    </div>
							    </div>
						    </div>
						    <!-- <a href="#"> -->
							    <div class="panel-footer">
								    <span class="pull-left">Average Days</span>
								    <span class="pull-right"><asp:Label ID="VendorPendingAvgTime" runat="server" Text="0"></asp:Label></span>
								    <div class="clearfix"></div>
							    </div>
						    <!-- </a> -->
					    </div>
				    </div>
            <div class="col-lg-3">
					    <div class="panel panel-deep-purple">
						    <div class="panel-heading">
							    <div class="row">
								    <div class="col-xs-3">
									    <i class="fa fa-hourglass-half fa-5x"></i>
								    </div>
								    <div class="col-xs-9 text-right">
                                        <div>Total Pending</div>
                                        <asp:Label ID="TotalPending" runat="server" Text="0" class="huge"></asp:Label>
								    </div>
							    </div>
						    </div>
						    <!-- <a href="#"> -->
							    <div class="panel-footer">
								    <span class="pull-left">Average Days</span>
								    <span class="pull-right"><asp:Label ID="TotalPendingAvgTime" runat="server" Text="0"></asp:Label></span>
								    <div class="clearfix"></div>
							    </div>
						    <!-- </a> -->
					    </div>
				    </div>
                            </div>
                        </div>
                    </div>
                </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-teal-inverse">
                    <div class="panel-heading">
                        Pending Tickets by Support Group
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#ActiveTickets" data-toggle="tab">Active</a>
                            </li>
                            <li class=""><a href="#UPTickets" data-toggle="tab">User Pending</a>
                            </li>
                            <li class=""><a href="#VPTickets" data-toggle="tab">Vendor Pending</a>
                            </li>
                        </ul>
                        <form runat="server">
                            <div class="tab-content">
                            <div class="tab-pane fade active in" id="ActiveTickets">
                                <div id="StackedActiveTickets"></div>
                                <hr />
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" ShowFooter="true">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                                            <asp:BoundField DataField="AffectedUser" HeaderText="AffectedUser" SortExpression="AffectedUser" HeaderStyle-CssClass="select-filter"></asp:BoundField>
                                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                                            <asp:BoundField DataField="Classification" HeaderText="Classification" ReadOnly="True" SortExpression="Classification"></asp:BoundField>
                                            <asp:BoundField DataField="SupportGroup" HeaderText="SupportGroup" ReadOnly="True" SortExpression="SupportGroup" HeaderStyle-CssClass="select-filter"></asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
                                            <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="True" SortExpression="Age"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DWDataMartConnectionString %>' SelectCommand="spGetActiveTickets" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="UPTickets">
                                <div id="StackedUPTickets"></div>
                                <hr />
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" ShowFooter="true">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                                            <asp:BoundField DataField="AffectedUser" HeaderText="AffectedUser" SortExpression="AffectedUser" HeaderStyle-CssClass="select-filter"></asp:BoundField>
                                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                                            <asp:BoundField DataField="Classification" HeaderText="Classification" ReadOnly="True" SortExpression="Classification"></asp:BoundField>
                                            <asp:BoundField DataField="SupportGroup" HeaderText="SupportGroup" ReadOnly="True" SortExpression="SupportGroup" HeaderStyle-CssClass="select-filter"></asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
                                            <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="True" SortExpression="Age"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:DWDataMartConnectionString %>' SelectCommand="spGetUPTickets" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="VPTickets">
                                <div id="StackedVPTickets"></div>
                                <hr />
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" CssClass="table table-striped table-bordered" ShowFooter="true">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
                                            <asp:BoundField DataField="AffectedUser" HeaderText="AffectedUser" SortExpression="AffectedUser" HeaderStyle-CssClass="select-filter"></asp:BoundField>
                                            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
                                            <asp:BoundField DataField="Classification" HeaderText="Classification" ReadOnly="True" SortExpression="Classification"></asp:BoundField>
                                            <asp:BoundField DataField="SupportGroup" HeaderText="SupportGroup" ReadOnly="True" SortExpression="SupportGroup" HeaderStyle-CssClass="select-filter"></asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" SortExpression="Status"></asp:BoundField>
                                            <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="True" SortExpression="Age"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString='<%$ ConnectionStrings:DWDataMartConnectionString %>' SelectCommand="spGetVPTickets" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                                </div>
                            </div>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
    <%: Scripts.Render("~/bundles/pendingpage")  %>
    <script>
        $(document).ready(function () {
            var table = $('#<%= GridView1.ClientID %>').DataTable({
                "paging": false,
                "order": [6, "desc"],
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                initComplete: function () {
                    // Forces selective filters only
                    this.api().columns('.select-filter').every(function () {
                        var column = this;
                        var select = $('<select><option value=""></option></select>')
                          .appendTo($(column.footer()).empty())
                          .on('change', function () {
                              var val = $.fn.dataTable.util.escapeRegex(
                                $(this).val()
                              );

                              column
                                .search(val ? '^' + val + '$' : '', true, false)
                                .draw();
                          });

                        column.data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                    });
                    // Moves tfoot beneath thead
                    var r = $('#<%= GridView1.ClientID %> tfoot tr');
                    r.find('th').each(function () {

                        $(this).css('padding', 8);

                    });
                    $('#<%= GridView1.ClientID %> thead').append(r);
                }
            });

            table.on('draw', function () {
                table.columns().indexes().each(function (idx) {
                    var select = $(table.column(idx).footer()).find('select');

                    if (select.val() === '') {
                        select
                          .empty()
                          .append('<option value=""/>');

                        // Forces API to display filtered fields only
                        table.column(idx, { search: 'applied' }).data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                    }
                });
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            var table = $('#<%= GridView2.ClientID %>').DataTable({
                "paging": false,
                "order": [6, "desc"],
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                initComplete: function () {
                    // Forces selective filters only
                    this.api().columns('.select-filter').every(function () {
                        var column = this;
                        var select = $('<select><option value=""></option></select>')
                          .appendTo($(column.footer()).empty())
                          .on('change', function () {
                              var val = $.fn.dataTable.util.escapeRegex(
                                $(this).val()
                              );

                              column
                                .search(val ? '^' + val + '$' : '', true, false)
                                .draw();
                          });

                        column.data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                    });
                    // Moves tfoot beneath thead
                    var r = $('#<%= GridView2.ClientID %> tfoot tr');
                    r.find('th').each(function () {

                        $(this).css('padding', 8);

                    });
                    $('#<%= GridView2.ClientID %> thead').append(r);
                }
            });

            table.on('draw', function () {
                table.columns().indexes().each(function (idx) {
                    var select = $(table.column(idx).footer()).find('select');

                    if (select.val() === '') {
                        select
                          .empty()
                          .append('<option value=""/>');

                        // Forces API to display filtered fields only
                        table.column(idx, { search: 'applied' }).data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                    }
                });
            });
        });
    </script>
    <script>
        $(document).ready(function () {
            var table = $('#<%= GridView3.ClientID %>').DataTable({
                "paging": false,
                "order": [6, "desc"],
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                initComplete: function () {
                    // Forces selective filters only
                    this.api().columns('.select-filter').every(function () {
                        var column = this;
                        var select = $('<select><option value=""></option></select>')
                          .appendTo($(column.footer()).empty())
                          .on('change', function () {
                              var val = $.fn.dataTable.util.escapeRegex(
                                $(this).val()
                              );

                              column
                                .search(val ? '^' + val + '$' : '', true, false)
                                .draw();
                          });

                        column.data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                    });
                    // Moves tfoot beneath thead
                    var r = $('#<%= GridView3.ClientID %> tfoot tr');
                    r.find('th').each(function () {

                        $(this).css('padding', 8);

                    });
                    $('#<%= GridView3.ClientID %> thead').append(r);
                }
            });

            table.on('draw', function () {
                table.columns().indexes().each(function (idx) {
                    var select = $(table.column(idx).footer()).find('select');

                    if (select.val() === '') {
                        select
                          .empty()
                          .append('<option value=""/>');

                        // Forces API to display filtered fields only
                        table.column(idx, { search: 'applied' }).data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>');
                        });
                    }
                });
            });
        });
    </script>
</asp:Content>
