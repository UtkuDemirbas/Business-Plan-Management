using BMP.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessPlanManagement
{
    public partial class UpdateNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                //Notification bilgilerini sayfaya basar.
                int nId =Convert.ToInt32(Decrypt(HttpUtility.UrlDecode(Request.QueryString["NotificationID"])));
                DataSet ds = UserNotificationFunctions.GetNotificationData(nId);
                txtTask.Text = ds.Tables[0].Rows[0]["Task"].ToString();
                txtStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                txtCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                Priority.Text = ds.Tables[0].Rows[0]["Priority"].ToString();
                txtTrgtDate.Text = ((DateTime)ds.Tables[0].Rows[0]["TargetDate"]).ToString("yyyy-MM-dd");
                if (ds.Tables[0].Rows[0]["FinishDate"]!= DBNull.Value)
                {
                    txtFnshDate.Text = ((DateTime)ds.Tables[0].Rows[0]["FinishDate"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    txtFnshDate.Text = null;
                }
                txtDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                DataTable dt = UserNotificationFunctions.Users();
                Owner.DataSource = dt;
                Owner.DataTextField = "UserNameSurName";
                Owner.DataValueField = "UserId";
                Owner.DataBind();
                Owner.SelectedValue = ((int)ds.Tables[0].Rows[0]["UserId"]).ToString();
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Notificaiton bilgilerini günceller.
            if ((txtTask.Text != null || txtTask.Text != "")&&(txtStatus.Text != null || txtStatus.Text != "")&& (txtCategory.Text != null || txtCategory.Text != "")&& (txtDescription.Text != null || txtDescription.Text != "") && (txtFnshDate.Text != null || txtFnshDate.Text != "") && (txtTrgtDate.Text != null || txtTrgtDate.Text != "") && Owner.SelectedValue != "-1")
            {
                int nId = Convert.ToInt32(Decrypt(HttpUtility.UrlDecode(Request.QueryString["NotificationID"])));
                DataSet ds = UserNotificationFunctions.GetNotificationData(nId);
                if((txtTask.Text== ds.Tables[0].Rows[0]["Task"].ToString())&&(txtStatus.Text == ds.Tables[0].Rows[0]["Status"].ToString())&& (txtCategory.Text == ds.Tables[0].Rows[0]["Category"].ToString())&& (Priority.Text == ds.Tables[0].Rows[0]["Priority"].ToString())&& (txtTrgtDate.Text ==((DateTime)ds.Tables[0].Rows[0]["TargetDate"]).ToString("yyyy-MM-dd"))&& (txtDescription.Text == ds.Tables[0].Rows[0]["Description"].ToString())&&(Owner.SelectedValue ==((int)ds.Tables[0].Rows[0]["UserId"]).ToString()))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bildirim güncelleme başarısız.En az bir bilgi değiştirilmelidir.')", true);
                }
                else
                {
                    Notification nf = new Notification();
                    nf.NotificationId = Convert.ToInt32(Decrypt(HttpUtility.UrlDecode(Request.QueryString["NotificationID"])));
                    nf.Status = txtStatus.Text.ToString();
                    nf.Task = txtTask.Text.ToString();
                    nf.Priority = Priority.SelectedValue;
                    nf.Category = txtCategory.Text.ToString();
                    nf.TargetDate = Convert.ToDateTime(txtTrgtDate.Text);
                    nf.FinishDate = Convert.ToDateTime(txtFnshDate.Text);
                    nf.Description = txtDescription.Text;
                    nf.UserId = Convert.ToInt16(Owner.SelectedValue);
                    UserNotificationFunctions.UpdateNotification(nf);
                    Response.Redirect("Table.aspx");
                }
               
            }
        }
        private string Decrypt(string cipherText)
        { //Linki decripte eder.
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}