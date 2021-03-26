using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Entities.Base
{

    /*
     * Here, we are implementing an Id property, that can be virtual.
     * Why we are doing this?
     * There can be different database in infrastructure layer.
     * Each database will have different type of Id property.
     * To overcome this, we are using a generic type TId as id property and make it virtual,
     * so that any one can override as per their need. 
     */
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        /*
         * This is a protected set. Why is that?
         * This Id property could be set in the Entity base class.
         * That means in the Order.cs
         */
        public virtual TId Id { get; protected set; }

        int? _requestedHashCode;

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

            var item = (EntityBase<TId>) obj;

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
                    _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution ()

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        {
            return !(left == right);
        }
    }
}
