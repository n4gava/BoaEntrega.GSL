using AutoMapper;
using BoaEntrega.GSL.Mercadorias.Domain;
using BoaEntrega.GSL.Mercadorias.WebApi.ViewModel;

namespace BoaEntrega.GSL.Mercadorias.WebApi.Maps
{
    public class MercadoriaMaps : Profile
    {
        public MercadoriaMaps()
        {
            CreateMap<AdicionarMercadoriaViewModel, Mercadoria>();
        }
    }
}
