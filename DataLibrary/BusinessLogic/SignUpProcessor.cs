using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class SignUpProcessor
    {

        public static int CreateUser(string email, string password)
        {
            try
            {
                SignUpModel data = new SignUpModel
                {
                    Email = email,
                    Password = password
                };
                data.Password = sqlDataAccess.EncryptString(data.Password);
                string sql = @"insert into dbo.UserInfo ( Email, Password)
                values(@Email, @Password);";
                return sqlDataAccess.SaveData(sql, data);
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }

        }
        public static int IsEmailExist(string email)
        {
            try
            {
                SignUpModel data = new SignUpModel
                {
                    Email = email
                };
                string sql = @"SELECT UserId FROM dbo.UserInfo WHERE Email = @Email;";
                return sqlDataAccess.IsExist(sql, data);
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }
        }
        public static int IsUserExists(string email, string password)
        {
            try
            {
                SignUpModel data = new SignUpModel
                {
                    Email = email,
                    Password = password
                };
                data.Password = sqlDataAccess.EncryptString(data.Password);
                string sql = @"SELECT UserId FROM dbo.UserInfo WHERE Email = @Email
                AND  Password = @Password;";

                return sqlDataAccess.IsExist(sql, data);
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }

        }
        public static bool IsUserNew(int userId)
        {

            string sql = @"select CompanyName, Address1, Address2, City, State, Zipcode
                           From CompanyProfile where UserCredentialsId = " + userId.ToString();
            if (sqlDataAccess.LoadData<CompanyPageModel>(sql).Count > 0)
            {
                return true;
            }
            else
                return false;

        }

    }
}
