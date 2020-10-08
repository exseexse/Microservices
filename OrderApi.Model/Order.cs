using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderApi.Model
{
    public partial class Order
    {
        public int Id { get; set; }
        public int OrderState { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string CustomerFullName { get; set; }
    }
}
