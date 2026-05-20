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
                SELECT p.id,
                       p.name,
                       p.description,
                       p.fileLocation,
                       c.id,
                       c.categoryName
                FROM dbo.Picture p
                LEFT JOIN dbo.CategoryAssignment ca ON p.id = ca.pictureID
                LEFT JOIN dbo.Category c           ON ca.categoryID = c.id;
            ";

            var pictureDict = new Dictionary<int, Picture>();

            connection.Query<Picture, Category, Picture>(
                sql,
                (picture, category) =>
                {
                    // Get existing picture from dict, or add this one
                    if (!pictureDict.TryGetValue(picture.ID, out var existing))
                    {
                        existing = picture;
                        pictureDict[picture.ID] = existing;
                    }

                    // Attach category if it exists (LEFT JOIN can return null)
                    if (category != null)
                        existing.Categories.Add(category);

                    return existing;
                },
                splitOn: "id" // Where to split each row into a new object
            );

            return pictureDict.Values.ToList();
        }
        //public IEnumerable<Picture> GetAll()
        //{
        //    using var connection = CreateConnection();
        //    string sql = @"
        //        SELECT id, name, description, fileLocation 
        //        FROM dbo.Picture;
        //        ";
        //    return connection.Query<Picture>(sql).ToList();
        //}

        public void Add(Picture picture)
        {
            using var connection = CreateConnection();
            string sql = @"
                    INSERT INTO Picture (name , description, fileLocation) VALUES
                    (@Name, @Description, @FileLocation);";
            connection.Execute(sql, new
            {
                Name = picture.Name,
                Description = picture.Description,
                FileLocation = picture.FileLocation
            });
        }

        public IEnumerable<Category> GetAllCategories()
        {
            using var connection = CreateConnection();
            string sql = @"
                SELECT id,
                       categoryName
                FROM dbo.Category;
            ";
            return connection.Query<Category>(sql).ToList();
        }

        public void AddCategory(string name)
        {
            using var connection = CreateConnection();
            string sql = @"
                INSERT INTO dbo.Category (categoryName)
                VALUES (@Name);
            ";
            connection.Execute(sql, new { Name = name });
        }

        public void AddCategoryToPicture(int pictureId, int categoryId)
        {
            using var connection = CreateConnection();
            string sql = @"
                INSERT INTO dbo.CategoryAssignment (pictureID, categoryID)
                VALUES (@PictureId, @CategoryId);
            ";
            connection.Execute(sql, new { PictureId = pictureId, CategoryId = categoryId });
        }
    }
}
