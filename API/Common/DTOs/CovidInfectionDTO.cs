using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class CovidInfectionDTO
    {
        public int InfectionId { get; set; }
        public string UserId { get; set; }
        public DateTime? PositiveTestDate { get; set; }
        public DateTime? RecoveryDate { get; set; }
    }
}
