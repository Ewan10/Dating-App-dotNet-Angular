using AutoMapper;
using Backend.DTOs;
using Backend.Entities;
using Backend.Extensions;

namespace Backend.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<User, MemberDto>()
            .ForMember(destination => destination.Age, origin => origin.MapFrom(src =>
                src.DateOfBirth.CalculateAge()))
            .ForMember(destination => destination.PhotoUrl, origin =>
                origin.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain)!.Url));

        CreateMap<Photo, PhotoDto>();
        CreateMap<MemberUpdateDto, User>();

    }

}
