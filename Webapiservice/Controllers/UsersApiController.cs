using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webapiservice.Models;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Webapiservice.Controllers
{
    public class UsersApiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //[Authorize]
        public string GetUsers()
        {
            var username = TokenManager.CheckHeader();
            if (username != null)
            {
                var UserManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var user = UserManager.FindByName(username);
                var userId = user.Id;
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                return userId;
            }
            return null;
            
        }
    }
}
