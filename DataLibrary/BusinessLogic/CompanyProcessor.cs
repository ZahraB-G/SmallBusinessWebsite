using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class CompanyProcessor
    {
        public static int InsertCompanyInformation(string companyName, string add1, string add2,
        string city, string state, string zipcode, int usercredentialsId)
        {
            try
            {
                CompanyProfileModel data = new CompanyProfileModel
                {
                    CompanyName = companyName,
                    Address1 = add1,
                    Address2 = add2,
                    City = city,
                    State = state,
                    Zipcode = zipcode,
                    UserCredentialsID = usercredentialsId
                };
                string sql = @"insert into CompanyProfile (CompanyName, Address1, Address2,
                City,State,Zipcode,UserCredentialsID)
                values(@CompanyName, @Address1, @Address2,@City, @State, @Zipcode,@UserCredentialsID);";
                return sqlDataAccess.SaveData(sql, data);
            }
            catch (InvalidOperationException ex)
            {
                return 0;
            }

        }
    }
}
