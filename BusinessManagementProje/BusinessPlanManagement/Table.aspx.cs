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
    public partial class Table : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"]== null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            { //Yönetici için tüm işleri  sayfaya basar.
                //
                int Okey = 0, Nokey= 0;
                if ((int)Session["RoleId"] == 1)
                {
                    DataTable dt = UserNotificationFunctions.NotificationWithUser();
                    RptNotification.DataSource = dt;
                    RptNotification.DataBind();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i][0])==Convert.ToInt32(Session["UserId"]))
                        {
                            if (dt.Rows[i]["Status"] == DBNull.Value || dt.Rows[i]["Status"] == null || Convert.ToInt32(dt.Rows[i]["Status"]) < 100)
                            {
                                Nokey++;
                            }
                            else
                            {
                                Okey++;
                            }
                        }
                    }
                }
                else
                {
                    //Yönetici olmayanlar için sadece kendi üstündeki işleri sayfaya basar.
                    DataTable dt = UserNotificationFunctions.NotificationWithRole((int)Session["UserId"]);
                    RptNotification.DataSource = dt;
                    RptNotification.DataBind();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Status"]==DBNull.Value  || dt.Rows[i]["Status"]==null || Convert.ToInt32(dt.Rows[i]["Status"])<100)
                        {
                            Nokey++;
                        }
                        else
                        {
                            Okey++;
                        }
                    }
                }
                lblOkey.Text = Okey.ToString();
                lblNokey.Text = Nokey.ToString();
            }
        }
        protected string Encrypt(string clearText)
        {
            //Linki kriptalamak için kullanılır.
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}