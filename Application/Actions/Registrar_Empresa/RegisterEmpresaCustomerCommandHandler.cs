using Domain.Customer;
using Domain.ValueObject;

namespace Application.Actions.Registar_Empresa
{
    internal sealed class RegisterEmpresaCustomerCommandHandler : IRequestHandler<RegisterEmpresaCustomerCommand, ErrorOr<Unit>>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IIdCustomer _Idcustomer;

        public RegisterEmpresaCustomerCommandHandler(ICustomerRepository customRepository, IIdCustomer Idcustomer)
        {
            _Idcustomer = Idcustomer ?? throw new ArgumentNullException(nameof(Idcustomer));
            _customerRepository = customRepository ?? throw new ArgumentNullException(nameof(customRepository));
        }



        public async Task<ErrorOr<Unit>> Handle(RegisterEmpresaCustomerCommand command, CancellationToken cancellationToken)
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

            List<Direccion> DireccionEmpresa = new List<Direccion>();

            DireccionEmpresa.Add(direccion);

            var customer = new CustomerEmpresa(
                id,                
                command.razonSocial,
                command.nombreUsuario,
                command.email,
                password.Value,
                command.indicativoCelular,
                numeroCelular,
                command.indicativoWhatsapp,
                numeroWhatsapp,
                command.tipoDocumento,
                command.numeroDocumento,
                command.digitoAdicional,
                DireccionEmpresa,
                null,
                null,
                null,
                null,
                true,
                false);



            await _Idcustomer.ActualizarID(id);
            await _customerRepository.AddEmpresa(customer);


            return Unit.Value;


        }


    }
}
