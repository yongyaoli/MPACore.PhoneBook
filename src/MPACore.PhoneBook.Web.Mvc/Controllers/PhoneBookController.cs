using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPACore.PhoneBook.Controllers;

namespace MPACore.PhoneBook.Web.Mvc.Controllers
{
    public class PhoneBookController : PhoneBookControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}