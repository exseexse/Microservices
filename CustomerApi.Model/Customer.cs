using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Model
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}

