using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVideos.Domain.Entities.ValueObject
{
    public abstract class ValueObject<T> where T : class
    {
        protected static bool EqualOperator(ValueObject<T> left, ValueObject<T> right)
        {
            if (left is null ^ right is null)
                return false;

            return left is null || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject<T> left, ValueObject<T> right)
            => !(EqualOperator(left, right));

        protected IEnumerable<object> GetEqualityComponents()
            => GetType().GetProperties().Select(propInfo => propInfo.GetValue(this, null));

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (ValueObject<T>)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
            => GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
    }

    public static class ValueObjectExtensions
    {
        public static IEnumerable<object> GetPropertiesVO<T>(this ValueObject<T> target)
            where T : ValueObject<T>
              => target.GetType().GetProperties().Select(propInfo => propInfo.GetValue(target, null));
    }
}
