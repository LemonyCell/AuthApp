using AuthApp.Models;
using AuthApp.Models.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using AuthApp.Domain;
using System.Windows.Forms;

namespace AuthApp.Service
{
    public class AccountService
    {
        private MySqlConnection conn;
        private string connString;

        public ServiceResult<ApplicationUser> Register(RegisterBindingModel model)
        {
            var serviceResult = new ServiceResult<ApplicationUser>();
            //check
            try
            {
                SetConn();
                conn.Open();

                if (LoginExist(model.Login))
                {
                    serviceResult.Error.ErrorCode = 403;
                    serviceResult.Error.ErrorDescription = "User is exist";
                }

                string values = "\"" + Guid.NewGuid().ToString() + "\"," +
                                "\"" + model.FirstName + "\"," +
                                "\"" + model.LastName + "\"," +
                                "\"" + model.Login + "\"," +
                                "\"" + model.Password + "\"," +
                                "\"" + model.Email + "\"," +
                                "\"" + model.PhoneNumber + "\"";
                var query = "INSERT INTO `Users`(`Id`, `FirstName`, `LastName`, `Login`, `Password`, `Email`, `PhoneNumber`) " +
                        "VALUES (" + values + ")";

                var cmd = new MySqlCommand(query, conn);
                var dataReader = cmd.ExecuteReader();

                serviceResult.Success = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                serviceResult.Error.ErrorCode = 100;
                serviceResult.Error.ErrorDescription = ex.Message;
                serviceResult.Success = false;
            }

            //foreach (var user in DATA.ApplicationUsers)
            //{
            //    if (user.Login == model.Login)
            //    {
            //        serviceResult.Error.ErrorCode = 403;
            //        serviceResult.Error.ErrorDescription = "User is exist";
            //        return serviceResult;
            //    }
            //}

            //var applicationUser = new ApplicationUser();
            //applicationUser.FirstName = model.FirstName;
            //applicationUser.LastName = model.LastName;
            //applicationUser.Login = model.Login;
            //applicationUser.Password = model.Password;
            //applicationUser.PhoneNumber = model.PhoneNumber;
            //applicationUser.Email = model.Email;
            //applicationUser.Id = Guid.NewGuid().ToString();

            //DATA.AddUser(applicationUser);
            
            conn.Close();

            return serviceResult;
        }

        public ServiceResult<ApplicationUser> Login(AuthBindingModel model)
        {
            var serviceResult = new ServiceResult<ApplicationUser>();
            //check

            try
            {
                SetConn();
                conn.Open();

                if (LoginExist(model.Login))
                {
                    if (PasswordIsСorrect(model))
                    {
                        var instanse = Singleton.getInstance();
                        instanse.User = GetUser(model);
                        serviceResult.Result = instanse.User;
                        serviceResult.Success = true;
                    }
                    else
                    {
                        serviceResult.Error.ErrorCode = 405;
                        serviceResult.Error.ErrorDescription = "Wrong password";
                    }
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                serviceResult.Error.ErrorCode = 100;
                serviceResult.Error.ErrorDescription = ex.Message;
                serviceResult.Success = false;
            }

            //foreach (var user in DATA.ApplicationUsers)
            //{
            //    if (user.Login == model.Login)
            //    {
            //        if (user.Password == model.Password)
            //        {
            //            var instanse = Singleton.getInstance();
            //            instanse.User = user;
            //            serviceResult.Result = user;
            //            serviceResult.Success = true;
            //        }
            //        else
            //        {
            //            serviceResult.Error.ErrorCode = 405;
            //            serviceResult.Error.ErrorDescription = "Wrong password";
            //        }
            //    }
            //}
            conn.Close();

            return serviceResult;
        }
        // true if user exist
        bool LoginExist(string login)
        {
            bool isLogin;
            string loginStr = "\"" + login + "\"";
            string query = "SELECT * FROM `Users` WHERE EXISTS ( SELECT * FROM `Users` WHERE Login = " + loginStr + " )";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            isLogin = dataReader.HasRows;
            dataReader.Close();

            return isLogin;
        }

        bool PasswordIsСorrect(AuthBindingModel model)
        {
            bool passIsCorr = false;
            string login = "\"" + model.Login + "\"";
            string query = "SELECT * FROM `Users` WHERE Login = " + login;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            var read = dataReader.Read();

            if (dataReader["Password"] + "" == model.Password)
            {
                passIsCorr = true;
            }
            dataReader.Close();

            return passIsCorr;
        }


        void SetConn()
        {
            if (conn == null)
            {
                conn = new MySqlConnection();
                connString = "SERVER= db4free.net;PORT=3306;DATABASE=users_auth_app;UID=auth_app;PASSWORD=AuthApp123;";
                conn.ConnectionString = connString;
            }
        }

        ApplicationUser GetUser(AuthBindingModel model)
        {
            var user = new ApplicationUser();

            string login = "\"" + model.Login + "\"";
            string query = "SELECT * FROM `Users` WHERE Login = " + login;

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            var read = dataReader.Read();

            user.Id = dataReader["Id"] + "";
            user.FirstName = dataReader["FirstName"] + "";
            user.LastName = dataReader["LastName"] + "";
            user.Login = dataReader["Login"] + "";
            user.Password = dataReader["Password"] + "";
            user.PhoneNumber = dataReader["PhoneNumber"] + "";
            user.Email = dataReader["Email"] + "";

            dataReader.Close();

            return user;
        }

    }
}
