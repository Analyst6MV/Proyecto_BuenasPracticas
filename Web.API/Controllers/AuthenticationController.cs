using Application.Actions.Registar_Empresa;
using Application.Actions.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Actions.Registrar_Persona;
using System.Security.Claims;
using Application.Actions.ActualizarToken;
using Application.FuncionesAdicionales;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Web.API.Controllers
{
    [Route("api/authentication")]

    public class AuthenticationController : APIController
    {

        private readonly ISender _mediator;
        private readonly IConfiguration _configuration;
        
        public AuthenticationController(ISender mediator, IConfiguration configuration)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            
        }




        [HttpPost]
        [Route("registar-persona")]
        public async Task<IActionResult> RegistrarPersona([FromBody] RegisterPersonaCustomerCommand command)
        {
            var registarCustomer = await _mediator.Send(command);
            return registarCustomer.Match(customer => Ok(),


                errors => Problem(errors)
            );

        }
        [HttpPost]
        [Route("registar-empresa")]
        public async Task<IActionResult> RegistrarEmpresa([FromBody] RegisterEmpresaCustomerCommand command)
        {
            var registarCustomer = await _mediator.Send(command);
            return registarCustomer.Match(customer => Ok(),


                errors => Problem(errors)
            );
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCustomerCommand command)
        {



            var Login = await _mediator.Send(command);

            if (Login.IsError) { return Problem(Login.Errors); }
            var JwtPrimerLogin = _configuration["JWT:KeySecrets"]; // _configuration.GetSection("JWT").GetSection("KeySecrets").Value;
            var audienc = _configuration.GetSection("JWT").GetSection("ValidAudiences").Value;
            var Issuer = _configuration.GetSection("JWT").GetSection("ValidIssuer").Value;
            Fecha fechaActual = new Fecha();
            var fehca = fechaActual.FechaActual();
            var clainsPrimerLogin = new[]
            {

                    new Claim(JwtRegisteredClaimNames.Iat,fehca.DateTime.ToString()),
                    new Claim("id",Login.Value.Id.ToString())

            };

            var KeyPrimerLogin = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtPrimerLogin));

            var singInPrimerLogin = new SigningCredentials(KeyPrimerLogin, SecurityAlgorithms.HmacSha256);

            var TokenPrimerLogin = new JwtSecurityToken(claims: clainsPrimerLogin, expires: fehca.AddHours(1).DateTime, signingCredentials: singInPrimerLogin);



            string TokenAcceso = new JwtSecurityTokenHandler().WriteToken(TokenPrimerLogin);
            await _mediator.Send(new ActualizarTokenAccesoCommand(Login.Value.Id, TokenAcceso, fehca.DateTime));

            return Ok(new {
            
                success = true,
                message = "Login Ok",
                data = new
                {
                     
                  id=  Login.Value.Id,
                  nombreUsuario= Login.Value.NombreUsuario,
                  tipoUsuario= Login.Value.NombreUsuario,
                  tokenAcceso= TokenAcceso,
                  fechaCreacionTokenAcceso= fehca.DateTime

                }
            
            });

        }
        [HttpPost]
        //[Authorize]
        [Route("login-token")]
        public async Task<IActionResult> LoginXToken() //[FromQuery] string id)
        {

            ClaimsIdentity Token = (ClaimsIdentity)HttpContext.User.Identity;

             if (Token.Claims.Count() == 0) 
            {
                return Unauthorized("El token no es valido");
            }


            int Id = int.Parse(Token.Claims.FirstOrDefault(s => s.Type == "id").Value);
            return Ok();

            //ActualizarTokenAccesoCommand command = new ActualizarTokenAccesoCommand(Id);

            //var actualizarToken = await _mediator.Send(command);
            //return actualizarToken.Match(customer => Ok(customer),errors=>Problem(errors));

        }

        [HttpPost]
        [Route("recuperar-password")]
        public void RecuperarPassword([FromBody] string value)
        {

        }

        [HttpPost]
        [Route("renovar-token")]
        public void RenovarToken([FromBody] string value)
        {

        }


        [HttpPost]
        [Route("actualizar-password")]
        public void LogOut()
        {
        }


    }
}
