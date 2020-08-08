using BMP.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessPlanManagement
{
    public partial class UpdateLoginInformation : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        { //bilgilerin sayfaya yüklenmesini sağlar. 
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            int uId = Convert.ToInt32(Session["UserId"]);
            if (!Page.IsPostBack)
            {
                txtPassword.Attributes["type"] = "password";
                DataSet ds = UserNotificationFunctions.BilgiGetir(uId);
                txtLogname.Text = ds.Tables[0].Rows[0]["LoginName"].ToString();
                txtPassword.Text = ds.Tables[0].Rows[0]["Pass"].ToString();
            }
        }
        protected void btnLog_Click(object sender, EventArgs e)
        {
            //Giriş bilgisi güncelleme işlemini gerçekleştirir.
            int uId = Convert.ToInt32(Session["UserId"]);
            DataSet ds = UserNotificationFunctions.BilgiGetir(uId);
            if (txtLogname.Text==ds.Tables[0].Rows[0]["LoginName"].ToString()&&txtPassword.Text==ds.Tables[0].Rows[0]["Pass"].ToString())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bildirim güncelleme başarısız.En az bir bilgi değiştirilmelidir.')", true);
            }
            else
            {
                UserNotificationFunctions.BilgiGuncelle(uId, txtLogname.Text, txtPassword.Text);
                Response.Redirect("Table.aspx");
            }
        }
    }
}