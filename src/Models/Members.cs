using System;
using System.Collections.Generic;

namespace SMSApi.Models
{
    public partial class Members
    {
        public Guid MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int? MobileNo { get; set; }
        public string EmailId { get; set; }

    }
}
