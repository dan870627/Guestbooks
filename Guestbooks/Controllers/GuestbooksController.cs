using Guestbooks.Services;
using Guestbooks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbooks.Controllers
{
    public class GuestbooksController : Controller
    {
        private readonly GuestbooksDBService GuestbookService = new GuestbooksDBService();
        // GET: Guestbooks
        public ActionResult Index()
        {
            GuestbooksViewModel Data = new GuestbooksViewModel();
            Data.DataList = GuestbookService.GetDataList();
            return View(Data);
        }
    }
}