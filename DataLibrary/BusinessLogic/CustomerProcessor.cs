using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CustomerProcessor
    {
        public static int InsertCustomerInformation(string first, string last, string add1, string add2,
        string city, string state, string zipcode,string email, string phone, int usercredentialsId)
        {
            try
            {
                CustomerProfileModel data = new CustomerProfileModel
                {
                    FirstName = first,
                    LastName = last,
                    Address1 = add1,
                    Address2 = add2,
                    City = city,
                    State = state,
                    Zipcode = zipcode,
                    Email = email,
                    Phone = phone,
                    UserCredentialsID = usercredentialsId
                };
                string sql = @"insert into CustomerProfile (FirstName, LastName, Address1, Address2,
                City,State,Zipcode,Email, Phone, UserCredentialsID)
                values(@FirstName,@LastName, @Address1, @Address2,@City, @State, @Zipcode, @Email , @Phone, @UserCredentialsID);";
                return sqlDataAccess.SaveData(sql, data);
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }

        }
        public static List<CustomerProfileModel> LoadCustomers(int userCredentialsId)
        {
            try
            {
                CustomerProfileModel data = new CustomerProfileModel
                {
                    UserCredentialsID = userCredentialsId
                };
                string sql = @"select FirstName,
                           LastName, 
                           Address1, 
                           Address2,
                           City,
                           State,
                           Zipcode,
                           Email,Phone
                           From dbo.CustomerProfile
                           Where UserCredentialsID =" + data.UserCredentialsID + ";";
                return sqlDataAccess.LoadData<CustomerProfileModel>(sql);
            }
            catch (InvalidOperationException ex)
            {
                return null;
            }

        }
        public static int IsCustomerExisted(int usercredentialsId)
        {
            try
            {
                CustomerProfileModel data = new CustomerProfileModel
                {
                    UserCredentialsID = usercredentialsId
                };

                string sql = @"SELECT CustomerId FROM dbo.CustomerProfile WHERE UserCredentialsID = @UserCredentialsID;";
                return sqlDataAccess.IsExist(sql, data);
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }

        }
    }
}
