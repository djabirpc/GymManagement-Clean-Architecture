using System;

namespace GymManagement.Domain.Common;

public class Entity
{
  public Guid Id { get; set; }
  protected readonly List<IDomainEvent> _domainEvents = [];
  protected Entity(Guid id) => Id = id;
  protected Entity()
  {
    
  }
}
