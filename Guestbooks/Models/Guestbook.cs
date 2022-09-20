using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guestbooks.Models
{
    public class Guestbook
    {
        //ID
        public int id { get; set; }
        
        //姓名
        public string Account { get; set; }

        //留言
        public string Content { get; set; }

        //新增時間
        public DateTime CreateTime { get; set; }
    }
}