using Common.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IAdditionalUserInfoService
    {
        List<VaccinationDTO> GetVaccinations(string userId);
        CovidInfectionDTO GetCovidInfection(string userId);
        bool AddVaccination(VaccinationDTO vaccination);
        bool addCovidInfection(CovidInfectionDTO covid);
    }
    public class AdditionalUserInfoService : IAdditionalUserInfoService
    {
        private readonly CoronaSystemContext context;
        public AdditionalUserInfoService(CoronaSystemContext context)
        {
            this.context = context;
        }

        public bool addCovidInfection(CovidInfectionDTO covid)
        {
            if (!context.CovidInfections.Any(x => x.UserId == covid.UserId))
            {
                var co = new CovidInfection()
                {
                    UserId = covid.UserId,
                    PositiveTestDate = covid.PositiveTestDate,
                    RecoveryDate = covid.RecoveryDate
                };
                context.CovidInfections.Add(co);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddVaccination(VaccinationDTO vaccination)
        {
            if (!(context.Vaccinations.Where(x => x.UserId == vaccination.UserId).Count() > 4))
            {
                var vac = new Vaccination()
                {
                    DoseNumber = vaccination.DoseNumber,
                    UserId = vaccination.UserId,
                    VaccineDate = vaccination.VaccineDate,
                    VaccineManufacturer = vaccination.VaccineManufacturer
                };
                context.Vaccinations.Add(vac);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public CovidInfectionDTO GetCovidInfection(string userId)
        {
            if (context.Users.Any(x => x.Id == userId))
            {
                var infection = context.CovidInfections.FirstOrDefault(x => x.UserId == userId);
                if (infection != null)
                {
                    return new CovidInfectionDTO()
                    {
                        UserId = userId,
                        InfectionId = infection.InfectionId,
                        PositiveTestDate = infection.PositiveTestDate,
                        RecoveryDate = infection.RecoveryDate
                    };
                }
                return null;
            }
            throw new Exception("not exist");
        }

        public List<VaccinationDTO> GetVaccinations(string userId)
        {

            if (context.Users.Any(x => x.Id == userId))
            {
                var vaccinations = context.Vaccinations.Where(x => x.UserId == userId).Select(x => new VaccinationDTO()
                {
                    UserId = userId,
                    DoseNumber = x.DoseNumber,
                    VaccinationId = x.VaccinationId,
                    VaccineDate = x.VaccineDate,
                    VaccineManufacturer = x.VaccineManufacturer
                }).ToList();
                return vaccinations;
            }
            throw new Exception("not exist");

        }
    }
}

