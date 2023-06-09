using DataModels;

using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthorsController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;

            public AuthorsController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            [HttpGet]
            public IActionResult GetById()
            {
                return Ok(_unitOfWork.Author.GetById(1));
            }

            [HttpGet("GetByIdAsync")]
            public async Task<IActionResult> GetByIdAsync()
            {
                return Ok(await _unitOfWork.Author.GetByIdAsync(1));
            }
        }
    }
}
