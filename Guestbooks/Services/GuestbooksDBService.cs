using Guestbooks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Guestbooks.Services
{
    public class GuestbooksDBService
    {
        //資料庫連線
        private readonly static string cnstr = ConfigurationManager.ConnectionStrings["Guestbook"].ConnectionString;
        private readonly SqlConnection conn = new SqlConnection(cnstr);

        #region 顯示
        public List<Guestbook> GetDataList()
        {
            List<Guestbook> DataList = new List<Guestbook>();
            //Sql
            string sql = @"SELECT * FROM Guestbooks; ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Guestbook Data = new Guestbook();
                    Data.id = Convert.ToInt32(dr["id"]);
                    Data.Account = dr["Account"].ToString();
                    Data.Content = dr["Content"].ToString();
                    Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
                    DataList.Add(Data);
                }
            }
            catch (Exception e) //e = 錯誤訊息
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
            return DataList;
        }
        #endregion

        #region 新增
        public void InsertGuestbooks (Guestbook newData)
        {
            //Sql $=內插變數 @=讓符號完整呈現
            string sql = $@"INSERT INTO Guestbooks (Account, [Content], CreateTime) VALUES ( '{newData.Account}', '{newData.Content}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' ); ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 查詢單筆
        public Guestbook GetDataById(int id)
        {
            Guestbook Data = new Guestbook();
            //Sql
            string sql = $@"SELECT * FROM Guestbooks WHERE id = {id}; ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                Data.id = Convert.ToInt32(dr["id"]);
                Data.Account = dr["Name"].ToString();
                Data.Content = dr["Content"].ToString();
                Data.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
            }
            catch (Exception e)
            {
                Data = null;
            }
            finally
            {
                conn.Close();
            }
            return Data;
        }
        #endregion

        #region 修改
        public void UpdateGuestbooks(Guestbook UpdateData)
        {
            //Sql
            string sql = $@"UPDATE Guestbooks SET Account = '{UpdateData.Account}', Content = '{UpdateData.Content}' WHERE id = {UpdateData.id}; ";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}