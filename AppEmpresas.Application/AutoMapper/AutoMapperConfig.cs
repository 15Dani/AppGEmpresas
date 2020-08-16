using AppEmpresas.Application.Dto;
using AppEmpresas.Domain.Identity;
using AutoMapper;


namespace AppEmpresas.Application.AutoMapper
{
   public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<User, UserLoginDto>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }

}
