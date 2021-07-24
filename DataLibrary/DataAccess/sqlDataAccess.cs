using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.DataAccess
{
    public static class sqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "WebsiteDB")
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            }
            catch (NullReferenceException ex)
            {
                return "";
            }
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }

        }
        public static int SaveData<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.Execute(sql, data);
                }
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }


        }
        public static int IsExist<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.ExecuteScalar<int>(sql, data);
                }
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }

        }
        public static string GetInfo<T>(string sql, T data)
        {
            try
            {
                using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
                {
                    return cnn.ExecuteScalar<string>(sql, data);
                }
            }
            catch (InvalidOperationException ex)
            {
                return "";
            }

        }
        public static string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
