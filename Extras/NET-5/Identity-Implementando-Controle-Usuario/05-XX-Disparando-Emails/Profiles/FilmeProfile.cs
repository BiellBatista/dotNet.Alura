using _05_XX_Disparando_Emails.Data.Dtos.Filme;
using _05_XX_Disparando_Emails.Models;
using AutoMapper;

namespace _05_XX_Disparando_Emails.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}