using Spiderman.Domain;
using Spiderman.Infrastructure.Repositories;
using Team05.Application.Framework;

namespace Spiderman.Application.Services
{
    public class PictureService
    {
        private readonly PictureRepository _repository;

        public PictureService()
        {
            _repository = new PictureRepository();
        }

        public SelectListResult<Picture> GetPictures()
        {
            SelectListResult<Picture> selectResult = new SelectListResult<Picture>();
            try
            {
                selectResult.Rows = _repository.GetAll();
            }
            catch (Exception ex)
            {
                selectResult.Errors.Add(ex.Message);
            }
            return selectResult;
        }

        public InsertResult<Picture> AddPicture(string name, string description, string fileLocation)
        {
            InsertResult<Picture> insertResult = new InsertResult<Picture>();
            try
            {
                Picture picture = new Picture()
                {
                    Name = name,
                    Description = description,
                    FileLocation = fileLocation
                };
                _repository.Add(picture);
            }
            catch (Exception ex)
            {
                insertResult.Errors.Add(ex.Message);
            }
            return insertResult;
        }

        
        public SelectListResult<Category> GetCategories()
        {
            SelectListResult<Category> selectResult = new SelectListResult<Category>();
            try
            {
                selectResult.Rows = _repository.GetAllCategories();
            }
            catch (Exception ex)
            {
                selectResult.Errors.Add(ex.Message);
            }
            return selectResult;
        }

        public InsertResult<Picture> AddCategory(string name)
        {
            InsertResult<Picture> insertResult = new InsertResult<Picture>();
            try
            {
                _repository.AddCategory(name);
            }
            catch (Exception ex)
            {
                insertResult.Errors.Add(ex.Message);
            }
            return insertResult;
        }

        public InsertResult<Picture> AddCategoryToPicture(int pictureId, int categoryId)
        {
            InsertResult<Picture> insertResult = new InsertResult<Picture>();
            try
            {
                _repository.AddCategoryToPicture(pictureId, categoryId);
            }
            catch (Exception ex)
            {
                insertResult.Errors.Add(ex.Message);
            }
            return insertResult;
        }
    }
}
