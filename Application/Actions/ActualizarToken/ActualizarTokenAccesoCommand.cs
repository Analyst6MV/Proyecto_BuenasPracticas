using Application.Actions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actions.ActualizarToken
{
    public record ActualizarTokenAccesoCommand(
        int id
        ) : IRequest<ErrorOr<RespuestaLogin>>;
}
