

namespace Application.Actions.Common
{
    public record RespuestaLogin
    (
        int Id,
        string NombreUsuario,
        string TipoUsuario,
        string TokenAcceso,
        DateTime FechaCreacionTokenAcceso

    );
}
