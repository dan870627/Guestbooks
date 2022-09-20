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

        //顯示
        public List<Guestbook> GetDataList()
        {
            List<Guestbook> DataList = new List<Guestbook>();
            //Sql
            string sql = @"SELECT * FROM [Guestbook0921].[dbo].[Guestbooks]; ";
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
    }
}