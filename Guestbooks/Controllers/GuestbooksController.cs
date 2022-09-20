using Guestbooks.Models;
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

        #region 顯示
        // GET: Guestbooks
        public ActionResult Index()
        {
            GuestbooksViewModel Data = new GuestbooksViewModel();
            Data.DataList = GuestbookService.GetDataList();
            return View(Data);
        }
        #endregion

        #region 新增
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Account, Content")]Guestbook Data)
        {
            GuestbookService.InsertGuestbooks(Data);
            return RedirectToAction("Index");
        }
        #endregion
    }
}