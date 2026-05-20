using Microsoft.AspNetCore.Mvc;
using Spiderman.Application.Services;
using Spiderman.Domain;
using Spiderman.WebApi.ViewModel;


namespace Spiderman.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly PictureService _service;
        public PictureController()
        {
            _service = new PictureService();
        }

        [HttpGet]
        public ActionResult<List<Picture>> Get()
        {
            var result = _service.GetPictures();
            return Ok(result.Rows);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddPictureViewModel viewModel)
        {
            _service.AddPicture(viewModel.Name, viewModel.Description, viewModel.FileLocation);
            return Ok();
        }

        [HttpGet("categories")]
        public ActionResult<List<Category>> GetCategories()
        {
            var result = _service.GetCategories();
            return Ok(result.Rows);
        }

        [HttpPost("categories")]
        public IActionResult PostCategory([FromBody] AddCategoryViewModel viewModel)
        {
            _service.AddCategory(viewModel.Name);
            return Ok();
        }

        [HttpPost("categories/assign")]
        public IActionResult PostCategoryAssignment([FromBody] AddCategoryToPictureViewModel viewModel)
        {
            _service.AddCategoryToPicture(viewModel.PictureId, viewModel.CategoryId);
            return Ok();
        }
    }
}
