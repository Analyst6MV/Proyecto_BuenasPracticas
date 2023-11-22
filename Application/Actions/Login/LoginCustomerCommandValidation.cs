using Application.Actions.Registar_Empresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actions.Login
{
    internal class LoginCustomerCommandValidation : AbstractValidator<LoginCustomerCommand>
    {
        public LoginCustomerCommandValidation()
        {

            RuleFor(e => e.usuario).NotEmpty().MaximumLength(255).MinimumLength(10).WithName("Nombre de usuario o correo");
            RuleFor(e => e.password).NotEmpty().MaximumLength(255).MinimumLength(8).WithName("Password");

        }
    }
}
