using MediatR;

namespace Domain.Primitive;

public record DomainEvent(int id): INotification;
        

