using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webapiservice.Models;

namespace Webapiservice.Controllers
{
    public class RoleapiController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult GetRoles()
        {
            var rolelist = db.Roles.ToList();
            if (rolelist.Count() > 0)
                return Ok(rolelist);
            else
                return Ok("Request successful... But no roles to available display");
        }

        [HttpPost]             //https://localhost:44310/api/Roleapi/createrole
        //Route("CreateRole")  //https://localhost:44310/createrole
        public IHttpActionResult CreateRole([FromBody] string rolename)
        {
            if (rolename == null)
            {
                return BadRequest("Rolename not provided");
            }
            IdentityRole role = new IdentityRole(rolename);
            db.Roles.Add(role);
            db.SaveChanges();
            return Ok("Role created");
        }
    }
}
