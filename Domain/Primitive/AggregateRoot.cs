
namespace Domain.Primitive
{
    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _domainEvents  = new ();

        public ICollection<DomainEvent> GetDomainEvent() => _domainEvents;
        

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }


    }
}
