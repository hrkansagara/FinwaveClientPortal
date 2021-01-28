using Dapper;
using FinwaveClientFrontOffice.Common;
using FinwaveClientFrontOffice.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FinwaveClientFrontOffice.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        /// <summary>
        /// Login User 
        /// </summary>
        /// <param name="oLogin"></param>
        /// <returns></returns>
        public Login LoginUser(Login oLogin)
        {
            try
            {
                using (IDbConnection connection = OpenConnection())
                {
                    var o = new DynamicParameters();
                    o.Add("@loginId", oLogin.UserName);
                    o.Add("@password", oLogin.Password);
                    return connection.Query<Login>("usp_GetUserLoginData", o, commandType: CommandType.StoredProcedure, commandTimeout: 900).ToList().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Login UserDetailByUserName(Login oLogin)
        {
            try
            {
                using (IDbConnection connection = OpenConnection())
                {
                    var o = new DynamicParameters();
                    o.Add("@UserName", oLogin.UserName);
                    return connection.Query<Login>("usp_GetUserLoginDatabyUserName", o, commandType: CommandType.StoredProcedure, commandTimeout: 900).ToList().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SaveResponse UpdatePasswardByClientname(Login oLogin)
        {
            try
            {
                using (IDbConnection connection = OpenConnection())
                {
                    DynamicParameters o = new DynamicParameters();
                    o.Add("@userName", oLogin.UserName, dbType: DbType.String);
                    o.Add("@passward", oLogin.Password, dbType: DbType.String);
                    connection.Execute("usp_UpdatePasswardByuserName", o, commandType: CommandType.StoredProcedure, commandTimeout: 900);
                    return new SaveResponse() { Success = true, ResponseString = "Passward changed successfully.Please check your mail." };
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public SaveResponse SaveUserDetails(AccountModel oAccountModel)
        {
            try
            {
                using (IDbConnection connection = OpenConnection())
                {
                    DynamicParameters o = new DynamicParameters();
                    o.Add("@UserName", oAccountModel.CLIENT_ID, dbType: DbType.String);
                    o.Add("@UserFullName", oAccountModel.CLIENT_NAME, dbType: DbType.String);
                    o.Add("@Mobile", oAccountModel.MOBILE_NO, dbType: DbType.String);
                    o.Add("@EmailID", oAccountModel.CLIENT_ID_MAIL, dbType: DbType.String);
                    o.Add("@Password", oAccountModel.Password, dbType: DbType.String);
                    connection.Execute("usp_InsertUserData", o, commandType: CommandType.StoredProcedure, commandTimeout: 900);
                }

                return new SaveResponse() { Success = true, ResponseString = "Details Saved successfully!" };
            }
            catch (Exception ex)
            {
                return new SaveResponse() { Success = false, ResponseString = ex.Message };
            }
        }

        //#region Dispose
        //public void Dispose()
        //{
        //    _connection.Dispose();
        //}
        //#endregion
    }
}