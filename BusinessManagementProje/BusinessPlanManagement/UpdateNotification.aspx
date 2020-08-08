<%@ Page Language="C#" MasterPageFile="~/BPM.Master" AutoEventWireup="true" CodeBehind="UpdateNotification.aspx.cs" Inherits="BusinessPlanManagement.UpdateNotification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AllPageHolder" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id="UpdateForm">
        <div class="limiter">
            <div class="container-login100" style="background-color:#d1d1d1">
                <div class="wrap-login100">
                    <img class="login100-form-title" style="background-image: url(images/klimasan-600-brands.png);" />

                    <div class="login100-form validate-form">
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Status is required">
                            <span class="label-input100">Completion</span>
                            <asp:TextBox class="input100" ID="txtStatus" runat="server" placeholder="Enter Status" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Task is required">
                            <span class="label-input100">Task</span>
                            <asp:TextBox class="input100" ID="txtTask" runat="server" placeholder="Enter Task" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Category is required">
                            <span class="label-input100">Category</span>
                            <asp:TextBox class="input100" ID="txtCategory" runat="server" placeholder="Enter Category" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Priority is required" style="margin-top: -10px; border-bottom: 0px" >
                            <span class="label-input100">Priority</span>
                            <asp:DropDownList ID="Priority"  runat="server">
                                <asp:ListItem Selected="True" Value="Critical"> Critical </asp:ListItem>
                                <asp:ListItem Value="High">High </asp:ListItem>
                                <asp:ListItem Value="Medium"> Medium </asp:ListItem>
                                <asp:ListItem Value="Low"> Low </asp:ListItem>
                            </asp:DropDownList>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Target Date is required">
                            <span class="label-input100">Target Date</span>
                            <asp:TextBox class="input100" ID="txtTrgtDate" runat="server" placeholder="Enter Target Date" TextMode="Date" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Finish Date is required">
                            <span class="label-input100">Finish Date</span>
                            <asp:TextBox class="input100" ID="txtFnshDate" runat="server" placeholder="Enter Finish Date" TextMode="Date" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 valideate-input m-b-26" style="border-bottom: 0px">
                            <span class="label-input100" style="margin-top: -10px;">Owner</span>
                            <asp:DropDownList ID="Owner"  runat="server">
                             
                        </asp:DropDownList>
                            <span class="focus-input100"></span>
                        </div>
                        <div class="wrap-input100 validate-input m-b-26" data-validate="Description is required">
                            <span class="label-input100" style="margin-top: -10px;">Description</span>
                           <asp:TextBox class="input100" ID="txtDescription" runat="server" placeholder="Enter Description" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

                        <div class="container-login100-form-btn">
                            <asp:Button  ID="btnUpdate" runat="server" Onclick="btnUpdate_Click" class="login100-form-btn m-l-40" style="background-color: #3333ff" Text="Update Notification"/> 
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
    </asp:Content>