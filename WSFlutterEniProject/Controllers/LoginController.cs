using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSFlutterEniProject.Interfaces;
using WSFlutterEniProject.Models.Requests;
using WSFlutterEniProject.Models.Response;

namespace WSFlutterEniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase

    {

        private ILoginInterface _loginInterface;

        public LoginController(ILoginInterface loginInterface)
        {
            this._loginInterface = loginInterface;
        }


        [HttpPost]

        public IActionResult Authenticate( AuthRequest authRequest)
        {

            Response response = new Response();

            try
            {
                var authenticationResponse = _loginInterface.AuthenticationResponse(authRequest);

                if (authenticationResponse == null)
                {
                    response.Message = "Usuario o contraseña incorrectos";
                    return BadRequest(response);
                }

                response.Successful = true;
                response.Data = authenticationResponse;

            }
            catch (Exception err)
            {

                response.Data = err.Message;
            }

            return Ok(response);

        }

    }
}
