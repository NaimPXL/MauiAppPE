using Microsoft.Data.SqlClient;
using System.Data;

namespace Spiderman.Infrastructure.Repositories
{
    public class Repository
    {

        private readonly string _connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MobileApp;User ID=sa;Password=digital@PXL;Pooling=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Authentication=SqlPassword;Application Name=vscode-mssql;Connect Retry Count=1;Connect Retry Interval=10;Command Timeout=30";

        public Repository()
        {
            
        }
        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

