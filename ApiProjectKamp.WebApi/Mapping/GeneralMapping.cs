using ApiProjectKamp.WebApi.Dtos.FeaturesDtos;
using ApiProjectKamp.WebApi.Dtos.MessageDtos;
using ApiProjectKamp.WebApi.Dtos.ProductDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjectKamp.WebApi.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

            CreateMap<Message, ResultFeatureDto>().ReverseMap();
            CreateMap<Message, CreateFeatureDto>().ReverseMap();
            CreateMap<Message, UpdateFeatureDto>().ReverseMap();
            CreateMap<Message, GetMessageByIdDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();
        }
    }
}
