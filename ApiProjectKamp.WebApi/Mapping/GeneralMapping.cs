using ApiProjectKamp.WebApi.Dtos.AboutDtos;
using ApiProjectKamp.WebApi.Dtos.CategoryDtos;
using ApiProjectKamp.WebApi.Dtos.FeaturesDtos;
using ApiProjectKamp.WebApi.Dtos.ImageDtos;
using ApiProjectKamp.WebApi.Dtos.MessageDtos;
using ApiProjectKamp.WebApi.Dtos.NotificationDtos;
using ApiProjectKamp.WebApi.Dtos.ProductDtos;
using ApiProjectKamp.WebApi.Dtos.ReservationDtos;
using ApiProjectKamp.WebApi.Entities;
using AutoMapper;

namespace ApiProjectKamp.WebApi.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetMessageByIdDto>().ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();

            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutByIdDto>().ReverseMap();

            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, ResultReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdDto>().ReverseMap();

            CreateMap<Image, CreateImageDto>().ReverseMap();
            CreateMap<Image, ResultImageDto>().ReverseMap();
            CreateMap<Image, UpdateImageDto>().ReverseMap();
            CreateMap<Image, GetImageByIdDto>().ReverseMap();
        }
    }
}
