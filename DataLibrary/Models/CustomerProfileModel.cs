using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public  class CustomerProfileModel
    {
        public int CustomerId;

       
        public string FirstName { get; set; }

        public string LastName { get; set; }

       
        public string Address1 { get; set; }

        
        public string Address2 { get; set; }

        public string City { get; set; }
       
        public string State { get; set; }

       public string Zipcode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        public int UserCredentialsID { get; internal set; }

    }
}
