using Domain.ValueObject;
using ErrorOr;
using MediatR;


namespace Application.Custumer.Register
{
    public record RegisterCustomerCommand(
         string primerNombre,
         string segundoNombre,
         string primerApellido,
         string segundoApellido,
         string email, 
         string password,
         List<IndicativoNumeroCelular_Whatsapp> indicativoCelular,
         string numeroCelular, 
         List<IndicativoNumeroCelular_Whatsapp> indicativoWhatsapp,
         string numeroWhatsapp, 
         List<TipoDocumento> tipoDocumento, 
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
         int idCiudad
        ) : IRequest<ErrorOr<Unit>>;
}
