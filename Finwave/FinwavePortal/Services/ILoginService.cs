using FinwavePortal.Models;

namespace FinwavePortal.Services
{
    /// <summary>
    /// ILoginService
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// LoginUser
        /// </summary>
        /// <param name="oLogin"></param>
        /// <returns></returns>
        Login LoginUser(Login oLogin);
    }
}