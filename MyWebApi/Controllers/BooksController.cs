using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books;
        public BooksController()
        {
            _books = new List<Book> {
                new Book {BookId=1,BookName="Düşüncenin Gücü", Writer="James Allen",Publisher="İkilem Yayınevi",PublicationYear=2019},
                new Book {BookId=2,BookName="IFA-Beden", Writer="Sinan Canan",Publisher="Tuti Kitap",PublicationYear=2020},
                new Book {BookId=3,BookName="IFA-İlişkiler ve Stres", Writer="Sinan Canan",Publisher="Tuti Kitap",PublicationYear=2020},
                new Book {BookId=4,BookName="IFA-Sınırları Aşmak", Writer="Sinan Canan",Publisher="Tuti Kitap",PublicationYear=2020},
                new Book {BookId=5,BookName="Bitir", Writer="John Acuff",Publisher="Pasaj",PublicationYear=2019},
                new Book {BookId=6,BookName="Ataleti Yenmek", Writer="Mumin Sekman",Publisher="ALFA",PublicationYear=2020}
            };
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _books.ToList();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _books.FirstOrDefault(c => c.BookId == id);
            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] Book book)
        {
            _books.Add(book);

            return Ok();
        }


        [HttpPut("update")]
        public IActionResult Update([FromBody] Book book)
        {
            var result = _books.FirstOrDefault(c => c.BookId == book.BookId);
            if (result == null)
            {
                return BadRequest(result);
            }
            result.BookName = book.BookName;
            result.Writer = book.Writer;
            result.Publisher = book.Publisher;
            result.PublicationYear = book.PublicationYear;


            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Book book)
        {
            Book result = _books.FirstOrDefault(c => c.BookId == book.BookId);
            if (result == null)
            {
                return BadRequest(result);
            }
            _books.Remove(result);


            return Ok(result);
        }
    }
}

