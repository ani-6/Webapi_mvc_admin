using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens;
using System.Configuration;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Webapiservice.Models
{
    public class TokenManager
    {
        static string Secret = ConfigurationManager.AppSettings["secret"];

        public static string CheckHeader()
        {
            var request = HttpContext.Current.Request;
            var h = request.Headers["Authorization"];
            if (h != null)
            {
                var username = TokenManager.ValidateToken(h);
                return username;
            }
            return null;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;
                var authSighkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = authSighkey
                };
                SecurityToken securityToken;

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                    parameters, out securityToken);
                return principal;
            }
            catch 
            {
                return null;
            }
        }

        public static string ValidateToken(string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null ;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            username = usernameClaim.Value;
            return username;
            
        }
    }
}