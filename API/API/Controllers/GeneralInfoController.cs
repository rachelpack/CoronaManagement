using BL;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GeneralInfoController : GlobalController
    {
        private IGeneralInfoService generalInfo;
        public GeneralInfoController( IGeneralInfoService infoService)
        {
                 this.generalInfo = infoService;
        }

        [HttpGet("GetActivePatients")]
        public Result GetActivePatients()
        {
            try
            {
                return JsonRes(Status.Success, data: generalInfo.ActivePatientsLastMonth());
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, message: ex.Message);
            }
        }


        [HttpGet("GetNumberUnvaccinatedPatients")]
        public Result GetNumberUnvaccinatedPatients()
        {
            try
            {
                return JsonRes(Status.Success, data: generalInfo.GetNumberUnvaccinatedPatients());
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, message:ex.Message);
            }
        }
    }
}
