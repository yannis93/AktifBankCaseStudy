using MediatR;

namespace AktifBankCaseStudy.SharedKernel.SeedWork;

public abstract class EntityBase<TId> : EntityBase, IEntity<TId>, ISoftDeletion
    {
        public virtual TId Id { get; protected set; }

        public virtual DateTime CreatedOn { get; protected set; }
        public virtual DateTime? UpdatedOn { get; protected set; }
        public virtual DateTime? DeletedOn { get; protected set; }

        public bool IsDeleted()
        {
            return DeletedOn != null;
        }
        public bool IsTransient()
        {
            return Id.Equals(default(TId));
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TId>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (EntityBase<TId>)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return GetHashCode();
        }
    }

    public abstract class EntityBase : IEntity
    {
        protected int? _requestedHashCode;

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }