using Common.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserService
    {
        List<UserDTO> GetUsers();
        UserDTO GetUser(string id);
        bool AddUser(UserDTO user);
        bool UpdateUser(string id,UserDTO user);
        bool DeleteUser(string id);

    }
    public class UserService:IUserService
    {
        private readonly CoronaSystemContext context;

        public UserService(CoronaSystemContext context)
        {
            this.context = context;
        }
        public bool AddUser(UserDTO user)
        {
            if (context.Users.Any(x => x.Id == user.Id))
            {
                return false;
            }
            var newUser = new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressCity = user.AddressCity,
                AddressStreet = user.AddressStreet,
                AddressNumber = user.AddressNumber,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                MobilePhone = user.MobilePhone
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            return true;
        }

        public bool DeleteUser(string id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                if (context.CovidInfections.Any(x => x.UserId == id))
                {
                    context.CovidInfections.Remove(context.CovidInfections.FirstOrDefault(x => x.UserId == id));
                }
                var vaccOfUser = context.Vaccinations.Where(x => x.UserId == id).ToList();
                if (vaccOfUser != null)
                {
                    foreach (var vacc in vaccOfUser)
                    {
                        context.Vaccinations.Remove(vacc);
                    }
                }
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public UserDTO GetUser(string id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);
            return new UserDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AddressCity = user.AddressCity,
                AddressStreet = user.AddressStreet,
                AddressNumber = user.AddressNumber,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                MobilePhone = user.MobilePhone
            };
        }

        public List<UserDTO> GetUsers()
        {
            var users = context.Users.Select(x => new UserDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                AddressCity = x.AddressCity,
                AddressStreet = x.AddressStreet,
                AddressNumber = x.AddressNumber,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                MobilePhone = x.MobilePhone
            }).ToList();
            return users;
        }

        public bool UpdateUser(string id,UserDTO user)
        {
            var user1 = context.Users.FirstOrDefault(x => x.Id == id);
            if (user1 != null)
            { 
                user1.FirstName = user.FirstName;
                user1.LastName = user.LastName;
                user1.AddressCity = user.AddressCity;
                user1.AddressStreet = user.AddressStreet;
                user1.AddressNumber = user.AddressNumber;
                user1.DateOfBirth = user.DateOfBirth;
                user1.PhoneNumber = user.PhoneNumber;
                user1.MobilePhone = user.MobilePhone;
                context.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
