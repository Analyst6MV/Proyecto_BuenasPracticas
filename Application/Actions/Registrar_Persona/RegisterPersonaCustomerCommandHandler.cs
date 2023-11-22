using Domain.Customer;
using Domain.ValueObject;

namespace Application.Actions.Registrar_Persona
{
    internal sealed class RegisterPersonaCustomerCommandHandler : IRequestHandler<RegisterPersonaCustomerCommand, ErrorOr<Unit>>
    {
        private readonly  ICustomerRepository _customerRepository;
        private readonly  IIdCustomer _Idcustomer;

        public RegisterPersonaCustomerCommandHandler(ICustomerRepository customRepository, IIdCustomer Idcustomer)
        {
            _Idcustomer = Idcustomer ?? throw new ArgumentNullException(nameof(Idcustomer));
            _customerRepository = customRepository ?? throw new ArgumentNullException(nameof(customRepository));
        }




        public async Task<ErrorOr<Unit>> Handle(RegisterPersonaCustomerCommand command, CancellationToken cancellationToken)
        {
            var validacion = await _customerRepository.ValidarEmailYNombreUsuario(command.nombreUsuario, command.email);
            if (validacion != string.Empty)
            {
                if (validacion == "Ya existe un usuario con este correo")
                {

                    return Error.Validation("Customer.Correo", validacion);
                }
                else
                {
                    return Error.Validation("Customer.Nombre Usuario", validacion);
                }


            }

            if (NumeroCelular.Create(command.numeroCelular) is not NumeroCelular numeroCelular)
            {

                return Error.Validation("Customer.NumeroCelular", "El numero de celular no posee un formato valido");

            }
            if (NumeroCelular.Create(command.numeroWhatsapp) is not NumeroCelular numeroWhatsapp)
            {
               
                return Error.Validation("Customer.NumeroWhatsapp", "El numero de celular no posee un formato valido");


            }

            if (Direccion.Create(command.idTipoVia, command.tipoVia, command.numeroVia, command.apendiceVia,
                                 command.numeroCruce, command.apendiceCruce, command.metrosEsquina, command.descripcionAdicional,
                                 command.codigoPostal, command.idPais, command.idDepartamento, command.idCiudad) is not Direccion direccion)
            {


                return Error.Validation("Customer.Direccion", "La direccion no es valida");
            }

            if (Password.Create(command.password) is not Password password)
            {


                return Error.Validation("Customer.Password", "La contraseña no tiene un formato valido");
            }
            int id = await _Idcustomer.UltimoID();
            id = id + 1;
            List<Direccion> DireccionPersona = new List<Direccion>();

            DireccionPersona.Add(direccion);

            var customer = new CustomerPersona(
                id,
                command.nombreUsuario,
                command.primerNombre,
                command.segundoNombre,
                command.primerApellido,
                command.segundoApellido,
                command.email,
                password.Value,
                command.indicativoCelular,
                numeroCelular,
                command.indicativoWhatsapp,
                numeroWhatsapp,
                command.tipoDocumento,
                command.numeroDocumento,
                DireccionPersona,
                null,
                null,
                null,
                null,
                true,
                false);

            await _Idcustomer.ActualizarID(id);

            await _customerRepository.AddPersona(customer);
          

            return Unit.Value;




        }
    }
}
