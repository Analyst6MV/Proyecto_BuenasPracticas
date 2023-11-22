
namespace Application.Actions.Registrar_Persona
{
    public class RegisterPersonaCustomerCommandValidation : AbstractValidator<RegisterPersonaCustomerCommand>
    {
        public RegisterPersonaCustomerCommandValidation()
        {
            RuleFor(e=> e.nombreUsuario).NotEmpty().MaximumLength(50).WithName("Nombre Usuario");
            RuleFor(e=> e.primerNombre).NotEmpty().MaximumLength(50).WithName("Primer Nombre");
            RuleFor(e=> e.segundoNombre).NotEmpty().MaximumLength(50).WithName("Segundo Nombre");
            RuleFor(e=> e.primerApellido).NotEmpty().MaximumLength(50).WithName("Primer Apellido");
            RuleFor(e=> e.segundoApellido).NotEmpty().MaximumLength(50).WithName("Segundo Apellido");
            RuleFor(e=> e.email).NotEmpty().EmailAddress().MaximumLength(255).WithName("Email");
            RuleFor(e => e.password).NotEmpty().MinimumLength(8).MaximumLength(255).WithName("Password");
            RuleFor(e => e.tipoDocumento).NotEmpty().WithName("Tipo Documento");
            RuleFor(e => e.numeroDocumento).NotEmpty().MaximumLength(10).WithName("Numero Documento");
            RuleFor(e=> e.indicativoCelular).NotEmpty().WithName("Indicativo Celular");
            RuleFor(e=> e.numeroCelular).NotEmpty().MaximumLength(20).WithName("Numero Celular");
            RuleFor(e=> e.indicativoWhatsapp).NotEmpty().WithName("Indicativo Whatsapp");
            RuleFor(e=> e.numeroWhatsapp).NotEmpty().MaximumLength(20).WithName("Numero Whatsapp");
            RuleFor(e => e.idTipoVia).NotEmpty().WithName("Tipo Via");
            RuleFor(e => e.tipoVia).NotEmpty().MaximumLength(20).WithName("Tipo Via");
            RuleFor(e => e.numeroVia).NotEmpty().MaximumLength(20).WithName("Numero Via");
            RuleFor(e => e.apendiceVia).NotEmpty().MaximumLength(20).WithName("Apendice Via");
            RuleFor(e => e.numeroCruce).NotEmpty().MaximumLength(20).WithName("Numero Cruce");
            RuleFor(e => e.apendiceCruce).NotEmpty().MaximumLength(20).WithName("Apendice Cruce");
            RuleFor(e => e.metrosEsquina).NotEmpty().MaximumLength(20).WithName("Metros Esquina");
            RuleFor(e => e.descripcionAdicional).MaximumLength(100).WithName("Descripcion Adicional"); 
        }
    }
}
