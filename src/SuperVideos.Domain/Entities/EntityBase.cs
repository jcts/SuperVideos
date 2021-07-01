using System;

namespace SuperVideos.Domain.Entities
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Classe base para todas as entidades que possuem as seguintes propriedades em comum, isto
        /// evita a ocorrência de DRY;
        /// </summary>

        protected virtual object Actual => this;

        public Guid Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public bool Delete { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (Actual.GetType() != other.Actual.GetType())
                return false;

            if (Guid.Empty == Id || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;

        }

        public static bool operator ==(EntityBase a, EntityBase b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase a, EntityBase b)
            => !(a == b);

        public override int GetHashCode()
        {
            unchecked
            {
                return (int)Crosscutting.Constants.Config.NumPrimo3049 * (int)Crosscutting.Constants.Config.NumPrimo5039 + Id.GetHashCode();
            }
        }
    }
}