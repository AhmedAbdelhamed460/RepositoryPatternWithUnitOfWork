using DataModels;
using DataModels.Consts;
using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPatternWithUnitOfWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [Route("api/[controller]")]
        [ApiController]
        public class BooksController : ControllerBase
        {
            private readonly IUnitOfWork _unitOfWork;

            public BooksController(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            [HttpGet]
            public IActionResult GetById()
            {
                return Ok(_unitOfWork.Book.GetById(1));
            }

            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {
                return Ok(_unitOfWork.Book.GetAll());
            }

            [HttpGet("GetByName")]
            public IActionResult GetByName()
            {
                return Ok(_unitOfWork.Book.Find(b => b.Title == "New Book", new[] { "Author" }));
            }

            [HttpGet("GetAllWithAuthors")]
            public IActionResult GetAllWithAuthors()
            {
                return Ok(_unitOfWork.Book.FindAll(b => b.Title.Contains("New Book"), new[] { "Author" }));
            }

            [HttpGet("GetOrdered")]
            public IActionResult GetOrdered()
            {
                return Ok(_unitOfWork.Book.FindAll(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
            }

            [HttpPost("AddOne")]
            public IActionResult AddOne()
            {
                var book = _unitOfWork.Book.Add(new Book { Title = "Test 4", AuthorId = 1 });
                _unitOfWork.Complete();
                return Ok(book);
            }

        }
    }
}