using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pizzeria.DataAccess
{
    public class ConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            var connectionStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            return new SqlConnection(connectionStr);
        }
    }
}
