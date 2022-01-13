using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Entities
{
    public class Book
    {
       
        public int BookId { get; set; }

        public string BookName { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
    }
}
