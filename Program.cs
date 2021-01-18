using ManuallyCreateJWT.CreateJWT;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ManuallyCreateJWT
{
    class Program
    {
        static void Main(string[] args)
        {
            var createToken = new CreateToken();
            string token = createToken.GenerateTokenV2(123);
            Console.WriteLine(token);
            Console.WriteLine(createToken.ValidateCurrentTokenV2(token));
        }
    }
}