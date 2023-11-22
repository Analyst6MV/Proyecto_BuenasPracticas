using Application.Actions.Common;
using Application.FuncionesAdicionales;
using Domain.Customer;
using Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Actions.Login
{
    internal sealed class LoginCustomerCommandHandler : IRequestHandler<LoginCustomerCommand, ErrorOr<RespuestaLogin>>
    {

        private readonly ICustomerRepository _customerRepository;

        private readonly IConfiguration _configuration;

        public LoginCustomerCommandHandler(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _configuration = configuration;
        }

        public async Task<ErrorOr<RespuestaLogin>> Handle(LoginCustomerCommand query, CancellationToken cancellationToken)
        {

            if (Password.Create(query.password) is not Password password)
            {

                return Error.Validation("Customer.Password", "La contraseña no tiene un formato valido");
            }
            if (await _customerRepository.Login(query.usuario,password.Value) is not DataLogin customer)
            {
                return Error.NotFound("Login.NotFound", "el nombre de usuario o la contraseña son incorrectos");
            }

            if( customer.SesionActiva == true) 
            {

                


                return Error.Unauthorized("Login.Unauthorized", "Ya este una sesion activa con este usaurio");

            }
            
            var JwtPrimerLogin = _configuration.GetSection("JWT").GetSection("KeySecrets").ToString();


            Fecha fechaActual = new Fecha();
            var fehca = fechaActual.FechaActual();
            var clainsPrimerLogin = new[]
            {

                    new Claim(JwtRegisteredClaimNames.Iat,fehca.ToString()),
                    new Claim("id",customer._id.ToString())

            };

            var KeyPrimerLogin = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtPrimerLogin));
            var singInPrimerLogin = new SigningCredentials(KeyPrimerLogin, SecurityAlgorithms.HmacSha256);

            var TokenPrimerLogin = new JwtSecurityToken(claims: clainsPrimerLogin, expires: fehca.AddHours(1).DateTime, signingCredentials: singInPrimerLogin);



            string TokenAcceso = new JwtSecurityTokenHandler().WriteToken(TokenPrimerLogin);

            await _customerRepository.RegistarToken(customer._id,TokenAcceso, fehca.DateTime);
            return new RespuestaLogin(
                customer._id,
                customer.NombreUsuario,
                customer.TipoUsuario,
                TokenAcceso,
                fehca.DateTime); 


        }
    }
}
