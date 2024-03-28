using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Vaccination
    {
        public int VaccinationId { get; set; }
        public string UserId { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string VaccineManufacturer { get; set; }
        public int? DoseNumber { get; set; }

        public virtual User User { get; set; }
    }
}
