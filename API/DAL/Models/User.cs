using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            CovidInfections = new HashSet<CovidInfection>();
            Vaccinations = new HashSet<Vaccination>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressCity { get; set; }
        public string AddressStreet { get; set; }
        public int? AddressNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }

        public virtual ICollection<CovidInfection> CovidInfections { get; set; }
        public virtual ICollection<Vaccination> Vaccinations { get; set; }
    }
}
