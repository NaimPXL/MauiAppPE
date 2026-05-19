using Dapper;
using Spiderman.Domain;

namespace Spiderman.Infrastructure.Repositories
{
    public class PictureRepository : Repository
    {
        public PictureRepository()
        {

        }

        public IEnumerable<Picture> GetAll()
        {
            using var connection = CreateConnection();
            string sql = @"
                SELECT
                FROM ;
                ";
            return connection.Query<Picture>(sql).ToList();
        }
    }
}
