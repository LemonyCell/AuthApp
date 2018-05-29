using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AuthApp.Domain;
using AuthApp.Models;
using AuthApp.Models.BindingModel;

namespace AuthApp.Service
{
    public class ValidationService
    {
        public ServiceResult<ApplicationUser> Validation(RegisterBindingModel model)
        {
            var serviceResult = new ServiceResult<ApplicationUser>();
           
            // чи заповнені всі поля
            if (IsFilled(model)){
                serviceResult.Error.ErrorCode = 400;
                serviceResult.Error.ErrorDescription = "Not all fields are filled";
                return serviceResult;
            }
            serviceResult.Success = true;
            return serviceResult;
        }
        // true якщо поля пусті
        bool IsFilled(RegisterBindingModel model)
        {
            bool isFilled = false;

            isFilled = model.FirstName == "" || model.LastName == ""
                    || model.Login == "" || model.Password == ""
                    || model.Email == "" || model.PhoneNumber == "";

            return isFilled;
        }

        public ServiceResult<ApplicationUser> Validation(AuthBindingModel model)
        {
            var serviceResult = new ServiceResult<ApplicationUser>();

            // чи заповнені всі поля
            if (IsFilled(model))
            {
                serviceResult.Error.ErrorCode = 400;
                serviceResult.Error.ErrorDescription = "Not all fields are filled";
                return serviceResult;
            }
            serviceResult.Success = true;
            return serviceResult;
        }
        // true якщо поля пусті
        bool IsFilled(AuthBindingModel model)
        {
            bool isFilled = false;

            isFilled = model.Login == "" || model.Password == "";

            return isFilled;
        }

    }
}
