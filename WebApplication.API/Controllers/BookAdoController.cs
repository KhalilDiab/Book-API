using Infrastructure.ADORepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookAdoController : ControllerBase
    {
        private readonly BookAdoRepository _adoRepo;

        public BookAdoController(BookAdoRepository adoRepo)
        {
            _adoRepo = adoRepo;
        }

        [HttpGet("GetAllBooks", Name ="GetAllBooksWithCategories")]

        public async Task<IActionResult> GetAllBooksWithCategories()
        {
            var result = await _adoRepo.GetAllBooksWithCategoriesAsync();
            return Ok(result);
        }
    }
}
