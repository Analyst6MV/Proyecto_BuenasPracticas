using MediatR;
using Domain.Primitive;
using Domain.Customer;
using Domain.ValueObject;
using ErrorOr;


namespace Application.Custumer.Register
{
    internal sealed class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, ErrorOr<Unit>>
    {
        private readonly  ICustomerRepository _customerRepository;
        private readonly  IIdCustomer _Idcustomer;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterCustomerCommandHandler(ICustomerRepository customRepository, IIdCustomer Idcustomer, IUnitOfWork unitOfWork)
        {
            _Idcustomer = Idcustomer ?? throw new ArgumentNullException(nameof(Idcustomer));
            _customerRepository = customRepository ?? throw new ArgumentNullException(nameof(customRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }




        public async Task<ErrorOr<Unit>> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (NumeroCelular.Create(command.numeroCelular) is not NumeroCelular numeroCelular)
                {
                    //throw new ArgumentNullException(nameof(numeroCelular));
                    return Error.Validation("Customer.NumeroCelular", "El numero de celular no posee un formato valido");

                }
                if (NumeroCelular.Create(command.numeroWhatsapp) is not NumeroCelular numeroWhatsapp)
                {
                    //throw new ArgumentNullException(nameof(numeroWhatsapp));
                    return Error.Validation("Customer.NumeroWhatsapp", "El numero de celular no posee un formato valido");


                }

                if (Direccion.Create(command.idTipoVia, command.tipoVia, command.numeroVia, command.apendiceVia,
                                     command.numeroCruce, command.apendiceCruce, command.metrosEsquina, command.descripcionAdicional,
                                     command.codigoPostal, command.idPais, command.idDepartamento, command.idCiudad) is not Direccion direccion)
                {
                    //throw new ArgumentNullException(nameof(direccion));

                    return Error.Validation("Customer.Direccion", "La direccion no es valida");
                }
                int id =await  _Idcustomer.UltimoID();
                id = id + 1;

                var customer = new Customer(
                    id,
                    command.primerNombre,
                    command.segundoNombre,
                    command.primerApellido,
                    command.segundoApellido,
                    command.email,
                    command.password,
                    command.indicativoCelular,
                    numeroCelular,
                    command.indicativoWhatsapp,
                    numeroWhatsapp,
                    command.tipoDocumento,
                    command.numeroDocumento,
                    direccion,
                    null,
                    null,
                    null,
                    null,
                    true,
                    false);

                await _Idcustomer.ActualizarID(id);

                await _customerRepository.Add(customer);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
            catch (Exception ex)
            {

                    return Error.Failure("RegistarUsuario",ex.Message);
            }


        }
    }
}
