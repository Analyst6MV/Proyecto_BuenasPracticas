using Application.Actions.Common;
using Application.FuncionesAdicionales;
using Domain.Customer;
using Domain.ValueObject;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Actions.ActualizarToken
{
    internal sealed class ActualizarTokenAccesoCommandHandler : IRequestHandler<ActualizarTokenAccesoCommand, ErrorOr<RespuestaTokenActualizado>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;

        public ActualizarTokenAccesoCommandHandler(ICustomerRepository customerRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _configuration = configuration;
        }

        public async  Task<ErrorOr<RespuestaTokenActualizado>> Handle(ActualizarTokenAccesoCommand request, CancellationToken cancellationToken)
        {
            await _customerRepository.RegistarToken(request.id, request.Token, request.Fecha);

            return new RespuestaTokenActualizado(
                 request.Token, 
                 request.Fecha);
        }
    }
}
