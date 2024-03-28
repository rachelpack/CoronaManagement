using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class VaccinationDTO
    {
        public int VaccinationId { get; set; }
        public string UserId { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string VaccineManufacturer { get; set; }
        public int? DoseNumber { get; set; }
    }
}
