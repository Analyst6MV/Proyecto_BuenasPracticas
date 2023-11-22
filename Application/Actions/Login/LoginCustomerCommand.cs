using Application.Actions.Common;

namespace Application.Actions.Login
{
    public record LoginCustomerCommand(
        string usuario,
        string password        
        ) : IRequest<ErrorOr<RespuestaLogin>>;
}
