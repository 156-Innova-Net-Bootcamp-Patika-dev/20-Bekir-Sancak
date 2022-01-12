using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                new Book {BookId=1,BookName="Düşüncenin Gücü", Yazar="James Allen",YayinEvi="İkilem Yayınevi",BasimYili=2019},
                new Book {BookId=2,BookName="IFA-Beden", Yazar="Sinan Canan",YayinEvi="Tuti Kitap",BasimYili=2020},
                new Book {BookId=3,BookName="IFA-İlişkiler ve Stres", Yazar="Sinan Canan",YayinEvi="Tuti Kitap",BasimYili=2020},
                new Book {BookId=4,BookName="IFA-Sınırları Aşmak", Yazar="Sinan Canan",YayinEvi="Tuti Kitap",BasimYili=2020},
                new Book {BookId=5,BookName="Bitir", Yazar="John Acuff",YayinEvi="Pasaj",BasimYili=2019},
                new Book {BookId=6,BookName="Ataleti Yenmek", Yazar="Mumin Sekman",YayinEvi="ALFA",BasimYili=2020}
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
            result.Yazar = book.Yazar;
            result.YayinEvi = book.YayinEvi;
            result.BasimYili = book.BasimYili;


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
