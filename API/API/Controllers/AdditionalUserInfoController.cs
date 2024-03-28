using BL;
using Common;
using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AdditionalUserInfoController : GlobalController
    {
        private IAdditionalUserInfoService infoService;
        public AdditionalUserInfoController(IAdditionalUserInfoService service)
        {
            this.infoService = service;
        }

        [HttpGet("GetVaccinations/{userId}")]
        public Result GetVaccinations(string userId)
        {
            try
            {
                return JsonRes(Status.Success, data: infoService.GetVaccinations(userId));
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, data:ex.Message);
            }
        }

        [HttpGet("GetCovidInfection/{userId}")]
        public Result GetCovidInfection(string userId)
        {
            try
            {
                return JsonRes(Status.Success, data: infoService.GetCovidInfection(userId));
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, message: ex.Message);
            }
        }

        [HttpPost("AddVaccination")]
        public Result AddVaccination(VaccinationDTO vaccination)
        {
            try
            {
               return JsonRes(Status.Success, data: infoService.AddVaccination(vaccination));
            }
            catch (Exception ex)
            {
              return  JsonRes(Status.Fail,message: ex.Message);   
            }
        }

        [HttpPost("addCovidInfection")]
        public Result addCovidInfection(CovidInfectionDTO covid)
        {
            try
            {
                return JsonRes(Status.Success, data: infoService.addCovidInfection(covid));
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, message: ex.Message);
            }
        }
    }
}
