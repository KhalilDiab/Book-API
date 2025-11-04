using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _repo;

        public BooksController(IGenericRepository<Book> repo)
        {
            _repo = repo;
        }

        [HttpGet(Name ="AllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _repo.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
                return NotFound(new { message = $"Book with ID {id} not found" });

            return Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(Book book)
        {
            if (book == null)
                return BadRequest(new { message = "Book data is required" });

            await _repo.AddAsync(book);
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest(new { message = "Book ID mismatch" });

            var existingBook = await _repo.GetByIdAsync(id);
            if (existingBook == null)
                return NotFound(new { message = $"Book with ID {id} not found" });

            await _repo.UpdateAsync(book);
            return Ok(new { message = "Book updated successfully", book });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null)
                return NotFound(new { message = $"Book with ID {id} not found" });

            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
