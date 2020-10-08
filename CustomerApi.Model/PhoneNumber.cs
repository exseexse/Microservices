using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerApi.Model
{

    public class PhoneNumber
    {
        public int Id { get; set; }

        [Phone]
        [Required]
        public string Number { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
