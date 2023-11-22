using Domain.ValueObject;

namespace Application.Actions.Registar_Empresa
{
    public record RegisterEmpresaCustomerCommand(
         string nombreUsuario,
         string razonSocial,
         string email,
         string password,
         List<IndicativoNumeroCelular_Whatsapp> indicativoCelular,
         string numeroCelular,
         List<IndicativoNumeroCelular_Whatsapp> indicativoWhatsapp,
         string numeroWhatsapp,
         List<TipoDocumento> tipoDocumento,
         string numeroDocumento,
         string digitoAdicional,
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
