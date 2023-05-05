using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3.Entity.Request;
using Project3.Services;

namespace Project3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("createOrUpdate")]
        public async Task<IActionResult> createOrUpdate([FromBody] AddBlogReq? menuReq)
        {
            return Ok(_blogService.createOrUpdate(menuReq));
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> getById(float Id)
        {
            return Ok(_blogService.getOne(Id));
        }

        [HttpDelete("deleteById/{menuId}")]
        public async Task<IActionResult> deleteById(float menuId)
        {
            return Ok(_blogService.deleteBlog(menuId));
        }

        [HttpPost("search")]
        public async Task<IActionResult> search([FromBody] BlogReq filter)
        {
            return Ok(_blogService.getPagin(filter));
        }

    }
}
