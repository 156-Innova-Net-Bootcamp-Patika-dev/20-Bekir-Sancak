using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi
{
    public class Book
    {
        public int BookId { get; set; }

        public string BookName { get; set; }
        public string Yazar { get; set; }
        public string YayinEvi { get; set; }
        public int BasimYili { get; set; }

    }
}
