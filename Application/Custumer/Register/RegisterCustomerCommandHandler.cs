using MediatR;
using Domain.Primitive;
using Domain.Customer;


namespace Application.Custumer.Register
{
    internal sealed class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, Unit>
    {
        private readonly  ICustomerRepository _customRepository;

        private readonly IUnitOfWork _unitOfWork;
        public Task<Unit> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
