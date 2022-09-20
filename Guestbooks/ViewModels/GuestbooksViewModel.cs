using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guestbooks.Models;

namespace Guestbooks.ViewModels
{
    public class GuestbooksViewModel
    {
        //留言資料
        public List<Guestbook> DataList { get; set; }
    }
}