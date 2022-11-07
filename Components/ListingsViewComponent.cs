using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Components
{
    [ViewComponent(Name = "Listings")]
    public class ListingsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Listings");
        }
    }
}