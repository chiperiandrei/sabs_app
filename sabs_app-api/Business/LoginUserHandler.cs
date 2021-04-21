using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sabs_app_api.Controllers;
using sabs_app_api.DTOs;
using sabs_app_api.Helpers;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class LoginUserHandler : IRequestHandler<LoginUser, ResponseLogin>

    {
        private readonly Context _context;
        private readonly AppSettings _appSettings;
        public LoginUserHandler(Context context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public async Task<ResponseLogin> Handle(LoginUser request, CancellationToken cancellationToken)
        {

     

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
                if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var ips = _context.IPs.Where(p => p.UserID == user.ID).Select(s => s.IPValue).ToList<string>();
                    string ipuri = string.Join(",", ips);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim("id", user.ID.ToString()),

                    new Claim("firstname", user.FirstName.ToString()),
                    new Claim("lastname", user.LastName.ToString()),

                    new Claim("email", user.Email.ToString()),
                    new Claim("phone", user.Phone.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("ips",ipuri) // not the best way, I will split in front end by comma

                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var res_token = tokenHandler.WriteToken(token);

                    var result = new ResponseLogin(res_token);
                    return result;
                }
            return null;
        }
    }
}



