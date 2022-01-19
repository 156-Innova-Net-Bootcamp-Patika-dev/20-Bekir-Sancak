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
                new Book {BookId=1,BookName="Düşüncenin Gücü", Author="James Allen",Publisher="İkilem Yayınevi",PublishDate=2019},
                new Book {BookId=2,BookName="IFA-Beden", Author="Sinan Canan",Publisher="Tuti Kitap",PublishDate=2020},
                new Book {BookId=3,BookName="IFA-İlişkiler ve Stres", Author="Sinan Canan",Publisher="Tuti Kitap",PublishDate=2020},
                new Book {BookId=4,BookName="IFA-Sınırları Aşmak", Author="Sinan Canan",Publisher="Tuti Kitap",PublishDate=2020},
                new Book {BookId=5,BookName="Bitir", Author="John Acuff",Publisher="Pasaj",PublishDate=2019},
                new Book {BookId=6,BookName="Ataleti Yenmek", Author="Mumin Sekman",Publisher="ALFA",PublishDate=2020}
            };
        }

        /// <summary>
        /// Kitap listesini getirir
        /// </summary>
        /// <returns></returns>

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _books.ToList();
            return Ok(result);
        }
        /// <summary>
        /// Parametre olarak verilen id'ye göre tek bir kitap getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var result = _books.FirstOrDefault(c => c.BookId == id);
            if (result == null)
            {
                return BadRequest("Kitap bulunamadı");
            }

            return Ok(result);
        }

        /// <summary>
        /// Kitap adına göre arama yapıldığında listeden kitabı getirir.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpGet("searchbook")]
        public IActionResult GetBook([FromQuery] string book)
        {
            if (!string.IsNullOrEmpty(book))
            {
                var result = _books.Where(b => b.BookName.ToLower().Contains(book.ToLower()));
                return Ok(result);
            }

            return BadRequest("Kitap bulunamadı");
        }

        /// <summary>
        /// Yazara göre arama yapıldığında listeden yazara ait kitapları getirir
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        [HttpGet("searchauthor")]
        public IActionResult SearchAuthor([FromQuery] string author)
        {
           if(!string.IsNullOrEmpty(author))
            {
              var result=  _books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
                return Ok(result);
            }

            return BadRequest("Yazar bulunamadı");
        }

        /// <summary>
        /// Yayın evine göre arama yapıldığında listeden yayın evine ait kitapları getirir
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
        [HttpGet("searchpublisher")]
        public IActionResult SearchPublisher([FromQuery] string publisher)
        {
            if (!string.IsNullOrEmpty(publisher))
            {
                var result = _books.Where(b => b.Publisher.ToLower().Contains(publisher.ToLower())).ToList();
                return Ok(result);
            }

            return BadRequest("Yayın evi bulunamadı");
        }


        /// <summary>
        /// Kitap listesine bir kitap ekler
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>

        [HttpPost("add")]
        public IActionResult Add([FromBody] Book book)
        {
            _books.Add(book);

            return Ok();
        }

        /// <summary>
        /// Parametre olarak verilen book nesnesine göre günceller.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>

        [HttpPut("update")]
        public IActionResult Update([FromBody] Book book)
        {
            var result = _books.FirstOrDefault(c => c.BookId == book.BookId);
            if (result == null)
            {
                return BadRequest("Kitap güncellenemedi");
            }
            result.BookName = book.BookName;
            result.Author = book.Author;
            result.Publisher = book.Publisher;
            result.PublishDate = book.PublishDate;


            return Ok("Kitap güncellendi");
        }

        /// <summary>
        /// Parametre olarak verilen book nesnesinin BookId'sine göre siler.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] Book book)
        {
            Book result = _books.FirstOrDefault(c => c.BookId == book.BookId);
            if (result == null)
            {
                return BadRequest("Kitap silinemedi");
            }
            _books.Remove(result);


            return Ok("Kitap silindi");
        }
    }
}