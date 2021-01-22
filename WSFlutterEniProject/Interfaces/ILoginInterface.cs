using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSFlutterEniProject.Models.Requests;
using WSFlutterEniProject.Models.Responses;

namespace WSFlutterEniProject.Interfaces
{
    public interface ILoginInterface
    {
        AuthResponse AuthenticationResponse(AuthRequest authRequest);
    }
}
