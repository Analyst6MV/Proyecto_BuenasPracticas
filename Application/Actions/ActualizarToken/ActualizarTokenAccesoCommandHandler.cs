using Application.Actions.Common;
using Application.FuncionesAdicionales;
using Domain.Customer;
using Domain.ValueObject;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actions.ActualizarToken
{
    internal sealed class ActualizarTokenAccesoCommandHandler : IRequestHandler<ActualizarTokenAccesoCommand, ErrorOr<RespuestaLogin>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;

        public ActualizarTokenAccesoCommandHandler(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _configuration = configuration;
        }

        public async  Task<ErrorOr<RespuestaLogin>> Handle(ActualizarTokenAccesoCommand request, CancellationToken cancellationToken)
        {

            if (await _customerRepository.ActualizarToken(request.id) is not DataLogin customer)
            {
                return Error.Failure("Actualizar.NotFound", "Se presento un error al momento de actualizar el token, por favor vuelve a intentar lo");
            }


            var JwtPrimerLogin = _configuration.GetSection("JWT").GetSection("KeySecrets").ToString();


            Fecha fechaActual = new Fecha();
            var fehca = fechaActual.FechaActual();
            var clainsPrimerLogin = new[]
            {

                    new Claim(JwtRegisteredClaimNames.Iat,fehca.ToString()),
                    new Claim("id",request.id.ToString())

            };

            var KeyPrimerLogin = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtPrimerLogin));
            var singInPrimerLogin = new SigningCredentials(KeyPrimerLogin, SecurityAlgorithms.HmacSha256);

            var TokenPrimerLogin = new JwtSecurityToken(claims: clainsPrimerLogin, expires: fehca.AddHours(1).DateTime, signingCredentials: singInPrimerLogin);
            string TokenAcceso = new JwtSecurityTokenHandler().WriteToken(TokenPrimerLogin);

            await _customerRepository.RegistarToken(request.id, TokenAcceso, fehca.DateTime);

            return new RespuestaLogin(
                customer._id,
                customer.NombreUsuario,
                customer.TipoUsuario,
                TokenAcceso,
                fehca.DateTime);
        }
    }
}
