// CarRentService.API/Mapping/MappingProfile.cs
using AutoMapper;
using CarRentService.DataAccess.Entities;
using CarRentService.API.DTO;

namespace CarRentService.API.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Маппинг из Car в CarDto и обратно (если нужно)
        CreateMap<Car, CarDto>()
            .ForMember(dest => dest.PhotoUrls, opt => opt.MapFrom(src => src.PhotoUrls)); // явно указываем, если имя совпадает

        CreateMap<CreateCarRequest, Car>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id генерируется БД
            .ForMember(dest => dest.Status, opt => opt.Ignore()) // статус задаётся отдельно
            .ForMember(dest => dest.Rentals, opt => opt.Ignore()) // навигационные свойства игнорируем
            .ForMember(dest => dest.Maintenances, opt => opt.Ignore());

        // Маппинг для User
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.LoyaltyProgramId, opt => opt.MapFrom(src => src.LoyaltyProgramId));

        CreateMap<RegisterRequest, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "user"))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.IsBlocked, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.UserSubscriptions, opt => opt.Ignore())
            .ForMember(dest => dest.Rentals, opt => opt.Ignore())
            .ForMember(dest => dest.LoyaltyProgram, opt => opt.Ignore());

        // Маппинг для Rental
        CreateMap<Rental, RentalDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.FirstName + " " + src.User.LastName : ""))
            .ForMember(dest => dest.CarInfo, opt => opt.MapFrom(src => src.Car != null ? src.Car.Brand + " " + src.Car.Model : ""));

        CreateMap<CreateRentalRequest, Rental>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.UserId, opt => opt.Ignore()) // будет установлено из контекста авторизации
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "active"))
            .ForMember(dest => dest.TotalCost, opt => opt.Ignore()) // будет рассчитано в сервисе
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Car, opt => opt.Ignore())
            .ForMember(dest => dest.UserSubscription, opt => opt.Ignore());

        // Маппинг для Subscription
        CreateMap<Subscription, SubscriptionDto>();

        // Маппинг для UserSubscription
        CreateMap<UserSubscription, UserSubscriptionDto>()
            .ForMember(dest => dest.SubscriptionName, opt => opt.MapFrom(src => src.Subscription != null ? src.Subscription.Name : ""));

        // Маппинг для LoyaltyProgram
        CreateMap<LoyaltyProgram, LoyaltyProgramDto>();

        // Маппинг для CarMaintenance
        CreateMap<CarMaintenance, CarMaintenanceDto>()
            .ForMember(dest => dest.CarInfo, opt => opt.MapFrom(src => src.Car != null ? src.Car.Brand + " " + src.Car.Model : ""));
    }
}