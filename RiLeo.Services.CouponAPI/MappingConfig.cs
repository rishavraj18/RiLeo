using AutoMapper;
using RiLeo.Services.CouponAPI.Models;
using RiLeo.Services.CouponAPI.Models.Dto;

namespace RiLeo.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
