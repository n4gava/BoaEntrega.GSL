using System;

namespace BoaEntrega.GSL.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTimeOffset DataCriacao { get; set; }


        protected Entity()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTimeOffset.Now;
        }
    }
}
