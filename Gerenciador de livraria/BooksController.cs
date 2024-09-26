using Microsoft.AspNetCore.Mvc;
using static Gerenciador_de_livraria.Book;

namespace Gerenciador_de_livraria;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    // Classe auxiliar para receber os dados de um livro na requisição
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
    }

    // GET api/books
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        List<Book> books =
        [
            new (1, "The Great Gatsby", "F. Scott Fitzgerald", GenreEnum.Fiction, 9.99, 10),
            new (2, "To Kill a Mockingbird", "Harper Lee", GenreEnum.Fiction, 7.99, 5),
            new (3, "1984", "George Orwell", GenreEnum.ScienceFiction, 11.99, 3),
            new (4, "Pride and Prejudice", "Jane Austen", GenreEnum.Romance, 6.99, 7)
        ];

        return Ok(books);
    }

    // GET api/books/{id}
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public IActionResult Get(int id)
    {
        Book book = new(id, "The Great Gatsby", "F. Scott Fitzgerald", GenreEnum.Fiction, 9.99, 10);
        return Ok(book);
    }

    // POST api/books
    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] BookDto newBook)
    {
        if (Enum.TryParse<GenreEnum>(newBook.Genre, true, out GenreEnum bookGenre))
        {
            Book book = new (5, newBook.Title, newBook.Author, bookGenre, newBook.Price, 1);
            return Created(String.Empty, book);
        }
        else
        {
            return BadRequest("Gênero inválido.");
        }
    }

    // PUT api/books/{id}
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
    public IActionResult Put(int id, [FromBody] BookDto updatedBook)
    {
        if (Enum.TryParse<GenreEnum>(updatedBook.Genre, true, out GenreEnum bookGenre))
        {
            Book response = new (id, updatedBook.Title, updatedBook.Author, bookGenre, updatedBook.Price, 1);
            return NoContent();
        }
        else
        {
            return BadRequest("Gênero inválido.");
        }
    }

    // DELETE api/books/{id}
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        return Ok($"Livro com ID {id} deletado.");
    }
}
