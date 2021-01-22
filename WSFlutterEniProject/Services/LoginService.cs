using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSFlutterEniProject.Interfaces;
using WSFlutterEniProject.Models;
using WSFlutterEniProject.Models.Config;
using WSFlutterEniProject.Models.Requests;
using WSFlutterEniProject.Models.Responses;
using WSFlutterEniProject.Tools;

namespace WSFlutterEniProject.Services
{
    public class LoginService : ILoginInterface

    {

        private readonly AppSettings _appSettings;

        public LoginService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }


        public AuthResponse AuthenticationResponse(AuthRequest authRequest)
        {
            using (FlutterEniProjectContext db = new FlutterEniProjectContext())
            {
                try
                {
                    string epassword = Encrypt.GetSHA256(authRequest.Password);
                    var user = db.User.Where(u => u.Email == authRequest.Email &&
                                            u.Password == epassword).FirstOrDefault();

                    if (user == null) return null;
                    
                    AuthResponse authResponse = new AuthResponse();
                    authResponse.Email = user.Email;
                    authResponse.Id = user.Id;
                    authResponse.Name = user.Name;
                    authResponse.Usertype = user.Usertype;
                    authResponse.Token = GetToken(user);
                    

                    return authResponse;

                }
                catch (Exception err)
                {

                    throw new Exception(err.Message);
                }

            }
        }

        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.LittleJwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email)
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }



    }
}
