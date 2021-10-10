using BoaEntrega.GSL.Core.Data;
using BoaEntrega.GSL.Mercadorias.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.GSL.Mercadorias.Data.Repositories
{
    public class MercadoriaRepository : BaseEntityRepository<Mercadoria>, IMercadoriaRepository
    {
        public MercadoriaRepository(MercadoriaContext context) : base(context, context)
        {
        }
    }
}
