using System;

namespace GymManagement.Domain.Common;

public class Entity
{
  public Guid Id { get; set; }
  protected readonly List<IDomainEvent> _domainEvents = [];
  public List<IDomainEvent> PopDomainEvents()
  {
    var copy = _domainEvents.ToList();
    _domainEvents.Clear();
    return copy;
  }
  protected Entity(Guid id) => Id = id;
  protected Entity()
  {
    
  }
}
