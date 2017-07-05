using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonitoringScosse.Data;
using MonitoringScosse.Models;

namespace MonitoringScosse.Controllers
{
    public class HomeController : Controller
    {
        private IDataAccess _data;

        public HomeController(IDataAccess dataAccess)
        {
            this._data = dataAccess;
        }


        [HttpPost]
        public IActionResult Measurement(int id, [FromBody] Misurazione m)
        {
            if(id > 0 && id < 101)
            {
                if (!_data.isWorking(id))
                    return Error();
                _data.Insert(m);
                return Json(m);
            }
           
            return Error();
            
        }

        public IActionResult Index()
        {
            return Json(_data.GetAll());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
