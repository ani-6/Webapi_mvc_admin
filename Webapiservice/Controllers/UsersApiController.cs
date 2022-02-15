using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webapiservice.Models;
using System.Web;

namespace Webapiservice.Controllers
{
    public class UsersApiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //[Authorize]
        public IHttpActionResult GetUsers()
        {
            var username = TokenManager.CheckHeader();
            if (username != null)
            {
                var users = db.Users.ToList();
                return Ok(username);
            }
            return BadRequest();
            
        }
    }
}
