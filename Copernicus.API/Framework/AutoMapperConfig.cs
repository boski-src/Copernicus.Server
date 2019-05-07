using AutoMapper;
using Copernicus.API.Dtos;
using Copernicus.Core.Domain.Games;
using Copernicus.Core.Domain.Identity;
using Copernicus.Core.Domain.Questions;

namespace Copernicus.API.Framework
{
    public static class AutoMapperConfig
    {
        public static Mapper Configure()
        {
            var mapper = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<User, AccountDto>()
                       .ForMember(
                           x => x.Provider,
                           o => o.MapFrom(x => new ProviderDto(x.ProviderName, x.ProviderId))
                       );

                    cfg.CreateMap<Question, QuestionDto>();
                    cfg.CreateMap<Choice, ChoiceDto>();

                    cfg.CreateMap<Answer, AnswerDto>();
                    cfg.CreateMap<Member, MemberDto>();
                    cfg.CreateMap<Winner, WinnerDto>();
                    cfg.CreateMap<GameQuestion, GameQuestionDto>();
                    cfg.CreateMap<Game, GameDto>()
                       .ForMember(
                           x => x.Winners,
                           o => o.MapFrom(x => x.Leaderboard.Winners)
                       );
                }
            );
            return new Mapper(mapper);
        }
    }
}