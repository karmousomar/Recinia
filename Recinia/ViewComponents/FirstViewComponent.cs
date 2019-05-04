using Microsoft.AspNetCore.Mvc;
using Recinia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recinia.ViewComponents
{
    public class FirstViewComponent:ViewComponent
    {
        private IMyService myservice;
        public FirstViewComponent(IMyService service)
        {
            this.myservice = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var myitem = await GetGuid();
            return View("Default", myitem);
        }
        private async Task<IMyService> GetGuid()
        {
            return await Task.FromResult(myservice);
        }

    }
}
