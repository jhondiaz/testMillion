using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestMillion.DTOs;
using TestMillion.UseCasesPorts.LogInPorts;

namespace TestMillion.UseCases.GetLogIn
{


    public class GetLogInInteractor : IGetLogInInputPort
    {
        private readonly IGetLogInOutputPort _outputPort;
        public IConfiguration _configuration;
        public GetLogInInteractor(IConfiguration configuration, IGetLogInOutputPort outputPort)
        {
            (_configuration, _outputPort) = (configuration, outputPort);
           


        }

        public async Task<Task> Handle(LogInDTO logInDTO)
        {

            var user = new UserDTO
            {
                Id = new Random().Next(1000, 5000),
                Email = logInDTO.User,
                Name = "Test User",
                LastName = "Demo",
                Token = "fake-j"
            };


            var ClaimsIdentity = new List<Claim> {
                            new Claim(ClaimTypes.Sid,user.Id.ToString()),
                            new Claim(ClaimTypes.Name,$"{user.Name} {user.LastName}"),
                            new Claim(ClaimTypes.Email,user.Email),
                    };


            var identity = new ClaimsIdentity(ClaimsIdentity);

            var key = _configuration.GetSection("Jwt:Key").Value;

            var ValidAudiences = _configuration.GetSection("Jwt:ValidAudiences").Get<string[]>() ?? [];

            var ValidIssuer = _configuration.GetSection("Jwt:ValidIssuer").Value;

            int ExpiresIn = int.Parse(_configuration.GetSection("Jwt:ExpiresIn").Value);

            // Generando token de usuario
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = ValidIssuer,
                Audience = String.Join(",", ValidAudiences),
                NotBefore = DateTime.UtcNow,
                Subject = identity,
                Expires = DateTime.UtcNow.AddSeconds(ExpiresIn),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            user.Token = token;

            await _outputPort.Handle(user);
            return Task.CompletedTask;
        }
    }
}
