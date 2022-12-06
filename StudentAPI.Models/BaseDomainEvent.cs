using MediatR;

namespace StudentAPI.Models
{
    public abstract class BaseDomainEvent : INotification
    {
        public BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            UpdatedOn = DateTime.UtcNow;
        }

        public virtual Guid EventId { get; init; }
        public virtual DateTime CreatedOn { get; init; }
        public virtual DateTime UpdatedOn { get; init; }
    }
}
