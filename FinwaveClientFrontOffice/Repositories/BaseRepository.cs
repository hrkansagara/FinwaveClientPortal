using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FinwaveClientFrontOffice.Repositories
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