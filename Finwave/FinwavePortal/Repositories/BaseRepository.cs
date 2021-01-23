using System.Data;
using System.Data.SqlClient;

namespace FinwavePortal.Repositories
{
    public class BaseRepository
    {
        protected static IDbConnection OpenConnection()
        {
            IDbConnection connection = null;
            connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["FinwaveConn"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}