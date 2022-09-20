using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guestbooks.Models
{
    public class Guestbook
    {
        public int id { get; set; }
        
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }
    }
}