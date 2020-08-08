<%@ Page Language="C#"  MasterPageFile="~/BPM.Master" AutoEventWireup="true" CodeBehind="AddNotification.aspx.cs" Inherits="BusinessPlanManagement.AddNotification" %>
<asp:Content ID="content1" ContentPlaceHolderID="AllPageHolder" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <div id="AddForm">
        <div class="limiter">
            <div class="container-login100" style="background-color:#d1d1d1">
                <div class="wrap-login100">
                    <img  class="login100-form-title" style="background-image: url(images/klimasan-600-brands.png)" />
                    
                <div class="login100-form validate-form">

                    <div class="wrap-input100 validate-input m-b-26" data-validate="Task is required" >
                        <span class="label-input100">Task</span>
                        <asp:TextBox class="input100" ID="txtTask" runat="server" placeholder="Enter Task" required="required"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-b-26" data-validate="Category is required">
                        <span class="label-input100">Category</span>
                        <asp:TextBox class="input100" ID="txtCategory" runat="server" placeholder="Enter Category" required="required"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-b-26" data-validate="Priority is required" style="border-bottom: 0px">
                        <span class="label-input100" style="margin-top: -10px">Priority</span>
                        <asp:DropDownList ID="Priority"
                            runat="server">
                            <asp:ListItem Selected="True" Value="Critical"> Critical </asp:ListItem>
                            <asp:ListItem Value="High">High </asp:ListItem>
                            <asp:ListItem Value="Medium"> Medium </asp:ListItem>
                            <asp:ListItem Value="Low"> Low </asp:ListItem>
                        </asp:DropDownList>
                        <span class="focus-input100"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-b-26" data-validate="Request Date is required">
                        <span class="label-input100">Request Date</span>
                        <asp:TextBox class="input100" ID="txtRqstDate" runat="server" placeholder="Enter Request Date" TextMode="Date" required="required"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>
                    <div class="wrap-input100 validate-input m-b-26" data-validate="Target Date is required">
                        <span class="label-input100">Target Date</span>
                        <asp:TextBox class="input100" ID="txtTrgtDate" runat="server" placeholder="Enter Target Date" TextMode="Date" required="required"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 valideate-input m-b-26" style="border-bottom: 0px">
                        <span class="label-input100" style="margin-top: -10px;">Owner</span>
                        <asp:DropDownList ID="Owner"  runat="server"   AppendDataBoundItems="true">
                             <asp:ListItem Selected="True" Text=" Select Personel" ></asp:ListItem>
                        </asp:DropDownList>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="btnAddNotification" runat="server" OnClick="btnAddNotification_Click" CSsclass="login100-form-btn m-l-50" style="background-color: #3333ff" Text="Add Notification"/>
                    </div>
                </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
    </asp:Content> 
