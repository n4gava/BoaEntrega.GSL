using AutoMapper;
using BoaEntrega.GSL.Mercadorias.Domain;
using BoaEntrega.GSL.Mercadorias.WebApi.ViewModel;

namespace BoaEntrega.GSL.Mercadorias.WebApi.Maps
{
    public class DepositoMaps : Profile
    {
        public DepositoMaps()
        {
            CreateMap<DepositoViewModel, Deposito>()
                .ForMember(v => v.Codigo, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
