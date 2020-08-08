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
    public partial class AddNotification : System.Web.UI.Page
    {

        Notification N = new Notification();
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (Session["UserId"]==null|| Session["RoleId"].ToString() == "2")
            {
                //Yetkilendirme için kullanılır.
                Response.Redirect("Table.aspx");
            }
            DataTable dt = UserNotificationFunctions.Users();
            Owner.DataSource = dt;
            Owner.DataTextField = "UserNameSurName";
            Owner.DataValueField = "UserId";
            Owner.DataBind();
        }
        protected void btnAddNotification_Click(object sender, EventArgs e)
        {

            //Notification eklemek için kullanılır.Sadece yönetici kullanabilir.
            if ((txtTask.Text != null || txtTask.Text!="")  && (txtCategory.Text != null ||txtCategory.Text!="" ) && (txtRqstDate.Text != null|| txtRqstDate.Text!="") && (txtTrgtDate.Text != null|| txtTrgtDate.Text!="") && Owner.SelectedItem.Value!=null && Owner.Text!="Select Personel")
            {
               
                N.Task = txtTask.Text;
                N.Category = txtCategory.Text;
                N.Priority = Priority.Text;
                N.RequestDate = Convert.ToDateTime(txtRqstDate.Text);
                N.TargetDate = Convert.ToDateTime(txtTrgtDate.Text);
                N.UserId = Convert.ToInt32(Owner.SelectedItem.Value);
                UserNotificationFunctions.AddNotification(N);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificationAddTrue",
                //"alert('Ekleme başarılı.ToDoListSayfasına Yönlendiriliyorsunuz.'); window.location='Table.aspx" +
                //Request.ApplicationPath + "';", true);
                Response.Redirect("Table.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "NotificationAddFalse",
                "alert('Ekleme başarsız.ToDoListSayfasına Yönlendiriliyorsunuz.'); window.location='Table.aspx" +
                Request.ApplicationPath + "';", true);
            }
        }

        
    }
}