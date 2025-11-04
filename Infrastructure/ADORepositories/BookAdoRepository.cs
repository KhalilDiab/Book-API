using Application.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.ADORepositories
{
    public class BookAdoRepository
    {
        private readonly string _connectionString;

        public BookAdoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<BookWithCategoryDto>> GetAllBooksWithCategoriesAsync()
        {
            var result = new List<BookWithCategoryDto>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("sp_GetAllBooksWithCategories", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        result.Add(new BookWithCategoryDto
                        {
                            BookId = reader.GetInt32(reader.GetOrdinal("BookId")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Author = reader.GetString(reader.GetOrdinal("Author")),
                            Categories = reader.IsDBNull(reader.GetOrdinal("Categories"))
                                ? ""
                                : reader.GetString(reader.GetOrdinal("Categories"))
                        });
                    }
                }
            }

            return result;
        }
    }
}
