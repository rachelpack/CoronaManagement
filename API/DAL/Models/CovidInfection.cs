using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class CovidInfection
    {
        public int InfectionId { get; set; }
        public string UserId { get; set; }
        public DateTime? PositiveTestDate { get; set; }
        public DateTime? RecoveryDate { get; set; }

        public virtual User User { get; set; }
    }
}
