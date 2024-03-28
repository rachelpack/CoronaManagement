using BL;
using Common;
using Common.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace API.Controllers
{

    public class UsersController : GlobalController
    {
        private IUserService usersService;
        public UsersController(IUserService usersService)
        {
            this.usersService = usersService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public Result GetUsers()
        {
            try
            {
                return JsonRes(Status.Success, data: usersService.GetUsers());
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, message: ex.ToString());
            }

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Result GetUser(string id)
        {
            try
            {
                return JsonRes(Status.Success, data: usersService.GetUser(id));
            }
            catch (Exception ex)
            {
                return JsonRes(Status.Fail, message: ex.ToString());
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Result Post(UserDTO user)
        {
            var res = usersService.AddUser(user);
            if (res)
            {
                return JsonRes(Status.Success);
            }
            else
            {
                return JsonRes(Status.Fail);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public Result Put(string id, UserDTO user)
        {
            var res = usersService.UpdateUser(id, user);
            if (res)
            {
                return JsonRes(Status.Success);
            }
            else
            {
                return JsonRes(Status.Fail, message: "user not exist");
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public Result Delete(string id)
        {
            var res = usersService.DeleteUser(id);
            if (res)
            {
                return JsonRes(Status.Success);
            }
            else
            {
                return JsonRes(Status.Fail, message: "user not exist");
            }
        }
    }
}
