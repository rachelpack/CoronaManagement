using Common.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BL.GeneralInfoService;

namespace BL
{
    public interface IGeneralInfoService
    {
        Dictionary<DateTime, int> ActivePatientsLastMonth();
        int GetNumberUnvaccinatedPatients();
    }
    public class GeneralInfoService : IGeneralInfoService
    {
        private readonly CoronaSystemContext context;
        public GeneralInfoService(CoronaSystemContext context)
        {
            this.context = context;
        }

        public Dictionary<DateTime, int> ActivePatientsLastMonth()
        {

            var activePatients = context.CovidInfections.Where(x => x.PositiveTestDate.HasValue && x.PositiveTestDate.Value.Month == DateTime.Today.Month ||
             x.RecoveryDate.HasValue && x.RecoveryDate.Value.Month == DateTime.Today.Month).ToList();
            return CalculateDailyPatientCount(activePatients);

        }
        public static Dictionary<DateTime, int> CalculateDailyPatientCount(List<CovidInfection> patients)
        {
            Dictionary<DateTime, int> dailyCount = new Dictionary<DateTime, int>();

            foreach (var patient in patients)
            {
                for (DateTime date = (DateTime)patient.PositiveTestDate; date <= patient.RecoveryDate; date = date.AddDays(1))
                {
                    if (date.Month == DateTime.Today.Month)
                    {
                        if (dailyCount.ContainsKey(date))
                        {
                            dailyCount[date]++;
                        }
                        else
                        {
                            dailyCount[date] = 1;
                        }
                    }
                }
            }
            var sortedDictionary = dailyCount.OrderBy(x => x.Key.Day).ToDictionary(pair => pair.Key, pair => pair.Value);
            return sortedDictionary;
        }
       public int GetNumberUnvaccinatedPatients()
        {
            int countOfPatients = context.Users.Count(u=>!context.Vaccinations.Any(v=>v.UserId==u.Id));
            return countOfPatients;
        }



    }
}

