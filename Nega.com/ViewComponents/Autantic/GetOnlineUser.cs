using BLL.Concrate;
using DAL.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;
using Negacom.Areas.Admin.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;
using DAL.Context;
using System.Linq;

namespace Negacom.Views.Shared.Components.Autantic
{
    

    public class GetOnlineUser :ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {

            return View();
        }

    }

}
