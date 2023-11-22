using Application.Actions.Registar_Empresa;
using Application.Actions.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Actions.Registrar_Persona;
using ErrorOr;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Actions.ActualizarToken;
using Microsoft.AspNetCore.Authorization;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API.Controllers
{
    [Route("api/authentication")]

    public class AuthenticationController : APIController
    {

        private readonly ISender _mediator;
        
        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            
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
            return Login.Match(customer =>  Ok(customer),


                errors => Problem(errors)
            );
        }
        [HttpPost]
        //[Authorize]
        [Route("login-token")]
        public async Task<IActionResult> LoginXToken()
        {
            ClaimsIdentity Token = HttpContext.User.Identity as ClaimsIdentity;
            if (Token.Claims.Count() == 0) 
            {
                return Unauthorized();
            
            }


            int Id = int.Parse(Token.Claims.FirstOrDefault(s => s.Type == "id").Value);

            ActualizarTokenAccesoCommand command = new ActualizarTokenAccesoCommand(Id);

            var actualizarToken = await _mediator.Send(command);
            return actualizarToken.Match(customer => Ok(customer),errors=>Problem(errors));

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
