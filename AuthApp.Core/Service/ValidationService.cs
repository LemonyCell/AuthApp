using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using AuthApp.Core.Models;
using AuthApp.Core.Models.BindingModel;

namespace AuthApp.Core.Service
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

        public ServiceResult FieldValidation(string model)
        {
            var serviceResult = new ServiceResult();

            if (model == "")
            {
                serviceResult.Error.ErrorCode = 401;
                serviceResult.Error.ErrorDescription = "field aren`t filled";
                return serviceResult;
            }
            int len = 6;
            if (model.Length < len)
            {
                serviceResult.Error.ErrorCode = 402;
                serviceResult.Error.ErrorDescription = "lenght must be longer than " + len;
                return serviceResult;
            }

            serviceResult.Success = true;
            return serviceResult;
        }

        public ServiceResult EmailValidation(string model)
        {
            var serviceResult = new ServiceResult();

            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            if (!Regex.IsMatch(model, pattern, RegexOptions.IgnoreCase))
            {
                serviceResult.Error.ErrorCode = 403;
                serviceResult.Error.ErrorDescription = "wrong email";
                return serviceResult;
            }

            serviceResult.Success = true;
            return serviceResult;
        }

        public ServiceResult PhoneNumberValidation(string model)
        {
            var serviceResult = new ServiceResult();

            var pattern = "[0-9]{12}";
            if (!Regex.IsMatch(model, pattern))
            {
                serviceResult.Error.ErrorCode = 398;
                serviceResult.Error.ErrorDescription = "wrong phone number";
                return serviceResult;
            }

            serviceResult.Success = true;
            return serviceResult;
        }

        public ServiceResult NameValidation(string model)
        {
            var serviceResult = new ServiceResult();

            var pattern = "([A-Z]|[a-z]){3,20}?";
            if (!Regex.IsMatch(model, pattern))
            {
                serviceResult.Error.ErrorCode = 399;
                serviceResult.Error.ErrorDescription = "wrong name";
                return serviceResult;
            }

            serviceResult.Success = true;
            return serviceResult;
        }

    }
}
