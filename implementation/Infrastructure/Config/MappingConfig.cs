using AutoMapper;
using implementation.Data;
using implementation.Models;

namespace implementation.Infrastructure.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDTO, Order>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}