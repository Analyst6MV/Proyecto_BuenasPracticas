using Application.Custumer.Register;

using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.API.Controllers
{
    [Route("api/Authentication")]

    public class AuthenticationController : APIController
    {

        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }



        // POST api/<AuthenticationController>
        [HttpPost]
        [Route("/registar")]
        public async Task<IActionResult> Registrarse([FromBody] RegisterCustomerCommand command)
        {
            var registarCustomer = await _mediator.Send(command);
            return registarCustomer.Match(customer => Ok(),


                errors => Problem(errors)
            );

        }

        // POST api/<AuthenticationController>
        [HttpPost]
        [Route("/login")]
        public void Login([FromBody] string value)
        {
        }
        [HttpPost]
        [Route("/login-token")]
        public void LoginXToken([FromBody] string value)
        {
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        [Route("/recuperar-password")]
        public void RecuperarPassword([FromBody] string value)
        {
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        [Route("/renovar-token")]
        public void RenovarToken([FromBody] string value)
        {

        }

        // POST api/<AuthenticationController>/5
        [HttpPost]
        [Route("/actualizar-password")]
        public void LogOut()
        {
        }


    }
}
