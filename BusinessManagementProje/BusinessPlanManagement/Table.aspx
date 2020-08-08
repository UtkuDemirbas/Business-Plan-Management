<%@ Page Language="C#" MasterPageFile="~/BPM.Master" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="BusinessPlanManagement.Table" %>

<asp:Content ID="AllPage" ContentPlaceHolderID="AllPageHolder" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml" lang="en">
    <body>
        <div class="container-fluid">

        <div class="row" style="background-color: #d1d1d1; margin-top: 50px">
            <div class="col-md-6 col-lg-4 offset-lg-2 col-xlg-3">
                <div class="card card-hover">
                    <div class="box bg-warning text-center" style="outline-style: solid">
                        <h1 class="font-light text-white"><i class="fas fa-check"></i></h1>
                        <h6 class="text-white">Tamamlanmış iş saysı:
                            <asp:Label ID="lblOkey" value="0" runat="server" /></h6>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-lg-4 col-xlg-3">
                <div class="card card-hover">
                    <div class="box bg-success text-center" style="outline-style: solid">
                        <h1 class="font-light text-white"><i class="fas fa-times"></i></h1>
                        <h6 class="text-white">Bekleyen İş sayısı:
                            <asp:Label ID="lblNokey" value="0" runat="server" /></h6>
                    </div>
                </div>
            </div>
        </div>
            </div>
        <div class="limiter">
            <div class="container-table100">
                <div class="wrap-table100 m-b-300">
                    <div class="table100">
                        <table data-vertable="ver1" border="0">
                            <thead>
                                <tr class="table100-head">
                                    <th class="column1">Notification Id</th>
                                    <th class="column2">Completion</th>
                                    <th class="column3">Task</th>
                                    <th class="column4">Category</th>
                                    <th class="column5">Owner</th>
                                    <th class="column6">Priority</th>
                                    <th class="column7">Request Date</th>
                                    <th class="column8">Target Date</th>
                                    <th class="column9">Finish Date</th>
                                    <th class="column10">Description</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RptNotification" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="column1">
                                                <asp:HyperLink ID="HpyId" runat="server" NavigateUrl='<%# "~/UpdateNotification.aspx?NotificationID="+this.Encrypt(Eval("NotificationID").ToString()) %>'><%# Eval("NotificationId") %> </asp:HyperLink>
                                            </td>
                                            <td class="column2"><%# Eval("Status")%></td>
                                            <td class="column3"><%# Eval("Task")%></td>
                                            <td class="column4"><%# Eval("Category")%></td>
                                            <td class="column5"><%# Eval("Owner")%></td>
                                            <td class="column6"><%# Eval("Priority")%></td>
                                            <td class="column7"><%# Eval("RequestDate","{0: dd/MM/yyyy}")%></td>
                                            <td class="column8"><%# Eval("TargetDate","{0: dd/MM/yyyy}")%></td>
                                            <td class="column9"><%# Eval("FinishDate","{0: dd/MM/yyyy}")%></td>
                                            <td class="column10"><%# Eval("Description")%></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </body>
    </html>
</asp:Content>
