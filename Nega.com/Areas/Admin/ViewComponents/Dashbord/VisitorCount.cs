using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Negacom.Areas.Admin.ViewComponents.Dashbord
{
    public class VisitorCount : ViewComponent
    {
        DB db = new DB();
        
        public IViewComponentResult Invoke()
        {
            var today = DateTime.Today; // Bugünün tarihini alır

            // Bugün için ziyaretçi kaydını alır
            var visit = db.visitorCounts
                .Where(o => o.visitdate == today)
                .FirstOrDefault();

            var count = visit?.count ?? 0; // Ziyaretçi sayısını alır, eğer kayıt yoksa 0 döner

            return View(count); // Sayacı view'e gönderir
        }
    }
}
