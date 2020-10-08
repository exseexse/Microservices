using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Model
{
    public class UpdateCustomerFullNameModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
