using AutoMapper;
using Server.DTOs;
using Server.Entities;
using Server.Extensions;
using Server.Interfaces;
using System.Linq;

namespace Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                //.ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>  src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            //CreateMap<Photo, PhotoDto>();

            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();

            //Word
            CreateMap<Word, WordDto>();
            CreateMap<WordDto, Word>();

            CreateMap<Word, AddWordDto>();
            CreateMap<AddWordDto, Word>();
            CreateMap<AddWordDto, WordDto>();

            //Lessons
            CreateMap<Lesson,LessonDto>()
                .ForMember(dest => dest.Words, opt => opt.MapFrom(src => src.Words.Select( t =>t.Word)));


            CreateMap<LessonDto, Lesson>();
            CreateMap<UpdateLessonDto, Lesson>();
            CreateMap<AddLessonDto, Lesson>();
                 //.ForMember(dest => dest.Words, opt => opt.MapFrom(src => _wordRepository.GetWordsByIds(src.WordIds)));

        }
    }
}
