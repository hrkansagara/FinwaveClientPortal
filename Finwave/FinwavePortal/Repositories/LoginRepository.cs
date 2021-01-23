using Dapper;
using FinwavePortal.Models;
using System;
using System.Data;
using System.Linq;

namespace FinwavePortal.Repositories
{
    /// <summary>
    /// Login Repository
    /// </summary>
    public class LoginRepository : BaseRepository,ILoginRepository
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
                    return connection.Query<Login>("usp_wsGetUserLoginData", o, commandType: CommandType.StoredProcedure, commandTimeout: 900).ToList().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}