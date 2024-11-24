using AutoMapper;
using Promocoes.Models;
using Promocoes.Request;

namespace Promocoes.Dtos.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Campaign, CampaignDto>().ReverseMap();
            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<Promotion, PromotionDto>().ReverseMap();
            CreateMap<CreateCouponRequest, Coupon>().ReverseMap();
            CreateMap<UpdateCouponRequest, Coupon>().ReverseMap();
            CreateMap<CreatePromotionRequest, Promotion>().ReverseMap();
            CreateMap<UpdatePromotionRequest, Promotion>().ReverseMap();
        }
    }
}
