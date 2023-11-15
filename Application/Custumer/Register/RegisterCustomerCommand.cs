using Domain.ValueObject;
using MediatR;


namespace Application.Custumer.Register
{
    public record RegisterCustomerCommand(
         string primnerNombre,
         string segundoNombre,
         string primerApellido,
         string segundoApellido,
         string email, 
         string password,
         object[] idicativoCelular,
         string numeroCelular, 
         object[] idicativoWhatsapp,
         string numeroWhatsapp, 
         object[] tipoDocumento, 
         string numeroDocumento,
         int idTipoVia,
         string tipoVia, 
         string numeroVia,
         string apendiceVia, 
         string numeroCruce,
         string apendiceCruce, 
         string metrosEsquina, 
         string descripcionAdicional, 
         string codigoPostal, 
         int idPais, 
         int idDepartamento,
         int idCiudad,
         string tokenAcceso, 
         DateTime fechaCreacionTokenAcceso, 
         string codigoValidacion, 
         DateTime fechaCreacionCodigoValidacion
        ) : IRequest<Unit>;
}
