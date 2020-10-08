using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderApi.Model
{
    public class OrderModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(2)]
        public string CustomerFullName { get; set; }
    }
}
