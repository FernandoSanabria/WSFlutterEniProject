using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSFlutterEniProject.Models.Responses
{
    public class AuthResponse
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Usertype { get; set; }

        public string Token { get; set; }

        //public AuthResponse(uint Id, string Name, string Email, string Usertype, string Token)
        //{
        //    this.Id = Id;
        //    this.Name = Name;
        //    this.Email = Email;
        //    this.Usertype = Usertype;
        //    this.Token = Token;
        //}

    }
}
