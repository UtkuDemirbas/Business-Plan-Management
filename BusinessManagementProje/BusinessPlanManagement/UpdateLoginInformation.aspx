<%@ Page Title="" Language="C#" MasterPageFile="~/BPM.Master" AutoEventWireup="true" CodeBehind="UpdateLoginInformation.aspx.cs" Inherits="BusinessPlanManagement.UpdateLoginInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AllPageHolder" runat="server">
    <!DOCTYPE html>
<html  xmlns="http://www.w3.org/1999/xhtml" lang="en" >
    <body>
	<div class="limiter">
		<div class="container-login100" style="background-color:#d1d1d1">
			<div class="wrap-login100">
				<image class="login100-form-title" style="background-image: url(images/klimasan-600-brands.png);">
					
				</image>

				<div class="login100-form validate-form">
					<div class="wrap-input100 validate-input m-b-26" data-validate="Login name is required">
                            <span class="label-input100">Login Name</span>
                            <asp:TextBox class="input100" ID="txtLogname" runat="server" placeholder="Enter New Login Name" required="required"></asp:TextBox>
                            <span class="focus-input100"></span>
                        </div>

					
					<div class="wrap-input100 validate-input m-b-18" data-validate = "Password is required">
						<span class=" label-input100" >Password</span>
						 <asp:TextBox class="input100" ID="txtPassword" runat="server" placeholder="Enter Password" required="required"></asp:TextBox>
						<span class="focus-input100"></span>
					</div>

					<div class="container-login100-form-btn" ">
						 <asp:Button ID="btnLog" runat="server" Text="Update your login information" onClick="btnLog_Click" CssClass="login100-form-btn ml-40" style="background-color:gold"/>
					</div>
					
				</div>
			</div>
		</div>
	</div>
</body>
</html>
</asp:Content>
