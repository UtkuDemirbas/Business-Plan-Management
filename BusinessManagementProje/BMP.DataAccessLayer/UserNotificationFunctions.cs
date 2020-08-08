using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BMP.DataAccessLayer
{
    public class UserNotificationFunctions
    {

        static string conString = "Server=DESKTOP-EM3U44N;Initial Catalog=DbBPM;User Id =utku;Password=10021998ud;";
        public static User Login(string LoginName, string Password)
        {
            /*Bu fonksiyon Login için giriş kontrolü yapar.sp_Login prosedürünü kullanır.
             * Gerekli parametreleri prosedüre gönderir ve kullanıcıya ait bilgileri çeker*/
            User U = new User();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@logName", LoginName);
            cmd.Parameters.AddWithValue("@pass", Password);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                U.UserId = Convert.ToInt32(rdr["UserId"]);
                U.UserNameSurName = rdr["UserName"].ToString() + " " + rdr["UserSurName"].ToString();
                U.Role = Convert.ToInt32(rdr["Role"]);
                U.LoginName = rdr["LoginName"].ToString();
                U.Password = rdr["Pass"].ToString();
            }
            con.Close();
            return U;
        }
        public static DataTable NotificationWithUser()
        {
            /*Bu fonksiyon yönetici için  notification bilgilerini tabloya(ana sayfaya) basmada kullanılır.
             *Bu bilgileri datatable şeklinde kullanıcı arayüzüne iletir. */
            string sql = "Select n.UserId,n.NotificationId,n.Status,n.Task,n.Category,u.UserName+' '+u.UserSurName as 'Owner',n.Priority,n.RequestDate,n.TargetDate,n.FinishDate,n.Description from tblNotifications n inner join tblUsers u on u.UserId = n.UserId";
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable Ntfctns = new DataTable();
                dataAdapter.Fill(Ntfctns);
               return Ntfctns;
            }

        }
        public static DataTable Users()
        {
            /*Bu fonksiyon kullanıcılara ait bilgileri dropdownlistlere basmak için kullanılır.
             * İstenilen bilgileri datable olarak kullanıcı arayüzüne gönderir.*/
            string sqlq = "Select u.UserName+' '+u.UserSurName as 'UserNameSurName',UserId  from tblUsers u";
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sqlq, con);
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.TableName = "Users";
                adpt.Fill(dt);
                return dt;
            }

        }
        public static void AddNotification(Notification N)
        {
            /*Bildirim(notification,iş) eklemek için kullanılır.Gerekli nesneden bilgileri çekip prosedüre gönderir ve veritabanına kaydeder.*/
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddNotificationWithUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tsk", N.Task);
                cmd.Parameters.AddWithValue("@Ctgry", N.Category);
                cmd.Parameters.AddWithValue("@Prrty", N.Priority);
                cmd.Parameters.AddWithValue("@RqstDate", N.RequestDate);
                cmd.Parameters.AddWithValue("@TrgtDate", N.TargetDate);
                cmd.Parameters.AddWithValue("@UsrId", N.UserId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public static void UpdateNotification(Notification N)
        {
            /*Bu fonksiyon  load edilmiş olan bilgileri güncellemek için kullanılır.
             * Nesne üzerinden aktalırılan bilgileri prosedüre gönderir ve veritabanındaki  gerekli kısımları günceller.*/
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateNotificationWithUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NtfctnId", N.NotificationId);
                cmd.Parameters.AddWithValue("@Stts", N.Status);
                cmd.Parameters.AddWithValue("@Tsk", N.Task);
                cmd.Parameters.AddWithValue("@Ctgry", N.Category);
                cmd.Parameters.AddWithValue("@Prrty", N.Priority);
                cmd.Parameters.AddWithValue("@TrgtDate", N.TargetDate);
                cmd.Parameters.AddWithValue("@FnshDate", N.FinishDate);
                cmd.Parameters.AddWithValue("@UsrId", N.UserId);
                cmd.Parameters.AddWithValue("@Dscrptn", N.Description);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }
        public static DataSet GetNotificationData(int nId)
        {
            /*Bu fonksiyon notificationa ait bilgilerin page_load olurken yüklenmesi için kullanılır.Parametre olarak notificationId'yi alır.*/
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sqlQuery = "Select N.NotificationId,N.Status,N.Task,N.Category,N.Priority,N.FinishDate,N.TargetDate,N.UserId,N.Description,U.UserName,U.UserSurName,U.Role  From tblNotifications N inner join tblUsers U on U.UserId = N.UserId where N.NotificationId=" + nId;
                con.Open();
                SqlCommand com = new SqlCommand(sqlQuery, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                return ds;
            }
        }
        public static DataTable NotificationWithRole(int UsrId)
        {
            /*Bu fonksiyon yönetici olmayan kişilerin kendi üzerindeki işlerin(notifications) tablo sayfasına basılmasında kullanılır.*/
            using (SqlConnection con = new SqlConnection(conString))
            {
                string sql = "select n.NotificationId,n.Status,n.Task,n.Category,u.UserName+' '+u.UserSurName as 'Owner',n.Priority,n.RequestDate,n.TargetDate,n.FinishDate,n.Description from tblNotifications n inner join tblUsers u on u.UserId = n.UserId where u.Role = 2 and u.UserId = " + UsrId;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable Ntfctns = new DataTable();
                dataAdapter.Fill(Ntfctns);
                return Ntfctns;
            }
        }
        public static DataSet BilgiGetir(int uId)
        {
            //Bu fonksiyon giriş bilgisi güncelleme sayfasında  kullanılır.Giriş bilgilerini veritabanından çekerek page load olurken sayfaya basar.
            string sql = "select u.LoginName,u.Pass from tblUsers u where u.UserId = " + uId;
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }

        }
        public static void BilgiGuncelle(int uId, string logName, string pass)
        {
            /*Bu fonksiyon sayfaya load olmuş bilgilerin güncellenmesinde kullanılır.
            Procedure gerekli parametreler gönderilir.Ve kullanıcı giriş bilgileri güncellenir.*/
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateLoginInf", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsrId", uId);
                cmd.Parameters.AddWithValue("@newLogName", logName);
                cmd.Parameters.AddWithValue("@newPass", pass);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
