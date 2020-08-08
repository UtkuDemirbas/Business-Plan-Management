using BMP.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessPlanManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            //Login için bilgilerin kontrolünü yapar ve anasayfaya yönlendirir.Yetkilendirme için 2 id yi sessionda tutar.
            User us = UserNotificationFunctions.Login(txtLogName.Text, txtPassword.Text);
            if (us != null && us.LoginName != null && us.Password != null)
            {
                Session["UserId"] = us.UserId;
                Session["RoleId"] = us.Role;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "LoginTrue",
                //"alert('Giriş başarılı.ToDoListSayfasına Yönlendiriliyorsunuz.'); window.location='Table.aspx" +
                //Request.ApplicationPath + "';", true);
                Response.Redirect("Table.aspx");

            }
            else
            {

               ScriptManager.RegisterStartupScript(this, this.GetType(), "LoginFalse", "javascript:alert('Giriş Başarısız.Tekrar Deneyiniz.')", true);

            }
            
        }
    }
}