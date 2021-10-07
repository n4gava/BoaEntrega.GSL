using AutoMapper;
using BoaEntrega.GSL.Cadastros.Domain;
using BoaEntrega.GSL.Cadastros.ViewModel;

namespace BoaEntrega.GSL.Cadastros.Maps
{
    public class CadastrosProfile : Profile
    {
        public CadastrosProfile()
        {
            CreateMap<ClienteViewModel, Cliente>().ReverseMap();
        }
    }
}
