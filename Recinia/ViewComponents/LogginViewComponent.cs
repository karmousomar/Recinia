using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.ViewComponents
{
    public class LogginViewComponent:ViewComponent
    {
        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
