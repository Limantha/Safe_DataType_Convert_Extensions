using SafeExtensions.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SafeExtensions.Controllers
{
    public class UsersController : Controller
    {

        private DBContext _dBContext;

        public UsersController()
        {
            _dBContext = new DBContext();
        }
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DetailedUser(int id)
        {
            var user = _dBContext.GetUserById(id);

            return View("Detail",user);
        }
    }
}