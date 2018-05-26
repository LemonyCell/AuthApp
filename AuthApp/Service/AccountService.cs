using AuthApp.Models;
using AuthApp.Models.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthApp.Domain;

namespace AuthApp.Service
{
    public class AccountService
    {
        public ServiceResult<ApplicationUser> Register(RegisterBindingModel model)
        {
            var serviceResult = new ServiceResult<ApplicationUser>();
            //check
            foreach (var user in DATA.ApplicationUsers)
            {
                if (user.Login == model.Login)
                {
                    serviceResult.Error.ErrorCode = 403;
                    serviceResult.Error.ErrorDescription = "User is exist";
                    return serviceResult;
                }
            }

            var applicationUser = new ApplicationUser();
            applicationUser.FirstName = model.FirstName;
            applicationUser.LastName = model.LastName;
            applicationUser.Login = model.Login;
            applicationUser.Password = model.Password;
            applicationUser.PhoneNumber = model.PhoneNumber;
            applicationUser.Email = model.Email;
            applicationUser.Id = Guid.NewGuid().ToString();

            DATA.AddUser(applicationUser);

            serviceResult.Success = true;
            return serviceResult;
        }
    }
}
