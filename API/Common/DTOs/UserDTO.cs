using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public int? AddressNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }

      // public bool InEdit { get; set; }=false;

    }
}
